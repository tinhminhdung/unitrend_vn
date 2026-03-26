using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class Fonlyitems
    {
        #region GET BY ID
        public List<onlyitems> GETBYID(string idl)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_onlyitems_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            comm.Parameters.Add(new SqlParameter("@idl", idl));
            try
            {
                return Database.Bind_List_Reader<onlyitems>(comm);
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

        #region GET BY ALL
        public List<onlyitems> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_onlyitems_All", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            try
            {
                return Database.Bind_List_Reader<onlyitems>(comm);
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
        public bool INSERT(onlyitems obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_onlyitems_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@display", obj.display));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region UPDATE
        public bool UPDATE(onlyitems obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_onlyitems_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
           
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@idl", obj.idl));
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@display", obj.display));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
                return true;
            }
            catch
            {
                tran.Rollback();
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region DELETE
        public void onlyitems_DELETE(string idl)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_onlyitems_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@idl", idl));
            try
            {
                comm.ExecuteNonQuery();
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        public List<onlyitems> LISTADMIN(string istatus, string lang)
        {
            string sql = @" select  * from onlyitems where lang='" + lang + "'";
            if (!istatus.Equals("-1"))
            {
                sql += " and istatus=" + istatus + "";
            }
            sql += " order by dcreatedate asc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
           
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!istatus.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            }
            try
            {
                return Database.Bind_List_Reader<onlyitems>(comm);
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
    }
}
