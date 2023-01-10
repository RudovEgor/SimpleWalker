namespace SomeProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
            Console.ReadKey();
        }
        
        static void StartGame()
        {

            Console.CursorVisible = false;
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
                {'#',' ',' ','#',' ',' ',' ',' ','X',' ',' ',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ','#',' ',' ','#', },
                {'#',' ',' ',' ','X',' ','#',' ',' ',' ','#',' ',' ',' ','X',' ','#', },
                {'#',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ','#',' ',' ',' ','#',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ','#', },
                {'#',' ',' ','#',' ',' ',' ',' ','X',' ',' ',' ',' ','#',' ',' ','#', },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#', },
            };
            int posX = 5, posY = 8,score =0;
            const int maxScore = 4;
            while (true)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                ConsoleColor defaultColor = Console.BackgroundColor;
                string bar = "";
                Console.SetCursorPosition(0, 11);
                for (int i = 0; i < score; i++)
                {
                    bar += " ";
                }
                Console.Write("Собранные сокровища: "+'[');
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(bar);
                Console.BackgroundColor = defaultColor;
                bar = "";
                for (int i = score; i < maxScore; i++)
                {
                    bar += " ";
                }
                Console.Write(bar + ']');
                Console.Write("\nОсталось собрать: " + (maxScore - score));
                Console.SetCursorPosition(posY, posX);
                Console.Write('@');
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[posX - 1, posY] != '#')
                        {
                            posX--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[posX + 1, posY] != '#')
                        {
                            posX++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[posX, posY - 1] != '#')
                        {
                            posY--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[posX, posY + 1] != '#')
                        {
                            posY++;
                        }
                        break;
                }
                
                if (map[posX,posY] == 'X')
                {
                    map[posX, posY] = 'O';
                    score++;
                }
                if (maxScore == score)
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.SetCursorPosition(10,10);
                    Console.WriteLine("Игра выиграна!");
                    break;
                }
                Console.Clear();
            }
            
        }
    }
}