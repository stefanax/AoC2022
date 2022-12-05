namespace AoC2022;

public class Day5
{
    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(5, false);
        var inputList = _inputFiles.SplitString(input);

        var stacks = new List<List<char>>();

        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                break;
            }

            var inputListItemLength = inputListItem.Length;

            var stackPos = 0;
            for (var i = 1; i < inputListItemLength; i += 4)
            {
                if (inputListItem[i] != ' ')
                {
                    if (stacks.Count <= stackPos)
                    {
                        while (stacks.Count <= stackPos)
                        {
                            stacks.Add(new List<char>());
                        }

                        stacks[stackPos].Add(inputListItem[i]);
                    }
                    else
                    {
                        stacks[stackPos].Insert(0, inputListItem[i]);
                    }
                }

                stackPos++;
            }
            
            //NOTE: The bottom layer will be the number of each stack. This is not pretty, but should still work just fine.
        }

        var isCommand = false;
        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                isCommand = true;
                continue;
            } 
            else if (!isCommand)
            {
                continue;
            }

            var command = inputListItem.Split(" ");
            
            moveBoxes(stacks, Int32.Parse(command[1]), Int32.Parse(command[3]), Int32.Parse(command[5]));
        }

        var outputString = "";
        foreach (var stack in stacks)
        {
            outputString += stack[stack.Count - 1];
        }

        Console.WriteLine($"Day Five. Step One. Output: {outputString}");
    }


    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(5, false);
        var inputList = _inputFiles.SplitString(input);

        var stacks = new List<List<char>>();

        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                break;
            }

            var inputListItemLength = inputListItem.Length;

            var stackPos = 0;
            for (var i = 1; i < inputListItemLength; i += 4)
            {
                if (inputListItem[i] != ' ')
                {
                    if (stacks.Count <= stackPos)
                    {
                        while (stacks.Count <= stackPos)
                        {
                            stacks.Add(new List<char>());
                        }

                        stacks[stackPos].Add(inputListItem[i]);
                    }
                    else
                    {
                        stacks[stackPos].Insert(0, inputListItem[i]);
                    }
                }

                stackPos++;
            }
            
            //NOTE: The bottom layer will be the number of each stack. This is not pretty, but should still work just fine.
        }

        var isCommand = false;
        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                isCommand = true;
                continue;
            } 
            else if (!isCommand)
            {
                continue;
            }

            var command = inputListItem.Split(" ");
            
            moveBoxesMulti(stacks, Int32.Parse(command[1]), Int32.Parse(command[3]), Int32.Parse(command[5]));
        }

        var outputString = "";
        foreach (var stack in stacks)
        {
            outputString += stack[stack.Count - 1];
        }

        Console.WriteLine($"Day Five. Step Two. Output: {outputString}");
    }


    private void moveBoxes(List<List<char>> stacks, int amount, int fromStack, int toStack)
    {
        // Fix indexing issue
        fromStack--;
        toStack--;
        
        for (var i = 0; i < amount; i++)
        {
            stacks[toStack].Add(stacks[fromStack][stacks[fromStack].Count - 1]);
            stacks[fromStack].RemoveAt(stacks[fromStack].Count - 1);
        }
    }
    
    private void moveBoxesMulti(List<List<char>> stacks, int amount, int fromStack, int toStack)
    {
        // Fix indexing issue
        fromStack--;
        toStack--;
        
        for (var i = amount; i > 0; i--)
        {
            stacks[toStack].Add(stacks[fromStack][stacks[fromStack].Count - i]);
            stacks[fromStack].RemoveAt(stacks[fromStack].Count - i);
        }
    }
}