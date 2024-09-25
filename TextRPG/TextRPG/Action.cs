using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    enum Movement
    {
        _showStat = 1,
        _showInventory,
        _showStore,

    }

    internal class Action
    {
        public void SelectAction(Character user, Store store)
        {
            while (true)
            {
                Movement movement;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다");
                Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine();

                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                movement = (Movement)System.Enum.Parse(typeof(Movement), Console.ReadLine()??"");

                if (movement == Movement._showStat)
                {
                    ShowStat(user);
                }
                else if (movement == Movement._showInventory)
                {
                    ShowInventory(user);
                }
                else if (movement == Movement._showStore)
                {
                    ShowStore(user, store);
                }
                else
                {

                }


            }
        }


        public void ShowStat(Character user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();

                user.ShowStat();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input;
                input = Console.ReadLine() ?? "";

                if (input == "0")
                {
                    break;
                }
            }
        }


        public void ShowInventory(Character user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();

                user.inventory.ShowItems();

                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input;
                input = Console.ReadLine() ?? "";
                if (input == "0")
                {
                    break;
                }
                else if (input == "1")
                {
                    ManageItem(user);
                }
            }
        }

        public void ManageItem(Character user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("인벤토리 - 장착관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.(아이템 번호를 선택하세요)");
                Console.WriteLine();

                user.inventory.ShowManagingItems();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input;
                input = Console.ReadLine() ?? "";

                // 0번 나가기 선택
                if (input == "0")
                {
                    break;
                }
                // 메뉴에 없는 번호 선택
                else if( (int.Parse(input) < 0) || (int.Parse(input) > user.inventory.CountItem()) )
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("아무 키나 눌러주세요.");
                    Console.ReadKey(true);
                }
                // 선택된 번호의 장비 장착
                else
                {
                    user.ItemEquipManage(int.Parse(input) - 1);
                }
            }
        }


        public void ShowStore(Character user, Store store)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{user.gold} G");
                Console.WriteLine();

                store.ShowItems();

                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input;
                input = Console.ReadLine() ?? "";

                // 0번 나가기 선택
                if (input == "0")
                {
                    break;
                }
                // 1번 아이템 구매
                else if (input == "1")
                {
                    BuyItem(user, store);
                }
                // 선택된 번호의 장비 구매
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("아무 키나 눌러주세요.");
                    Console.ReadKey(true);
                }
            }
        }


        public void BuyItem(Character user, Store store)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{user.gold} G");
                Console.WriteLine();

                store.ShowSaliItems();

                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input;
                input = Console.ReadLine() ?? "";

                // 0번 나가기 선택
                if (input == "0")
                {
                    break;
                }
                // 메뉴에 없는 번호 선택
                else if ((int.Parse(input) < 0) || (int.Parse(input) > store.CountItem()))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.WriteLine("아무 키나 눌러주세요.");
                    Console.ReadKey(true);
                }
                // 선택된 번호의 장비 구매
                else
                {
                    Item item = store.GetItem(int.Parse(input) - 1);
                    if (user.gold > item.price)
                    {
                        if (item.sale == false)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Console.WriteLine("아무 키나 눌러주세요.");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            user.inventory.AddItem(item);
                            user.gold -= item.price;
                            item.sale = false;
                            Console.WriteLine("구매를 완료했습니다.");
                            Console.WriteLine("아무 키나 눌러주세요.");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                        Console.WriteLine("아무 키나 눌러주세요.");
                        Console.ReadKey(true);
                    }
                }
            }
        }


    }
}
