using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Microsoft.Win32.SafeHandles;

namespace snakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write your name: ");
            string name = Console.ReadLine();

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек			
            point p = new point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            point food = foodCreator.CreateFood();
            food.Draw();

            Params settings = new Params();
            Sounds sound = new Sounds(settings.GetResourceFolder());
            sound.Play();

            Sounds sound1 = new Sounds(settings.GetResourceFolder());

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    Score ScoreGame = new Score();
                    ScoreGame.ScoreInGame(snake.score);
                    food = foodCreator.CreateFood();
                    food.Draw();
                    sound1.PlayEat();
                }
                else
                {
                    snake.Move();
                }

                System.Threading.Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

           sound.Stop();
            GameOverSnake GameOver = new GameOverSnake();
            GameOver.WriteGameOver(name, snake.score);
            Console.ReadLine();

        }
    }
}


//VerticalLine v1 = new VerticalLine(0, 10, 5, '%');
//Draw(v1);

//		point p = new point(4, 5, '*');
//            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
//            Draw(fSnake);
//            Snake snake = (Snake)fSnake;

//            HorizontalLine h1 = new HorizontalLine(0, 5, 6, '&');

//            List<Figure> figures = new List<Figure>();
//            figures.Add(fSnake);
//            figures.Add(v1);
//            figures.Add(h1);

//            foreach (var f in figures)
//            {
//                f.Draw();

//            }
//        }
//        static void Draw(Figure figure)
//        {
//            figure.Draw();
//        }
//    }
//}



//HorizontalLine upLine = new HorizontalLine(0, 78, 0, '+');
//HorizontalLine DownLine = new HorizontalLine(0, 78, 24, '+');
//VerticalLine leftLine = new VerticalLine(0, 24, 0, '+');
//VerticalLine rightLine = new VerticalLine(0, 24, 78, '+');
//upLine.Drow();
//DownLine.Drow();
//leftLine.Drow();
//rightLine.Drow();

//        Walls walls = new Walls(80, 25);
//        walls.Draw();

//        //Отрисовка точек
//        point p = new point(4, 5, '*');
//        Snake snake = new Snake(p, 4, Direction.RIGHT);


//        while (true)
//        {
//            if (walls.IsHit(snake) || snake.IsHitTail())
//            {
//                break;
//            }
//            if (snake.Eat(food))
//            {
//                food = foodCreator.CreateFood();


//                //snake.Drow();
//                snake.Move();
//            }




//        //Создание еды для змейки
//        //FoodCreator foodcreator = new FoodCreator(80, 25, 'o');
//        //point food = foodcreator.CreateFood();
//        //food.Draw();

//        //while (true)
//        //{
//        //    if (snake.Eat(food))
//        //    {
//        //        food = foodcreator.CreateFood();
//        //        food.Draw();
//        //    }
//        //    else
//        //    {
//        //        snake.Move();
//        //    }

//            System.Threading.Thread.Sleep(100);

//            if (Console.KeyAvailable)
//            {
//                ConsoleKeyInfo key = Console.ReadKey();
//                snake.HandleKey(key.Key);
//            }

//             }                           
//        }
//    }
//}
