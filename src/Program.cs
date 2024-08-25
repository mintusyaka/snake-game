using snake_game_console.src;

public class Program
{
    public static int LATENCY = 100;
    public static int MAP_SIZE_X = 40;
    public static int MAP_SIZE_Y = 20;

    public static void Main(string[] args)
    {
        Snake snake = new Snake();
        Food food = new Food();

        while (true)
        {
            Console.Clear();

            try
            {
                snake.Move();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Game Over! {ex.Message}\nYour score is {snake.Score - 1}");
                break;
            }

            for(int i = 0; i < MAP_SIZE_Y; ++i)
            {
                for(int j = 0; j < MAP_SIZE_X; ++j)
                {
                    Coords point = new Coords(j, i);

                    if (i == 0 || j == 0 || i == MAP_SIZE_Y - 1 || j == MAP_SIZE_X - 1)
                    {
                        Console.Write("#");
                    }
                    else if (snake.PositionEquals(point))
                    {
                        Console.Write("☻");
                    }
                    else if(food.Coords.Equals(point))
                    {
                        Console.Write("o");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.Write("\n");
            }


            var curTime = DateTime.Now;
            while((DateTime.Now - curTime).Milliseconds < LATENCY)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        default:
                            break;
                    }
                }

                if (food.Coords.Equals(snake.Head))
                {
                    snake.Eat();
                    food.changePos();
                }
            }
        }

    }

    

    public enum Direction
    {
        Up = 0,
        Down,
        Left,
        Right
    }
}