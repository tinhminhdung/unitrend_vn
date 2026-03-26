using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FStatisticsLink
    {
        #region GET BY ID
        public List<StatisticsLink> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_StatisticsLink_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            try
            {
                return Database.Bind_List_Reader<StatisticsLink>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region INSERT
        public bool Insert(StatisticsLink obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_StatisticsLink_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@IP", obj.IP));
            comm.Parameters.Add(new SqlParameter("@Link", obj.Link));
            comm.Parameters.Add(new SqlParameter("@NameUser", obj.NameUser));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@IDDate", obj.IDDate));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("StatisticsLink");
                return true;
            }
            catch
            {
                objtran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region DELETE
        public void DELETE(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_StatisticsLink_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("StatisticsLink");
            }
            catch
            {
                objtran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
        #region GetTopProductInCategory
        public List<StatisticsLink> GetTopProductInCategory(string id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from  products where  IDDate (" + id + ") order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<StatisticsLink>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion
        #region Name Text
        public List<StatisticsLink> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<StatisticsLink>(comm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
