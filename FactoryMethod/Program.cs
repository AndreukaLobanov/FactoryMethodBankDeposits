using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Реализовать структуру классов, в соответствии с паттерном «Фабричный Метод» (Factory Method). 
Реализовать процесс случайного выбора депозита и расчёта процента прибыли за определённый период (месяц, квартал, год).
Вывести на экран название депозита и прибыли вкладчика, в зависимости от начальной суммы и периода вложения. 
Предусмотреть наличие минимум 3 разных процентных ставок.*/
namespace FactoryMethodSpace
{
    
    public interface IDeposit
        {
            string DepositName();
            void InfoAboutDeposit();
            double Profit();
            double procent();
            int period();
            double StartedMoney ();
    }
    abstract public class Creator // creator
    {
        abstract public IDeposit factorymethod();
    }
     class FastDeposit : IDeposit
    {
        public double procent() { return new Random().NextDouble() * (21.0 - 12.0) + 12.0; }
        public int period() { return new Random().Next(1, 12) * 30; }
        public double StartedMoney() { return 1000; }

        public string DepositName()
        {
            return "Срочный депозит";
        }
        public double Profit()
        {
           
            return (StartedMoney() * period() * procent()) / (365 * 100);
        }
        public void InfoAboutDeposit()
        {
            string Deposit_Name = DepositName();
            Console.WriteLine(Deposit_Name);
            Console.WriteLine($"Profit: {Profit()}, Started summa:{StartedMoney()}, Period:{period()}");
        }
    }
    class CreatorFastDeposit : Creator
    {
        public override IDeposit factorymethod()
        {
            return new FastDeposit();
        }
    }
    class SaveDeposit:IDeposit
    {
        public double procent() { return new Random().NextDouble() * (10.0 - 5.0) + 5.0; }
        public int period() { return new Random().Next(1, 12) * 30; }
        public double StartedMoney() { return 1000; }

        public string DepositName()
        {
            return "Сберегательный депозит";
        }
        public double Profit()
        {
            return (StartedMoney() * period() * procent()) / (365 * 100);
        }
        public void InfoAboutDeposit()
        {
            string Deposit_Name = DepositName();
            Console.WriteLine(Deposit_Name);
            Console.WriteLine($"Profit: {Profit()}, Started summa:{StartedMoney()}, Period:{period()}");
        }
    }
    class CumulativeDeposit:IDeposit //накопительный
    {
        public double procent() { return new Random().NextDouble() * (18.0 - 10.0) + 10.0; }
        public int period() { return new Random().Next(1, 12) * 30; }
        public double StartedMoney() { return 1000; }
        public string DepositName()
        {
            return "Накопительный депозит";
        }
        public void InfoAboutDeposit()
        {
            string Deposit_Name = DepositName();
            Console.WriteLine(Deposit_Name);
            Console.WriteLine($"Profit: {Profit()}, Started summa:{StartedMoney()}, Period:{period()}");
        }
        public double Profit()
        {
            return (StartedMoney() * period() * procent()) / (365 * 100);
        }
    }
    class CreatorSaveDeposit:Creator
    {  
        public override IDeposit factorymethod()
        {
            return new SaveDeposit();
        } 
    }
    class CreatorCumulativeDeposit : Creator
    {
        public override IDeposit factorymethod()
        {
            return new CumulativeDeposit();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var deposits = new List<Creator>();
            deposits.Add(new CreatorCumulativeDeposit());
            deposits.Add(new CreatorSaveDeposit());
            deposits.Add(new CreatorFastDeposit());
            var tempdeposit = new List<IDeposit>();
            for (int i=0; i<3; i++)
            {
                tempdeposit.Add(deposits[i].factorymethod());
                tempdeposit[i].InfoAboutDeposit();
            }
            Console.ReadKey();
        }
    }
}
