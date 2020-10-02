using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Version
{
    class Musteri
    {
        public static void Kaydet(int id, string ad, string soyad, string sehir, int bakiye)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();
            NpgsqlCommand comd = new NpgsqlCommand("insert into musteri (id,ad,soyad,sehir,bakiye) values ('" + id.ToString() + "','" + ad.ToString() + "','" + soyad.ToString() + "','" + sehir.ToString() + "','" + bakiye.ToString() + "') ", conn);
            comd.ExecuteNonQuery();
            conn.Close();
        }
        public static void VerileriGoster()
        {
            using var conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();

            // var sql = "select * from musteri where bakiye>2000 order by id";
            using var comd = new NpgsqlCommand("select * from musteri where bakiye>100 order by id", conn);


            NpgsqlDataReader reader = comd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{Int32.Parse(reader["id"].ToString())} {reader["ad"].ToString()} {reader["soyad"].ToString()} {reader["sehir"].ToString()} {Int32.Parse(reader["bakiye"].ToString())}");

                int val = Int32.Parse(reader[0].ToString());
                // Console.WriteLine(">>>"+val);
            }
            
        }
        public static void Bul(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();

            var sql = "select * from musteri ";
            using var comd = new NpgsqlCommand(sql, conn);

            NpgsqlDataReader reader = comd.ExecuteReader();

            bool bulunduMu = false;
            while (reader.Read())
            {

                if (id == Int32.Parse(reader[0].ToString()))
                {
                    Console.Write("\nBulunan :");
                    Console.WriteLine($"{Int32.Parse(reader["id"].ToString())} {reader["ad"].ToString()} {reader["soyad"].ToString()} {reader["sehir"].ToString()} {Int32.Parse(reader["bakiye"].ToString())}");
                    bulunduMu = true;
            
                    break;
                }

                // Console.WriteLine($"{Int32.Parse(reader["id"].ToString())} {reader["ad"].ToString()} {reader["soyad"].ToString()} {reader["sehir"].ToString()} {Int32.Parse(reader["bakiye"].ToString())}");

                // int val = Int32.Parse(reader[0].ToString());
                // // Console.WriteLine(">>>"+val);
            }
            if (!bulunduMu)
            {
                Console.WriteLine("Böyle bir arama bulunamdı.");
            }
            conn.Close();
            Console.WriteLine();

        }

        public static void Sil(int id)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();

            using var comd = new NpgsqlCommand("delete from musteri where id =("+id+")", conn);
        
            conn.Close();
            Console.WriteLine();

            VerileriGoster();

        }
        public static void Guncelle(int idEski, int idYeni, string ad, string soyad,string sehir, int bakiye )
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Amorfati2020.;Database=dburun");
            conn.Open();

            using var comd = new NpgsqlCommand("update musteri set id='"+idYeni.ToString()+"',ad='"+ad.ToString()+"',soyad='"+soyad.ToString()+"',sehir='"+sehir.ToString()+"',bakiye='"+bakiye.ToString()+"' where id =("+idEski+")", conn);
        
            comd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine();

            VerileriGoster();

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

    }
}
