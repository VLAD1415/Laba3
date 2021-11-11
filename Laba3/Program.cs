using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    partial class Customer
    {
        
        private readonly uint x = 0;// Поле только для чтения
        private uint id;
        public uint Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }

        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        private const string patronymic = "Andreevich";// Поле константа
        public string Patronymic
        {
            get
            {
                return patronymic;
            }
            
        }

        private string adress;
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
            }
        }

        private long kkNum;
        public long KkNum
        {
            get
            {
                return kkNum;
            }
            set
            {
                kkNum = value;
            }
        }

        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public Customer()// без параметров
        {
            firstName = "Vlad";
            lastName = "Brichkovski";
            adress = "Luchinskaya 1, kv. 68";
            kkNum = 1234567890098765;
            balance = 1000;
            id = (uint)GetHashCode() + x;
        }

        public Customer(string fi, string la, string ad, long kk, int ba)// С параметрами
        {
            firstName = fi;
            lastName = la;
            adress = ad;
            kkNum = kk;
            balance = ba;
            id = (uint)GetHashCode() + x;

        }

        public Customer ( string  la, string ad, long kk, int ba, string fi = "vanya")// С параметром по умолчанию
        {
            firstName = fi;
            lastName = la;
            adress = ad;
            kkNum = kk;
            balance = ba;
            

        }

        static Customer()// статический конструктор
        {
            Console.WriteLine("Статический конструктор работает");
        }

        public void GetMoney()// Метод пополнения(через ref)
        {
            Console.WriteLine("Введите сумму пополнения: ");
            int Plus = Convert.ToInt32(Console.ReadLine());
            balance += Plus; 
        }

       

        public void PullMoney()// Метод списания
        {
            Console.WriteLine("Введите сумму списания: ");
            int Minus = Convert.ToInt32(Console.ReadLine());
            balance -= Minus;
            
        }


        public override string ToString()// Переопределение метода ToSrting
        {
            return $"{firstName} {lastName} {adress} {kkNum} {balance} {id} ";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Customer customer = (Customer)obj;
            return (this.firstName == customer.firstName);
        }


        



        public void GetInfo()
        {
            Console.WriteLine($"Id = {id}");
            Console.WriteLine($"firstName = {firstName}");
            Console.WriteLine($"lastName = {lastName}");
            Console.WriteLine($"patronymic = {patronymic}");
            Console.WriteLine($"adress = {adress}");
            Console.WriteLine($"Kart Number = {kkNum}");
            Console.WriteLine($"balance = {balance}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer("Egor", "Levanski", "Pushkina 2, kv.55", 0000000000000499, 2000);
            Customer customer3 = new Customer("Garkun", "fghjkl",000000000000501,3000);
            Customer customer4 = new Customer("Vlad", "Dovnar", "Sharko 6, kv. 44", 0123456789123456, 5000);



            // Добавление денег через 
            customer2.GetMoney();
            

            // Списание денег через 
            customer3.PullMoney();


            Console.WriteLine(customer3.ToString());// вывод инфы в строку


            Customer[] arr = { customer1, customer2, customer3, customer4 };
            for (int i = 0; i < arr.Length; i++)// Сортировка по номеру
            {
                if (arr[i].KkNum < 1000000000000000 & arr[i].KkNum > 0000000000000500)
                {
                    Console.WriteLine("Список покупателей у которых номер кредитки находится в интервале от 0000000000000500 до 1000000000000000  : " + arr[i].FirstName + " " + arr[i].LastName);
                }
            }

            

            bool p1Ep2 = customer2.Equals(customer4);   // false
            Console.WriteLine(p1Ep2);


            //Информация о клиентах
            customer1.GetInfo();
            customer2.GetInfo();
            customer3.GetInfo();
            customer4.GetInfo();

            // Использование REF
             void TestRef(ref int n)
            {
                n++;

            }
            int nomer = 10;
            Console.WriteLine($"Nomer до метода TestRef: {nomer}");
            TestRef(ref nomer);
            Console.WriteLine($"Nomer после метода TestRef: {nomer}");

            // Использование OUT
            void TestOut(int x, int y, out int summa)
            {
                summa = x + y;
            }
            int sum;
            TestOut(100, 23, out sum);
            Console.WriteLine($"Метод TestOut: {sum}");

        }
    }
}

