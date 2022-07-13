using ATM;

try
{
    Console.WriteLine("Kullanıcı adını giriniz:");
    string user = Console.ReadLine().TrimEnd().TrimStart();

    bool log = Register.Login(user);
    if (!log)
    {
        Console.WriteLine("Kullanıcı bulunamadı!\nKayıdınızı oluşturuyoruz...");
        Register register = new Register(user);
    }
    start:
    Console.WriteLine("\nHoşgeldin {0}", user);
    Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçin:" + 
        "\nPara çekmek için 1" +
        "\nPara yatırmak için 2" +
        "\nParanızı görmek için 3" +
        "\nGün sonu raporu için 4");
    int firstRes = Convert.ToInt32(Console.ReadLine());
    if(firstRes <= 3)
    {
        switch (firstRes)
        {
            case 1:
                Console.WriteLine("Çekmek istediğiniz miktarı giriniz:");
                double money = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"{money} Çekiliyor..");
                MoneyWorks.Deposit(money, user);
                Console.WriteLine("Para çekme işlemi başarılı");
                break;
            case 2:
                Console.WriteLine("Lütfen yatırmak istediğiniz para miktarını giriniz:");
                double plus = Convert.ToDouble(Console.ReadLine());
                MoneyWorks.AddMoney(plus, user);
                break;
            case 3:
                Console.WriteLine(MoneyWorks.GetMoney(user));
                break;
            case 4:
                Console.WriteLine("\nGün sonu raporu alınıyor...");
                MoneyWorks.EndOfDay();
                break;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine("HATA!! {0}", e.Message);
}

