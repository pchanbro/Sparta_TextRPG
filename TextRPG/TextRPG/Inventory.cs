using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextRPG
{
    internal class Inventory
    {
        private List<Item> items = new List<Item>();

        public Inventory()
        {
            items.Add(new ItemList().IronArmor);
            items.Add(new ItemList().IronArmor);
            items.Add(new ItemList().SpartanSpear);
            items.Add(new ItemList().SpartanSpear);
            items.Add(new ItemList().OldSword);
            items.Add(new ItemList().OldSword);
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
                if(item != null)
                {
                    Console.WriteLine($" - {item.name}\t | {item.optionType} +{item.option} | {item.description}");
                }
            }
            Console.WriteLine();
        }


        public void ShowManagingItems()
        {
            Console.WriteLine("[아이템 목록]");
            int itemNum = 0;
            foreach (var item in items)
            {
                if (item != null)
                {
                    Console.WriteLine($" - {itemNum + 1} {item.name}\t | {item.optionType} +{item.option} | {item.description}");
                    itemNum++;
                }
            }
            Console.WriteLine();
        }


        public void AddItem(Item newItem)
        {
            items.Add(newItem);
        }


        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }


        public void EquipItem(int num)
        {
            items[num].wearing = true;
            items[num].name = "[E]" + items[num].name;
        }


        public void UnequipItem(int num)
        {
            items[num].wearing = false;
            items[num].name = items[num].name.Replace("[E]", "");
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
