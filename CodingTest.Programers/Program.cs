using System;
using System.Linq;
using System.Collections.Generic;

namespace CodingTest.Programers
{
    class Program
    {
        static void Main(string[] args)
        {

            //solution7(3, new int[] {10, 100, 20, 150, 1, 100, 200});
            //solution(4, new int[] { 0, 300, 40, 300, 20, 70, 150, 50, 500, 1000 });


            //solution(3, 4, new int[] { 1, 2, 3, 1, 2, 3, 1 });
            //solution(4, 3, new int[] { 4, 1, 2, 2, 4, 4, 4, 4, 1, 2, 4, 2 });


            
        }


        /// <summary>
        /// https://school.programmers.co.kr/learn/courses/30/lessons/118666
        /// 겅격 유형 검사하기
        /// Console.WriteLine(solution(new string[] { "AN", "CF", "MJ", "RT", "NA" }, new int[] { 5, 3, 2, 7, 5 }));
        /// Console.WriteLine(solution(new string[] { "TR", "RT", "TR" }, new int[] {7,1,3}));
        /// </summary>
        /// <param name="survey"></param>
        /// <param name="choices"></param>
        /// <returns></returns>
        public static string solution(string[] survey, int[] choices)
        {
            Dictionary<char, int> type = new Dictionary<char, int>();
            
            for(var i=0; i< survey.Length; i++)
            {
                int prefix = 0;
                int score = 0;
                if (choices[i] > 4) 
                    prefix = 1;

                if      (choices[i] == 1 || choices[i] == 7) score = 3;
                else if (choices[i] == 2 || choices[i] == 6) score = 2;
                else if (choices[i] == 3 || choices[i] == 5) score = 1;

                var key = survey[i].ToString()[prefix];

                if (type.ContainsKey(key) == false)
                    type.Add(key, score);
                else
                    type[key] = type[key] + score;
            }

            type.TryGetValue('R', out int rValue);
            type.TryGetValue('T', out int tValue);
            type.TryGetValue('C', out int cValue);
            type.TryGetValue('F', out int fValue);
            type.TryGetValue('J', out int jValue);
            type.TryGetValue('M', out int mValue);
            type.TryGetValue('A', out int aValue);
            type.TryGetValue('N', out int nValue);

            string answer = "";
            answer += (rValue >= tValue ? "R" : "T");
            answer += (cValue >= fValue ? "C" : "F");
            answer += (jValue >= mValue ? "J" : "M");
            answer += (aValue >= nValue ? "A" : "N");

            return answer;
        }

        public static int solution(int k, int m, int[] score)
        {
            int answer = 0;

            Array.Sort(score);
            List<List<int>> packing = new List<List<int>>();
            bool isAdd = false;
            /*
            for(var i=0; i< score.Length; i++)
            {
                isAdd = false;
                int[] arr = new int[m];
                for(var j=0; j<m; j++ )
                {
                    arr[j] = score[i];
                    if(j == m-1)
                    {
                        isAdd = true;
                    }
                }
                if(isAdd) packing.Add(arr);
            }
            */
            Console.WriteLine(string.Join(",", score));

            List<int> arr = new List<int>();
            int idx = 0;
            for (var i = 0; i < score.Length; i++)
            {
                arr.Add(score[i]);

                if (arr.Count() == m)
                {
                    packing.Add(arr);
                    arr = new List<int>();
                    idx = 0;
                }
            }


            return answer;
        }

        public static int[] solution7(int k, int[] score)
        {
            int[] answer = new int[score.Length];
            List<int> honer = new List<int>();

            for(var i = 0; i< score.Length; i++)
            {
                honer.Add(score[i]);
                honer = honer.OrderByDescending(sco => sco).Take(k).ToList();
                answer[i] = honer.Min();
            }
            

            return answer;
        }


        public static int[] solution6(int num, int total)
        {
            int[] answer = new int[num];

            int maxnum = 1000;
            int sum = 0;
            while(maxnum >= 0)
            {
                sum = 0;
                for (var i= maxnum; i> maxnum - num; i--)
                {
                    sum += i;
                }

                if(sum == total)
                {
                    Console.WriteLine(maxnum);

                    for (var k = 0; k < num; k++)
                    {
                        answer[k] = maxnum--;
                    }
                    break;
                }

                maxnum--;
            }

            Console.WriteLine("");
            /*
            for(var i=100; i>=0; i--)
            {

                if(i<=total)
                {
                    int sum = 0;
                    for (var j=i; j> i-num; j--)
                    {
                        sum += j;
                    }

                    if (sum == total)
                    {
                        for (var k = 0; k < num; k++)
                        {
                            answer[k] = i--;
                        }

                        return answer.ToArray();
                    }

                }

            }
            */

            return answer.ToArray(); 
        }

        public static void dfsMain()
        {
            Dictionary<string, string> numbers = new Dictionary<string, string>();
            numbers.Add("1", "X");
            numbers.Add("7", "X");

            for (var i = 0; i< numbers.Count(); i++)
            {

                
            }


        }

