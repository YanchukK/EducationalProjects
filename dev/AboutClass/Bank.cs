using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutClass
{
    // уже можно разбить по отдельным файлам
    
    class Client
    {
        // У клиента есть имя и фамилия, и список его счетов.
        // Методы для получения баланса по счетам.

        private string name;
        private string surname;
        Account[] accounts;

        public Client(string Name, string Surname)
        {
            name = Name;
            surname = Surname;
            // this.accounts = new Account[0];
            // поэтому не нужны проверки на null
        }

        public Client(string Name, string Surname, Account[] Accounts)
        {
            name = Name;
            surname = Surname;
            accounts = Accounts;
        }

        public Account[] GetAccounts()
        {
            return accounts;
        }

        public void AddAccount(Account account)
        {
            if (accounts != null)
            {
                Account[] newAccounts;

                newAccounts = new Account[accounts.Length + 1];

                for (int i = 0; i < newAccounts.Length; i++)
                {
                    while (i != (newAccounts.Length - 1))
                    {
                        newAccounts[i] = accounts[i];
                        i++;
                    }
                    
                    newAccounts[i] = account;
                }
                // newAccounts[length] = account; поэтому можно без вайл?
                accounts = newAccounts;
            }
            else
            {
                accounts = new Account[] { account };
            }
        }

        // Методы для получения баланса по счетам.
        public Money GetWholeBalance() // работает?
        {
            Money wholeBalance = new Money(0, 0);

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
    }

    class Account
    {
        // У счета есть Деньги - баланс, ставка. На счет
        // можно переводить деньги и снимать их. Менять ставку.
        // Делать это может только банк.

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

        private void SetAll(int Hryvnia, int Coin)
        {
            SetHryvnia(Hryvnia);
            SetCoins(Coin);
        }

        private void SetHryvnia(int value)
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

        private void SetCoins(int value)
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

        public void Print()
        {
            if (coin > 100)
            {
                hryvnia += 1;
                coin -= 100;
            }

            Console.WriteLine($"{hryvnia} hgn {coin} kop");
        }

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


        // исправить, потому что деньги неизменяемый тип!
        public static Money operator -(Money money1, Money money2)
        {
            // создать новый тип. Концепция: если прибавть 10 к 5, 5 не привраться в 15 

            if (money2.hryvnia > money1.hryvnia)
            {
                if (money2.coin > money1.coin)
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
    }

    class Bank // все классы сложить в банк, клиент и деньги ничего не знают о банке, но банк все знает о них
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

        // Получать список всех клиентов
        public Client[] GetClients()
        {
            return clients;
        }


        // получить список всех счетов



        public void OpenAnAccount(Client client, Money money)
        {
            Account newAccount = new Account(money);

            client.AddAccount(newAccount);
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
        public void Withdraw(Client client, Account account, Money money)
        {
            int clientId = ClientId(client);

            int accountId = AccountId(client, account);

            clients[clientId].SetBalance(accountId, clients[clientId].GetBalance(accountId) - money);
        }

        // перевести деньги
        public void Put(Client client, Account account, Money money)
        {
            int clientId = ClientId(client);

            int accountId = AccountId(client, account);

            clients[clientId].SetBalance(accountId, clients[clientId].GetBalance(accountId) + money);
        }

        private int ClientId(Client client)
        {
            int clientId = 0;
            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i] == client)
                {
                    clientId = i;
                    break;
                }
            }

            return clientId;
        }

        private int AccountId(Client client, Account account)
        {
            int clientId = ClientId(client);

            int accountId = 0;
            int n = clients[clientId].GetAccounts().Length;
            for (int i = 0; i < n; i++)
            {
                if (clients[clientId].GetAccounts()[i] == account)
                {
                    accountId = i;
                    break;
                }
            }
            return accountId;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Money elevenhr = new Money(11, 0);
            Money nineAndFifty = new Money(9, 50);

            Account myFirstAccount = new Account(elevenhr);
            Account[] accounts = new Account[] { myFirstAccount };

            Client me = new Client("Kate", "Yanchuk", accounts);
            Client notme = new Client("Name", "Surname");
            Client[] clients = new Client[] { me, notme };

            Bank bank = new Bank(clients);

            bank.Put(me, myFirstAccount, nineAndFifty);

            Money wholeMoney = me.GetWholeBalance();

            bank.Withdraw(me, myFirstAccount, nineAndFifty);


            // Добавить клиенту без счетов счет

            bank.OpenAnAccount(notme, nineAndFifty);

            notme.GetWholeBalance().Print();

            Money tenandninetynine = new Money(10, 99);
            bank.OpenAnAccount(notme, tenandninetynine);

            notme.GetWholeBalance().Print();


            bank.GetAccounts();
        }
    }
}
