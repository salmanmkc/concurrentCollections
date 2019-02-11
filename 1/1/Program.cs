using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(() => orderProducts("mark"));
            Task task2 = new Task(() => orderProducts("Lucy"));
            task1.Start();
            task2.Start();
            Task.WaitAll(task1,task2);
        }


        static void orderProducts(string name)
        {
            for(int i = 0; i<5; i++)
            {
                Console.WriteLine($"{name} order number {i}.");
            }
        }
    }


}
