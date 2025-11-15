using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithmTest
{
    class ItemI
    {
        public int Id;
        public int Pos;
    }

    class ItemE
    {
        public ItemI ItemInner;
        public int extData;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<ItemE> items = new List<ItemE>()
            {
                new ItemE() {ItemInner = new ItemI(){Id = 2, Pos = 20}, extData = 102 },
                new ItemE() {ItemInner = new ItemI(){Id = 3, Pos = 3}, extData = 103 },
                new ItemE() {ItemInner = new ItemI(){Id = 1, Pos = 5}, extData = 101}
            };

            var itemsRet = items.OrderBy(t => t.ItemInner.Id);
            
            items = itemsRet.ToList();
            int _tmpPos = 0;
            for (int i = 0; i < items.Count(); i++)
            {
                items[i].ItemInner.Pos = _tmpPos;
                _tmpPos++;
            }

            foreach (var item in items)
            {
                Console.WriteLine($"Id: {item.ItemInner.Id}, Pos: {item.ItemInner.Pos}, extData: {item.extData}");
            }

        }
    }
}