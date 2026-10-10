namespace 入门实践
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //2026.10.9
            Console.CursorVisible = false;
            //Console.SetWindowSize(50, 20);
            //Console.SetBufferSize(50, 20);
                int w = Console.WindowWidth-1;
                int h = Console.WindowHeight;
            int nowScene = 1;

            while (true)
            {
                
                switch (nowScene)
                {
                    case 1:
                        Console.Clear();
                        #region 开始场景逻辑
                        Console.SetCursorPosition(w / 2 - 3, 6);
                        Console.WriteLine("阿源营救舟舟");
                        int nowSelect = 0;
                        while (true)
                        {   
                            bool isExit = false;
                           
                            Console.SetCursorPosition(w / 2 - 2, 8);
                            Console.ForegroundColor = nowSelect == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("开始游戏");
                            Console.SetCursorPosition(w / 2 - 2, 10);
                            Console.ForegroundColor = nowSelect == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("退出游戏");                        
                            char c = Console.ReadKey(true).KeyChar;
                            switch (c) {
                                case 'W':
                                case 'w':
                                    nowSelect--;
                                    if(nowSelect < 0)
                                    {
                                        nowSelect = 1;
                                    }
                                    break;
                                case 'S':
                                case 's':
                                    nowSelect++;
                                    if(nowSelect > 1)
                                    {
                                        nowSelect = 0;
                                    }
                                    break;
                                case 'j':
                                case 'J':
                                    if (nowSelect == 0)
                                    {
                                        nowScene = 2;
                                        isExit = true;
                                    }
                                    else if (nowSelect == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isExit)
                            {
                                break;
                            }
                        }
                        #endregion
                        break;
                    //游戏场景
                    case 2:
                        Console.Clear();
                        #region 游戏场景逻辑

                        #region 不变的红墙

                        while (true)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            for (int i = 0; i <= w - 2; i += 2)
                            {
                                Console.SetCursorPosition(i, 0);
                                Console.Write("\u25A0");
                                Console.SetCursorPosition(i, h - 1);
                                Console.Write("\u25A0");
                                Console.SetCursorPosition(i, h - 6);
                                Console.Write("\u25A0");
                            }

                            for (int i = 0; i < h; i++)
                            {
                                Console.SetCursorPosition(0, i);
                                Console.Write("\u25A0");
                                Console.SetCursorPosition(w - 1, i);
                                Console.Write("\u25A0");
                            }
                            break;
                        }

                        #endregion
                        #region BOSS属性
                        int bossX = w / 2;
                        int bossY = h/2;
                        int bossHP = 100;
                        int bossAtkMin = 7;
                        int bossAtkMax = 14;
                        string bossIcon = "B";
                        //自定义颜色
                        ConsoleColor bossColor = ConsoleColor.Green;
                        #endregion
                        #region 玩家属性
                        int playerX = w / 3;
                        int playerY = 3;
                        int playerHP = 100;
                        int playerAtkMin = 5;
                        int playerAtkMax = 15;
                        string playerIcon = "P";
                        ConsoleColor playerColor = ConsoleColor.Blue;
                        char playerInput;
                        #endregion

                        while (true)
                        {   
                            #region BOSS相关逻辑 
                            if (bossHP>0)
                            {
                            Console.SetCursorPosition(bossX, bossY);
                            Console.ForegroundColor = bossColor;
                            Console.Write(bossIcon);
                            }
                            #endregion
                            #region 玩家相关逻辑
                    
                            Console.SetCursorPosition(playerX, playerY);

                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(" ");
                            switch (playerInput)
                            {
                                case 'W':
                                case 'w':
                                    --playerY;
                                    if (playerY<1)
                                    {
                                        playerY = 1;
                                    }
                                    else if(playerY == bossY && playerX == bossX && bossHP > 0)
                                    {
                                        playerY++;
                                    }
                                    
                                    
                                    break;
                                case 'S':
                                case 's':
                                    ++playerY;
                                    if (playerY == h - 1 || playerY == h - 6)
                                    {
                                        playerY--;
                                    }
                                    else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                    {
                                        playerY--;
                                    }
                                    break;
                                case 'A':
                                case 'a':
                                    playerX -= 2;
                                    if (playerX<2)
                                    {
                                        playerX = 2;
                                    }
                                    else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                    {
                                        playerX+=2;
                                    }
                                    break;
                                case 'D':
                                case 'd':
                                    playerX += 2;
                                    if (playerX > w-2)
                                    {
                                        playerX -= 2;
                                    }
                                    else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                    {
                                        playerX -= 2;
                                    }
                                    break;
                            }
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(playerIcon);
                            #endregion
                        }





                        #endregion

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("游戏结束");
                        break;
                }

            }
        }
    }
}
