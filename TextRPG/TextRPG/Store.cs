using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Store
    {
        private List<Item> items = new List<Item>();

        public Store()
        {
            items.Add(new ItemList().TrainersArmor);
            items.Add(new ItemList().IronArmor);
            items.Add(new ItemList().SpartanArmor);
            items.Add(new ItemList().OldSword);
            items.Add(new ItemList().BronzeAx);
            items.Add(new ItemList().SpartanSpear);
        }


        public Item GetItem(int num)
        {
            return items[num];
        }


        public void ShowItems()
        {
            Console.WriteLine("[아이템 목록]");
            foreach (var item in items)
            {
                if (item != null)
                {
                    Console.Write($" - {item.name}\t | {item.optionType} +{item.option}\t | {item.description}\t | ");
                    if(item.sale == true)
                    {
                        Console.WriteLine(item.price + " G");
                    }
                    else if(item.sale == false)
                    {
                        Console.WriteLine("구매완료");
                    }
                }
            }

            Console.WriteLine();
        }


        public void ShowSaliItems()
        {
            Console.WriteLine("[아이템 목록]");
            int itemNum = 0;
            foreach (var item in items)
            {
                if (item != null)
                {
                    Console.Write($" - {itemNum + 1} {item.name}\t | {item.optionType} +{item.option} | {item.description} \t | ");
                    if (item.sale == true)
                    {
                        Console.WriteLine(item.price + " G");
                    }
                    else if (item.sale == false)
                    {
                        Console.WriteLine("구매완료");
                    }
                    itemNum++;
                }
            }

            Console.WriteLine();
        }


        public int CountItem()
        {
            int count = 0;
            foreach (var item in items)
            {
                if (item != null)
                {
                    count++;
                }
            }
            return count;
        }


    }
}
