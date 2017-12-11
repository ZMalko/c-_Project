using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace AntiMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con;

            String str;
            //int num=0;
            //DateTime date=new DateTime();
            DateTime date = DateTime.Now;
            //DateTime date = DateTime.Today;
            String content;

            try
            {
                //str = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\zahi_\source\repos\AntiMessage\AntiMessage\Messages.mdf;Initial Catalog=EFCodeFirst;Integrated Security=True";
                str = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\Messages.mdf;Initial Catalog=EFCodeFirst;Integrated Security=True";
                Console.WriteLine(str);
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Database Connected");

                //Console.WriteLine("\n Number {0}", num);
                // for(int i = num; i <= 100; i++) { num += i; }


                //num = int.Parse(Console.ReadLine());

                //Console.WriteLine("\n MassageDate {0} \n",DateTime.Now);
                Console.WriteLine("\n MassageDate {0} \n",date.ToString());
                //date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("\n Enter Your Messages");
                content = Console.ReadLine();

                //String query = "INSERT INTO Message (Id,MessageDate,Message) VALUES('" + num +"','" + date + "','" + content + "') ON DUPLICATE KEY UPDATE Id=Id+1";
                String query = "INSERT INTO Messages (MessageDate,Message) VALUES('" + date.ToString() + "','" + content + "')";
                
                SqlCommand ins = new SqlCommand(query, con);
                ins.ExecuteNonQuery();
                Console.WriteLine("\n Data stored into DataBase");

                //num += num + 1;

                String q = "SELECT * FROM Messages";
                SqlCommand view = new SqlCommand(q, con);
                SqlDataReader dr = view.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("\nNum: " + dr.GetValue(0).ToString());
                    Console.WriteLine("\nDate: "+dr.GetValue(1).ToString());
                    Console.WriteLine("\nContent: " + dr.GetValue(2).ToString());
                }
                con.Close();
            }
            catch(SqlException x)
            {
                Console.WriteLine(x.Message);
            }

            Console.ReadLine();

        }
    }
}
