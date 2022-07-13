namespace ATM
{
    public class Register
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\atmloging.txt";
        public Register(string username)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            using(StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine($"{username} / {DateTime.UtcNow.ToShortDateString()}");
            }
        }
        public static bool Login(string username)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                    if (sr.ReadLine().Contains(username))
                        return true;
                return false;
            }
        }
    }
}
