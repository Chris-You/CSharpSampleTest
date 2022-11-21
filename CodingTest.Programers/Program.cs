using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingTest.Programers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            Console.WriteLine(올바른괄호("((()))"));

            //solution("-1 -2 -3 -4");


            /*
            string[] book = { "123", "456", "789" };

            Console.WriteLine(PhoneBook(book));
            */

        }


        /// <summary>  
        /// 올바른괄호 https://school.programmers.co.kr/learn/courses/30/lessons/12909#qna
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool 올바른괄호(string s)
        {
            int cnt = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    cnt++;
                }
                else
                {
                    if (cnt == 0)
                    {
                        cnt++;
                        break;
                    }
                    else
                    {
                        cnt--;
                    }
                }
            }

            bool answer = cnt == 0 ? true : false;
            return answer;
        }


        //최솟값 만들기
        //https://school.programmers.co.kr/learn/courses/30/lessons/12941
        public static int minval(int[] A, int[] B)
        {

            int answer = 0;

            Array.Sort(A);
            Array.Sort(B, (a, b) => (a > b) ? -1 : 1);

            for(var i=0; i< A.Length; i++)
            {
                answer += A[i] * B[i];
            }


            return answer;
        }


        static bool PhoneBook(string[] phone_book)
        {
            Int64[] phonebook = Array.ConvertAll(phone_book, long.Parse);
            Array.Sort(phonebook);


            Dictionary<string, int> phone = new Dictionary<string, int>();
            
            for(var i=0; i< phonebook.Length; i++)
            {
                var len = phonebook[i].ToString().Length;


                for(var j=i+1;  j< phonebook.Length; j++ )
                {
                    if (!phone.ContainsKey(phonebook[j].ToString().Substring(0, len)))
                        phone.Add(phone_book[i], 1);
                    else
                    {
                        return false;
                    }
                }

                



            }

            return true;
        }

        //기사단원의 무기
        //https://school.programmers.co.kr/learn/courses/30/lessons/136798

        static int KnightWeapon(int number, int limit, int power)
        {
            int answer = 0;
            for(var i = 1; i<=number; i++)
            {
                int cnt = 0;
                for(var j=1; j * j <= i; j++)
                {
                    if( i % j == 0)
                    {
                        cnt++;

                        if (j * j < i)
                            cnt++;
                    }
                }

                if (cnt > limit) answer += power;
                else answer += cnt;
            }

            return answer;

        }


        
    }
}

