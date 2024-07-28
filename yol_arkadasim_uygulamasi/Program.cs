using System;

namespace YolArkadasim
{
    class Program
    {
        
        static void Main(string[] args)
        {
            bool active = true;
            //program çalışma kontrol eğer active false olursa çalışmaz
            while (active)
            {
                string choise = "";
                string name = "";
                int transport;
                bool transportControl;
                string locationOne = "bodrum";
                string locationTwo = "marmaris";
                string locationTree = "çeşme";
                int locationPrice = 0;
                bool control;
                int entryCount = 3;

                Console.WriteLine("Yol Arkadaşıma Hoş Geldiniz!\nİsminizi Giriniz:");
                name = Console.ReadLine();
                Console.WriteLine("-------------------------------------------------");

                do
                {
                    //Kullanıcıya gitmek istediğini lokasyonu soruyoruz
                    Console.WriteLine("Lütfen gitmek istediğiniz lokasyonu seçiniz. (Bodrum/Marmaris/Çeşme)");
                    //Girilen değeri choise değişkenine atıyoruz
                    choise = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("-------------------------------------------");
                    //Kullanıcının verdiğimiz seçeneklerden birini girip girmediğini bir seçenekte tutuyoruz
                    control = (choise == locationOne || choise == locationTwo || choise == locationTree);

                    //3 seçenekten biri seçilmediyse if kontrolüne sokup hata mesajı giriyoruz ve tekrar girmesini istiyoruz
                    //kullanıcının girdiği hatalı girişleri bir değişkende saklayıp 3 hatada programı sonlandırıyoruz

                    if (!control)
                    {
                        Console.WriteLine("Hatalı bir seçim yaptınız. Lütfen tekrar giriniz.");
                        Console.WriteLine();
                        //Yanlış işlem sonucu giriş hakkını düşürüyoruz
                        entryCount--;
                        if (entryCount == 0)
                        {
                            Console.WriteLine("3 kere hatalı işlem girdiniz.\nLütfen daha sonra tekrar deneyiniz.");
                            //Program sonlandırmak için
                            Environment.Exit(0);

                        }
                    }

                    //Girilen lokasyon doğru ise while döngüsü başlatılıyor
                } while (!control);
                {
                    //Kişi sayısını alıyoruz
                    Console.WriteLine("Muhteşem bir seçim! Lütfen rezervasyon için kişi sayısı giriniz:");

                    int numberPeople = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("------------------------------------:");
                    //Seçilen lokasyona göre tatil planlarını yazıyoruz

                    switch (choise)
                    {
                        case "Bodrum":
                            Console.WriteLine($"Harika {name.ToUpper()} !\nGitmek istediğin lokasyon {choise.ToUpper()} .\nYapılabilecek faaileyetler : ----- ");
                            //Fiyat belirleniyor
                            locationPrice = 4000;
                            Console.WriteLine("-----------------------");
                            break;

                        case "Marmaris":
                            Console.WriteLine($"Harika {name.ToUpper()} !\nGitmek istediğin lokasyon {choise.ToUpper()} .\nYapılabilecek faaliyetler : ----- ");
                            //Fiyat belirlniyor
                            locationPrice = 3000;
                            Console.WriteLine("----------------------");
                            break;

                        case "Çeşme":
                            Console.WriteLine($"Harika {name.ToUpper()} !\nGitmek istediğin lokasyon {choise.ToUpper()} . \nYapılabilecek faaliyetler : -----");
                            //Fiyat belirleniyor
                            locationPrice = 5000;
                            Console.WriteLine("----------------------");
                            break;

                        default:
                            Console.WriteLine("Beklenmeyen bir hata oluştu!");
                            Environment.Exit(0);
                            break;

                    }
                    //Tatile hangi ulaşım yolu ile gideceğinizi soruyoruz
                    do
                    {
                        Console.WriteLine("Seçim yaptığınız lokasyona gitmek için hangi ulaşım türünü tercih edersiniz? Lütfen seçimi rakam ile yapınız./n(1) Kara Yolu (2) Hava Yolu");

                        //Girilen değeri değişkene atıyoruz
                        string vote = Console.ReadLine();
                        Console.WriteLine("------------------------------");
                        //string türünden tryParse ile transport değişkenine tam sayı olarak atıyoruz
                        transportControl = int.TryParse(vote, out transport) && (transport == 1 || transport == 2);

                    } while (!transportControl);
                    //Kullanılan değere karşı metinsel ifadesi belirlendi
                    string transportType = transport == 1 ? "Kara Yolu" : "Hava Yolu";
                    int transportPrice = transport == 1 ? 1500 : 4000;
                    //Ulaşım fiyatı hesaplamak için: ulaşım fiyatı * kişi sayısı
                    int transportTotal = transportPrice * numberPeople;
                    //Konum fiyatı * kişi sayısı
                    int locationTotal = locationPrice * numberPeople;
                    //Toplam fiyat
                    int totalPrice = transportTotal + locationTotal;

                    //Kullanıcı bilgi sunumları

                    Console.WriteLine($"Tüm seçimleri tamamladın {name} ! Bilgiler hazırlanıyor.Fiyat kişi sayısı, gideceğiniz lokasyon ve ulaşım tercihine göre hesaplanmıştır."); ;
                    Console.WriteLine($"Tatil için ödemeniz gereken toplam miktar : {totalPrice} 'TL. Tatil detayları aşağıda bulunmaktadır.");
                    Console.WriteLine("Seçilen lokasyon {choise.ToUpper()}  ");
                    Console.WriteLine("----------------------------------");

                    //Kullanıcı yeni bir tatil yapmak istiyor mu
                    Console.WriteLine("Yeni bir tatil planı oluşturmak ister misiniz? (Evet/Hayır");
                    string continueChoice = Console.ReadLine().Trim().ToUpper();
                    if (continueChoice != "Evet")
                    {
                        Console.WriteLine("İyi günler!");
                        break;
                    }

                    
                }


            }
        }
    }
}