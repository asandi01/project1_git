using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project1.Models {
    public class ResourceTypeDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        public bool Add(ResourceTypeModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewRecurenceType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@detail", smodel.detail);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW DETAILS ********************
        public List<ResourceTypeModel> Get() {
            connection();
            List<ResourceTypeModel> list = new List<ResourceTypeModel>();

            SqlCommand cmd = new SqlCommand("GetRecurenceTypes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                list.Add(
                    new ResourceTypeModel {
                        id = Convert.ToInt32(dr["id"]),
                        detail = Convert.ToString(dr["detail"])
                    });
            }
            return list;
        }

        // ***************** UPDATE DETAILS *********************
        public bool UpdateDetails(ResourceTypeModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateRecurenceType", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);

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
            SqlCommand cmd = new SqlCommand("DeleteRecurenceType", con);
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