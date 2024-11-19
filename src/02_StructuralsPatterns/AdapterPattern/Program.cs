using NGeoHash;
using System;

namespace AdapterPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            RadioTest();            

        }

        private static void RadioTest()
        {
            RadioAdapterFactory radioAdapterFactory = new RadioAdapterFactory();
            IRadioAdapter radio = radioAdapterFactory.Create("hytera");
            radio.Send("Hello World!", 10);
           
        }

    }

    


}
