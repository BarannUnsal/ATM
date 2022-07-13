namespace ATM
{
    public class MoneyWorks
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ATMParaIslemleri.txt";        
      
        public static string GetMoney(string username)
        {
            double money = 0;
            string res = "";

            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                    switch (sr.ReadLine().TrimEnd().TrimStart())
                    {
                        case "1":
                            res += sr.ReadLine();
                            break;
                        default:
                            break;
                    }
            }
            res = String.Format($"\nHesabınızdaki para: " +
                $"\n{username} = {money}");
            return res;
        }

        public static void AddMoney(double money, string username)
        {
            if (!File.Exists(path))
                File.Create(path).Close();
            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine($"\n{money} yatırılan para. {username} / {DateTime.UtcNow.ToShortDateString()}");
            }
        }

        public static void Deposit(double money, string username)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine($"\n{money} çekilen para. {username} / {DateTime.UtcNow.ToShortDateString()}");
            }
        }

        public static void EndOfDay()
        {
            List<string> list = Log.GetLogs();

            for (int i = list.Count - 1; i > 0; i--)
            {
                DateTime dt = Convert.ToDateTime((list[i].Split(list[i][list[i].IndexOf(' ')]))[0]);
                if (dt.Day == DateTime.Now.Day && dt.Month == DateTime.Now.Month)
                    Console.WriteLine(list[i]);
            }
        }       
    }
    class Log
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ATMParaIslemleri.txt";
        public static List<string> GetLogs()
        {
            fileControl();
            List<string> list = new List<string>();

            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    while (!sr.EndOfStream)
                    {
                        string satir = sr.ReadLine();
                        if (!String.IsNullOrEmpty(satir))
                            list.Add(satir.TrimEnd().TrimStart());
                    }
                }
                catch { }
            }
            return list;
        }
        static void fileControl()
        {
            if (!File.Exists(path))
                File.Create(path).Close();
        }
    }
}
