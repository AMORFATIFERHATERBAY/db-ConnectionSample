using System;
using System.Linq;
using Npgsql;

namespace Version
{
    enum Islemler : byte
    {
        Kaydet = 1,
        Goruntule = 2,
        Sıl = 3,
        Guncelle = 4,
        Cıkıs = 5
    }
    class Program
    {
        public static void Kaydet(int id, string ad, string soyad, string sehir, int bakiye)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();
            NpgsqlCommand comd = new NpgsqlCommand("insert into musteri (id,ad,soyad,sehir,bakiye) values ('" + id.ToString() + "','" + ad.ToString() + "','" + soyad.ToString() + "','" + sehir.ToString() + "','" + bakiye.ToString() + "') ", conn);
            comd.ExecuteNonQuery();
            conn.Close();
        }
        public static void Main(string[] args)
        {
            Console.WriteLine();
            byte secim = 0;


            do
            {
                Console.Clear();
                foreach (var e in Enum.GetValues(typeof(Islemler)))
                {
                    Console.WriteLine(string.Format("{0,-10} = {1}", e.ToString(), (byte)e));

                }

                Console.Write("\n-->İşleminizi seçiniz :");
                secim = Convert.ToByte(Console.ReadLine());
                Console.WriteLine();

                if (secim == 1)
                {
                    // Console.Clear();
                    Console.WriteLine("\n*************************************");
                    Console.WriteLine("****** Müşteri Kayıt Bilgileri ******");
                    Console.WriteLine("*************************************\n");
                    Console.Write("-> Kişi no   :");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("-> Adınız    :");
                    string ad = Console.ReadLine();

                    Console.Write("-> Soyadınız :");
                    string soyad = Console.ReadLine();

                    Console.Write("-> İliniz    :");
                    string sehir = Console.ReadLine();

                    Console.Write("-> Bakiyeniz :");
                    int bakiye = Convert.ToInt32(Console.ReadLine());

                    Kaydet(id, ad, soyad, sehir, bakiye);
                }

                // // var cs = "Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun";
                // // using var con = new NpgsqlConnection(cs);

                // // using var con = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
                // // con.Open();
                // // using var cmd = new NpgsqlCommand(sql, con);
                // NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
                // conn.Open();


                // // var sql = "select * from musteri where bakiye>2000 order by id";
                // NpgsqlCommand comd = new NpgsqlCommand("select * from musteri where bakiye>100 order by id", conn);


                // NpgsqlDataReader reader = comd.ExecuteReader();
                // while (reader.Read())
                // {
                //     Console.WriteLine($"{Int32.Parse(reader["id"].ToString())} {reader["ad"].ToString()} {reader["soyad"].ToString()} {reader["sehir"].ToString()} {Int32.Parse(reader["bakiye"].ToString())}");

                //     // val = Int32.Parse(reader[0].ToString());
                //     //do whatever you like
                // }
                // // var version = cmd.ExecuteNonQuery();
                // // Console.WriteLine($"PostgreSQL version: {version}");





                // using var con1 = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dbpersonel");

                // try
                // {
                //     con1.Open();
                //     using (NpgsqlCommand cmd2 = con1.CreateCommand())
                //     {
                //         cmd2.CommandText = @"CREATE TABLE Personelbilgileri (
                //         Id      integer PRIMARY KEY NOT NULL,
                //         Ad      varchar(50) NOT NULL,
                //         Soyad   varchar(50) NOT NULL,
                //         Date    varchar(30) NOT NULL, 
                //         Bolum   varchar(100),
                //         Bakiye  decimal,
                //         Adres   varchar(100))";


                //         cmd2.ExecuteNonQuery();
                //     }
                //     con1.Close();
                //     Console.WriteLine("Tablo Oluşturuldu.");
                // }
                // catch (System.Exception)
                // {
                //     Console.WriteLine("Bu tablo zaten var!");
                // }
            } while (secim != 5);

        }
    }
}