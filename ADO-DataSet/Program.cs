using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ADO_DataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectString = @"Data Source = ASPIRE-5560G\ZLSQL; Initial Catalog = DBSlides; Integrated Security = True";

            try
            {
                SqlConnection db = new SqlConnection();
                db.ConnectionString = connectString;
                string selectQuery = "SELECT se.section_name AS section, st.first_name + ' ' + st.last_name AS 'délégué' FROM section se JOIN student st ON se.delegate_id = st.student_id";

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = db.CreateCommand();
                da.SelectCommand.CommandText = selectQuery;

                DataSet ds = new DataSet();

                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(string.Format("{0} | {1}", dr["section"], dr["délégué"]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
