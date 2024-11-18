using System;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singleton Pattern!");           

            LoadBalancerTest();

            Console.ReadKey();

            // ServiceCollection services;
            // services.AddSingleton<Logger>();
        }

      

        private static void LoadBalancerTest()
        {
            //LoadBalancer loadBalancer1 = LoadBalancer.Instance;
            //LoadBalancer loadBalancer2 = LoadBalancer.Instance;

            //if (ReferenceEquals(loadBalancer1, loadBalancer2))
            //{
            //    Console.WriteLine("Instance are the same");
            //}
            //else
            //{
            //    Console.WriteLine("Diffrenent instances");
            //}


            Task.Run(() => LoadBalanceRequestTest(15));
            Task.Run(() => LoadBalanceRequestTest(15));
        }

        private static void LoadBalanceRequestTest(int numberOfRequests)
        {
            LoadBalancer loadBalancer = LoadBalancer.Instance;

            for (int i = 0; i < numberOfRequests; i++)
            {
                Server server = loadBalancer.NextServer;
                Console.WriteLine($"Send request to: {server.Name} {server.IP}");
            }
        }

        

        
    }




  
}
