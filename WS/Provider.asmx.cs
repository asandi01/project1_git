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
    /// Summary description for Provider
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Provider : System.Web.Services.WebService {
          
        private SqlConnection con;
        private void connection() {
            string constring = ConfigurationManager.ConnectionStrings["Project1Conn"].ToString();
            con=new SqlConnection(constring);
        }

        // **************** ADD NEW *********************
        [WebMethod]
        public bool Add(ProviderModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProvider", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@detail", smodel.detail);

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
        public List<ProviderModel> GetDetails() {
            connection();
            List<ProviderModel> list = new List<ProviderModel>();

            SqlCommand cmd = new SqlCommand("GetProviders", con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows) {
                list.Add(
                    new ProviderModel {
                        id=Convert.ToInt32(dr["id"]),
                        detail=Convert.ToString(dr["detail"])
                    });
            }
            return list;
        }

        // ********** VIEW DETAILS ********************
        [WebMethod]
        public ProviderModel GetDetailsById(int id) {
            List<ProviderModel> listPayment = GetDetails();
            foreach (var item in listPayment) {
                if (item.id == id) {
                    return item;
                }
            }
            return null;
        }

        // ***************** UPDATE DETAILS *********************
        [WebMethod]
        public bool UpdateDetails(ProviderModel smodel) {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProvider", con);
            cmd.CommandType=CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", smodel.id);
            cmd.Parameters.AddWithValue("@detail", smodel.detail);

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
            SqlCommand cmd = new SqlCommand("DeleteProvider", con);
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
