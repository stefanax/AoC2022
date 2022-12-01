using System.Collections;

namespace AoC2022;

public class Day1
{
    private InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(1, false);
        var inputList = _inputFiles.SplitString(input);

        var maxCalories = 0;
        var currentCalories = 0;

        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                if (currentCalories > maxCalories) maxCalories = currentCalories;
                currentCalories = 0;
            }
            else
            {
                currentCalories += Int32.Parse(inputListItem);    
            }
        }
        
        if (currentCalories > maxCalories) maxCalories = currentCalories;  // Just in case the last item is the largest...
        
        Console.WriteLine($"Step One Max Cal: {maxCalories}");
    }

    public void Step2()
    {
        var input = _inputFiles.ReadInputFileForDay(1, false);
        var inputList = _inputFiles.SplitString(input);

        var maxCalories = new List<int>() { 0, 0, 0 };
        var currentCalories = 0;

        foreach (var inputListItem in inputList)
        {
            if (inputListItem == "")
            {
                CheckListValues(maxCalories, currentCalories);
                currentCalories = 0;
            }
            else
            {
                currentCalories += Int32.Parse(inputListItem);    
            }
        }
        
        CheckListValues(maxCalories, currentCalories);  // Just in case the last item is the largest...

        var totalMaxCalories = maxCalories[0] + maxCalories[1] + maxCalories[2];
        Console.WriteLine($"Step Two Total Max Cal: {totalMaxCalories}");
    }

    public void CheckListValues(List<int> list, int value)
    {
        if (value >= list[0])
        {
            list[2] = list[1];
            list[1] = list[0];
            list[0] = value;
        } else if (value >= list[1])
        {
            list[2] = list[1];
            list[1] = value;
        } else if (value >= list[2])
        {
            list[2] = value;
        }
    }
}