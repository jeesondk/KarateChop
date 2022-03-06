using System.ComponentModel.Design.Serialization;

namespace KarateChop;

public class KarateChop
{
    private int _pos = 0;

    public int ChopChop(int chopValue, int[] array)
    {
        var isValid = ValidateArray(array);
        if (!isValid)
            return -1;

        var initChopPos = ChopPos(array.Length);
        
        _pos = initChopPos;
        
        var hasMatch = DoChop(chopValue, array);
        if (hasMatch)
            return _pos;
        else
            return -1;
    }

    private bool DoChop(int chopValue, int[] array)
    {
        var valueAtChopPos = array[ChopPos(array.Length)];

        while (array.Length > 1)
        {
            var arraySection = valueAtChopPos > chopValue ? ChopHigh(array) : ChopLow(array);
            DoChop(chopValue, arraySection);
        }

        return CheckValue(chopValue, array);
    }

    private bool ValidateArray(int[] array)
    {
        return array != Array.Empty<int>();
    }

    private int[] ChopLow(int[] array)
    {
        var tmpPos = ChopPos(array.Length);
        var lowSection = Array.Empty<int>();
        Array.Copy(array, lowSection, tmpPos);
        _pos--;
        
        return lowSection;
    }
    
    private int[] ChopHigh(int[] array)
    {
        var tmpPos = ChopPos(array.Length);
        var highSection = Array.Empty<int>();
        Array.Copy(array, tmpPos, highSection, 0, array.Length);
        _pos++;
        
        return highSection;
    }

    private int ChopPos(int arrayLength)
    {
        return arrayLength / 2;
    }

    private bool CheckValue(int chopValue, int[] arraySection)
    {
        return arraySection[0] == chopValue;
    }
}