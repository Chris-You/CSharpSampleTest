using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Singleton
{
    public class Singleton
    {
        public static Singleton instance = new Singleton();

        private Singleton()
        {
            
        }

        public static Singleton getInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }


    }
}
