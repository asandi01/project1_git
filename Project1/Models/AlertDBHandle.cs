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
    public class AlertDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // ********** VIEW User DETAILS ********************
        public List<AlertModel> GetAlerts() {
            connection();
            List<AlertModel> list = new List<AlertModel>();

            SqlCommand cmd = new SqlCommand("GetAlerts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                DateTime localDate = DateTime.Now;
                if (Convert.ToString(dr["sumDate"]) == localDate.AddDays(3).ToString("d/M/yyy 00:00:00")
                    || Convert.ToString(dr["sumDate"]) == localDate.AddDays(2).ToString("d/M/yyy 00:00:00")
                    || Convert.ToString(dr["sumDate"]) == localDate.AddDays(1).ToString("d/M/yyy 00:00:00")
                    || Convert.ToString(dr["sumDate"]) == localDate.AddDays(0).ToString("d/M/yyy 00:00:00")) {
                    list.Add(
                        new AlertModel {
                            id = Convert.ToInt32(dr["id"]),
                            paymentDate = Convert.ToDateTime(dr["paymentDate"]),
                            detail = Convert.ToString(dr["detail"]),
                            amount = Convert.ToDouble(dr["amount"]),
                            days = Convert.ToInt32(dr["days"]),
                            sumDate = Convert.ToDateTime(dr["sumDate"])
                        });
                }
            }
            return list;
        }
    }
}