        public static void dfs(string numbers, string current)
        {

        }


        public static string solution4(int num, int arithmetic)
        {
            int number = num;
            string result = "";

            while (true)
            {
                var quotient = num / arithmetic;      // 몺
                var remainder = num % arithmetic;      // 나머지 

                num = quotient; // 몫을 다시 계산하기 위해서 값에 넣는다.

                string value ="";
                if(arithmetic > 10)
                {
                    if (remainder == 10) value = "a";
                    else if (remainder == 11) value = "b";
                    else if (remainder == 12) value = "c";
                    else if (remainder == 13) value = "d";
                    else if (remainder == 14) value = "e";
                    else if (remainder == 15) value = "f";
                    else if (remainder == 16) value = "g";
                    else if (remainder == 17) value = "h";
                    else if (remainder == 18) value = "i";
                    else if (remainder == 19) value = "j";
                    else if (remainder == 20) value = "k";
                    else if (remainder == 21) value = "l";
                    else if (remainder == 22) value = "m";
                    else if (remainder == 23) value = "n";
                    else if (remainder == 24) value = "o";
                    else if (remainder == 25) value = "p";
                    else if (remainder == 26) value = "q";
                    else if (remainder == 27) value = "r";
                    else if (remainder == 28) value = "s";
                    else if (remainder == 29) value = "t";
                    else if (remainder == 30) value = "u";
                    else if (remainder == 31) value = "v";
                    else if (remainder == 32) value = "w";
                    else if (remainder == 33) value = "x";
                    else if (remainder == 34) value = "y";
                    else if (remainder == 35) value = "z";
                    else
                    {
                        value = remainder.ToString();
                    }
                }
                else
                {
                    value = remainder.ToString();
                }

                result += value;


                if (num < arithmetic)
                {
                    string value2 = "";

                    if (quotient == 10) value2 = "a";
                    else if (quotient == 11) value2 = "b";
                    else if (quotient == 12) value2 = "c";
                    else if (quotient == 13) value2 = "d";
                    else if (quotient == 14) value2 = "e";
                    else if (quotient == 15) value2 = "f";
                    else if (quotient == 16) value2 = "g";
                    else if (quotient == 17) value2 = "h";
                    else if (quotient == 18) value2 = "i";
                    else if (quotient == 19) value2 = "j";
                    else if (quotient == 20) value2 = "k";
                    else if (quotient == 21) value2 = "l";
                    else if (quotient == 22) value2 = "m";
                    else if (quotient == 23) value2 = "n";
                    else if (quotient == 24) value2 = "o";
                    else if (quotient == 25) value2 = "p";
                    else if (quotient == 26) value2 = "q";
                    else if (quotient == 27) value2 = "r";
                    else if (quotient == 28) value2 = "s";
                    else if (quotient == 29) value2 = "t";
                    else if (quotient == 30) value2 = "u";
                    else if (quotient == 31) value2 = "v";
                    else if (quotient == 32) value2 = "w";
                    else if (quotient == 33) value2 = "x";
                    else if (quotient == 34) value2 = "y";
                    else if (quotient == 35) value2 = "z";
                    else
                    {
                        value2 = quotient.ToString();
                    }

                    result += value2.ToString();

                    break;
                }
            }


            var answer = string.Join("", result.Reverse());
            Console.WriteLine($"{number}의 {arithmetic}진수 값은 : {answer}");

            return answer;
        }

        public static int solution5(string number, int arithmetic)
        {
            int answer = 0;
            var idx = number.Length;

            for (var i = 0; i < number.Length; i++)
            {
                var pow = (int)Math.Pow(arithmetic, --idx);
                string num = number[i].ToString().ToLower();
                
                if (number[i] == 'a')      num = "10";
                else if (number[i] == 'b') num = "11";
                else if (number[i] == 'c') num = "12";
                else if (number[i] == 'd') num = "13";
                else if (number[i] == 'e') num = "14";
                else if (number[i] == 'f') num = "15";
                else if (number[i] == 'g') num = "16";
                else if (number[i] == 'h') num = "17";
                else if (number[i] == 'i') num = "18";
                else if (number[i] == 'j') num = "19";
                else if (number[i] == 'k') num = "20";
                else if (number[i] == 'l') num = "21";
                else if (number[i] == 'm') num = "22";
                else if (number[i] == 'n') num = "23";
                else if (number[i] == 'o') num = "24";
                else if (number[i] == 'p') num = "25";
                else if (number[i] == 'q') num = "26";
                else if (number[i] == 'r') num = "27";
                else if (number[i] == 's') num = "28";
                else if (number[i] == 't') num = "29";
                else if (number[i] == 'u') num = "30";
                else if (number[i] == 'v') num = "31";
                else if (number[i] == 'w') num = "32";
                else if (number[i] == 'x') num = "33";
                else if (number[i] == 'y') num = "34";
                else if (number[i] == 'z') num = "35";
                
                answer += Convert.ToInt32(num) * pow;
            }




            Console.WriteLine($"{arithmetic}진수 {number}의 10진수 값은 : {answer}");

            return answer;
        }



