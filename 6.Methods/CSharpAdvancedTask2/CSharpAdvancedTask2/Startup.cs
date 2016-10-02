namespace CSharpAdvancedTask2
{
    using System;

    public class Startup
    {
        const string StopCommand = "stop";

        private static int[] ConvertDanceFieldNumbersToInteger(string[] input)
        {
            int[] danceField = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                danceField[i] = Convert.ToInt32(input[i]);
            }

            return danceField;
        }

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            var danceField = ConvertDanceFieldNumbersToInteger(input);

            long danceScores = 0;
            int fieldIndex = 0;
            int rounds = 0;
            while (true)
            {
                string currentLine = Console.ReadLine();
                string[] elements = currentLine.Split(' ');
                if (currentLine == StopCommand)
                {
                    break;
                }

                int jumps = Convert.ToInt32(elements[0]);
                string direction = elements[1];
                int step = Convert.ToInt32(elements[2]);

                for (int i = 0; i < jumps; i++)
                {
                    switch (direction)
                    {
                        case "right":
                            fieldIndex = (fieldIndex + step) % danceField.Length;
                            break;
                        case "left":
                            fieldIndex = (danceField.Length + ((fieldIndex - step) % danceField.Length)) % danceField.Length;
                            break;
                    }

                    danceScores += danceField[fieldIndex];
                }

                rounds++;
            }

            decimal finalResult = (decimal)danceScores / rounds;

            Console.WriteLine("{0:F1}", finalResult);
        }
    }
}