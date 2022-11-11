using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcService
{
    public class PersonReq
    {
        public string id;
    }

    public class Person
    {
        public string id;
        public int age;
        public string name;
        public DateTime birth;

        public List<string> memo;

        public Person()
        {
            memo = new List<string>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public Person PersonList(Person person)
        {
            return person;
        }
    }
}
