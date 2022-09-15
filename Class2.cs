using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assessment_11th_Q
{
    class Class2
    {

        static void Main(string[] args)
        static void Main(string[] args)
        {
            Console.Write("Enter First Name : ");
            string fname = Console.ReadLine();

            Console.Write("Enter Last Name : ");
            string lname = Console.ReadLine();

            Console.Write("Enter Age : ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Salary : ");
            int salary = Convert.ToInt32(Console.ReadLine());

            string cs = "data source = .; database = TestDB; Integrated Security = true";
            SqlConnection con = new SqlConnection(cs);

            string query = string.Format("insert into Employee values('{0}','{1}',{2},{3})"
                , fname, lname, age, salary);

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int n = cmd.ExecuteNonQuery();

            Console.WriteLine("{0} row(s) inserted successfully!...", n);

            con.Close();
        }

