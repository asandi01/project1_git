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
    public class PaymentRecordDBHandle {

        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        public bool Add(PaymentRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewPayment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idPaymentRecord", smodel.idPaymentRecord);
            cmd.Parameters.AddWithValue("@idUser", smodel.idUser);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@anount", smodel.amount);
            cmd.Parameters.AddWithValue("@recurrence", smodel.recurrence);
            cmd.Parameters.AddWithValue("@recurrenceType", smodel.recurrenceType);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);
            cmd.Parameters.AddWithValue("@provider", smodel.provider);
            cmd.Parameters.AddWithValue("@serviceType", smodel.serviceType);

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
            List<PaymentRecordModel> Paymentlist = new List<PaymentRecordModel>();

            SqlCommand cmd = new SqlCommand("GetPayment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                Paymentlist.Add(
                    new PaymentRecordModel {
                        idPaymentRecord = Convert.ToInt32(dr["idPaymentRecord"]),
                        idUser = Convert.ToInt32(dr["idUser"]),
                        detail = Convert.ToString(dr["detail"]),
                        amount = Convert.ToDouble(dr["amount"]),
                        recurrence = Convert.ToBoolean(dr["recurrence"]),
                        recurrenceType = Convert.ToInt32(dr["recurrenceType"]),
                        paymentDate = Convert.ToDateTime(dr["paymentDate"]),
                        provider = Convert.ToString(dr["provider"]),
                        serviceType = Convert.ToInt32(dr["serviceType"])
                    });
            }
            return Paymentlist;
        }

        // ***************** UPDATE DETAILS *********************
        public bool UpdateDetails(PaymentRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdatePayment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idPaymentRecord", smodel.idPaymentRecord);
            cmd.Parameters.AddWithValue("@idUser", smodel.idUser);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@anount", smodel.amount);
            cmd.Parameters.AddWithValue("@recurrence", smodel.recurrence);
            cmd.Parameters.AddWithValue("@recurrenceType", smodel.recurrenceType);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);
            cmd.Parameters.AddWithValue("@provider", smodel.provider);
            cmd.Parameters.AddWithValue("@serviceType", smodel.serviceType);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE Payment DETAILS *******************
        public bool Delete(int id) {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePayment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idPaymentRecord", id);

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