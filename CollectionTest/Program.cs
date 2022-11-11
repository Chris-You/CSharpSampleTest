using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionTest
{
    public class Student
    {
        public int grade;       //학년
        public string name;     //이름
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student{grade = 3, name = "Tom" },
                new Student{grade = 3, name = "Brian" },
                new Student{grade = 4, name = "Chris" },
                new Student{grade = 5, name = "James" }
            };
            
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


            foreach (var s in students)
                Console.WriteLine(s.grade + "," + s.name);



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
