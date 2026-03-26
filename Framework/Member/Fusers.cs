using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace Framework
{
    public class Fusers
    {
        #region BULD PASSOWRD
        static string BuildPassword(string input)
        {
            //MD5 md5Hasher = MD5.Create();
            //byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            //StringBuilder sBuilder = new StringBuilder();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    sBuilder.Append(data[i].ToString("x2"));
            //} return sBuilder.ToString();
            return input.ToString();
        }
        #endregion

        #region DETAIL VUSERUN
        public List<users> DETAIL_VUSERUN(string vuserun)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_Vuserun", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        #region DETAIL VEMAIL
        public List<users> DETAIL_VEMAIL(string vuserun, string vemail)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_vemail", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vemail", vemail));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        #region DETAIL VALIDATEKEY
        public List<users> DETAIL_VALIDATEKEY(string vvalidatekey)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_vvalidatekey", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@vvalidatekey", vvalidatekey));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        #region DETAIL VUSERUN VUSERPWD
        public List<users> DETAIL_VUSERUN_VUSERPWD(string vuserun, string vuserpwd)
        {
            vuserpwd = BuildPassword(vuserpwd);
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_vuserun_vuserpwd", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        #region UPDATE VUSERUN PASSWORD
        public bool UPDATE_VUSERUN_PASSWORD(string vuserun, string newpassword)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_settings_Update_vuserun_password", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", newpassword));
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

        #region UPDATE VUSERUN PASSWORD
        public bool DoiMatKhau(string vuserun)
        {
            string key = DateTime.Now.Ticks.ToString();
            key = key.Substring(key.Length - 8, 7);
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set validatekey=" + key + "  where vuserun=" + vuserun + "", conn);
            comm.CommandType = CommandType.Text;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
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

        # region UPDATE DATETIME
        public List<users> Update_validatekey_byemail(string vemail, string hash)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set vvalidatekey=@vvalidatekey where vemail=@vemail", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vvalidatekey", hash));
            comm.Parameters.Add(new SqlParameter("@vemail", vemail));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        #region DETAIL VUSERUN VUSERPWD STATUS
        public List<users> DETAIL_VUSERUN_STATUS(string vuserun, string vuserpwd, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_vuserun_vuserpwd_istatus", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        public List<users> GETBYID(string iuser_id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_ID", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@iuser_id", iuser_id));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        public List<users> GETBYALL()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_All", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        public bool INSERT(users obj)
        {
             
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vuserun", obj.vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", BuildPassword(obj.vuserpwd)));
            comm.Parameters.Add(new SqlParameter("@vfname", obj.vfname));
            comm.Parameters.Add(new SqlParameter("@vlname", obj.vlname));
            comm.Parameters.Add(new SqlParameter("@igender", obj.igender));
            comm.Parameters.Add(new SqlParameter("@dbirthday", obj.dbirthday));
            comm.Parameters.Add(new SqlParameter("@vidcard", obj.vidcard));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@iregionid", obj.iregionid));
            comm.Parameters.Add(new SqlParameter("@vavatar", obj.vavatar));
            comm.Parameters.Add(new SqlParameter("@vavatartitle", obj.vavatartitle));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@dlastvisited", obj.dlastvisited));
            comm.Parameters.Add(new SqlParameter("@vvalidatekey", obj.vvalidatekey));
            comm.Parameters.Add(new SqlParameter("@istatus", obj.istatus));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));

            comm.Parameters.Add(new SqlParameter("@Thanhpho", obj.Thanhpho));
            comm.Parameters.Add(new SqlParameter("@Quanhuyen", obj.Quanhuyen));
            comm.Parameters.Add(new SqlParameter("@Phuongxa", obj.Phuongxa));

            comm.Parameters.Add(new SqlParameter("@Tencongty", obj.Tencongty));
            comm.Parameters.Add(new SqlParameter("@Diachicongty", obj.Diachicongty));
            comm.Parameters.Add(new SqlParameter("@Dienthoaicongty", obj.Dienthoaicongty));
            comm.Parameters.Add(new SqlParameter("@Masothuecongty", obj.Masothuecongty));
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
        public bool UPDATE(users obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;

            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@iuser_id", obj.iuser_id));
            comm.Parameters.Add(new SqlParameter("@vuserun", obj.vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", obj.vuserpwd));
            comm.Parameters.Add(new SqlParameter("@vfname", obj.vfname));
            comm.Parameters.Add(new SqlParameter("@vlname", obj.vlname));
            comm.Parameters.Add(new SqlParameter("@igender", obj.igender));
            comm.Parameters.Add(new SqlParameter("@dbirthday", obj.dbirthday));
            comm.Parameters.Add(new SqlParameter("@vidcard", obj.vidcard));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@iregionid", obj.iregionid));
            comm.Parameters.Add(new SqlParameter("@vavatar", obj.vavatar));
            comm.Parameters.Add(new SqlParameter("@vavatartitle", obj.vavatartitle));
            comm.Parameters.Add(new SqlParameter("@dcreatedate", obj.dcreatedate));
            comm.Parameters.Add(new SqlParameter("@dlastvisited", obj.dlastvisited));
            comm.Parameters.Add(new SqlParameter("@vvalidatekey", obj.vvalidatekey));
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
        public void DELETE(string iuser_id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_users_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@iuser_id", iuser_id));
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

        #region UPDATE STATUS
        public bool UPDATE_STATUS(string iuser_id, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("UPDATE [users] SET [istatus] = @istatus WHERE iuser_id = @iuser_id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            comm.Parameters.Add(new SqlParameter("@iuser_id", iuser_id));
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

        #region CATEGORY
        public List<users> CATEGORY(string istatus)
        {
            string sql = @"select * from users order by dcreatedate desc";
            if (!istatus.Equals("-1"))
            {
                sql = sql + "where istatus=" + istatus + "";
            }
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            if (!istatus.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@istatus", istatus));

            }
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        #region UPDATE
        public bool users_update(users obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set vuserun=@vuserun,vfname=@vfname,vlname=@vlname,igender=@igender,dbirthday=@dbirthday,vaddress=@vaddress,vphone=@vphone,vavatartitle=@vavatartitle,vemail=@vemail where iuser_id=@iuser_id", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vuserun", obj.vuserun));
            comm.Parameters.Add(new SqlParameter("@vfname", obj.vfname));
            comm.Parameters.Add(new SqlParameter("@vlname", obj.vlname));
            comm.Parameters.Add(new SqlParameter("@igender", obj.igender));
            comm.Parameters.Add(new SqlParameter("@dbirthday", obj.dbirthday));
            comm.Parameters.Add(new SqlParameter("@vaddress", obj.vaddress));
            comm.Parameters.Add(new SqlParameter("@vphone", obj.vphone));
            comm.Parameters.Add(new SqlParameter("@vavatartitle", obj.vavatartitle));
            comm.Parameters.Add(new SqlParameter("@vemail", obj.vemail));
            comm.Parameters.Add(new SqlParameter("@iuser_id", obj.iuser_id));
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
        public bool Active_vvalidatekey(string vuserun, string vvalidatekey)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set vvalidatekey=@vvalidatekey where vuserun=@vuserun", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vvalidatekey", vvalidatekey));
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
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
        #region CATEGORY ADMIN
        public List<users> CATEGORY_ADMIN(string orderby, string searchkeyword, string[] searchfields, string lang, string istatus)
        {
            int i;
            string shortbydate = "";
            if (orderby.Length < 1)
            {
                shortbydate = "order by dcreatedate desc";
            }
            else
            {
                shortbydate = "order by " + orderby;
            }
            string sql = @"select * from users where lang=@lang ";
            if (!istatus.Equals("-1"))
            {
                sql += " and istatus=@istatus";
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                sql = sql + " and ";
                string strsearch = "(";
                for (i = 0; i < searchfields.Length; i++)
                {
                    if (i < (searchfields.Length - 1))
                    {
                        strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%' or ";
                    }
                    else
                    {
                        strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%'";
                    }
                }
                strsearch = strsearch + ")";
                sql = sql + strsearch;
            }
            sql += " " + shortbydate + "";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!istatus.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                for (i = 0; i < searchfields.Length; i++)
                {
                    comm.Parameters.Add(new SqlParameter("@" + searchfields[i], searchkeyword));
                }
            }
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        #region UPDATE
        public bool users_update_updatepassword(string vuserun, string newpassword)
        {
            newpassword = BuildPassword(newpassword);
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set vuserpwd=@vuserpwd where vuserun=@vuserun", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vuserpwd", newpassword));
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
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
        public bool users_update_updateavatar(users obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update users set vavatar=@vavatar,vavatartitle=@vavatartitle  where vuserun=@vuserun", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@vavatar", obj.vavatar));
            comm.Parameters.Add(new SqlParameter("@vavatartitle", obj.vavatartitle));
            comm.Parameters.Add(new SqlParameter("@vuserun", obj.vuserun));
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
        public DataTable Detail_IDLOGIN(string iuser_id)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where iuser_id=@iuser_id", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@iuser_id", iuser_id));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }
        public DataTable vvalidatekey(string vvalidatekey)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vvalidatekey=@vvalidatekey", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vvalidatekey", vvalidatekey));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        public DataTable Detailvuserun(string vuserun)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vuserun=@vuserun", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        public DataTable Detailemail(string vemail)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vemail=@vemail", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vemail", vemail));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        #region GET BY ID
        public List<users> Logiin(string vuserun, string vuserpwd, string istatus)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vuserun='" + vuserun + "' and vuserpwd='" + vuserpwd + "' and istatus=" + istatus + "", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", BuildPassword(vuserpwd)));
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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

        public DataTable Detail_vuserun_vuserpwd(string vuserun, string vuserpwd, string istatus)
        {
            vuserpwd = BuildPassword(vuserpwd);
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vuserun=@vuserun and vuserpwd=@vuserpwd and istatus=@istatus", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", BuildPassword(vuserpwd)));
            comm.Parameters.Add(new SqlParameter("@istatus", istatus));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        public DataTable Getdetailbyunpwd(string vuserun, string vuserpwd)
        {
            vuserpwd = BuildPassword(vuserpwd);
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vuserun=@vuserun and vuserpwd=@vuserpwd", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vuserun", vuserun));
            comm.Parameters.Add(new SqlParameter("@vuserpwd", vuserpwd));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }

        #region Name StoredProcedure
        public List<users> Name_StoredProcedure(string Name_StoredProcedure)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_StoredProcedure, conn);
            comm.CommandType = CommandType.StoredProcedure;
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        public List<users> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<users>(comm);
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
        public DataTable DetailPhone(string vphone)
        {
            DataTable dts = new DataTable();
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from users where vphone=@vphone", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@vphone", vphone));
            try
            {
                VSda = new SqlDataAdapter(comm);
                VSda.Fill(dts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }
    }
}
