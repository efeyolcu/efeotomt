using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFEOTOMAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hak = 2;
            double toplam = 0;
            string adminPass = "admin";
            string[] urunler = { "Kola", "Bisküvi", "Çikolata" };
            double[] urunfiyat = { 7, 3, 2 };

                          ANAMENU:
            Console.Clear();
            Console.Write("**********GİRİŞ SEÇENEKLERİ**********\n\t1 Admin Girişi\n\t2 Kullanıcı Girişi\n\t3 Çıkış\nSeçim: ");
            string girisSecim = Console.ReadLine();

            if (girisSecim == "1") 
            {
                while (hak >= 0) 
                {
                    Console.Write("ADMIN SIFRE: ");
                    string adminSifre = Console.ReadLine();

                    if (adminSifre == adminPass) 
                    {
                        Console.Clear();
                        Console.Write("1 Ürün Güncelle\n2 Fiyat Güncelle\n3 Çıkış\nLütfen yapmak istediğiniz işlemi seçiniz: ");
                        string secim = Console.ReadLine();
                        if (secim == "1")
                        {
                            Console.Clear();
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine("{0}-{1} ({2} TL)", (i + 1), urunler[i], urunfiyat[i]);
                            }
                            Console.Write("GÜNCEL ÜRÜN : ");
                            int degisim = Convert.ToInt32(Console.ReadLine());
                            Console.Write("YENI ÜRÜN: ");
                            string yeniurun = Console.ReadLine();
                            urunler[degisim - 1] = yeniurun;
                            Console.Clear();
                            Console.WriteLine("DEĞİŞİM GERÇEKLEŞTİ.");
                            goto ANAMENU;

                        }
                        else if (secim == "2")
                        {
                            Console.Clear();
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine("{0}-{1} ({2} TL)", (i + 1), urunler[i], urunfiyat[i]);
                            }
                            Console.Write("FİYATI GÜNCELLENECEK ÜRÜN: ");
                            int degisim = Convert.ToInt32(Console.ReadLine());
                            Console.Write("ÜRÜNÜN YENİ FİYATINI GİRİNİZ: ");
                            double yenifiyat = Convert.ToDouble(Console.ReadLine());
                            urunfiyat[degisim - 1] = yenifiyat;
                            Console.Clear();
                            Console.WriteLine("DEĞİŞİM GERÇEKLEŞTİ.");
                            goto ANAMENU;
                        }
                        else if (secim == "3")
                        {
                            Console.WriteLine("ÇIKIŞ BAŞARILI.");
                            break;
                        }
                    }
                    else if (hak == 0)
                    {
                        Console.Write("ÇIKIŞ BAŞARILI.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"ŞİFRE YANLIŞ.KALAN DENEME: {hak}");
                    }
                    hak--;
                }
            }
           
            else if (girisSecim == "2") 
            {
            BAKIYEGIRIS:

                Console.Write("BAKİYENİZİ GİRİNİZ:");
                double bakiye = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                for (int i = 0; i < urunler.Length; i++)
                {
                    Console.WriteLine("{0}-{1} {2} TL", (i + 1), urunler[i], urunfiyat[i]);
                }
                Console.Write("ALINACAK ÜRÜN: ");
                int urunsecim = Convert.ToInt32(Console.ReadLine());

                if (bakiye < urunfiyat[urunsecim - 1])
                {
                BAKIYEMENU:
                    Console.Clear();
                    Console.WriteLine("YETERSİZ BAKİYE \n1 PARA EKLEME \n2 PARA İADEİ");
                    string bakiyesecim = Console.ReadLine();

                    if (bakiyesecim == "1")
                    {
                        goto BAKIYEGIRIS;
                    }
                    else if (bakiyesecim == "2")
                    {
                        Console.Clear();
                        Console.WriteLine($"Para iadesi yapılmıştır. İade edilen tutar: {bakiye} TL");
                        Console.WriteLine("ÇIKIŞ GERÇEKLESTİ");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("BAŞARISIZ GİRİŞ DENEMESİ");
                        goto BAKIYEMENU;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Alınan Ürün: {urunler[urunsecim - 1]}\nPara Üstü: {bakiye - (urunfiyat[urunsecim - 1])}\nİyi Günler Dileriz...");
                }

            }
            else if (girisSecim == "3")
            {
                Console.WriteLine("ÇIKIŞ GERÇEKLEŞTİ...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                goto ANAMENU;
            }

            Console.ReadLine();
        }
    }
}
