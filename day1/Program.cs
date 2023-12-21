// See https://aka.ms/new-console-template for more information

class program
{
    static void Main(string[] args)
    {
        solver solution = new();
        solution.looper();
    }
}

class solver
{
    public void looper()
    {

        int answer = 0;
        string file = @"C:\Users\david.rothamel\source\repos\aoc_2023\day1\day1\TextFile1.txt";
        string[] file_lines = File.ReadAllLines(file);

        Console.WriteLine(file_lines[0]);

        foreach (string line in file_lines)
        {


            answer += Int32.Parse(GetNumber(line, true) + GetNumber(line, false));
        }

        Console.WriteLine(answer);

    }

    private string GetNumber(string line, bool direction)
    {
        string number = "";
        Dictionary<char, string> number_words = new();
        number_words.Add('0', "zero");
        number_words.Add('1', "one");
        number_words.Add('2', "two");
        number_words.Add('3', "three");
        number_words.Add('4', "four");
        number_words.Add('5', "five");
        number_words.Add('6', "six");
        number_words.Add('7', "seven");
        number_words.Add('8', "eight");
        number_words.Add('9', "nine");


        if (direction)
        {
            for (int i = 0; i < line.Length; i++)
            {
                foreach (KeyValuePair<char, string> letter in number_words)
                {
                    if (line[i] == letter.Key)
                    {
                        number += line[i];
                        break;
                    }
                }

                if (number.Length == 1)
                {
                    break;
                }

                foreach (KeyValuePair<char, string> word in number_words)
                {
                    if (IsNumberWord(word, line, i, true))
                    {
                        number += word.Key;
                        break;
                    }
                }

                if (number.Length == 1)
                {
                    break;
                }
            }
        }
        else
        {
            for (int i = line.Length - 1; i >= 0; i--)
            {
                foreach (KeyValuePair<char, string> letter in number_words)
                {
                    if (line[i] == letter.Key)
                    {
                        number += line[i];
                        break;
                    }
                }

                if (number.Length == 1)
                {
                    break;
                }

                foreach (KeyValuePair<char, string> word in number_words)
                {
                    if (IsNumberWord(word, line, i, false))
                    {
                        number += word.Key;
                        break;
                    }
                }

                if (number.Length == 1)
                {
                    break;
                }
            }
        }



        Console.WriteLine(number);

        return number;
    }

    private bool IsNumberWord(KeyValuePair<char, string> number, string line, int index, bool direction)
    {
        string newWord = "";

        if (direction)
        {
            if (line.Length - index < number.Value.Length)
            {
                return false;
            }

            for (int i = index; i < number.Value.Length + index; i++)
            {
                newWord += line[i];
            }
        }
        else
        {
            if (number.Value.Length > index)
            {
                return false;
            }

            for (int i = index - number.Value.Length + 1; i < index + 1; i++)
            {
                newWord += line[i];
            }
            //Console.WriteLine(newWord);
        }


        if (newWord == number.Value)
        {
            return true;
        }
        else
        {
            return false;
        }


    }
}