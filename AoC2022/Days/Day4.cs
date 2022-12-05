namespace AoC2022;

public class Day4
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(4, false);
        var inputList = _inputFiles.SplitString(input);

        var pairsMatching = 0;

        foreach (var pairs in inputList)
        {
            var elves = pairs.Split(",");
            var elfOne = elves[0].Split("-");
            var elfTwo = elves[1].Split("-");

            if ((Int32.Parse(elfOne[0]) >= Int32.Parse(elfTwo[0]) && Int32.Parse(elfOne[1]) <= Int32.Parse(elfTwo[1])) || 
                 (Int32.Parse(elfOne[0]) <= Int32.Parse(elfTwo[0]) && Int32.Parse(elfOne[1]) >= Int32.Parse(elfTwo[1])))
            {
                pairsMatching++;
            }
        }
        
        Console.WriteLine($"Day Four Step One Score: {pairsMatching}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(4, false);
        var inputList = _inputFiles.SplitString(input);

        var pairsMatching = 0;

        foreach (var pairs in inputList)
        {
            var elves = pairs.Split(",");
            var elfOne = elves[0].Split("-");
            var elfTwo = elves[1].Split("-");

            if ((Int32.Parse(elfOne[0]) >= Int32.Parse(elfTwo[0]) && Int32.Parse(elfOne[0]) <= Int32.Parse(elfTwo[1])) || 
                (Int32.Parse(elfOne[1]) >= Int32.Parse(elfTwo[0]) && Int32.Parse(elfOne[1]) <= Int32.Parse(elfTwo[1])) || 
                (Int32.Parse(elfTwo[0]) >= Int32.Parse(elfOne[0]) && Int32.Parse(elfTwo[0]) <= Int32.Parse(elfOne[1])) || 
                (Int32.Parse(elfTwo[1]) >= Int32.Parse(elfOne[0]) && Int32.Parse(elfTwo[1]) <= Int32.Parse(elfOne[1])))
            {
                pairsMatching++;
            }
        }
        
        Console.WriteLine($"Day Four Step Two Score: {pairsMatching}");
    }
}