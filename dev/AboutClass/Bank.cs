using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClass
{
    class Client
    {
        // У клиента есть имя и фамилия, и список его счетов.
        // Методы для получения баланса по счетам.

        private string name;
        private string surname;
        Account[] accounts;

        public Client(string Name, string Surname, Account[] Accounts)
        {
            name = Name;
            surname = Surname;
            accounts = Accounts;
        }

        // Методы для получения баланса по счетам.
        public Money GetWholeBalance() // работает?
        {
            Money wholeBalance = null;

            for (int i = 0; i < accounts.Length; i++)
            {
                Money temp = accounts[i].GetBalance();
                wholeBalance += temp;
            }

            return wholeBalance;
        }

        public Money GetBalance(int accountId)
        {
            return accounts[accountId].GetBalance();
        }

        public void SetBalance(int accountId, Money money)
        {
            accounts[accountId] = new Account(money);
        }

        public void AddAccount(Money money)
        {
            Account newAccount = new Account(money);

            Account[] newAccounts = new Account[accounts.Length + 1];

            for (int i = 0; i < newAccounts.Length; i++)
            {
                while(i != (newAccounts.Length - 1))
                {
                    newAccounts[i] = accounts[i];
                    i++;
                }
                newAccounts[i] = newAccount;
            }
        }
    }

    class Account
    {
        // У счета есть Деньги - баланс, ставка. На счет
        // можно переводить деньги и снимать их. Менять ставку.
        // Делать это может только банк.

        //private int balance;

        Money balance;

        public Account(Money balance)
        {
            this.balance = balance;
        }

        public Money GetBalance()
        {
            return balance;
        }
    }

    class Money
    {
        // Деньги состоят из гривен и копеек,
        // с ними можно проводить простые арифмет. операции.
        // Должен быть неизменным.

        private int hryvnia;
        private int coin;

        public Money(int Hryvnia, int Coin)
        {
            SetAll(Hryvnia, Coin);
        }

        public void SetAll(int Hryvnia, int Coin)
        {
            if(Hryvnia == 0 && Coin == 0)
            {
                Console.WriteLine("Nice try");
            }
            else
            {
                SetHryvnia(Hryvnia);
                SetY(Coin);
            }
        }

        public void SetHryvnia(int value)
        {             
            if (value >= 0)
            {
                hryvnia = value;
            }
            else
            {
                Console.WriteLine("Nice try");
            }
        }

        public void SetY(int value)
        {
            if (value >= 0 && value < 100)
            {
                coin = value;
            }
            else
            {
                Console.WriteLine("Nice try");
            }
        }

        //public double ReturnDouble()
        //{
        //    string result = $"{hryvnia}.{coin}";

        //    return double.Parse(result);
        //}

        //public Money Sum(Money value)
        //{
        //    value.hryvnia += this.hryvnia;
        //    value.coin += this.coin;

        //    if(value.coin > 100)
        //    {
        //        int hr = value.coin / 100;
        //        value.hryvnia += hr;
        //        value.coin -= hr;
        //    }

        //    return value;            
        //}

        public static Money operator +(Money money1, Money money2)
        {
            money1.hryvnia += money2.hryvnia;
            money1.coin += money2.coin;

            if (money1.coin > 100)
            {
                int hr = money1.coin / 100;
                money1.hryvnia += hr;
                money1.coin -= hr;
            }

            return money1; /*new Money { Value = c1.Value + c2.Value }*/
        }

        public static Money operator -(Money money1, Money money2)
        {
            if(money2.hryvnia > money1.hryvnia)
            {
                if(money2.coin > money1.coin)
                    Console.WriteLine("Недостаточно средств");
            }
            else
            {
                money1.hryvnia -= money2.hryvnia;

                if (money2.coin > money1.coin)
                {
                    money1.hryvnia -= 1;
                    money1.coin += 100;
                }

                money1.coin -= money2.coin;
            }

            return money1;
        }



        //public void Sum(Number value)
        //{
        //    if (y == value.y)
        //    {
        //        x += value.x;
        //    }
        //    else
        //    {
        //        x = value.x * y + value.y * x;
        //        y = value.y * y;
        //    }
        //}

        //public void Dif(int value)
        //{
        //    x -= value * y;
        //}

        //public void Dif(Number value)
        //{
        //    x = value.y * x - value.x * y;
        //    y = value.y * y;
        //}

        //public void Product(int value)
        //{
        //    x *= value;
        //}

        //public void Product(Number value)
        //{
        //    x *= value.x;
        //    y *= value.y;
        //}

        //public void Div(int value)
        //{
        //    y *= value;
        //}

        //public void Div(Number value)
        //{
        //    x *= value.y;
        //    y *= value.x;
        //}

    }

    class Bank
    {
        // Есть класс Банк, он содержит в себе список
        // клиентов и счетов. Не у всех клиентов могут
        // быть счета. Можно открывать счета, добавлять
        // клиентов. Привязывать счет к клиенту.
        // Получать список всех счетов и клиентов.

        Client[] clients;

        public Bank(Client[] Clients)
        {
            this.clients = Clients;
        }

        public void OpenAnAccount(int clientId, Money money)
        {
            clients[clientId].AddAccount(money);
        }

        public void AddClient(Client client)
        {
            Client[] newClients = new Client[clients.Length + 1];

            for (int i = 0; i < newClients.Length; i++)
            {
                while (i != (newClients.Length - 1))
                {
                    newClients[i] = clients[i];
                    i++;
                }
                newClients[i] = client;
            }
        }


        // снять
        public void Withdraw(int clientId, int accountId, Money money)
        {
            clients[clientId].SetBalance(accountId, clients[clientId].GetBalance(accountId) - money);
        }

        // перевести деньги
        public void Put(int clientId, int accountId, Money money)
        {
            clients[clientId].SetBalance(accountId, clients[clientId].GetBalance(accountId) + money);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Money elevenhr = new Money(11, 0);
            Money nineAndFifty = new Money(9, 50);

            Account myAccount = new Account(elevenhr);
            Account[] accounts = new Account[] { myAccount };

            Client me = new Client("Kate", "Yanchuk", accounts);
            Client[] clients = new Client[] { me };
                
            Bank bank = new Bank(clients);

            bank.Withdraw(0, 0, nineAndFifty);
        }
    }
}
