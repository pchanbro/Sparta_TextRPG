using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Character
    {

        public int level { get; set; }
        private string nickName;
        private string className;
        private int attack { get; set; }
        public int addAttack { get; set; }
        private int defense { get; set; }
        public int addDefense { get; set; }
        private int hp { get; set; }
        public int gold { get; set; }

        public Inventory inventory = new Inventory();
        public List<Item> equipment = new List<Item>();

        public Character()
        {
            level = 1;
            addAttack = 0;
            addDefense = 0;
            gold = 1500;

            while (true)
            {
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
                Console.WriteLine("캐릭터를 생성합니다.");
                Console.WriteLine();

                Console.WriteLine("원하시는 이름을 설정해주세요.");
                Console.WriteLine();

                Console.Write("이름 : ");
                nickName = Console.ReadLine() ?? "User";
                Console.WriteLine();

                Console.WriteLine("입력하신 이름은 '{0}'입니다", nickName);
                Console.WriteLine();

                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.WriteLine();

                int selectMove;
                Console.WriteLine("원하시는 행동을 선택해주세요.");
                Console.Write("선택 : ");

                try
                { 
                selectMove = int.Parse(Console.ReadLine() ?? "2");
                }
                catch(System.FormatException ex)
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    selectMove = int.Parse(Console.ReadLine() ?? "2");
                }

                if (selectMove == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("취소하셨습니다. 다시 이름을 설정해주세요");
                    Console.WriteLine("아무 키나 누르면 다시 설정합니다.");
                    Console.ReadKey(true);
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("직업을 선택하세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 도적");
                Console.WriteLine();

                Console.Write("직업 선택 : ");
                className = Console.ReadLine() ?? "0";

                Console.WriteLine();

                if (className == "1")
                {
                    className = "전사";
                }
                else if(className == "2") 
                {
                    className = "도적";
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    Console.WriteLine("아무 키나 누르면 다시 설정합니다.");
                    Console.ReadKey(true);
                    continue;
                }

                Console.WriteLine("선택한 직업 : {0}", className);
                Console.WriteLine();

                if (className == "전사")
                {
                    attack = 10;
                    defense = 5;
                    hp = 100;

                    Console.WriteLine(className + "의 능력치");
                    Console.WriteLine();
                    ShowStat();
                }
                else if (className == "도적")
                {
                    attack = 15;
                    defense = 3;
                    hp = 70;
                    Console.WriteLine(className + "의 능력치");
                    Console.WriteLine();
                    ShowStat();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    Console.WriteLine("아무 키나 누르면 다시 설정합니다.");
                    Console.ReadKey(true);
                    continue;
                }

                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 직업 다시선택");
                Console.WriteLine();

                int selectMove;
                Console.WriteLine("원하시는 행동을 선택해주세요.");
                Console.Write("선택 : ");
                try
                {
                    selectMove = int.Parse(Console.ReadLine() ?? "2");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    selectMove = int.Parse(Console.ReadLine() ?? "2");
                }

                if (selectMove == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("직업을 다시 선택합니다.");
                    Console.WriteLine("아무 키나 눌러주세요.");
                    Console.ReadKey(true);
                }
            }
        }


        public void ShowStat()
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            Console.WriteLine("Lv. " + string.Format("{0:00}", level));
            Console.WriteLine(nickName + $" ( {className} )");
            Console.WriteLine("공격력 : {0} (+{1})", attack + addAttack, addAttack);
            Console.WriteLine("방어력 : {0} (+{1})", defense + addDefense, addDefense);
            Console.WriteLine($"HP : {hp}");
            Console.WriteLine($"Gold : {gold}G");
            Console.WriteLine();
        }


        public void ItemEquipManage(int num)
        {
            Item item = inventory.GetItem(num);

            if (item.wearing == false)
            {
                equipment.Add(item);
                inventory.EquipItem(num);

                if (item.optionType == "공격력")
                {
                    addAttack += item.option;
                }
                else if (item.optionType == "방어력")
                {
                    addDefense += item.option;
                }
            }
            else if (item.wearing == true)
            {
                equipment.Remove(item);
                inventory.UnequipItem(num);

                if (item.optionType == "공격력")
                {
                    addAttack -= item.option;
                }
                else if (item.optionType == "방어력")
                {
                    addDefense -= item.option;
                }
            }

        }


        public void LevelUP()
        {

        }
    }
}
