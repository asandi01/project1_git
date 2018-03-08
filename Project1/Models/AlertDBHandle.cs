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

        // ********** Get alert Soon to pay ********************
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
        
        // ********** Get alert Soon to pay ********************
        private double GetPaymentsByMont(int montLess) {
            connection();
            SqlCommand cmd = new SqlCommand("GetPaymentCurrentMonth", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@montLess", montLess);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            double currentMont = 0;
            foreach (DataRow dr in dt.Rows) {
                currentMont = Convert.ToDouble(dr["sumamount"]);
            }
            return currentMont;
        }

        public double GetPayments() {
            double currentMont = GetPaymentsByMont(0);
            double previousMont = GetPaymentsByMont(1);

            return currentMont - previousMont;
        }

        private double GetIncomentByMont(int montLess) {
            connection();
            SqlCommand cmd = new SqlCommand("GetIncomentByMonth", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@montLess", montLess);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            double currentMont = 0;
            foreach (DataRow dr in dt.Rows) {
                currentMont = Convert.ToDouble(dr["sumamount"]);
            }
            return currentMont;
        }

        public double GetIncoments() {
            double currentMont = GetIncomentByMont(0);
            double previousMont = GetIncomentByMont(1);

            return currentMont - previousMont;
        }

        public double getBeterP() {
            double currentMontIP = GetIncomentByMont(1);
            double currentMontPP = GetPaymentsByMont(1);

            return currentMontIP - currentMontPP;
        }

        public double getBeterC() {
            double currentMontIC = GetIncomentByMont(0);
            double currentMontPC = GetPaymentsByMont(0);

            return currentMontIC - currentMontPC;
        }

        // ********** Get Payment By Expense Category Current Month ********************
        public List<AlertModel> GetPaymentByExpenseCategoryCurrentMonth() {
            connection();
            List<AlertModel> list = new List<AlertModel>();

            SqlCommand cmd = new SqlCommand("GetPaymentByExpenseCategoryCurrentMonth", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                list.Add(
                    new AlertModel {
                        detail = Convert.ToString(dr["detail"]),
                        amount = Convert.ToDouble(dr["sumamount"])
                    });
            }
            return list;
        }

        public double GetFutureProjectionsPay() {
            connection();
            SqlCommand cmd = new SqlCommand("GetFutureProjectionsPay", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            double currentMont = 0;
            foreach (DataRow dr in dt.Rows) {
                currentMont = Convert.ToDouble(dr["payMonth"]);
            }
            return currentMont;
        }

        public double GetFutureProjectionsIncoment() {
            connection();
            SqlCommand cmd = new SqlCommand("GetFutureProjectionsIncoment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            double currentMont = 0;
            foreach (DataRow dr in dt.Rows) {
                currentMont = Convert.ToDouble(dr["incomentMonth"]);
            }

            return currentMont - GetFutureProjectionsPay();
        }

        public double GetFutureProjectionsSaving() {
            connection();
            SqlCommand cmd = new SqlCommand("GetFutureProjectionsSaving", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            double currentMont = 0;
            foreach (DataRow dr in dt.Rows) {
                currentMont = Convert.ToDouble(dr["payMonth"]);
            }

            return GetFutureProjectionsPay() - currentMont;
        }
    }
}