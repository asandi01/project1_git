﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WS.Models;

namespace WS {
    /// <summary>
    /// Summary description for IncomeRecord
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IncomeRecord : System.Web.Services.WebService {
          
        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con=new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        [WebMethod]
        public bool Add(IncomeRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddIncomeRecord", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idUser", 1);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@amount", smodel.amount);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i>=1)
                return true;
            else
                return false;
        }

        // ********** VIEW DETAILS ********************
        [WebMethod]
        public List<IncomeRecordModel> GetDetails() {
            connection();
            List<IncomeRecordModel> list = new List<IncomeRecordModel>();

            SqlCommand cmd = new SqlCommand("GetIncomeRecords", con);
            cmd.CommandType=CommandType.StoredProcedure;
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
                    new IncomeRecordModel {
                        id=Convert.ToInt32(dr["id"]),
                        detail=Convert.ToString(dr["detail"]),
                        amount=Convert.ToInt32(dr["amount"]),
                        paymentDate=Convert.ToDateTime(dr["paymentDate"])
                    });
            }
            return list;
        }

        // ********** VIEW DETAILS ********************
        [WebMethod]
        public IncomeRecordModel GetDetailsById(int id) {
            List<IncomeRecordModel> listPayment = GetDetails();
            foreach (var item in listPayment) {
                if (item.id == id) {
                    return item;
                }
            }

            return null;
        }

        // ***************** UPDATE DETAILS *********************
        [WebMethod]
        public bool UpdateDetails(IncomeRecordModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateIncomeRecord", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@amount", smodel.amount);
            cmd.Parameters.AddWithValue("@paymentDate", smodel.paymentDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i>=1)
                return true;
            else
                return false;
        }

        // ********************** DELETE DETAILS *******************
        [WebMethod]
        public bool Delete(int id) {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteIncomeRecord", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i>=1)
                return true;
            else
                return false;
        }

    }
}
