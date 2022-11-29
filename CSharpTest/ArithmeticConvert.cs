using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CSharpTest
{
    class ArithmeticConvert
    {
        public string Convert10ToX(int num, int arithmetic)
        {
            int number = num;
            string result = "";

            while (true)
            {
                var quotient = num / arithmetic;      // 몺
                var remainder = num % arithmetic;      // 나머지 

                num = quotient; // 몫을 다시 계산하기 위해서 값에 넣는다.

                string value = "";
                if (arithmetic > 10)
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

        public  int ConvertXTo10(string number, int arithmetic)
        {
            int answer = 0;
            var idx = number.Length;

            for (var i = 0; i < number.Length; i++)
            {
                var pow = (int)Math.Pow(arithmetic, --idx);
                string num = number[i].ToString().ToLower();

                if (number[i] == 'a') num = "10";
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
    }
}
