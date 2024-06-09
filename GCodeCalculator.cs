using System.Text;

public record GCodeCalculator(List<List<bool>> Table)
{
    public string GCodes()
    {
        var sb = new StringBuilder();
        for (int y = 0; y < Table.Count; y += 1)
        {
            var row = Table[y];
            for (int x = 0; x < row.Count; x += 1)
            {
                if (Table[y][x])
                {
                    sb.AppendLine("G00 X" + x + "Y" + y + "Z10");
                    sb.AppendLine("G00 X" + x + "Y" + y + "Z0");
                    sb.AppendLine("G00 X" + x + "Y" + y + "Z10");
                }
            }
        }
        sb.AppendLine("G00 X0Y0Z10");

        return sb.ToString();
    }
}