using System.Collections.Generic;

public static class ListUtility
{
    public static List<T> CloneList<T>(List<T> originalList)
    {
        List<T> clonedList = new List<T>(originalList);
        return clonedList;
    }
}
