namespace EnterTheDungeon
{
    public class Lobby // 게임 시작화면
    {
        public void mainLobby()
        {
            Console.Clear();

            MyChar character = new MyChar("Park", "Warrior", 1, 10, 5, 100, 1500);
            Inventory inven = new Inventory();

            Console.WriteLine("엔터 더 던전에 오신 것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine(" ");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리 보기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            string input = Console.ReadLine();
            if(input == "1")
            {
                character.ShowMyChar();
                if(character.menu == 0)
                {
                    mainLobby();
                }
            }
            else if(input == "2")
            {
                inven.ShowInven();
                if (inven.menu == 0)
                {
                    mainLobby();
                }else if(inven.menu == 1)
                {
                    inven.Equip();
                }
            }
            else
            {
                Console.WriteLine("잘못된 선택입니다.");
                Thread.Sleep(1000);
                mainLobby();
            }
        }
        // 1. 상태 보기로 전환
        // 2. 인벤토리 보기로 전환
    }

    public class MyChar // 캐릭터 상태보기
    {
        public string Name { get; }
        public string Job { get; }
        public int Lv { get; }
        public int Attack { get; }
        public int Defend { get; }
        public int Health { get; }
        public int Gold { get; }
        public int menu;
        public MyChar( string _name, string _job, int _Lv, int _attack, 
            int _defend, int _health, int _gold)
        {
            // 이름(직업)
            Name = _name;
            Job = _job;
            // 레벨
            Lv = _Lv;
            // 공격력
            Attack = _attack;
            // 방어력
            Defend = _defend;
            // 체력
            Health = _health;
            // 골드
            Gold = _gold;            
        }

        public void ShowMyChar()
        {
            Console.Clear();

            Console.WriteLine("캐릭터 정보");
            Console.WriteLine($"LV : {Lv}");
            Console.WriteLine($"이름(직업) : {Name}({Job})");
            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defend}");
            Console.WriteLine($"체  력 : {Health}");
            Console.WriteLine($"골  드 : {Gold} G");
            Console.WriteLine(" ");
            Console.WriteLine("0. 나가기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력하시오");
            menu = int.Parse(Console.ReadLine() );
        }
        // 0. 나가기(로비로)
    }

    public class Inventory // 인벤토리 보기
    {
        public List<string> Inven;
        public int menu;
        public void manageInven()
        {
            Inven = new List<string>();
            string[] weapon = { "Axe", "Attack : 5", "Basic axe",
                                "Bow", "Attack : 10", "Basic bow"};
            for(int i = 0;i < weapon.Length; i++)
            {
                Inven.Add(weapon[i]);
            }
        }

        public void ShowInven()
        {
            Console.Clear();
            manageInven();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[아이템 이름]   |  [장비 효과]  |  [장비 설명]  ");
            for (int i =0;i<Inven.Count ;i+=3)
            {
                Console.WriteLine("\t" + Inven[i]+ "\t" + Inven[i+1] + "\t" + Inven[i+2] + "\n");
            }
            Console.WriteLine(" ");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력하시오");
            menu = int.Parse(Console.ReadLine());
        }

        public void Equip()
        {
            Console.Clear();
            manageInven();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[아이템 이름]   |  [장비 효과]  |  [장비 설명]  ");
            for (int i = 0; i < Inven.Count; i += 3)
            {
                Console.WriteLine("\t" + Inven[i] + "\t" + Inven[i + 1] + "\t" + Inven[i + 2] + "\n");
            }
            Console.WriteLine("장착할 장비를 선택하시오");
        }
        // [아이템목록]
        // [아이템 이름]   |  장비 효과  |  장비 설명
        // 1. 장착 관리
        // 0. 나가기(로비로)
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Lobby lobby = new Lobby();
            lobby.mainLobby();
        }
    }

}