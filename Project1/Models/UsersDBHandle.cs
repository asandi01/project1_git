using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace Project1.Models {
    public class UsersDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW User *********************
        public bool AddUser(UserModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsers", smodel.idUsers);
            cmd.Parameters.AddWithValue("@login", smodel.login);
            cmd.Parameters.AddWithValue("@password", MD5Hash(smodel.password));
            cmd.Parameters.AddWithValue("@name", smodel.name);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW User DETAILS ********************
        public List<UserModel> GetUser() {
            connection();
            List<UserModel> userlist = new List<UserModel>();

            SqlCommand cmd = new SqlCommand("GetUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                userlist.Add(
                    new UserModel {
                        idUsers = Convert.ToInt32(dr["idUsers"]),
                        login = Convert.ToString(dr["login"]),
                        password = Convert.ToString(dr["password"]),
                        name = Convert.ToString(dr["name"])

                    });
            }
            return userlist;
        }

        // ***************** UPDATE User DETAILS *********************
        public bool UpdateDetails(UserModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateUserDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsers", smodel.idUsers);
            cmd.Parameters.AddWithValue("@login", smodel.login);
            cmd.Parameters.AddWithValue("@password", MD5Hash(smodel.password));
            cmd.Parameters.AddWithValue("@name", smodel.name);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE User DETAILS *******************
        public bool DeleteUser(int id) {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUsers", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
        
        public static string MD5Hash(string input) {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++) {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}