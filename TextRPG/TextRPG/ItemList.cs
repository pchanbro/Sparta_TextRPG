using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class ItemList
    {
        public Item IronArmor { get; set; }
        public Item SpartanSpear { get; set; }
        public Item OldSword { get; set; }
        public Item TrainersArmor { get; set; }
        public Item SpartanArmor { get; set; }
        public Item BronzeAx { get; set; }



        public ItemList()
        {
            IronArmor = new Item()
            {
                name = "무쇠갑옷",
                optionType = "방어력",
                option = 5,
                description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                wearing = false,
                price = 2000,
                sale = true,
            };

            SpartanSpear = new Item()
            {
                name = "스파르타의 창",
                optionType = "공격력",
                option = 7,
                description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                wearing = false,
                price = 2500,
                sale = true,
            };

            OldSword = new Item()
            {
                name = "낡은 검",
                optionType = "공격력",
                option = 2,
                description = "쉽게 볼 수 있는 낡은 검입니다.",
                wearing = false,
                price = 600,
                sale = true,
            };

            TrainersArmor = new Item()
            { 
                name = "수련자 갑옷",
                optionType = "방어력",
                option = 5,
                description = "수련에 도움을 주는 갑옷입니다.",
                wearing = false,
                price = 1000,
                sale = true,
            };

            SpartanArmor = new Item()
            {
                name = "스파르타의 갑옷",
                optionType = "방어력",
                option = 15,
                description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                wearing = false,
                price = 3500,
                sale = true,
            };

            BronzeAx = new Item()
            {
                name = "청동 도끼",
                optionType = "공격력",
                option = 5,
                description = "어디선가 사용됐던거 같은 도끼입니다.",
                wearing = false,
                price = 1500,
                sale = true,
            };



        }


    }
}
