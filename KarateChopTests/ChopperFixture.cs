using System;
using System.Collections.Generic;

namespace KarateChopTests;

public class ChopperFixture: IDisposable
{

    public Dictionary<int, Tuple<int, int[]>> TestCases { get; set; }

    public ChopperFixture()
    {
        TestCases = new Dictionary<int, Tuple<int, int[]>>();
        InitializeTestCases();
    }

    private void InitializeTestCases()
    {
        TestCases.Add(1, new Tuple<int, int[]>(3, Array.Empty<int>()));
        TestCases.Add(2, new Tuple<int, int[]>(3, new [] {1}));
        TestCases.Add(3, new Tuple<int, int[]>(1, new [] {1}));
        
        TestCases.Add(4, new Tuple<int, int[]>(1, new [] {1, 3, 5}));
        TestCases.Add(5, new Tuple<int, int[]>(3, new [] {1, 3, 5}));
        TestCases.Add(6, new Tuple<int, int[]>(5, new [] {1, 3, 5}));
        TestCases.Add(7, new Tuple<int, int[]>(0, new [] {1, 3, 5}));
        TestCases.Add(8, new Tuple<int, int[]>(2, new [] {1, 3, 5}));
        TestCases.Add(9, new Tuple<int, int[]>(4, new [] {1, 3, 5}));
        TestCases.Add(10, new Tuple<int, int[]>(6, new [] {1, 3, 5}));
        
        TestCases.Add(11, new Tuple<int, int[]>(1, new [] {1, 3, 5, 7}));
        TestCases.Add(12, new Tuple<int, int[]>(3, new [] {1, 3, 5, 7}));
        TestCases.Add(13, new Tuple<int, int[]>(5, new [] {1, 3, 5, 7}));
        TestCases.Add(14, new Tuple<int, int[]>(7, new [] {1, 3, 5, 7}));
        TestCases.Add(15, new Tuple<int, int[]>(0, new [] {1, 3, 5, 7}));
        TestCases.Add(16, new Tuple<int, int[]>(2, new [] {1, 3, 5, 7}));
        TestCases.Add(17, new Tuple<int, int[]>(4, new [] {1, 3, 5, 7}));
        TestCases.Add(18, new Tuple<int, int[]>(6, new [] {1, 3, 5, 7}));
        TestCases.Add(19, new Tuple<int, int[]>(8, new [] {1, 3, 5, 7}));
        
    }

    public void Dispose()
    { }
}