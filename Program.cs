var saved = new HashSet<string>();
while (saved.Count < 8)
{
    RGB color = new RGB(0, 0, 0);
    //Поток 1:
    var task1 = Task.Run(() =>
    {
        color.SetColor(255, 255, 255);
    });
    //Поток 2:
    var task2 = Task.Run(() =>
    {
        var line = $"{color.R}, {color.G}, {color.B}";
        if (!saved.Contains(line))
        {
            saved.Add(line);
            Console.WriteLine(line);
        }
    });
    Task.WaitAll(task1, task2);
}

struct RGB
{
    public byte R, G, B;

    public RGB(byte r, byte g, byte b)
    {
        (R, G, B) = (r, g, b);
    }

    public void SetColor(byte r, byte g, byte b)
    {
        (R, G, B) = (r, g, b);
    }
}
