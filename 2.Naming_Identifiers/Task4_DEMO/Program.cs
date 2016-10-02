using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Mines
    {
        public enum FieldSize
        {
            row = 5,
            column = 10
        }

        public class PlayerPoints
        {
            string name;
            int points;

            public string Name { get; set; }

            public int Points { get; set; }

            public PlayerPoints() { }

            public PlayerPoints(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreatePlayerField();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool mineWasHit = false;
            List<PlayerPoints> champions = new List<PlayerPoints>(6);
            int row = 0;
            int column = 0;
            bool startFlag = true;
            const int max = 35;
            bool endFlag = false;

            do
            {
                if (startFlag)
                {
                    Console.WriteLine("Lets play a game, it is called Minesweeper. Try to find the fields with no mines in it.");
                    Console.WriteLine("There are 3 major commands in the game : \n 'top' shows the ranking \n 'restart' starts a new game \n 'exit' exits of the current game" );

                    printTheField(field);
                    startFlag = false;
                }

                Console.Write("Please enter row and column : ");
                command = Console.ReadLine().Trim();
                
                bool rowIsValidNumber = int.TryParse(command[0].ToString(), out row);
                bool columnIsValidNumber = int.TryParse(command[2].ToString(), out column);

                bool rowInValidRange = row <= field.GetLength(0);
                bool columnInValidRange = column <= field.GetLength(1);

                if (command.Length >= 3)
                {
                    if (rowIsValidNumber && columnIsValidNumber)
                    {
                        if (rowInValidRange && columnInValidRange)
                        {
                            command = "turn";
                        }
                    }
                }
                
                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        field = CreatePlayerField();
                        bombs = PlaceBombs();
                        printTheField(field);
                        mineWasHit = false;
                        startFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, column] != '*')
                        {
                            if (bombs[row, column] == '-')
                            {
                                yourTurn(field, bombs, row, column);
                                counter++;
                            }
                            if (max == counter)
                            {
                                endFlag = true;
                            }
                            else
                            {
                                printTheField(field);
                            }
                        }
                        else
                        {
                            mineWasHit = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (mineWasHit)
                {
                    printTheField(bombs);
                    Console.Write("\nGood luck next time ! You stepped on a mine, now you are dead with {0} points. " +
                        "Please insert your nickname : ", counter);
                    string nickname = Console.ReadLine();
                    PlayerPoints playerPoints = new PlayerPoints(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(playerPoints);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < playerPoints.Points)
                            {
                                champions.Insert(i, playerPoints);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((PlayerPoints r1, PlayerPoints r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((PlayerPoints r1, PlayerPoints r2) => r2.Points.CompareTo(r1.Points));
                    Ranking(champions);

                    field = CreatePlayerField();
                    bombs = PlaceBombs();
                    counter = 0;
                    mineWasHit = false;
                    startFlag = true;
                }
                if (endFlag)
                {
                    Console.WriteLine("\nCongratulations ! You have reached the maximum amount of 35 points.");
                    printTheField(bombs);
                    Console.WriteLine("Please insert your nickname : ");
                    string imeee = Console.ReadLine();
                    PlayerPoints to4kii = new PlayerPoints(imeee, counter);
                    champions.Add(to4kii);
                    Ranking(champions);
                    field = CreatePlayerField();
                    bombs = PlaceBombs();
                    counter = 0;
                    endFlag = false;
                    startFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria !");
            Console.WriteLine("Bye for now");
            Console.Read();
        }

        private static void Ranking(List<PlayerPoints> points)
        {
            Console.WriteLine("\nPoints : ");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine((points[i].Points == 1) ? "{0}. {1} --> {2} point"
                                                              : "{0}. {1} --> {2} points",
                                                i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No ranking yet !\n");
            }
        }

        private static void yourTurn(char[,] field, char[,] bombs, int row, int column)
        {
            char kolkoBombi = numberOfBombsAroundTheField(bombs, row, column);
            bombs[row, column] = kolkoBombi;
            field[row, column] = kolkoBombi;
        }

        private static void printTheField(char[,] board)
        {
            int row = board.GetLength(0);
            int column = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < row; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < column; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayerField()
        {
            int boardRows = (int)FieldSize.row;
            int boardColumns = (int)FieldSize.column;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rowBombField = (int)FieldSize.row;
            int columnBombField = (int)FieldSize.column;
            char[,] bombField = new char[rowBombField, columnBombField];

            for (int i = 0; i < rowBombField; i++)
            {
                for (int j = 0; j < columnBombField; j++)
                {
                    bombField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();
            while (bombs.Count < 15)
            {
                Random random = new Random();
                int newBomb = random.Next(50);
                if (!bombs.Contains(newBomb))
                {
                    bombs.Add(newBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int rowBombCoordinates = (bomb / columnBombField);
                int columnBombCoordinate = (bomb % columnBombField);

                if (columnBombCoordinate == 0 && bomb != 0)
                {
                    rowBombCoordinates--;
                    columnBombCoordinate = columnBombField;
                }
                else
                {
                    columnBombCoordinate++;
                }
                bombField[rowBombCoordinates, columnBombCoordinate - 1] = '*';
            }

            return bombField;
        }

        private static void smetki(char[,] pole)
        {
            int kol = pole.GetLength(0);
            int red = pole.GetLength(1);

            for (int i = 0; i < kol; i++)
            {
                for (int j = 0; j < red; j++)
                {
                    if (pole[i, j] != '*')
                    {
                        char kolkoo = numberOfBombsAroundTheField(pole, i, j);
                        pole[i, j] = kolkoo;
                    }
                }
            }
        }

        private static char numberOfBombsAroundTheField(char[,] playField, int currentRow, int currentColumn)
        {
            int numberOfBombs = 0;
            int rowPlayField = playField.GetLength(0);
            int columnPlayField = playField.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (playField[currentRow - 1, currentColumn] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (currentRow + 1 < rowPlayField)
            {
                if (playField[currentRow + 1, currentColumn] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (currentColumn - 1 >= 0)
            {
                if (playField[currentRow, currentColumn - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if (currentColumn + 1 < columnPlayField)
            {
                if (playField[currentRow, currentColumn + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (playField[currentRow - 1, currentColumn - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((currentRow - 1 >= 0) && (currentColumn + 1 < columnPlayField))
            {
                if (playField[currentRow - 1, currentColumn + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((currentRow + 1 < rowPlayField) && (currentColumn - 1 >= 0))
            {
                if (playField[currentRow + 1, currentColumn - 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            if ((currentRow + 1 < rowPlayField) && (currentColumn + 1 < columnPlayField))
            {
                if (playField[currentRow + 1, currentColumn + 1] == '*')
                {
                    numberOfBombs++;
                }
            }
            return char.Parse(numberOfBombs.ToString());
        }
    }
}
