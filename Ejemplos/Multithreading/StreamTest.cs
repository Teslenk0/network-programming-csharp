using System.Text;

class StreamTest
{
    public static void OldMain()
    {

        string path = @"c:\temp\MyStream.txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = File.Create(path))
        {
            AddText(fs, "This is some text");
            AddText(fs, "This is wqeq text");
            AddText(fs, "This is dqwdggrg text");
            AddText(fs, "This is 123123 text");

            for (int i = 1; i < 120; i++)
            {
                AddText(fs, Convert.ToChar(i).ToString());
            }
        }

        using (FileStream fs = File.OpenRead(path))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }
    }

    public static void AddText(FileStream fs, string value)
    {
        if (fs.CanWrite)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);

            fs.Write(info, 0, info.Length);
        }
    }
}