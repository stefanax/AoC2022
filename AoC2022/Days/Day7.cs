namespace AoC2022;

public class Day7
{
    private class FileSystemObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }
        
        public FileSystemObject? Parent { get; set; }
        public List<FileSystemObject> Children { get; set; }

        public FileSystemObject(string name, string type, int? size, FileSystemObject? parent)
        {
            Name = name;
            Type = type;
            Size = size;
            Parent = parent;
            Children = new List<FileSystemObject>();
        }
    }

    private readonly InputFiles _inputFiles = new InputFiles();

    public void Step1()
    {
        var input = _inputFiles.ReadInputFileForDay(7, false);
        var inputList = _inputFiles.SplitString(input);

        var rootFolder = new FileSystemObject("/", "dir", null, null);

        var currentFolder = rootFolder;
        
        foreach (var inputListItem in inputList)
        {
            if (inputListItem[0] == '$')
            {
                var command = inputListItem.Split(" ");
                switch (command[1])
                {
                    case "cd":
                        if (command[2] == "/")
                        {
                            currentFolder = rootFolder;
                        }
                        else if (command[2] == "..")
                        {
                            currentFolder = currentFolder.Parent;
                        }
                        else
                        {
                            foreach (var child in currentFolder.Children)
                            {
                                if (child.Type == "dir" && child.Name == command[2])
                                {
                                    currentFolder = child;
                                    break;
                                }
                            }
                        }

                        break;
                    case "ls":
                        //NOTE: Not really anything to do...
                        break;
                    default:
                        throw new Exception("How the hell did we get here?");
                }
            }
            else
            {
                var fileListItem = inputListItem.Split(" ");
                if (fileListItem[0] == "dir")
                {
                    var newFolder = new FileSystemObject(fileListItem[1], "dir", null, currentFolder);
                    currentFolder.Children.Add(newFolder);
                }
                else
                {
                    var newFile = new FileSystemObject(fileListItem[1], "file", Int32.Parse(fileListItem[0]), currentFolder);
                    currentFolder.Children.Add(newFile);
                }
            }
        }
        
        CalculateFolderSize(rootFolder);
        
        var totalSize = 0;
        totalSize = GetFolderSize(rootFolder, 100000);
        Console.WriteLine($"Day Seven. Step One. Total size: {totalSize}");
    }
    
    public void Step2()
    {
        
        var input = _inputFiles.ReadInputFileForDay(7, false);
        var inputList = _inputFiles.SplitString(input);

        var rootFolder = new FileSystemObject("/", "dir", null, null);

        var currentFolder = rootFolder;
        
        foreach (var inputListItem in inputList)
        {
            if (inputListItem[0] == '$')
            {
                var command = inputListItem.Split(" ");
                switch (command[1])
                {
                    case "cd":
                        if (command[2] == "/")
                        {
                            currentFolder = rootFolder;
                        }
                        else if (command[2] == "..")
                        {
                            currentFolder = currentFolder.Parent;
                        }
                        else
                        {
                            foreach (var child in currentFolder.Children)
                            {
                                if (child.Type == "dir" && child.Name == command[2])
                                {
                                    currentFolder = child;
                                    break;
                                }
                            }
                        }

                        break;
                    case "ls":
                        //NOTE: Not really anything to do...
                        break;
                    default:
                        throw new Exception("How the hell did we get here?");
                }
            }
            else
            {
                var fileListItem = inputListItem.Split(" ");
                if (fileListItem[0] == "dir")
                {
                    var newFolder = new FileSystemObject(fileListItem[1], "dir", null, currentFolder);
                    currentFolder.Children.Add(newFolder);
                }
                else
                {
                    var newFile = new FileSystemObject(fileListItem[1], "file", Int32.Parse(fileListItem[0]), currentFolder);
                    currentFolder.Children.Add(newFile);
                }
            }
        }
        
        CalculateFolderSize(rootFolder);
        
        var largestDeletionSize = 0;
        var sizeNeeded = 30000000 - (70000000 - rootFolder.Size ?? 0);
        largestDeletionSize = GetSizeToBeDeleted(rootFolder, sizeNeeded);
        Console.WriteLine($"Day Seven. Step Two. Largest size: {largestDeletionSize}");
    }

    private void CalculateFolderSize(FileSystemObject folder)
    {
        var totalSize = 0;

        foreach (var folderChild in folder.Children)
        {
            if (folderChild.Type == "dir")
            {
                CalculateFolderSize(folderChild);
            }

            totalSize += folderChild.Size ?? 0;
        }

        folder.Size = totalSize;
    }

    private int GetFolderSize(FileSystemObject folder, int limit)
    {
        var totalSize = folder.Size ?? 0;

        if (totalSize > limit) totalSize = 0;

        foreach (var folderChild in folder.Children)
        {
            if (folderChild.Type == "file") continue;
            totalSize += GetFolderSize(folderChild, limit);
        }

        return totalSize;
    }

    private int GetSizeToBeDeleted(FileSystemObject folder, int minimumSizeNeeded)
    {
        var size = 0;
        if (folder.Size > minimumSizeNeeded) size = folder.Size ?? 0;
        foreach (var folderChild in folder.Children)
        {
            if (folderChild.Type == "file") continue;
            var childSize = GetSizeToBeDeleted(folderChild, minimumSizeNeeded);
            if (childSize > minimumSizeNeeded && childSize < size) size = childSize;
        }

        return size;
    }
}