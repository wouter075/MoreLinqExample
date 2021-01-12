using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace MoreLinqExample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // If this does not work, you need to install MoreLinq with NuGet
            // Go to the following menu:
            // Rider:   Tools -> NuGet -> Manage NuGet Packages for <ProjectName>
            //          Search for: MoreLinq, add the latest version to your project.
            
            // make new list:
            List<Phone> phones = new List<Phone>();
            
            // add phones to list:
            phones.Add(new Phone(1, "Samsung", "S20", 1000, 128));
            phones.Add(new Phone(2, "Xiaomi", "Note 20", 350, 64));
            phones.Add(new Phone(3, "HabbieBabbie", "Stux", 100, 32));
            
            // stats without Linq:
            int totalPhones1 = phones.Count();
            double averagePrice1;
            double averageSize1;
            
            double averagePriceTemp = 0;
            double averageSizeTemp = 0;
            double priceSizeTemp = 99999999;
            Phone priceSize1 = new Phone();
            
            foreach (Phone p in phones)
            {
                averagePriceTemp += p.Price;
                averageSizeTemp += p.Memory;

                if ((p.Price / p.Memory) < priceSizeTemp)
                {
                    priceSize1 = p;
                    priceSizeTemp = p.Price / p.Memory;
                }
            }

            averagePrice1 = averagePriceTemp / totalPhones1;
            averageSize1 = averageSizeTemp / totalPhones1;
            Console.WriteLine($"Average price: {averagePrice1}");
            Console.WriteLine($"Average memory size: {averageSize1}");
            Console.WriteLine($"Id Phone with cheapest price/size: {priceSize1.Id}");
            
            
            // stats with Linq:
            int totalPhones2 = phones.Count();
            double averagePrice2 = phones.Average(p => p.Price);
            double averageSize2 = phones.Average(p => p.Memory);
            
            // MoreLinq magic:
            Phone priceSize2 = phones.MinBy(p => p.Price / p.Memory).First();

            Console.WriteLine($"Average price: {averagePrice2}");
            Console.WriteLine($"Average memory size: {averageSize2}");
            Console.WriteLine($"Id Phone with cheapest price/size: {priceSize2.Id}");
        }
    }

    public class Phone
    {
        // fields
        private int _id;
        private string _make;
        private string _model;
        private double _price;
        private double _memory;
        
        // constructor
        public Phone()
        {
            
        }

        public Phone(int id, string make, string model, double price, double memory)
        {
            this._id = id;
            this._make = make;
            this._model = model;
            this._price = price;
            this._memory = memory;
        }
        
        // properties
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Make
        {
            get => _make;
            set => _make = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public double Memory
        {
            get => _memory;
            set => _memory = value;
        }
    }
}