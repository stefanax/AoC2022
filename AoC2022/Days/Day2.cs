namespace AoC2022;

public class Day2
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(2, false);
        var inputList = _inputFiles.SplitString(input);

        var score = 0;

        foreach (var inputListItem in inputList)
        {
            var challenge = inputListItem.Split(" ");

            switch (challenge[1])
            {
                case "X": score += 1;
                    break;
                case "Y": score += 2;
                    break;
                case "Z": score += 3;
                    break;
            }

            // Draw
            if ((challenge[0] == "A" && challenge[1] == "X") ||
                (challenge[0] == "B" && challenge[1] == "Y") ||
                (challenge[0] == "C" && challenge[1] == "Z"))
            {
                score += 3;
            }

            // Win
            if ((challenge[0] == "A" && challenge[1] == "Y") ||
                (challenge[0] == "B" && challenge[1] == "Z") ||
                (challenge[0] == "C" && challenge[1] == "X"))
            {
                score += 6;
            }
        }
        
        Console.WriteLine($"Day Two, Step One. Score: {score}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(2, false);
        var inputList = _inputFiles.SplitString(input);

        var score = 0;

        foreach (var inputListItem in inputList)
        {
            var challenge = inputListItem.Split(" ");

            switch (challenge[1])
            {
                case "X":
                    switch (challenge[0])
                    {
                        case "A": score += 3; 
                            break;
                        case "B": score += 1;
                            break;
                        case "C": score += 2;
                            break;
                    }
                    break;
                case "Y":
                    score += 3;
                    switch (challenge[0])
                    {
                        case "A": score += 1; 
                            break;
                        case "B": score += 2;
                            break;
                        case "C": score += 3;
                            break;
                    }
                    break;
                case "Z":
                    score += 6;
                    switch (challenge[0])
                    {
                        case "A": score += 2; 
                            break;
                        case "B": score += 3;
                            break;
                        case "C": score += 1;
                            break;
                    }
                    break;
            }
        }
            
        Console.WriteLine($"Day Two, Step Two. Score: {score}");
    }
}