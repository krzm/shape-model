namespace Shape.Model;

public class InfoContext
{
    public Dictionary<string, int> Count { get; set; }

    public InfoContext()
    {
        Count = new Dictionary<string, int>();
    }

    public void Add(string key)
    {
        if (!Count.ContainsKey(key))
            Count.Add(key, 1);
        else Count[key]++;
    }

    public int Get(string key)
    {
        if (!Count.ContainsKey(key))
            return -1;
        else return Count[key];
    }
}