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
        
    }
}