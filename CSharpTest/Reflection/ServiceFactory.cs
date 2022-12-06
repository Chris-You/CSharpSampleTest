using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpTest.Reflection
{
    public class ServiceFactory
    {

        public ServiceFactory(IService service)
        {

        }

        public static void UseAction<T>(Action<T> action)
        {
            Type type = typeof(T);

            // 인터페이스 타입을 상속한 클래스의 인스턴스를 가져오는 방법 ??
            Console.WriteLine(type.FullName);
            dynamic objType = Activator.CreateInstance(type);

            action(objType);
        }   
    }
}
