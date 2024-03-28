using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

namespace Banking;

class Program
{
    public delegate void Function();
    static void Main(String[] args)
    {
        Bank bank = new Bank();
        Threading thr = new Threading();
        Function ReadFile = bank.ReadTransection;
        ReadFile += bank.ReadAccount;
        ReadFile();
        //bank.ReadTransection();
        //bank.ReadAccount();
        //thr.readtransection1();
        Console.Write(" 1) AddAccount\n 2) RemoveAccount\n 3) DisplayAccounts\n 4)AddTranscation: \n 5)RemoveTranscation\n 6)DisplayTranscations\n 7)DisplayTranscationByDateRange\n 8)DisplayTranscationByAccount\n 9)Thread Transction\n 10)Exit\n \n Enter your choice: ");
        Function addAccount = bank.AddAccount;
        addAccount += bank.WriteAccount;
        Function removeAccount = bank.RemoveAccount;
        removeAccount += bank.WriteAccount;
        Function addTransction = bank.AddTranscation;
        addTransction += bank.WriteTransction;
        Function removeTransction = bank.RemoveTranscation;
        removeTransction += bank.WriteTransction;
        Function SaveFile = bank.WriteAccount;
        SaveFile += bank.WriteTransction;

        while (true)
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    addAccount();
                    break;
                case 2:
                    removeAccount();
                    break;
                case 3:
                    bank.DisplayAccounts();
                    break;
                case 4:
                    addTransction();
                    break;
                case 5:
                    removeTransction();
                    break;
                case 6:
                    bank.DisplayTranscations();
                    break;
                case 7:
                    bank.DisplayTranscationByDateRange();
                    break;
                case 8:
                    bank.DisplayTranscationByAccount();
                    break;
                case 9:
                    //thr.DisplayTranscations();
                    Console.Write("Enter id and amount:");
                    string idA = Console.ReadLine();
                    string[] idB = idA.Split(" ");
                    Thread tr1 = new Thread(() => thr.GreaterThenId(Convert.ToInt32(idB[0])));
                    Thread tr2 = new Thread(() => thr.GreaterThenAmount(Convert.ToInt32(idB[1])));
                    tr1.Start();
                    tr2.Start();
                    //tr1.Join();
                    //tr2.Join();
                    break;
                default:
                    SaveFile();
                    Console.WriteLine("Thank you for using our banking system");
                    return;
            }
        }
    }
}


