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

        public bool Equals(Student other)
        {
            if (other is null)
                return false;

            return this.grade == other.grade && this.name == other.name;
        }

        public override bool Equals(object obj) => Equals(obj as Student);
        public override int GetHashCode() => (grade, name).GetHashCode();
    }

    class Collection
    {
        List<Student> students = new List<Student>
        {
            new Student{grade = 3, name = "Tom" },
            new Student{grade = 3, name = "Brian" },
            new Student{grade = 4, name = "Chris" },
            new Student{grade = 5, name = "James" },
            new Student{grade = 5, name = "James" },
        };

        List<Student> students2 = new List<Student>
        {
            new Student{grade = 3, name = "Tom" },
            new Student{grade = 4, name = "Chris" },
            new Student{grade = 6, name = "Erick" },
        };


        int[] scores = { 80, 60, 70, 40, 70, 100, 70 };

        int[] scores2 = { 70, 100 };

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
