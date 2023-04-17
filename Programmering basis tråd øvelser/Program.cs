using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;

namespace Programmering_basis_tråd_øvelser
{
    class Program
    {
        public static int alarmCount = 0;
        public static char ch = '*';

        public void WorkThreadFunction()
        {
            for (int i = 0; i < 5; i++)
            {
                // Øvelse 1
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(1000);
            }
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        public void WorkThreadFunction2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Også med flere tråde ...");
                Thread.Sleep(1000);
            }
            Console.WriteLine(Thread.CurrentThread.Name);
        }
        public void WorkThreadFunction3()
        {
            try
            {
                while(alarmCount < 3)
                {
                    Random rnd = new Random();
                    int num = rnd.Next(-20, 120);

                    Console.WriteLine(num + " C");

                    if (num > 100 || num < 0)
                    {
                        alarmCount++;
                        Console.WriteLine("Alarm count: " + alarmCount);
                    }

                    Thread.Sleep(2000);
                }

            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"ThreadAbortException Occurred, Message : { e.Message}");
            }

        }
        public void WorkThreadFunction4()
        {
            while (true)
            {
                Thread.Sleep(500);
                Console.Write(ch);
            }
        }
        public void WorkThreadFunction5()
        {
            while(true)
            {
                ch = Console.ReadKey().KeyChar;
            }
        }
    }


    class threprog
    {

        static void Main()
        {
            Program pg = new Program();
            Thread t1 = new Thread(new ThreadStart(pg.WorkThreadFunction));
            t1.Name = "Thread 1";
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(pg.WorkThreadFunction2));
            t2.Name = "Thread 2";
            t2.Start();

            Thread t3 = new Thread(new ThreadStart(pg.WorkThreadFunction3));
            t3.Name = "Thread 3";
            t3.Start();

            Thread print = new Thread(new ThreadStart(pg.WorkThreadFunction4));
            print.Name = "Thread 4";
            print.Start();

            Thread reader = new Thread(new ThreadStart(pg.WorkThreadFunction4));
            reader.Name = "Thread 4";
            reader.Start();

            while (t3.IsAlive)
            {
                Console.WriteLine(t3.Name + " Lever");
                Thread.Sleep(10000);
            }

            t1.Join();
            t2.Join();
            t3.Join();
            print.Join();
            reader.Join();

            Console.WriteLine("");
            Console.WriteLine("Alarm-tråd termineret!");

            Console.Read();
        }

    }
}
