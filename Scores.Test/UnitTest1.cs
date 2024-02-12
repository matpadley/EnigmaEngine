namespace Scores.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var score = new Score("6.9");
        
        Assert.AreEqual(score.Name, "6.9");
        Assert.AreEqual(score.Points, 0);
        
        score.AddToScore(4);
        
        Assert.AreEqual(score.Points, 4);
        
    }
}