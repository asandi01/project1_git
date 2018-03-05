using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace Project1.Models {
    public class PaymentRecordDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        public bool Add(PaymentRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddPaymentRecord", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@idUser", 1);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@amount", smodel.amount);
            cmd.Parameters.AddWithValue("@recurrence", smodel.recurrence);
            cmd.Parameters.AddWithValue("@recurrenciaTypeId", smodel.recurrenciaTypeId);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);
            cmd.Parameters.AddWithValue("@providerId", smodel.providerId);
            cmd.Parameters.AddWithValue("@expenseCategoryId", smodel.expenseCategoryId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW DETAILS ********************
        public List<PaymentRecordModel> Get() {
            connection();
            List<PaymentRecordModel> list = new List<PaymentRecordModel>();

            SqlCommand cmd = new SqlCommand("GetPaymentRecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idUser", 1);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows) {
                /*string dateString = Convert.ToString(dr["paymentDate"]);
                DateTime dateTime = DateTime.Parse(dateString);
                string format = "MM/dd/YYYY";   // Use this format.
                dateTime.ToString(format);*/
                list.Add(
                    new PaymentRecordModel {
                        id = Convert.ToInt32(dr["id"]),
                        detail = Convert.ToString(dr["detail"]),
                        amount = Convert.ToInt32(dr["amount"]),
                        recurrence = Convert.ToInt32(dr["recurrence"]),
                        recurrenciaTypeId = Convert.ToInt32(dr["recurrenciaTypeId"]),
                        paymentDate = Convert.ToDateTime(dr["paymentDate"]),
                        providerId = Convert.ToInt32(dr["providerId"]),
                        expenseCategoryId = Convert.ToInt32(dr["expenseCategoryId"])
            });
            }
            return list;
        }

        // ***************** UPDATE DETAILS *********************
        public bool UpdateDetails(PaymentRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePaymentRecord", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@amount", smodel.amount);
            cmd.Parameters.AddWithValue("@recurrence", smodel.recurrence);
            cmd.Parameters.AddWithValue("@recurrenciaTypeId", smodel.recurrenciaTypeId);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);
            cmd.Parameters.AddWithValue("@providerId", smodel.providerId);
            cmd.Parameters.AddWithValue("@expenseCategoryId", smodel.expenseCategoryId);

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
            SqlCommand cmd = new SqlCommand("DeletePaymentRecord", con);
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