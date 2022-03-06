namespace KarateChop;

public class KarateChop
{
    private int _pos = 0;
    private bool _break = false;
    private int[] _sourceArray;
    private int _chopValue;

    public int ChopChop(int chopValue, int[] array)
    {
        var isValid = ValidateArray(array);
        if (!isValid)
            return -1;

        _sourceArray = array;
        _chopValue = chopValue;
        _pos = ChopPos(array.Length);
        
        var hasMatch = DoChop(array);
        if (hasMatch)
            return _pos;
        else
            return -1;
    }

    private bool DoChop(int[] array)
    {
        var chopPos = ChopPos(array.Length);
        var valueAtChopPos = array[chopPos];

        if (valueAtChopPos == _chopValue)
        {
            _break = true;
        }
            
        if (array.Length <= 1)
            _break = true;
        
        while (!_break)
        {
            var arraySection = valueAtChopPos <= _chopValue ? ChopHigh(array) : ChopLow(array);
            DoChop(arraySection);
        }

        return CheckValue();
    }

    private bool ValidateArray(int[] array)
    {
        return array != Array.Empty<int>();
    }

    private int[] ChopLow(int[] array)
    {
        var lowBounds = array.Length / 2;
        var tmpPos = ChopPos(array.Length);
        var lowSection = new int[lowBounds];
        Array.Copy(array, lowSection, tmpPos);
        _pos--;
        
        return lowSection;
    }
    
    private int[] ChopHigh(int[] array)
    {
        var highBounds = array.Length % 2 == 0 ? array.Length / 2 : array.Length / 2 + 1;
        var highSection = new int[array.Length - highBounds];
        Array.Copy(array, highBounds, highSection, 0, array.Length - highBounds);
        
        _pos += (highBounds-1);
        
        return highSection;
    }

    private int ChopPos(int arrayLength)
    {
        return arrayLength / 2;
    }

    private bool CheckValue()
    {
        return (_sourceArray[_pos] == _chopValue);
    }
}