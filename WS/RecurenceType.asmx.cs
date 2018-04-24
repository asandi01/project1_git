using System;
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
    /// Summary description for RecurenceType
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RecurenceType : System.Web.Services.WebService {
           
        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con=new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        [WebMethod]
        public bool Add(RecurenceTypeModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewRecurenceType", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@days", smodel.days);

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
        public List<RecurenceTypeModel> GetDetails() {
            connection();
            List<RecurenceTypeModel> list = new List<RecurenceTypeModel>();

            SqlCommand cmd = new SqlCommand("GetRecurenceTypes", con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                list.Add(
                    new RecurenceTypeModel {
                        id=Convert.ToInt32(dr["id"]),
                        detail=Convert.ToString(dr["detail"]),
                        days=Convert.ToInt32(dr["days"])
                    });
            }
            return list;
        }

        // ********** VIEW DETAILS ********************
        [WebMethod]
        public RecurenceTypeModel GetDetailsById(int id) {
            List<RecurenceTypeModel> listPayment = GetDetails();
            foreach (var item in listPayment) {
                if (item.id == id) {
                    return item;
                }
            }
            return null;
        }

        // ***************** UPDATE DETAILS *********************
        [WebMethod]
        public bool UpdateDetails(RecurenceTypeModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateRecurenceType", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);
            cmd.Parameters.AddWithValue("@days", smodel.days);

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
            SqlCommand cmd = new SqlCommand("DeleteRecurenceType", con);
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
