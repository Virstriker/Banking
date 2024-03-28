using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Diagnostics;

namespace Banking
{
    internal class Threading
    {
        Bank b = new Bank();
        Dictionary<int, Transcation> Transactions = Bank.Transactions;
        //string pathTransection;
        public Threading() {
            //Transactions = new Dictionary<int, Transcation>();
            //pathTransection = @"D:\file\Transection.txt";
        }
        /*public void ReadTransection1()
        {
            StreamReader sr = new StreamReader(pathTransection);
            string s = sr.ReadLine();
            while (s != null)
            {
                string[] split = s.Split(' ');
                string date = string.Concat(split[4], " ", split[5]);
                Transactions1.Add(Convert.ToInt32(split[0]), new Transcation
                {
                    TranscationId = Convert.ToInt32(split[0]),
                    FromAccountNumber = Convert.ToInt32(split[1]),
                    ToAccountNumber = Convert.ToInt32(split[2]),
                    Amount = Convert.ToInt32(split[3]),
                    TransacationDate = Convert.ToDateTime(date)
                });
                s = sr.ReadLine();
            }
            sr.Close();
        }*/
        public void DisplayTranscations()
        {
            foreach (var transcation in Transactions)
            {
                Console.WriteLine("Transcation Id: " + transcation.Key + ", From Account Number: " + transcation.Value.FromAccountNumber + ", To Account Number: " + transcation.Value.ToAccountNumber + ", Amount: " + transcation.Value.Amount + ", Transacation Date: " + transcation.Value.TransacationDate);
            }
        }
        public void GreaterThenId(int id1)
        {
            //ParallelOptions parallelOptions = new ParallelOptions
            //{
            //    MaxDegreeOfParallelism = 5
            //};
            int a = 0;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            Parallel.ForEach(Transactions, tr=>
            {
                if (tr.Key >= id1)
                {
                    a++;
                    Console.WriteLine("Thread id a"+a);
                }
                //Thread.Sleep(1000);
            });
            stopwatch1.Stop();
            Console.WriteLine($"loop 1 took {stopwatch1.ElapsedMilliseconds} milliseconds.\n");
            //foreach(var tr in Transactions)
            //{
            //    if(tr.Key >= id1)
            //    {
            //        a++;
            //        Console.WriteLine("Thread id a"+a);
            //    }
            //    Thread.Sleep(1000);
            //}
            Console.WriteLine("Total Id greater then {0} is {1}", id1, a);
        }
        public void GreaterThenAmount(int amt)
        {
            //ParallelOptions parallelOptions = new ParallelOptions
            //{
            //    MaxDegreeOfParallelism = 5
            //};
            int b = 0;
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Parallel.ForEach(Transactions, tr =>
            {
                if (tr.Value.Amount >= amt)
                {
                    b++;
                    Console.WriteLine("Thread id b" + b);
                }
                //Thread.Sleep(1000);
            });
            stopwatch2.Stop();
            Console.WriteLine($"loop 2 took {stopwatch2.ElapsedMilliseconds} milliseconds.\n");
            //foreach (var tr in Transactions)
            //{
            //    if(tr.Value.Amount >= amt)
            //    {
            //        b++;
            //        Console.WriteLine("Thread amt b"+b);
            //    }
            //    Thread.Sleep(1000);

            //}
            Console.WriteLine("Total Transction greater then {0} is {1}", amt, b);
        }
    }
}
