using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharpTest
{

    class Student  : IEquatable<Student>
    {
        public int grade;       //학년
        public string name;     //이름

        public int[] scores = new int[2];

        public bool Equals(Student other)
        {
            if (other is null)
                return false;

            return this.grade == other.grade && this.name == other.name;
        }

        public override bool Equals(object obj) => Equals(obj as Student);
        public override int GetHashCode() => (grade, name).GetHashCode();


    }


    class Teacher : IEquatable<Teacher>
    {
        public int grade;       //학년
        public string name;     //이름


        public bool Equals(Teacher other)
        {
            if (other is null)
                return false;

            return this.grade == other.grade && this.name == other.name;
        }

        public override bool Equals(object obj) => Equals(obj as Teacher);
        public override int GetHashCode() => (grade, name).GetHashCode();


    }


    class Collection
    {
        Student defaultStudent = new Student { grade = 0, name = "default", scores = new int[] { 0, 0 } };

        List<Student> emptyStudents = new List<Student>();


        List<Student> students2 = new List<Student>
        {
            new Student{grade = 3, name = "Christina" },
            new Student{grade = 4, name = "Tayler" },
            new Student{grade = 6, name = "David" },
        };


        
        int[] scores2 = { 70, 100 };




        List<Student> students = new List<Student>
        {
            new Student{grade = 3, name = "Tom", scores = new int[] {60, 80} },     
            new Student{grade = 3, name = "Brian" , scores = new int[] {50, 70} },  
            new Student{grade = 4, name = "Chris" , scores = new int[] {80, 80}},   
            new Student{grade = 5, name = "James" , scores = new int[] {100, 100} },
        };





        List<Teacher> teachers = new List<Teacher>
        {
            new Teacher{grade = 3, name = "Miss Christina" },
            new Teacher{grade = 4, name = "Mr. Tayler" },
            new Teacher{grade = 6, name = "Mr. Jone" },
            new Teacher{grade = 5, name = "James" },
        };


        int[] scores = { 80, 60, 70, 40, 70, 100, 70 };


        public void Element()
        {
            var elementAt = students.ElementAt(1).name;
            //var elementAtException = students.ElementAt(5);        // 인덱스에 요소가 없으면 ArgumentOutOfRangeException  예외 발생
            //var elementAtNull = students.ElementAtOrDefault(5); // Elenemt 가 없으면 null 반환
            Console.WriteLine(elementAt);

            var first = students.First().name;
            var last = students.Last().name;

            var firstDefault = emptyStudents.FirstOrDefault();
            var lastDefault = emptyStudents.LastOrDefault();


            //var singleEmpty = emptyStudents.Single();   // 비어있는 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'
            //var single = students.Single();             // 2개 이상 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'

            //var singleDefaultEmpty = emptyStudents.SingleOrDefault();        // 비어있는요소는 null 을 반환
            //var singleDefault = students.SingleOrDefault( student=> student.grade==3);      // 2개 이상 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'


            //Console.WriteLine(single);

        }


        public void Select()
        {
            Console.WriteLine("zip====");
            var zip = teachers.Zip(students, (first, second) => new { first.grade, first.name, student = second.name });
            foreach (var sel in zip)
            {
                Console.WriteLine(sel.grade + ", " + sel.name + ", " + sel.student);
            }

            Console.WriteLine("selectMany====");
            var selectMany = students.SelectMany((student, index) => student.scores.Select(score => index + ">" + score) );

            foreach (var sel in selectMany)
            {
                Console.WriteLine(sel);
            }


            var selectmanyQuery = from student in students
                                    from score in student.scores
                                    select new { score, student };
            foreach (var sel in selectmanyQuery)
            {
                Console.WriteLine(sel.score + ">" + sel.student.name);
            }

            var selectby = students.Select((student) => student.scores);
            foreach (var sel in selectby)
            {
                foreach (var score in sel)
                {
                    Console.WriteLine(score);
                }
            }





            Console.WriteLine("select====");
            var select = students.Select(std => std);
            var selectNew = students.Select(std => new { grd = std.grade, nm = std.name.Substring(0,1), max = std.scores.Max() });

            foreach(var sel in select)
            {
                Console.WriteLine(sel.grade + "," + sel.name + "," + sel.scores.Max());
            }

            foreach (var sel in selectNew)
            {
                Console.WriteLine(sel.grd + "," + sel.nm + "," + sel.max);
            }
            
        }


        public void DictionaryVsLookup()
        {

            var lookup = teachers.ToLookup(teacher => teacher.grade, teacher => teacher.grade + ":" + teacher.name);

            

            var teacher = teachers.ToDictionary(teacher => teacher.grade);

            // key 등록 Exception 발생
            var dictionary = students.ToDictionary(student => student.grade, student => student.grade + ":" + student.name);


            Console.WriteLine(lookup[3]);
            Console.WriteLine(lookup[10]);


            // 없는 Key 참조 예외 발생
            Console.WriteLine(teacher[10]);

        }



        public void Aggregation()
        {

            var aggregate = students.Aggregate<Student, string>("", (student, next) => student + ">" + next.name);
            var sum = 0;
            var aggregate2 = scores.Aggregate((score, next) => score
            
            ) ;

            Console.WriteLine(students.Average(student => student.scores.Average()));
            Console.WriteLine(students.Count());
            Console.WriteLine(students.LongCount());
            Console.WriteLine(students.Max(student=> student.scores.Max()));
            Console.WriteLine(students.Min(student => student.scores.Min()));
            Console.WriteLine(students.Sum(student => student.scores.Sum()));
        }

        public void Join()
        {


            var grpByQuery = from student in students
                             group student by student.grade;
                             

            var groupByMethod = students.GroupBy(student => student.grade);

            foreach (var grp in groupByMethod) 
            {
                Console.WriteLine("key : " + grp.Key);
                foreach(var item in grp)
                {
                    Console.WriteLine("   " + item.name);
                }
            }

            // Key, Element 로 그룹화
            var lookup = students.ToLookup(student => student.grade, student=> student.grade + ":" +student.name);
            foreach (var grp in lookup)
            {
                Console.WriteLine("Lookup key : " + grp.Key);
                foreach (var item in grp)
                {
                    Console.WriteLine("   " + item);
                }
            }


            foreach (var grp in lookup)
            {
                Console.WriteLine("Lookup key : " + grp.Key);
                foreach (var item in lookup[grp.Key])
                {
                    Console.WriteLine("     lookup   " + item);
                }
            }

            




            /*
            Console.WriteLine("group join===");
            // Join categories and product based on CategoryId and grouping result
            var grpJoin = from teacher in teachers
                        join student in students on teacher.grade equals student.grade into grp
                        select grp;
            foreach (var key in grpJoin)
            {
                foreach (var teacher in key)
                {
                    Console.WriteLine(teacher.grade + "," + teacher.name, 8);
                }
            }

            Console.WriteLine("join by grade===");
            var join = teachers.Join(students, t => t.grade, s => s.grade, (t, s) => new { grade = t.grade, name = t.name, studentName = s.name });

            var query = from teacher in teachers
                        join student in students on teacher.grade equals student.grade
                        select new { teacher.grade, teacher.name, studentName = student.name  };

            foreach (var teacher in query)
            {
                Console.WriteLine(teacher.grade + "," + teacher.name, 8);
            }



            Console.WriteLine("join by name===");
            var joinName = teachers.Join(students, 
                                        t => t.name, 
                                        s => s.name, 
                                        (t, s) => new { grade = t.grade, name = t.name, studentName = s.name });

            foreach (var teacher in joinName)
            {
                Console.WriteLine(teacher.grade + ", " + teacher.name + ", " + teacher.studentName);
            }
            */


        }


        public void Create()
        {
            foreach (var student in students.DefaultIfEmpty(defaultStudent))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            //default
            foreach (var student in emptyStudents.DefaultIfEmpty(defaultStudent))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


            var empty = Enumerable.Empty<Student>();

            var range = Enumerable.Range(0, 10);

            foreach (var item in range)
            {
                Console.WriteLine(item);
            }

            var repeat = Enumerable.Repeat("Hello world!!", 5);
            foreach (var item in repeat)
            {
                Console.WriteLine(item);
            }



        }

        public void Quantifier()
        {
            bool isAll = students.All(item => item.grade > 3);
            Console.WriteLine(isAll);


            var all = from student in students
                        where student.scores.All(item => item > 70)
                        select student;

            foreach (var student in all)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


            bool isAny = students.Any(item => item.grade > 3);
            Console.WriteLine(isAny);

            var any = from student in students
                      where student.scores.Any(item => item >= 80)
                      select student;

            foreach (var student in any)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            
            

            bool isContains = scores.Contains(100);
            Console.WriteLine(isContains);


            var contains = from student in students
                      where student.name.Contains('B')
                      select student;

            foreach (var student in contains)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

        }


        public void Divid()
        {
            Console.WriteLine("== Skip ==");
            foreach (var student in students.Skip(3))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== SkipLast ==");
            foreach (var student in students.SkipLast(2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== SkipWhile ==");
            foreach (var student in students.SkipWhile(st => st.grade == 3))    //grade == 3 이면 건너뜀
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }



            Console.WriteLine("== Take ==");
            foreach (var student in students.Take(3))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== TakeLast ==");
            foreach (var student in students.TakeLast(2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== TakeWhile ==");
            foreach (var student in students.TakeWhile(x=> x.grade==3)) //grade == 3 인 경우만 가져옴
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


        }




        public void Element()
        {
            var elementAt = students.ElementAt(1).name;
            //var elementAtException = students.ElementAt(5);        // 인덱스에 요소가 없으면 ArgumentOutOfRangeException  예외 발생
            //var elementAtNull = students.ElementAtOrDefault(5); // Elenemt 가 없으면 null 반환
            Console.WriteLine(elementAt);

            var first = students.First().name;
            var last = students.Last().name;

            var firstDefault = emptyStudents.FirstOrDefault();
            var lastDefault = emptyStudents.LastOrDefault();


            //var singleEmpty = emptyStudents.Single();   // 비어있는 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'
            //var single = students.Single();             // 2개 이상 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'

            //var singleDefaultEmpty = emptyStudents.SingleOrDefault();        // 비어있는요소는 null 을 반환
            //var singleDefault = students.SingleOrDefault( student=> student.grade==3);      // 2개 이상 요소 반환시 System.InvalidOperationException: 'Sequence contains more than one element'


            //Console.WriteLine(single);
        }


        public void Select()
        {
            Console.WriteLine("zip====");
            var zip = teachers.Zip(students, (first, second) => new { first.grade, first.name, student = second.name });
            foreach (var sel in zip)
            {
                Console.WriteLine(sel.grade + ", " + sel.name + ", " + sel.student);
            }

            Console.WriteLine("selectMany====");
            var selectMany = students.SelectMany((student, index) => student.scores.Select(score => index + ">" + score) );

            foreach (var sel in selectMany)
            {
                Console.WriteLine(sel);
            }


            var selectmanyQuery = from student in students
                                    from score in student.scores
                                    select new { score, student };
            foreach (var sel in selectmanyQuery)
            {
                Console.WriteLine(sel.score + ">" + sel.student.name);
            }

            var selectby = students.Select((student) => student.scores);
            foreach (var sel in selectby)
            {
                foreach (var score in sel)
                {
                    Console.WriteLine(score);
                }
            }





            Console.WriteLine("select====");
            var select = students.Select(std => std);
            var selectNew = students.Select(std => new { grd = std.grade, nm = std.name.Substring(0,1), max = std.scores.Max() });

            foreach(var sel in select)
            {
                Console.WriteLine(sel.grade + "," + sel.name + "," + sel.scores.Max());
            }

            foreach (var sel in selectNew)
            {
                Console.WriteLine(sel.grd + "," + sel.nm + "," + sel.max);
            }
            
        }


        public void DictionaryVsLookup()
        {

            var lookup = teachers.ToLookup(teacher => teacher.grade, teacher => teacher.grade + ":" + teacher.name);

            

            var teacher = teachers.ToDictionary(teacher => teacher.grade);

            // key 등록 Exception 발생
            var dictionary = students.ToDictionary(student => student.grade, student => student.grade + ":" + student.name);


            Console.WriteLine(lookup[3]);
            Console.WriteLine(lookup[10]);


            // 없는 Key 참조 예외 발생
            Console.WriteLine(teacher[10]);

        }



        public void Aggregation()
        {

            var aggregate = students.Aggregate<Student, string>("", (student, next) => student + ">" + next.name);
            var sum = 0;
            var aggregate2 = scores.Aggregate((score, next) => score
            
            ) ;

            Console.WriteLine(students.Average(student => student.scores.Average()));
            Console.WriteLine(students.Count());
            Console.WriteLine(students.LongCount());
            Console.WriteLine(students.Max(student=> student.scores.Max()));
            Console.WriteLine(students.Min(student => student.scores.Min()));
            Console.WriteLine(students.Sum(student => student.scores.Sum()));
        }

        public void Join()
        {


            var grpByQuery = from student in students
                             group student by student.grade;
                             

            var groupByMethod = students.GroupBy(student => student.grade);

            foreach (var grp in groupByMethod) 
            {
                Console.WriteLine("key : " + grp.Key);
                foreach(var item in grp)
                {
                    Console.WriteLine("   " + item.name);
                }
            }

            // Key, Element 로 그룹화
            var lookup = students.ToLookup(student => student.grade, student=> student.grade + ":" +student.name);
            foreach (var grp in lookup)
            {
                Console.WriteLine("Lookup key : " + grp.Key);
                foreach (var item in grp)
                {
                    Console.WriteLine("   " + item);
                }
            }


            foreach (var grp in lookup)
            {
                Console.WriteLine("Lookup key : " + grp.Key);
                foreach (var item in lookup[grp.Key])
                {
                    Console.WriteLine("     lookup   " + item);
                }
            }

            




            /*
            Console.WriteLine("group join===");
            // Join categories and product based on CategoryId and grouping result
            var grpJoin = from teacher in teachers
                        join student in students on teacher.grade equals student.grade into grp
                        select grp;
            foreach (var key in grpJoin)
            {
                foreach (var teacher in key)
                {
                    Console.WriteLine(teacher.grade + "," + teacher.name, 8);
                }
            }

            Console.WriteLine("join by grade===");
            var join = teachers.Join(students, t => t.grade, s => s.grade, (t, s) => new { grade = t.grade, name = t.name, studentName = s.name });

            var query = from teacher in teachers
                        join student in students on teacher.grade equals student.grade
                        select new { teacher.grade, teacher.name, studentName = student.name  };

            foreach (var teacher in query)
            {
                Console.WriteLine(teacher.grade + "," + teacher.name, 8);
            }



            Console.WriteLine("join by name===");
            var joinName = teachers.Join(students, 
                                        t => t.name, 
                                        s => s.name, 
                                        (t, s) => new { grade = t.grade, name = t.name, studentName = s.name });

            foreach (var teacher in joinName)
            {
                Console.WriteLine(teacher.grade + ", " + teacher.name + ", " + teacher.studentName);
            }
            */


        }


        public void Create()
        {
            foreach (var student in students.DefaultIfEmpty(defaultStudent))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            //default
            foreach (var student in emptyStudents.DefaultIfEmpty(defaultStudent))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


            var empty = Enumerable.Empty<Student>();

            var range = Enumerable.Range(0, 10);

            foreach (var item in range)
            {
                Console.WriteLine(item);
            }

            var repeat = Enumerable.Repeat("Hello world!!", 5);
            foreach (var item in repeat)
            {
                Console.WriteLine(item);
            }



        }

        public void Quantifier()
        {
            bool isAll = students.All(item => item.grade > 3);
            Console.WriteLine(isAll);


            var all = from student in students
                        where student.scores.All(item => item > 70)
                        select student;

            foreach (var student in all)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


            bool isAny = students.Any(item => item.grade > 3);
            Console.WriteLine(isAny);

            var any = from student in students
                      where student.scores.Any(item => item >= 80)
                      select student;

            foreach (var student in any)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            
            

            bool isContains = scores.Contains(100);
            Console.WriteLine(isContains);


            var contains = from student in students
                      where student.name.Contains('B')
                      select student;

            foreach (var student in contains)
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

        }


        public void Divid()
        {
            Console.WriteLine("== Skip ==");
            foreach (var student in students.Skip(3))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== SkipLast ==");
            foreach (var student in students.SkipLast(2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== SkipWhile ==");
            foreach (var student in students.SkipWhile(st => st.grade == 3))    //grade == 3 이면 건너뜀
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }



            Console.WriteLine("== Take ==");
            foreach (var student in students.Take(3))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== TakeLast ==");
            foreach (var student in students.TakeLast(2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== TakeWhile ==");
            foreach (var student in students.TakeWhile(x=> x.grade==3)) //grade == 3 인 경우만 가져옴
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }


        }




        public void Sets()
        {
            // 중복제거
            var distinct = scores.Distinct();

            // 차집합
            var except = scores.Except(scores2);

            // 교집합
            var intersect = scores.Intersect(scores2);

            // 합집합
            var union = scores.Union(scores2);


            Console.WriteLine("== Distinct ==");
            foreach (var student in students.Distinct())
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== Except ==");
            foreach (var student in students.Except(students2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== Intersect ==");
            foreach (var student in students.Intersect(students2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== Union ==");
            foreach (var student in students.Union(students2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

            Console.WriteLine("== Concat ==");
            foreach (var student in students.Concat(students2))
            {
                Console.WriteLine(student.grade + ", " + student.name);
            }

        }

        public void Filter()
        {

            var query = from student in students
                        where student.grade ==3 && student.name.IndexOf("B") >= 0
                        select student;


            var list = students.Where(w => w.grade == 3 && w.name.IndexOf("B")>=0);

            foreach(var student in list)
            {
                Console.WriteLine(student.grade +", " +student.name);
            }
            /*
             * 결과
             * 3, Brian
             */

            var ofType = students.OfType<string>();
            Console.WriteLine(ofType.Count());
        }

        public void Sort()
        {
            
            var query = from student in students
                            // grade 를 기준으로 내림차순 (descending 없으면 ascending이 기본 오름차순:사전순)
                        orderby student.grade descending, student.name
                        select student;

            Console.WriteLine("\r\nquery by order");
            foreach (var s in query)
                Console.WriteLine(s.grade + "," + s.name);


            var method = students.OrderByDescending<Student, string>(student => student.name).ThenBy(student => student.name);
            Console.WriteLine("\r\nmethod by order");
            foreach (var s in method)
                Console.WriteLine(s.grade + "," + s.name);



            // Reverse            
            students.Reverse(); // 전체 요소의 순서를 바꿈
            /*
            결과
            5 James
            4 Chris      
            3 Brian
            3 Tom
            */

            Console.WriteLine("\r\nmethod by Reverse");
            foreach (var s in students)
                Console.WriteLine(s.grade + "," + s.name);


            Console.WriteLine("\r\nmethod by Reverse(0,3)");
            students.Reverse(0, 3); // 0 번재 요소부터 3개를 바꿈.
            /* 0번째 3개를 바꿈 (위 예제 에서  뒤바뀐 결과에서)
             결과
            3 Brian
            4 Chris      
            5 James
            3 Tom
             */


            foreach (var s in students)
                Console.WriteLine(s.grade + "," + s.name);

        }


    }

}
