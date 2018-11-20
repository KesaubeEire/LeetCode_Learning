using System;

namespace 测试专用Program1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Husband husband = new Husband();
            husband._Wife._WifeSister();
            Console.WriteLine("++++++++++++++++");
            husband._Wife._WifeSister += husband.CallOther;
            Console.WriteLine("++++++++++++++++");
            husband._Wife._WifeSister();
        }
    }

    public class Wife
    {
        public int Money;

        public delegate void WifeSister();

        public WifeSister _WifeSister;
    }


    public class Husband
    {
        public Wife _Wife;
        public int Money;

        public Husband()
        {
            _Wife = new Wife();

            _Wife._WifeSister += CallMe;
        }

        public void LendMoney()
        {
            Money += _Wife.Money;
        }

        public void CallMe()
        {
            Console.WriteLine("出事啦");
        }

        public void CallOther()
        {
            Console.WriteLine("233");
        }
    }
}