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
        Action action = new Action(); // 마을화면
        Store store = new Store(); // 상점화면
        // 스크린 매니저 하나 만들어서 싱글톤으로 만들고 거기에 show~~screen 해서 보여주는게
        // 매개변수 신경 안써도 되게 될거다.

        public InGame()// 생성자는 무한루프가 돌아가면 안좋다, 초기화 하는 부분
        {
            while (true)
            {
                action.SelectAction(user, store); 
                // 이름이 이게 뭐하는거? 직관적이지 않음 Action이 뭔지 알게 해줘야함
                // 
            }
        }
    }
}
