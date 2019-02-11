using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            //using ConcurrentQueue ensures thread safety, now works
            var orders = new ConcurrentQueue<string>();
            Task task1 = new Task(() => orderProducts(orders, "mark"));
            Task task2 = new Task(() => orderProducts(orders, "Lucy"));
            task1.Start();
            task2.Start();
            Task.WaitAll(task1, task2);
            foreach (string order in orders)
                Console.WriteLine("Order: " + order);
        }


        static void orderProducts(ConcurrentQueue<string> orders, string name)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                String orderName = $"{name} order number {i}.";
                orders.Enqueue(orderName);
           }
        }
    }


}
