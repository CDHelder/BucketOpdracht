using BucketOpdracht.Models;
using System;
using System.Threading;

namespace BucketOpdracht
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create buckets
            var bucket1 = new Bucket(BucketSize.Small);
            bucket1.ContainerStatusEvent += ContainerStatusEventHandler;
            var bucket2 = new Bucket(BucketSize.Small);
            bucket2.ContainerStatusEvent += ContainerStatusEventHandler;

            WriteContentAndCapacity(bucket1, bucket2);
            Console.WriteLine($"Bucket1 and bucket2 created");

            Console.WriteLine("Let's try filling bucket2 with the content of bucket1\n");
            Thread.Sleep(3000);

            bucket1.Fill(2, bucket2);

            Console.WriteLine("Oops, lets give bucket1 some content\n");

            //Thread.Sleep(2000);

            WaitAndClearCMD();
            bucket1.Fill(5);

            WriteContentAndCapacity(bucket1, bucket2);

            //Thread.Sleep(2000);

            Console.WriteLine("Lets'try filling bucket2 from bucket1");

            WaitAndClearCMD();
            bucket1.Fill(2, bucket2);
            WriteContentAndCapacity(bucket1, bucket2);

            Console.WriteLine("Nice, it worked!");

            //Thread.Sleep(2000);

            Console.WriteLine("Let's try overflowing the bucket");
            Console.WriteLine("Firstly we will need to gice bucket1 some more content");

            WaitAndClearCMD();
            bucket1.Fill(7);
            WriteContentAndCapacity(bucket1, bucket2);

            Console.WriteLine("Let's go!");

            WaitAndClearCMD();
            bucket1.Fill(10, bucket2);
            WriteContentAndCapacity(bucket1, bucket2);


            Console.ReadLine();
        }

        public static void ContainerStatusEventHandler(object sender, ContainerStatusEvent e)
        {
            if (e.ContainerStatus == ContainerStatus.Overflowing)
            {
                if (e.AllowOverflow == true)
                {
                    Console.WriteLine("Container is overflowing and allowed to overflow");
                }
                else if (e.AllowOverflow == false)
                {
                    Console.WriteLine("Container is overflowing and NOT allowed to overflow");
                }
            }
        }

        public static void WriteContentAndCapacity(Bucket bucket1, Bucket bucket2)
        {
            Console.WriteLine($"Bucket1 size:                   {bucket1.Capacity}");
            Console.WriteLine($"Bucket1 content:                {bucket1.Content}");
            if (bucket1.Overflowed != 0
                || bucket1.ContainerStatus == ContainerStatus.Overflowing
                || bucket1.Content == bucket1.Capacity)
            {
                Console.WriteLine($"Bucket1 Allow overflowing =     {bucket1.AllowOverflowing}");
                Console.WriteLine($"Bucket1 overflowed amount:      {bucket1.Overflowed}");
            }
            Console.WriteLine("\n");

            Console.WriteLine($"Bucket2 size:                   {bucket2.Capacity}");
            Console.WriteLine($"Bucket2 content:                {bucket2.Content}");
            if (bucket2.Overflowed != 0
                || bucket2.ContainerStatus == ContainerStatus.Overflowing
                || bucket2.Content == bucket2.Capacity)
            {
                Console.WriteLine($"Bucket2 Allow overflowing =     {bucket2.AllowOverflowing}");
                Console.WriteLine($"Bucket2 overflowed amount:      {bucket2.Overflowed}");
            }
            Console.WriteLine("\n");
        }

        public static void WaitAndClearCMD()
        {
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
