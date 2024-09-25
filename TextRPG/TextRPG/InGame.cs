using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class InGame
    {
        Character user = new Character();
        Action action = new Action();
        Store store = new Store();

        public InGame()
        {
            while (true)
            {
                action.SelectAction(user, store);
            }
        }
    }
}
