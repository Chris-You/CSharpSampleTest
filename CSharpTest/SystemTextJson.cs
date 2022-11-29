using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace CSharpTest
{

    public class Person
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public List<string> Phone { get; set; } = new List<string> { };

        [JsonIgnore]
        public int Age { get; set; } = 0;

        public static List<Person> GetList()
        {
            return new List<Person>
            {
                new Person { Name = "홍길동" },
                new Person { Name = "고길동", Address = "seoul" },
                new Person { Name = "남길동", Address = "seoul" },
                new Person { Name = "박길동", Address = "busan", Phone= new List<string>{ "1234-5678", "5678-4457" } },
                new Person { Name = "유길동", Address = "suwon", Phone= new List<string>{ "1124-1457"} },
            };
        }

        public static Person Get()
        {
            return new Person
            {
                Name = "박길동",
                Address = "busan",
                Phone = new List<string> { "1234-5678", "5678-4457" }
            };
        }
    }


    public class SystemTextJson
    {
        private JsonSerializerOptions JsonOption()
        {
            return new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }


        public void CaseSensitive()
        {
            var jsonStr = "[ {\"name\":\"박길동\",\"address\":\"busan\",\"Phone\":[\"1234 - 5678\",\"5678 - 4457\"]}," +
                            "{\"name\":\"유길동\",\"address\":\"suwon\",\"Phone\":[\"1124 - 1457\"]}" +
                            "]";

            var deserialize = JsonSerializer.Deserialize<List<Person>>(jsonStr);
            
        }


        public void JsonParse()
        {
            var jsonStr = "[ {\"Name\":\"홍길동\",\"Address\":\"\"     ,\"Phone\":[]}," +
                            "{\"Name\":\"고길동\",\"Address\":\"seoul\",\"Phone\":[]}," +
                            "{\"Name\":\"남길동\",\"Address\":\"seoul\",\"Phone\":[]}," +
                            "{\"Name\":\"박길동\",\"Address\":\"busan\",\"Phone\":[\"1234 - 5678\",\"5678 - 4457\"]}," +
                            "{\"Name\":\"유길동\",\"Address\":\"suwon\",\"Phone\":[\"1124 - 1457\"]}" +
                            "]";

            
            JsonDocument json = JsonDocument.Parse(jsonStr);

            var root = json.RootElement;

            Console.WriteLine("Root Cnt :  " + root.GetArrayLength());
            foreach (var element in root.EnumerateArray())
            {
                Console.WriteLine("json element");
                Console.WriteLine("   -> " + element);
                Console.WriteLine("   -> " + element.GetProperty("Name") +"," + element.GetProperty("Address"));
                Console.WriteLine("   -> " + element.GetProperty("Phone"));
                Console.WriteLine("   -> " + element.ValueKind);

                foreach (var obj in element.EnumerateObject())
                {
                    Console.WriteLine("        -> " + obj.ToString());
                    Console.WriteLine("        -> " + obj.Name +"," + obj.Value + "," + obj.GetType().Name);
                }
            }

            //Console.WriteLine("----------------------------------------------");

            //var jsonGet = JsonSerializer.Serialize(Person.Get(), JsonOption());
            //JsonDocument jsonParse = JsonDocument.Parse(jsonGet);
            //var rootParse = jsonParse.RootElement;

            ////Console.WriteLine("Root Cnt :  " + rootParse.GetArrayLength());

            //Console.WriteLine("json element");
            //Console.WriteLine("   -> " + rootParse);
            //Console.WriteLine("   -> " + rootParse.GetProperty("Name") + "," + rootParse.GetProperty("Address"));
            //Console.WriteLine("   -> " + rootParse.GetProperty("Phone"));
            //Console.WriteLine("   -> " + rootParse.ValueKind);

            //foreach (var obj in rootParse.EnumerateObject())
            //{
            //    Console.WriteLine("json Object");
            //    Console.WriteLine("    -> " + obj.ToString());
            //    Console.WriteLine("    -> " + obj.Name + "," + obj.Value + "," + obj.GetType().Name);
            //}
        }


        public void Serialize()
        {
            var jsonString = JsonSerializer.Serialize(Person.GetList());
            Console.WriteLine(jsonString);
            Console.WriteLine("----------------------------------------------");

            var jsonStringOption = JsonSerializer.Serialize(Person.GetList(), JsonOption());
            Console.WriteLine(jsonStringOption);
            Console.WriteLine("----------------------------------------------");
        }


        public List<Person> Deserialize()
        {
            var jsonString = JsonSerializer.Serialize(Person.GetList());

            var deserialize = JsonSerializer.Deserialize<List<Person>>(jsonString);

            return deserialize;
        }

    }
}

