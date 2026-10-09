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
            int w = Console.WindowWidth;
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
                    case 2:
                        Console.Clear();
                        Console.WriteLine("游戏进行中");
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
