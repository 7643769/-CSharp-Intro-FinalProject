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
            int w = Console.WindowWidth - 1;
            int h = Console.WindowHeight;
            int nowScene = 1;
            string gameOverInfo = " ";
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
                            switch (c)
                            {
                                case 'W':
                                case 'w':
                                    nowSelect--;
                                    if (nowSelect < 0)
                                    {
                                        nowSelect = 1;
                                    }
                                    break;
                                case 'S':
                                case 's':
                                    nowSelect++;
                                    if (nowSelect > 1)
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
                        int bossY = h / 2;
                        int bossHP = 100;
                        int bossAtkMin = 7;
                        int bossAtkMax = 10;
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

                        #region 公主相关
                        int princessX = w / 2;
                        int princessY = h / 2;
                        string princessIcon = "Z";
                        ConsoleColor princessColor = ConsoleColor.Magenta;
                        #endregion





                        bool isFight = false;
                        bool isGameOver = false;

                        while (true)
                        {

                            if (bossHP > 0)
                            {
                                #region BOSS相关逻辑
                                Console.SetCursorPosition(bossX, bossY);
                                Console.ForegroundColor = bossColor;
                                Console.Write(bossIcon);
                                #endregion
                            }
                            else
                            {
                                #region 公主相关逻辑
                                Console.SetCursorPosition(princessX, princessY);
                                Console.ForegroundColor = princessColor;
                                Console.Write(princessIcon);
                                #endregion
                            }



                            Console.SetCursorPosition(playerX, playerY);

                            Console.ForegroundColor = playerColor;
                            Console.Write(playerIcon);
                            playerInput = Console.ReadKey(true).KeyChar;
                            if (isFight)
                            {

                                if (playerInput == 'j' || playerInput == 'J')
                                {
                                    if (playerHP == 0)
                                    {
                                        nowScene = 3;
                                        gameOverInfo = "玩家被击败,游戏结束";
                                        break;
                                    }
                                    else if (bossHP <= 0)
                                    {
                                        isFight = false;

                                    }
                                    else
                                    {
                                        #region 战斗逻辑
                                        Random r = new Random();
                                        int damage = r.Next(playerAtkMin, playerAtkMax + 1);
                                        bossHP -= damage;
                                        if (bossHP <= 0)
                                        {
                                            bossHP = 0;
                                        }

                                        Console.SetCursorPosition(w / 2 - 5, h - 5);
                                        Console.Write("攻击成功,BOSS扣除" + damage + "点血,BOSS还剩" + bossHP + "点血");
                                        Console.SetCursorPosition(w / 2 - 5, h - 4);
                                        Console.Write("BOSS当前血量为{0}       ", bossHP);

                                        if (bossHP == 0 && playerHP > 0)
                                        {

                                            Console.SetCursorPosition(w / 2 - 5, h - 4);
                                            Console.Write("攻击成功,BOSS被击败");
                                            Console.SetCursorPosition(w / 2 - 5, h - 3);
                                            Console.Write("恭喜玩家击败boss，快去营救舟舟                                        ");
                                            Console.SetCursorPosition(bossX, bossY);
                                            Console.Write(" ");
                                            Console.SetCursorPosition(w / 2 - 5, 2);
                                            Console.Write("按J键继续，前往营救舟舟");
                                        }

                                        if (bossHP > 0 && playerHP > 0)
                                        {
                                            Random a = new Random();
                                            int damage1 = a.Next(bossAtkMin, bossAtkMax + 1);
                                            playerHP -= damage1;
                                            if (playerHP <= 0)
                                            {
                                                playerHP = 0;
                                            }

                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.SetCursorPosition(w / 2 - 5, h - 3);
                                            Console.Write("BOSS攻击成功,玩家扣除" + damage1 + "点血,玩家还剩" + playerHP + "点血");
                                            Console.SetCursorPosition(w / 2 - 5, h - 2);
                                            Console.Write("玩家当前血量为{0}       ", playerHP);
                                        }

                                        if (playerHP == 0 && bossHP > 0)
                                        {
                                            isFight = false;
                                            Console.SetCursorPosition(w / 2 - 5, h - 4);
                                            Console.Write("玩家被击败,游戏结束");
                                            Console.SetCursorPosition(playerX, playerY);
                                            Console.Write(" ");
                                            Console.SetCursorPosition(w / 2 - 5, h - 3);
                                            Console.Write("按J键继续，前往游戏结束界面                                  ");
                                        }
                                        #endregion
                                    }
                                }

                            }
                            else
                            {
                                #region 玩家移动逻辑与游戏是否结束

                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(" ");
                                switch (playerInput)
                                {
                                    case 'W':
                                    case 'w':
                                        --playerY;
                                        if (playerY < 1)
                                        {
                                            playerY = 1;
                                        }
                                        else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                        {
                                            playerY++;
                                        }
                                        else if (playerY == princessY && playerX == princessX)
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
                                        else if (playerY == princessY && playerX == princessX)
                                        {
                                            playerY--;
                                        }
                                        break;
                                    case 'A':
                                    case 'a':
                                        playerX -= 2;
                                        if (playerX < 2)
                                        {
                                            playerX = 2;
                                        }
                                        else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                        {
                                            playerX += 2;
                                        }
                                        else if (playerY == princessY && playerX == princessX)
                                        {
                                            playerX += 2;
                                        }
                                        break;
                                    case 'D':
                                    case 'd':
                                        playerX += 2;
                                        if (playerX > w - 2)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerY == bossY && playerX == bossX && bossHP > 0)
                                        {
                                            playerX -= 2;
                                        }
                                        else if (playerY == princessY && playerX == princessX)
                                        {
                                            playerX -= 2;
                                        }
                                        break;
                                    case 'J':
                                    case 'j':

                                        if ((playerX == bossX && playerY == bossY - 1 ||
                                            playerX == bossX && playerY == bossY + 1 ||
                                            playerX == bossX - 2 && playerY == bossY ||
                                            playerX == bossX + 2 && playerY == bossY) && (bossHP > 0))
                                        {
                                            isFight = true;
                                            Console.SetCursorPosition(w / 2, h - 5);
                                            Console.Write("进入战斗");
                                        }
                                        else if ((playerX == princessX && playerY == princessY - 1 ||
                                            playerX == princessX && playerY == princessY + 1 ||
                                            playerX == princessX - 2 && playerY == princessY ||
                                            playerX == princessX + 2 && playerY == princessY) && (bossHP <= 0))
                                        {
                                            nowScene = 3;
                                            gameOverInfo = "恭喜玩家营救舟舟成功";
                                            isGameOver = true;
                                            break;
                                        }

                                        break;

                                }
                                Console.SetCursorPosition(playerX, playerY);
                                Console.Write(playerIcon);
                                #endregion
                            }
                            if (isGameOver)
                            {
                                break;
                            }

                        }





                        #endregion

                        break;
                    case 3:
                        
                        Console.Clear();
                        #region 游戏结束场景逻辑
                        Console.SetCursorPosition(w / 2 - 3, h / 2);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("本轮游戏结束");
                        Console.SetCursorPosition(w / 2 - 3, h / 2 + 2);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(gameOverInfo);
                        int nowSelect1 = 0;
                       
                        while (true)
                        { 
                            Console.SetCursorPosition(w / 2 - 2, 8);
                            Console.ForegroundColor = nowSelect1 == 0 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("回到开始界面");
                            Console.SetCursorPosition(w / 2 - 2, 10);
                            Console.ForegroundColor = nowSelect1 == 1 ? ConsoleColor.Red : ConsoleColor.White;
                            Console.WriteLine("退出游戏");
                            bool isExit1 = false;
                            char c = Console.ReadKey(true).KeyChar;
                            switch (c)
                            {
                                case 'W':
                                case 'w':
                                    nowSelect1--;
                                    if (nowSelect1 < 0)
                                    {
                                        nowSelect1 = 1;
                                    }
                                    break;
                                case 'S':
                                case 's':
                                    nowSelect1++;
                                    if (nowSelect1 > 1)
                                    {
                                        nowSelect1 = 0;
                                    }
                                    break;
                                case 'J':
                                case 'j':
                                    if (nowSelect1 == 0)
                                    {
                                        nowScene = 1;
                                        isExit1 = true;
                                        break;
                                    }
                                    else if (nowSelect1 == 1)
                                    {
                                        Environment.Exit(0);
                                    }
                                    break;
                            }
                            if (isExit1)
                            {
                                break;
                            }

                        }
                        #endregion
                        break;
                        
                }
            }
        }
    }
}
