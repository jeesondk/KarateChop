using System.Reflection.Metadata.Ecma335;

namespace KarateChop;

public class KarateChop
{
    public int ChopChop(int chopValue, int[] array)
    {
        if (array == Array.Empty<int>())
        {
            return -1;
        }

        if (array.Length <= 1) return checkForChopValue(chopValue, array);
        
        var currentArray = splitArray(chopValue, array);
        
        if (currentArray.Length != 1) ChopChop(chopValue, currentArray);
        
        return checkForChopValue(chopValue, currentArray);
    }

    
    private int checkForChopValue(int chopValue, int[] array)
    {
        return chopValue == array[0] ? Array.IndexOf(array, chopValue) : -1;
    }

    private int[] splitArray(int chopValue, int[] array)
    {
        var lowBounds = array.Length / 2;
        var highBounds = array.Length % 2 == 0 ? array.Length / 2 : array.Length / 2 + 1;

        var midpoint = array.Length % 2 == 0 ? 0: (array.Length / 2 + 1);

        if (array.Length % 2 != 0 && array.Length > 1)
        {
            if(array[midpoint] == chopValue)
                return new [] {array[midpoint]};
        }
            
            
        
        var lowSplit = new int[lowBounds];
        var highSplit = new int[array.Length - highBounds];
        
        Array.Copy(array, 0, lowSplit, 0, lowBounds);
        Array.Copy(array, highBounds, highSplit, 0, array.Length-highBounds);

        return arraySelector(chopValue, lowSplit, highSplit);
    }

    private int[] arraySelector(int chopValue, int[] lowSplit, int[] highSplit)
    {
        return lowSplit[^1] <= chopValue ? highSplit : lowSplit;
    }
}