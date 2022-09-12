using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_11th_Q
{

    internal class Class1
    {
        static void Main(string[] args)
        {
            string cs = "data source = .; database = TestDB; Integrated security = true";

            SqlConnection con = new SqlConnection(cs);

            string query = "select * from employee";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;

            Console.WriteLine("Id   FName     LName     Age    Salary");
            Console.WriteLine("--- -------   -------   -----   --------");


            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Console.WriteLine("{0}    {1}    {2}     {3}    {4}"
                        , rdr["Empid"], rdr["First_Name"], rdr["Last_Name"], rdr["Age"], rdr["Salary"]);
                }
            }
            con.Close();

            //SqlCommand cmd1 = new SqlCommand(query, con);
        }
    }


    Question:




