// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Score(string name)
{
    public string Name { get; set; } = name;
    public int Points { get; set; } = 0;

    public void AddToScore(int points)
    {
        Points += points;
    }
}