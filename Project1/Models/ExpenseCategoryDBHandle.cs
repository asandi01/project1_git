using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project1.Models {
    public class ExpenseCategoryDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        public bool Add(ExpenseCategoryModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddExpenseCategoryType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@priority", smodel.priority);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW DETAILS ********************
        public List<ExpenseCategoryModel> Get() {
            connection();
            List<ExpenseCategoryModel> list = new List<ExpenseCategoryModel>();

            SqlCommand cmd = new SqlCommand("GetexpenseCategorys", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                list.Add(
                    new ExpenseCategoryModel {
                        id = Convert.ToInt32(dr["id"]),
                        detail = Convert.ToString(dr["detail"]),
                        priority = Convert.ToInt32(dr["priority"])
                    });
            }
            return list;
        }

        // ***************** UPDATE DETAILS *********************
        public bool UpdateDetails(ExpenseCategoryModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateexpenseCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@priority", smodel.priority);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE DETAILS *******************
        public bool Delete(int id) {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteexpenseCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
    }
}