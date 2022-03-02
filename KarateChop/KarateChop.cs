using System.Reflection.Metadata.Ecma335;

namespace KarateChop;

public class KarateChop
{
    private int cursor = 0;
    
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
        var result = chopValue == array[0] ? cursor : -1;
        return result;
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
        var isInLowSplit = lowSplit[^1] >= chopValue;

        if (isInLowSplit)
        {
            return lowSplit;
        }
        else
        {
            cursor += lowSplit.Length + 1;
            return highSplit;
        }
        
    }
}