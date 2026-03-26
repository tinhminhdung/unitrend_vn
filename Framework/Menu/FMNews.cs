using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class FMNews
    {
        #region IN ID
        public List<MNews> IN_ID(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [MNews] WHERE ID in (" + ID + ")", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region GET BY ID
        public List<MNews> GETBYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [MNews] WHERE ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region GET BY TOP
        public List<MNews> GETBYTOP(string Top, string Where, string Order)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_MNews_GetByTop", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Top", Top));
            comm.Parameters.Add(new SqlParameter("@Where", Where));
            comm.Parameters.Add(new SqlParameter("@Order", Order));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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
        public List<MNews> GETBYALL(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_MNews_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region PAGING
        public List<MNews> PAGING(string CurentPage, string PageSize, string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("sp_MNews_Paging", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@CurentPage", CurentPage));
            comm.Parameters.Add(new SqlParameter("@PageSize", PageSize));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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
        public bool INSERT(MNews obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_MNews_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Url_Name", obj.Url_Name));
            comm.Parameters.Add(new SqlParameter("@User_Name", obj.User_Name));
            comm.Parameters.Add(new SqlParameter("@Search", obj.Search));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@Tags", obj.Tags));
            comm.Parameters.Add(new SqlParameter("@Lang", obj.Lang));
            comm.Parameters.Add(new SqlParameter("@Types", obj.Types));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@CheckBox1", obj.CheckBox1));
            comm.Parameters.Add(new SqlParameter("@CheckBox2", obj.CheckBox2));
            comm.Parameters.Add(new SqlParameter("@CheckBox3", obj.CheckBox3));
            comm.Parameters.Add(new SqlParameter("@CheckBox4", obj.CheckBox4));
            comm.Parameters.Add(new SqlParameter("@CheckBox5", obj.CheckBox5));
            comm.Parameters.Add(new SqlParameter("@CheckBox6", obj.CheckBox6));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("MNews");
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
        public bool UPDATE(MNews obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_MNews_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", obj.Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Title", obj.Title));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@Keywords", obj.Keywords));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Url_Name", obj.Url_Name));
            comm.Parameters.Add(new SqlParameter("@User_Name", obj.User_Name));
            comm.Parameters.Add(new SqlParameter("@Search", obj.Search));
            comm.Parameters.Add(new SqlParameter("@Orders", obj.Orders));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@Tags", obj.Tags));
            comm.Parameters.Add(new SqlParameter("@Lang", obj.Lang));
            comm.Parameters.Add(new SqlParameter("@Types", obj.Types));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@CheckBox1", obj.CheckBox1));
            comm.Parameters.Add(new SqlParameter("@CheckBox2", obj.CheckBox2));
            comm.Parameters.Add(new SqlParameter("@CheckBox3", obj.CheckBox3));
            comm.Parameters.Add(new SqlParameter("@CheckBox4", obj.CheckBox4));
            comm.Parameters.Add(new SqlParameter("@CheckBox5", obj.CheckBox5));
            comm.Parameters.Add(new SqlParameter("@CheckBox6", obj.CheckBox6));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("MNews");
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
        public void DELET(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_MNews_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID", Id));
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("MNews");
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

        #region UPDATE STATUS
        public bool UPDATE_STATUS(string ID, string status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update MNews set status=@status where ID=@ID", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            comm.Parameters.Add(new SqlParameter("@status", status));
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("MNews");
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

        #region CATE DELETE MENU ID
        public void CATE_DELETE_MENUID(string Menu_ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("delete from MNews where Menu_ID in (" + Menu_ID + ")", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction objtran = conn.BeginTransaction();
            comm.Transaction = objtran;
            try
            {
                comm.ExecuteNonQuery();
                objtran.Commit();
                System.Web.HttpContext.Current.Cache.Remove("MNews");
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

        #region GET DETAI BY ID
        public List<MNews> GET_DETAIL_BYID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from MNews where ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", Id));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region GET DETAIL BY MENU ID
        public List<MNews> GET_DETAIL_BYMENUID(string Menu_ID, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from MNews where Menu_ID = @Menu_ID  or Menu_ID in (" + imcid + ")", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region CATEGORY
        public List<MNews> CATEGORY(string Menu_ID, string Lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from MNews where  Menu_ID=@Menu_ID  and Lang=@Lang and Status=@Status  order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region NEWS OTHER LAST
        public List<MNews> NEWS_OTHERLAST(string ID, int top, string lang, string Menu_ID)
        {
            string sql = @"select  top " + top.ToString() + " * from MNews where Create_Date < (select Create_Date from MNews where ID=@ID) and lang=@lang and Menu_ID=@Menu_ID  order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region NEWS OTHER FIRST
        public List<MNews> NEWS_OTHERFIRST(string ID, int top, string lang, string Menu_ID)
        {
            string sql = @"select top " + top.ToString() + "  * from MNews where Create_Date > (select Create_Date from MNews where ID=@ID) and lang=@lang and Menu_ID=@Menu_ID   order by Create_Date desc";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", ID));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Menu_ID", Menu_ID));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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

        #region UPDATE VIEW TIME
        public List<MNews> UPDATE_VIEW_TIME(string ID)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update MNews set Views=Views + 1 where ID=@ID", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ID", ID));
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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
        public List<MNews> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<MNews>(comm);
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
