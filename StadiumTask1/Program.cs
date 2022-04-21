using StadiumTask1.Data;
using StadiumTask1.Models;
using System;


namespace StadiumTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            string answer = "";
            string stadName = "";
            string hourPriceStr;
            decimal hourPrice;
            string capacityStr;
            int capacity;
            string IdStr;
            int Id;
            bool check = false;
            do
            {
                Console.WriteLine("1. Stadion elave et \n 2. Stadionlari goster \n 3. Verilmish id-li stadionu goster \n 4. Verilmish id-li stadionu sil \n 0. Proqrami bitir");
                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":   
                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun adini daxil edin: ");
                            stadName = Console.ReadLine();
                        } while (stadName.Length < 256 && String.IsNullOrEmpty(stadName));

                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun saatliq qiymetini daxil edin: ");
                            hourPriceStr = Console.ReadLine();
                        } while (!decimal.TryParse(hourPriceStr, out hourPrice));

                        do
                        {
                            Console.WriteLine("Zehmet olmasa stadionun tutumunu daxil edin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr, out capacity));

                        Stadium stadium = new Stadium
                        {
                            Name = stadName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };

                        stadiumData.Add(stadium);

                        break;

                    case "2":

                        foreach (var item in stadiumData.GetAll())
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.HourPrice} - {item.Capacity}");
                        };
                        break;

                    case "3":

                        do
                        {
                            Console.WriteLine("Zehmet olmasa Id daxil edin: ");
                            IdStr = Console.ReadLine();
                        } while (!int.TryParse(IdStr, out Id) && stadiumData.GetAll().Count < Id);

                        Console.WriteLine(stadiumData.GetById(Id).Name);

                        break;
                    case "4":

                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            IdStr = Console.ReadLine();
                        } while (!int.TryParse(IdStr, out Id) && stadiumData.GetAll().Count < Id);

                        stadiumData.DeleteById(Id);

                        break;
                    case "0": check = false;
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin!");
                        break;
                }

            } while (check);
        }
    }
}
