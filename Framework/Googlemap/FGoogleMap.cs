using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FGoogleMap
    {
        #region INSERT
        public bool Insert(GoogleMap data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_GoogleMap_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Name", data.Name));
            comm.Parameters.Add(new SqlParameter("@Degrees", data.Degrees));
            comm.Parameters.Add(new SqlParameter("@vimg", data.vimg));
            comm.Parameters.Add(new SqlParameter("@lang", data.lang));
            comm.Parameters.Add(new SqlParameter("@Orders", data.Orders));
            comm.Parameters.Add(new SqlParameter("@Createdate", data.Createdate));
            comm.Parameters.Add(new SqlParameter("@Status", data.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("GoogleMap");
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

        #region UPDATE
        public bool UPDATE(GoogleMap data)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_GoogleMap_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@igm", data.igm));
            comm.Parameters.Add(new SqlParameter("@Name", data.Name));
            comm.Parameters.Add(new SqlParameter("@Degrees", data.Degrees));
            comm.Parameters.Add(new SqlParameter("@vimg", data.vimg));
            comm.Parameters.Add(new SqlParameter("@lang", data.lang));
            comm.Parameters.Add(new SqlParameter("@Orders", data.Orders));
            comm.Parameters.Add(new SqlParameter("@Createdate", data.Createdate));
            comm.Parameters.Add(new SqlParameter("@Status", data.Status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("GoogleMap");
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
        public void DELETE(string igm)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_GoogleMap_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@igm", igm));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("GoogleMap");
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

        #region CATEGORY ADMIN
        public List<GoogleMap> CATEGORY_ADMIN(string lang, string Status)
        {
            string sql = @"select * from GoogleMap where lang = @lang";
            if (!Status.Equals("-1"))
            {
                sql += " and Status = @Status";
            }
            sql += " order by Orders desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@Status", Status));
            }
            try
            {
                return Database.Bind_List_Reader<GoogleMap>(comm);
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

        #region DETAIL
        public List<GoogleMap> Detail(string igm)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from GoogleMap where igm = @igm", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@igm", igm));
            try
            {
                return Database.Bind_List_Reader<GoogleMap>(comm);
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

        #region UPDATE STATUS
        public bool UPDATESTATUS(string igm, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_GoogleMap_Updatestatus", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@igm", igm));
            comm.Parameters.Add(new SqlParameter("@status", status));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("GoogleMap");
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

        #region UPDATE IMG
        public bool UPDATEIMG(string igm, string vimg)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_GoogleMap_Updateimg", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@igm", igm));
            comm.Parameters.Add(new SqlParameter("@vimg", vimg));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("GoogleMap");
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

        #region Category
        public List<GoogleMap> Category(string lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from GoogleMap where lang=@lang  and Status=@Status order by Orders asc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<GoogleMap>(comm);
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
