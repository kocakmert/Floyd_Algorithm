using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ag
{
    class Program
    {
        public static string baslangic;
        public static string bitis;
        public static int x = 0, y = 0, z = 0;
        static void Main(string[] args)
        {
            //FLOYD ALGORİTMASI .....
            Console.WriteLine("*******************----- FLOYD ALGORİTMASI -----*******************");
            Console.WriteLine("");
            //Kullanıcıdan Değerler Alınması...
            Console.WriteLine("GİREBİLECEĞİNİZ NOKTALAR :**__S-E-C-H-F-D-B-G-A-B__**");
            Console.WriteLine("");
            Console.Write("Başlangıç Noktanızı Giriniz:");
            baslangic = Console.ReadLine();  //Başlangıç Noktası Kullanıcadan alındı.
            baslangic = baslangic.ToUpper();
            deger_toSayibaslangic();  // geri dönüş parametresi x değişkeni...
            Console.Write("Gitmek İstediğiniz Noktayı Giriniz:");
            bitis = Console.ReadLine();//Bitiş Noktası Kullanıcadan alındı.
            bitis = bitis.ToUpper();
            deger_toSayibitis();   //geri dönüş parametresi y değişkeni...
            int inf = 1000;
            int[,] S = new int[9, 9];
            int[,] D ={
                    {0,4,inf,5,inf,inf,2,inf,inf},
                    {4,0,inf,inf,inf,3,1,5,inf},
                    {inf,inf,0,2,1,3,inf,inf,3},
                    {5,inf,2,0,inf,2,1,inf,inf},
                    {inf,inf,1,inf,0,inf,inf,1,2},
                    {inf,3,3,2,inf,0,inf,2,inf},
                    {2,1,inf,1,inf,inf,0,inf,inf},
                    {inf,5,inf,inf,1,2,inf,0,1},
                    {inf,inf,3,inf,2,inf,inf,1,0}
                };
            //
            //S Matrisinin Oluşturulması...
            for (int i = 0; i < 9; i++)
            {
                for (int t = 0; t < 9; t++)
                {

                    if (i == t)
                    {
                        S[i, t] = 0; //Diagonel Eşitlikte sıfır atandı.
                    }
                    else
                    {
                        S[i, t] = t + 1;
                    }
                }
            }
            //Floyd Algoritması
            for (int k = 0; k < 9; k++)
            {
                for (int u = 0; u < 9; u++)
                {
                    for (int v = 0; v < 9; v++)
                    {
                        if (D[u, v] > D[u, k] + D[k, v])
                        {
                            D[u, v] = D[u, k] + D[k, v];
                            //S[u, v] = S[u, k];
                            S[u, v] = k + 1;
                        }
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("********* --- En Kısa Mesafe İçin Uzaklık Matrisi --- *********");
            String[] points = { "A", "B", "C", "D", "E", "F", "G", "H", "S" };
            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("  " + points[i]); Console.Write("\t");
                }
                else
                {
                    Console.Write("{0}\t", points[i]);
                }
            }
            Console.WriteLine("");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(points[i] + " ");
                    }

                    Console.Write("{0}\t", D[i, j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("**------------ S Matrisi(Yol Matrisi) --------------**");
            //S Matrisinin  sayısal noktalardan harfe dönüştürülmesi...
            for (int i = 0; i < points.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("  " + points[i]); Console.Write("\t");
                }
                else
                {
                    Console.Write("{0}\t", points[i]);
                }
            }
            Console.WriteLine("");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(points[i] + " ");
                    }
                    // Console.Write(S[i, j].ToString().PadLeft(7));  //İstenirse sayısal olarakta gösterilebilir.
                    if (S[i, j] == 1)
                        Console.Write("{0}\t", "A");
                    else if (S[i, j] == 2)
                        Console.Write("{0}\t", "B");
                    else if (S[i, j] == 3)
                        Console.Write("{0}\t", "C");
                    else if (S[i, j] == 4)
                        Console.Write("{0}\t", "D");
                    else if (S[i, j] == 5)
                        Console.Write("{0}\t", "E");
                    else if (S[i, j] == 6)
                        Console.Write("{0}\t", "F");
                    else if (S[i, j] == 7)
                        Console.Write("{0}\t", "G");
                    else if (S[i, j] == 8)
                        Console.Write("{0}\t", "H");
                    else if (S[i, j] == 9)
                        Console.Write("{0}\t", "S");
                    else
                        Console.Write("{0}\t", "0");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
            Console.WriteLine("**-------------------------------------------------------------**");
            List<int> path = new List<int>();  //yol , değerleri listede tutulacak.
            int sayac = 0;
            string value = "";
            int bitirme_parametresi = 1;
            string devam = "E";
            while (devam == "E")
            {
                path.Add(x); //Başlangıc noktası
                path.Add(y); //Bitiş noktası listeye atıldı.

                Console.WriteLine("Gidilmek İstenen En Kısa Mesafe Uzunluğu: " + D[x - 1, y - 1]);
                while (bitirme_parametresi == 1)
                {
                    int eleman_sayi = path.Count();  //Liste içindeki eleman sayısı
                    for (int i = 0; i < eleman_sayi; i++)
                    {
                        if (S[path[i] - 1, path[i + 1] - 1] == path[i + 1] && i == (eleman_sayi - 2))  //S matrisindeki elemanla ,listedeki eleman aynıysa ve listedeki tüm elemanlar incelendiyse buraya girer.
                        {
                            bitirme_parametresi = 0;  // 0 olursa döngüden çıkılacak,İşlem Bitmiş olacak...

                            break;

                        }
                        else if (S[path[i] - 1, path[i + 1] - 1] != path[i + 1]) //Listenin içindeki elemanlarla S matrisindeki eleman karşılaştırılıyor...
                        {

                            path.Insert(i + 1, S[path[i] - 1, path[i + 1] - 1]);  //S matrisinin içerisindeki deger listeye eklendi...
                            break;
                        }
                    }
                }
                sayac = 0;
                int lenght = path.Count();  //Ekrana bastırmak için listedeki değer yeniden alınır...
                Console.WriteLine("");
                Console.WriteLine("**-------------------------------------------------------------**");
                Console.Write("Gitmek İstediğiniz Yer İçin İzlemeniz Gereken Yol :");
                while (sayac < lenght)
                {
                    if (path[sayac] == 1)
                        value = "A";
                    else if (path[sayac] == 2)
                        value = "B";
                    else if (path[sayac] == 3)
                        value = "C";
                    else if (path[sayac] == 4)
                        value = "D";
                    else if (path[sayac] == 5)
                        value = "E";
                    else if (path[sayac] == 6)
                        value = "F";
                    else if (path[sayac] == 7)
                        value = "G";
                    else if (path[sayac] == 8)
                        value = "H";
                    else if (path[sayac] == 9)
                        value = "S";
                    sayac++;
                    Console.Write("->" + value);
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("**-------------------------------------------------------------**");
                Console.Write("Başka İşlem Yapmak İster Misiniz(E/H)");
                devam = Console.ReadLine();
                devam = devam.ToUpper();
                if (devam == "E")
                {
                    //YeNİDEN İŞLEM İÇİN DEĞERLER SIFIRLANIR....
                    path.Clear();  //Listenin içi sıfırlanır
                    Console.WriteLine("");
                    Console.WriteLine("**-------------------------------------------------------------**");
                    Console.Write("Başlangıç Noktanızı Giriniz:");
                    baslangic = Console.ReadLine();  //Başlangıç Noktası Kullanıcadan alındı.
                    baslangic = baslangic.ToUpper();
                    deger_toSayibaslangic();
                    Console.Write("Gitmek İstediğiniz Noktayı Giriniz:");
                    bitis = Console.ReadLine();//Bitiş Noktası Kullanıcadan alındı.
                    bitis = bitis.ToUpper();
                    deger_toSayibitis();
                    bitirme_parametresi = 1; //Bitirme parametresi sıfırlandı...
                }
            }
            Console.ReadKey();
        }
        public static int deger_toSayibaslangic()
        {
            if (baslangic == "A") { x = 1; }
            else if (baslangic == "B") { x = 2; }
            else if (baslangic == "C") { x = 3; }
            else if (baslangic == "D") { x = 4; }
            else if (baslangic == "E") { x = 5; }
            else if (baslangic == "F") { x = 6; }
            else if (baslangic == "G") { x = 7; }
            else if (baslangic == "H") { x = 8; }
            else if (baslangic == "S") { x = 9; }
            return x;
        }
        public static int deger_toSayibitis()
        {
            //Bitiş Noktasının Belirlenmesi
            if (bitis == "A")
                y = 1;
            else if (bitis == "B")
                y = 2;
            else if (bitis == "C")
                y = 3;
            else if (bitis == "D")
                y = 4;
            else if (bitis == "E")
                y = 5;
            else if (bitis == "F")
                y = 6;
            else if (bitis == "G")
                y = 7;
            else if (bitis == "H")
                y = 8;
            else if (bitis == "S")
                y = 9;
            return y;
        }
    }
}
