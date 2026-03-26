using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FBaoGias
    {
        #region UPDATE STATUS
        public bool UPDATESTATUS(string ino, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_BaoGia_Updatestatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            comm.Parameters.Add(new SqlParameter("@ino", ino));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("BaoGia");
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

        #region GET BY ID
        public List<BaoGia> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_BaoGia_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            try
            {
                return Database.Bind_List_Reader<BaoGia>(comm);
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
        public List<BaoGia> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_BaoGia_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<BaoGia>(comm);
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
        public bool Insert(BaoGia obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_BaoGia_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vname", obj.vname));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@File1", obj.File1));
            comm.Parameters.Add(new SqlParameter("@File2", obj.File2));
            comm.Parameters.Add(new SqlParameter("@MaBaoGia", obj.MaBaoGia));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("BaoGia");
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
        public bool Update(BaoGia obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_BaoGia_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ino", obj.ino));
            comm.Parameters.Add(new SqlParameter("@vtitle", obj.vtitle));
            comm.Parameters.Add(new SqlParameter("@vname", obj.vname));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@vcontent", obj.vcontent));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("BaoGia");
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
            SqlCommand comm = new SqlCommand("S_BaoGia_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ino", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("BaoGia");
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
        public List<BaoGia> CATEGORY_ADMIN(string lang, string istatus)
        {
            string sql = @"select * from BaoGia where lang='" + lang + "'";
            if (!istatus.Equals("-1"))
            {
                sql += " and istatus=" + istatus + " ";
            }
            sql += " order by dcreatedate desc ";
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
                return Database.Bind_List_Reader<BaoGia>(comm);
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

        #region Name StoredProcedure
        public List<BaoGia> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<BaoGia>(comm);
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
        public List<BaoGia> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<BaoGia>(comm);
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
