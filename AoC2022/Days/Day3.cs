namespace AoC2022;

public class Day3
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(3, false);
        var inputList = _inputFiles.SplitString(input);

        var score = 0;

        foreach (var backpack in inputList)
        {
            var foundItems = new List<char>();
            var pocketOne = backpack.Substring(0, backpack.Length / 2);
            var pocketTwo = backpack.Substring(backpack.Length / 2);
            //Console.WriteLine($"Meep: {pocketOne} - {pocketTwo}");

            foreach (var pocketOneItem in pocketOne)
            {
                foreach (var pocketTwoItem in pocketTwo)
                {
                    if (pocketOneItem == pocketTwoItem)
                    {
                        if (!foundItems.Contains(pocketOneItem))
                        {
                            foundItems.Add(pocketOneItem);
                        }
                    }
                }
            }

            foreach (var foundItem in foundItems)
            {
                int charValue = foundItem;
                //Console.WriteLine($"Meep - Found item: {foundItem}   Char value {charValue}");
                if (charValue < 97)
                {
                    charValue -= 38;
                }
                else
                {
                    charValue -= 96;
                }

                //Console.WriteLine($"Meep 2 - Found item: {foundItem}   Char value {charValue}");
                score += charValue;
            }
        }

        Console.WriteLine($"Day Three Step One Score: {score}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(3, false);
        var inputList = _inputFiles.SplitString(input);

        var score = 0;

        for (var i = 0; i < inputList.Length; i += 3)
        {
            foreach (var backpackItemOne in inputList[i])
            {
                foreach (var backpackItemTwo in inputList[i+1])
                {
                    foreach (var backpackItemThree in inputList[i+2])
                    {
                        if (backpackItemOne == backpackItemTwo && backpackItemTwo == backpackItemThree)
                        {
                            int charValue = backpackItemOne;
                            //Console.WriteLine($"Meep - Found item: {foundItem}   Char value {charValue}");
                            if (charValue < 97)
                            {
                                charValue -= 38;
                            }
                            else
                            {
                                charValue -= 96;
                            }

                            //Console.WriteLine($"Meep 2 - Found item: {foundItem}   Char value {charValue}");
                            score += charValue;
                            goto EndOfLoop;
                        }                
                    }
                }   
            }
            EndOfLoop: ;
        }
        
        Console.WriteLine($"Day Three Step Two Score: {score}");
    }
}