using System;
using Xunit;
using FluentAssertions;

namespace KarateChopTests;

public class KarateChopTests: IClassFixture<ChopperFixture>
{
    private readonly ChopperFixture _fixture;

    public KarateChopTests(ChopperFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Theory]
    [InlineData(1, -1)]
    [InlineData(2, -1)]
    [InlineData(3, 0)]
    
    [InlineData(4, 0)]
    [InlineData(5, 1)]
    [InlineData(6, 2)]
    [InlineData(7, -1)]
    [InlineData(8, -1)]
    [InlineData(9, -1)]
    [InlineData(10, -1)]
    
    [InlineData(11, 0)]
    [InlineData(12, 2)]
    [InlineData(13, 2)]
    [InlineData(14, 3)]
    [InlineData(15, -1)]
    [InlineData(16, -1)]
    [InlineData(17, -1)]
    [InlineData(18, -1)]
    [InlineData(19, -1)]
    public void KarateChopTest(int testCaseId, int expectedResult)
    {
        var karateChop = new KarateChop.KarateChop();
        var (chopValue, array) = _fixture.TestCases[testCaseId];
        karateChop
            .ChopChop(chopValue, array)
            .Should()
            .Be(expectedResult);
    }
}