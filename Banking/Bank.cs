using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Bank
    {
        public Dictionary<int, AccountHolder> Accounts;
        public static Dictionary<int, Transcation> Transactions;
        string pathAccount;
        string pathTransection;
        public Bank()
        {
            pathAccount = @"D:\file\Account.txt";
            pathTransection = @"D:\file\Transection.txt";
            Accounts = new Dictionary<int, AccountHolder>();
            Transactions = new Dictionary<int, Transcation>();
        }
        public void ReadAccount()
        {
            StreamReader sr = new StreamReader(pathAccount);
            string s = sr.ReadLine();
            while (s != null)
            {
                string[] split = s.Split(' ');
                Accounts.Add(Convert.ToInt32(split[0]), new AccountHolder { AccountNumber = Convert.ToInt32(split[0]), Name = split[1], Balance = Convert.ToInt32(split[2]) });
                s = sr.ReadLine();
            }
            sr.Close();
        }
        public void WriteAccount()
        {
            StreamWriter sr = new StreamWriter(pathAccount);
            foreach (var acc in Accounts)
            {
                string s = string.Concat(acc.Key, " ", acc.Value.Name, " ", acc.Value.Balance);
                sr.WriteLine(s);
            }
            sr.Close();
        }
        public void ReadTransection()
        {
            StreamReader sr = new StreamReader(pathTransection);
            string s = sr.ReadLine();
            while (s != null)
            {
                string[] split = s.Split(' ');
                string date = string.Concat(split[4], " ", split[5]);
                Transactions.Add(Convert.ToInt32(split[0]), new Transcation
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
        }
        public void WriteTransction()
        {
            StreamWriter sr = new StreamWriter(pathTransection);
            foreach (var acc in Transactions)
            {
                string s = string.Concat(acc.Key, " ", acc.Value.FromAccountNumber, " ", acc.Value.ToAccountNumber, " ",
                    acc.Value.Amount, " ", acc.Value.TransacationDate);
                sr.WriteLine(s);
            }
            sr.Close();
        }
        public void AddAccount()
        {
            Console.Write("Enter account number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter balance: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            Accounts.Add(accountNumber, new AccountHolder { AccountNumber = accountNumber, Name = name, Balance = balance });
        }
        public void RemoveAccount()
        {
            Console.Write("Enter account number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            Accounts.Remove(accountNumber);
        }
        public void DisplayAccounts()
        {
            foreach (var account in Accounts)
            {
                Console.WriteLine("Account Number: {0}, Name: {1}, Balance: {2}", account.Key, account.Value.Name, account.Value.Balance);
            }
        }
        public void AddTranscation()
        {
            Random r = new Random();
            int ra = r.Next(100000);
            Console.WriteLine(ra);
            int transcationId = ra;
        reacc:
            Console.Write("Enter from account number: ");
            int fromAccountNumber = Convert.ToInt32(Console.ReadLine());
            if (!(Accounts.ContainsKey(fromAccountNumber)))
            {
                Console.WriteLine("Accountnumber does not exist enter correct account number!");
                goto reacc;
            }
        reacc1:
            Console.Write("Enter to account number: ");
            int toAccountNumber = Convert.ToInt32(Console.ReadLine());
            if (!(Accounts.ContainsKey(toAccountNumber)))
            {
                Console.WriteLine("Accountnumber does not exist enter correct account number!");
                goto reacc1;
            }
            if (fromAccountNumber == toAccountNumber)
            {
                Console.WriteLine("Account Can not be Same:");
                goto reacc;
            }
            Console.Write("Enter amount: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter transcation date: ");
            // DateTime transcationDate = DateTime.Now;
            DateTime transcationDate = Convert.ToDateTime(Console.ReadLine());
            bool Success = false;
            foreach (var account in Accounts)
            {
                if (account.Key == fromAccountNumber)
                {
                    if (account.Value.Balance >= amount)
                    {
                        account.Value.Balance -= amount;
                        Success = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                        break;
                    }
                }
            }
            foreach (var account1 in Accounts)
            {
                if (account1.Key == toAccountNumber && Success)
                {
                    account1.Value.Balance += amount;
                    Console.WriteLine("Transcation successful");
                    Transactions.Add(transcationId, new Transcation { TranscationId = transcationId, FromAccountNumber = fromAccountNumber, ToAccountNumber = toAccountNumber, Amount = amount, TransacationDate = transcationDate });
                    break;
                }
            }
            // Transactions.Add(transcationId, new Transcation{TranscationId = transcationId, FromAccountNumber = fromAccountNumber, ToAccountNumber = toAccountNumber, Amount = amount, TransacationDate = transcationDate});
        }
        public void RemoveTranscation()
        {
            Console.Write("Enter transcation id: ");
            int transcation = Convert.ToInt32(Console.ReadLine());
            Transactions.Remove(transcation);
        }
        public void DisplayTranscations()
        {
            foreach (var transcation in Transactions)
            {
                Console.WriteLine("Transcation Id: " + transcation.Key + ", From Account Number: " + transcation.Value.FromAccountNumber + ", To Account Number: " + transcation.Value.ToAccountNumber + ", Amount: " + transcation.Value.Amount + ", Transacation Date: " + transcation.Value.TransacationDate);
            }
        }
        public void DisplayTranscationByDateRange()
        {
            Console.Write("Enter start date: ");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter end date: ");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());
            foreach (var transcation in Transactions)
            {
                if (transcation.Value.TransacationDate >= startDate && transcation.Value.TransacationDate <= endDate)
                {
                    Console.WriteLine("Transcation Id: " + transcation.Key + ", From Account Number: " + transcation.Value.FromAccountNumber + ", To Account Number: " + transcation.Value.ToAccountNumber + ", Amount: " + transcation.Value.Amount + ", Transacation Date: " + transcation.Value.TransacationDate);
                }
            }
        }
        public void DisplayTranscationByAccount()
        {
            Console.Write("Enter account number: ");
            int accountNumber = Convert.ToInt32(Console.ReadLine());
            foreach (var transcation in Transactions)
            {
                if (transcation.Value.FromAccountNumber == accountNumber)
                {
                    Console.WriteLine("Transcation Id: " + transcation.Key + ", From Account Number: " + transcation.Value.FromAccountNumber + ", To Account Number: " + transcation.Value.ToAccountNumber + ", Amount: " + transcation.Value.Amount + ", Transacation Date: " + transcation.Value.TransacationDate);
                }
            }
        }
    }
}
