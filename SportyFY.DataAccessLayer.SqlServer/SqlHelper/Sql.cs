using Elmah;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportyFY.DataAccessLayer.SqlServer.SqlHelper
{
    public class Sql
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ServerConStr"].ConnectionString);
        private SqlCommand com = null;
        private SqlDataAdapter da = null;
        private DataSet ds = new DataSet();
        private int t = 0;

        // dispose objects
        ~Sql()
        {
            if ((this.con != null) && (this.con.State == ConnectionState.Open))
            {
                this.con.Close();
            }
            if ((this.ds != null) && this.ds.IsInitialized)
            {
                this.ds.Clear();
            }
            if (com != null)
            {
                com.Dispose();
            }
        }

        // dispose the member.
        private void DisposeObj()
        {
            if (com != null)
            {
                com.Dispose();
            }
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        /// <summary>
        // open connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection OpenCon()
        {
            if (this.con != null && this.con.State != ConnectionState.Open)
            {
                this.con.Open();
            }
            return this.con;
        }

        private void executeStoreProcedureRetrival(string spName, Dictionary<string, dynamic> spParameters, int connectiontimeout = 60)
        {
            ds.Clear();

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = spName;
                com.CommandType = CommandType.StoredProcedure;

                //seconds
                com.CommandTimeout = connectiontimeout;

                //adding the parameters
                foreach (var item in spParameters)
                {
                    com.Parameters.AddWithValue(item.Key, item.Value);
                }

                da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private int executeStoreProcedureDML(string spName, Dictionary<string, dynamic> spParameters)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = spName;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandTimeout = 60;

                //adding the parameters
                foreach (var item in spParameters)
                {
                    com.Parameters.AddWithValue(item.Key, item.Value);
                }

                t = com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return t;
        }

        public DataSet getLoggingInUserdetails(Guid? Userid)
        {
            Dictionary<string, dynamic> spParameters = new Dictionary<string, dynamic>();
            spParameters.Clear();

            spParameters.Add("@UserId", Userid != null ? Userid.ToString() : null);
            executeStoreProcedureRetrival("proc_GetLoggingInUserDetails", spParameters);
            return ds;
        }
    }
}
