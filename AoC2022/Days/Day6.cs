namespace AoC2022;

public class Day6
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(6, false);

        for (var i = 0; i < input.Length - 4; i++)
        {
            var messageStart = true;
            for (var j = i; j < i + 3; j++)
            {
                for (var k = j + 1; k < i + 4; k++)
                {
                    if (input[j] == input[k])
                    {
                        messageStart = false;
                    }
                }
            }

            if (messageStart)
            {
                Console.WriteLine($"Day Six. Step One. Pos: {i+4}");
                break;
            }
        }

    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(6, false);

        for (var i = 0; i < input.Length - 4; i++)
        {
            var messageStart = true;
            for (var j = i; j < i + 13; j++)
            {
                for (var k = j + 1; k < i + 14; k++)
                {
                    if (input[j] == input[k])
                    {
                        messageStart = false;
                    }
                }
            }

            if (messageStart)
            {
                Console.WriteLine($"Day Six. Step Two. Pos: {i+14}");
                break;
            }
        }
        
    }
}