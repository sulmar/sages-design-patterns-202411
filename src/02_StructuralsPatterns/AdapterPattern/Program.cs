using NGeoHash;
using System;
using System.Threading;

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
            ITextRadioAdapter radio = radioAdapterFactory.Create("motorola");

            radio.Send("Hello World!", 10);

            if (radio is IBinaryRadioAdapter binaryRadioAdapter)
            {
                byte[] data = new byte[] { 1, 2, 3, 4, 5 };
                binaryRadioAdapter.Send(data, 10);
            }

        }

    }

    


}
