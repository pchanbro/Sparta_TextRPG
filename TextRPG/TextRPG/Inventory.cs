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
            // 이렇게 하면 리스트 3개에서 각각 다른 요소를 가져옴 -> 메모리 잡아먹고 후에 활용하기도 힘들다.
            // 업데이트도 따로된다.
            items.Add(new ItemList().IronArmor);
            items.Add(new ItemList().SpartanSpear);
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
            // 장착하면 실제 이름이 바뀜
            // 이름이 이렇게 바뀌면 무슨 문제가 생기냐
            // 상표를 바꾼것 ('갤럭시s20' -> '박찬형의 갤럭시s20)
            // 화면 표시때문에 데이터가 변형되면 쓸모없음
            // 화면과 / 화면을 컨트롤 하는것과 / 데이터 -> 세개를 분리하는게 좋다.
            // mvc(model view controller)모델
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
