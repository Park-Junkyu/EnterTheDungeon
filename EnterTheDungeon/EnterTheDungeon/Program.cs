namespace EnterTheDungeon
{
    public class Lobby // 게임 시작화면
    {
        public int input;
        public void mainLobby()
        {
            Console.Clear();

            Console.WriteLine("엔터 더 던전에 오신 것을 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine(" ");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리 보기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            input = int.Parse(Console.ReadLine());

        }
          
        // 1. 상태 보기로 전환
        // 2. 인벤토리 보기로 전환
    }

    public class MyChar // 캐릭터 상태보기
    {
        public string Name { get; }
        public string Job { get; }
        public int Lv { get; }
        public int Attack { get; set; }
        public int Defend { get; set; }
        public int Health { get; set; }
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
        
        item item = new item();
        public void StatusPlus(bool equip,int WeaponNum)
        {
            if (equip)
            {
                Attack += item.WeaponDmg[WeaponNum];
            }
        }
        public void StatusMinus(bool already, int WeaponNum)
        {
            if (already)
            {
                Attack -= item.WeaponDmg[WeaponNum];
            }
        }
        // 0. 나가기(로비로)
    }

    public class item
    {
        public string Name { get; set; }
        public int Effect { get; set; }
        public string script { get; set; }

        public string[] WeaponName = { "Axe", "Bow", "Sword" };
        public int[] WeaponDmg = { 5, 10, 20 };
        public string[] WeaponScrpt = { "Basic Axe", "Basic Bow", "Basic Sword" };

        public void EquipItem(bool equip, int WeaponNum)
        {
            if (equip)
            {
                // 장착했을 경우 [E]을 WeaponName에 추가
                WeaponName[WeaponNum] = "[E]" + WeaponName[WeaponNum];
                
            }
        }              

        public void UnequipItem(bool unequip, int WeaponNum)
        {
            if (unequip)
            {
                string substring = "[";
                int firstsubstring = WeaponName[WeaponNum].IndexOf(substring);
                WeaponName[WeaponNum] = WeaponName[WeaponNum].Remove(firstsubstring,3);
            }
        }
    }
    public class Inventory // 인벤토리 보기
    {
        item item = new item();
        public List<string> Inven;
        public int menu;
        public int select;
        public bool equip;
        

        public void ShowInven()
        {
            Console.Clear();

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[아이템 이름]  |  [장비 효과] |  [장비 설명] ");
            for (int i =0;i<item.WeaponName.Length ;i++)
            {
                Console.WriteLine(item.WeaponName[i] +"\t|\tDamage : "+ item.WeaponDmg[i] +"\t|\t"+ item.WeaponScrpt[i]);
            }
            Console.WriteLine(" ");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine(" ");
            Console.WriteLine("원하시는 행동을 입력하시오");
            menu = int.Parse(Console.ReadLine());
        }

        
        public void Equip(MyChar targetCharacter)
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[아이템 이름]  |  [장비 효과] |  [장비 설명] ");
            for (int i = 0; i < item.WeaponName.Length; i++)
            {
                Console.WriteLine("["+(i+1)+"]" + item.WeaponName[i] + "\t|\tDamage : " + item.WeaponDmg[i] + "\t|\t" + item.WeaponScrpt[i]);
            }
            Console.WriteLine("장착할 장비를 선택하시오");
            select = int.Parse(Console.ReadLine());
            if(select != null)
            {
                equip = true;
            }
            // 선택한 무기의 이름 배열에서 [E]를 찾아보고 있으면 장착해제, 없으면 장착
            bool alreadyEquip = item.WeaponName[select - 1].Contains("[E]");
            if (alreadyEquip)
            {
                item.UnequipItem(equip, select - 1);
                targetCharacter.StatusMinus(alreadyEquip, select - 1);
            }
            else
            {
                item.EquipItem(equip, select - 1);
                targetCharacter.StatusPlus(equip, select - 1);
            }                      
        }
        
        // [아이템목록]
        // [아이템 이름]   |  장비 효과  |  장비 설명
        // 1. 장착 관리
        // 0. 나가기(로비로)
    }

    public class Program
    {
        static MyChar character = new MyChar("Park", "Warrior", 1, 10, 5, 100, 1500);
        static Inventory inven = new Inventory();
        static Lobby lobby = new Lobby();
        static item item = new item();
        static void Main(string[] args)
        {
            
            while (true)
            {
                lobby.mainLobby();
                switch (lobby.input)
                {
                    case 1:
                        character.ShowMyChar();
                        break;                        
                    case 2:
                        inven.ShowInven();
                        if (inven.menu == 1)
                        {
                            inven.Equip(character);
                            goto case 2;
                        }
                        else if (inven.menu == 0)
                        {
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(1000);
                        break;
                }
            }          
            
        }
    }

}