            /// <summary>
            /// 이진 변환 반복하기
            ///  https://school.programmers.co.kr/learn/courses/30/lessons/70129
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public static int[] solution3(string s)
        {
            int zeroCnt = 0;
            int cnt = 0;
            while(s!="1")
            {
                var tmpStr = "";
                for(var i=0; i< s.Length; i++)
                {
                    if (s[i].ToString() == "0")
                        zeroCnt++;
                    else
                    {
                        tmpStr += s[i];
                    }
                }

                s = Convert.ToString(tmpStr.Length, 2);
                cnt++;

            }

            int[] answer = new int[2] {cnt, zeroCnt };
            return answer;
        }



        public static int solution1(string[,] clothes)
        {
            Dictionary<string, List<string>> dicCloth = new Dictionary<string, List<string>>();
            List<string> cloth = new List<string>();
            for (var i=0; i< clothes.GetLength(0); i++)
            {
                

                

                if (dicCloth.ContainsKey(clothes[i, 1]))
                {
                    dicCloth[clothes[i, 1]].Add(clothes[i, 0]);
                }
                else
                {
                    cloth = new List<string>();
                    cloth.Add(clothes[i, 0]);

                    dicCloth.Add(clothes[i, 1], cloth);
                }
            }



            int answer = 0;

            return answer ;
        }


        /// <summary>
        /// JadenCase 문자열 만들기
        /// https://school.programmers.co.kr/learn/courses/30/lessons/12951
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string solution2(string s)
        {

            string[] str = s.ToLower().Replace(" ","^" ).Split("^");
            string[] ans = new string[str.Length];
            for (var i=0; i< str.Length; i++)
            {
                if (str[i] != "")
                {
                    var first = str[i].ToCharArray()[0].ToString().ToUpper();
                    ans[i] =  first + str[i].Substring(1);
                }
            }

            string answer = string.Join(" ", ans);

            return answer;
        }


        // 기능개발
        //solution(new int[] {93,30,55 }, new int[] { 1, 30, 5 });
        //solution(new int[] { 95, 90, 99, 99, 80, 99 }, new int[] { 1, 1, 1, 1, 1, 1 });
        //https://school.programmers.co.kr/learn/courses/30/lessons/42586
        public static int[] solution(int[] progresses, int[] speeds)
        {
            List<int> workDay = new List<int>();
            List<int> answer = new List<int>();

            for (var i=0; i<progresses.Length; i++)
            {
                var day = 1;
                while(true)
                {
                    var process = progresses[i] + (speeds[i] * day );

                    if (process >= 100)
                    {
                        workDay.Add(day);
                        break;
                    }

                    day++;
                }
            }

            var value = 0;
            int cnt = 0;
            for(var i=0; i< workDay.Count(); i++)
            {
                if (i == 0)
                {
                    value = workDay[0];
                    cnt++;
                }
                else
                {
                    if (value >= workDay[i])
                    {
                        cnt++;
                    }
                    else
                    {
                        answer.Add(cnt);
                        
                        value = workDay[i];
                        cnt = 1;
                    }
                }
            }

            
            answer.Add(cnt);

            return answer.ToArray();
        }


        /// <summary>  
        /// 올바른괄호 https://school.programmers.co.kr/learn/courses/30/lessons/12909#qna
        /// Console.WriteLine(올바른괄호("((()))"));
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


        /// <summary>
        /// 
        /// Console.WriteLine(PhoneBook(new string[] { "119", "97674223", "1195524421" }));
        /// Console.WriteLine(PhoneBook(new string[] { "123", "456", "789" }));
        /// Console.WriteLine(PhoneBook(new string[] { "12", "123", "1235", "567", "88" }));
        /// 
        /// </summary>
        /// <param name="phone_book"></param>
        /// <returns></returns>
static bool PhoneBook(string[] phone_book)
        {

            bool isok = true;
            Array.Sort(phone_book);

            Dictionary<string, List<string>> phoneDic = new Dictionary<string, List<string>>();
            

            for (var i = 0; i < phone_book.Length; i++)
            {
                var first = phone_book[i].Substring(0, 1);

                if (phoneDic.ContainsKey(first))
                {
                    phoneDic[first].Add(phone_book[i]);
                }
                else
                {
                    phoneDic.Add(first, new List<string> { phone_book[i] });
                }

            }
            foreach(var phone in phoneDic)
            {
                for (var i = 0; i < phone.Value.Count(); i++)
                {
                    for (var j = +1; j < phone.Value.Count(); j++)
                    {
                        if (phone.Value[j].IndexOf(phone.Value[i]) == 0)
                        {
                            return false;
                        }
                    }
                }
            }

             





            /*
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
            */

            return isok;
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

