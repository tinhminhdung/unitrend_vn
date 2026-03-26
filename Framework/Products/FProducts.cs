using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System.Text;
namespace Framwork
{
    public class Fproducts
    {
        #region[GetById]
        public List<Products> GetById(string ipid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [products] WHERE ipid = @ipid", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region[More_icid]
        public List<Products> More_icid(string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [products] WHERE icid IN (" + icid + ")", conn);
            comm.CommandType = CommandType.Text;

            comm.Parameters.Add(new SqlParameter("@ipid", icid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region[GetByAll]
        public List<Products> GetByAll(string Lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_products_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Lang", Lang));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region[Insert]
        public bool Insert(Products obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_products_Insert", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@icid", obj.icid));
            comm.Parameters.Add(new SqlParameter("@ID_Hang", obj.ID_Hang));
            comm.Parameters.Add(new SqlParameter("@sanxuat", obj.sanxuat));
            comm.Parameters.Add(new SqlParameter("@Code", obj.Code));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Quantity", obj.Quantity));
            comm.Parameters.Add(new SqlParameter("@Price", obj.Price));
            comm.Parameters.Add(new SqlParameter("@OldPrice", obj.OldPrice));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@News", obj.News));
            comm.Parameters.Add(new SqlParameter("@Home", obj.Home));
            comm.Parameters.Add(new SqlParameter("@Check_01", obj.Check_01));
            comm.Parameters.Add(new SqlParameter("@Check_02", obj.Check_02));
            comm.Parameters.Add(new SqlParameter("@Check_03", obj.Check_03));
            comm.Parameters.Add(new SqlParameter("@Check_04", obj.Check_04));
            comm.Parameters.Add(new SqlParameter("@Check_05", obj.Check_05));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@Anh", obj.Anh));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@Noidung1", obj.Noidung1));
            comm.Parameters.Add(new SqlParameter("@Noidung2", obj.Noidung2));
            comm.Parameters.Add(new SqlParameter("@Noidung3", obj.Noidung3));
            comm.Parameters.Add(new SqlParameter("@Noidung4", obj.Noidung4));
            comm.Parameters.Add(new SqlParameter("@Noidung5", obj.Noidung5));
            comm.Parameters.Add(new SqlParameter("@RateCount", obj.RateCount));
            comm.Parameters.Add(new SqlParameter("@RateSum", obj.RateSum));

            comm.Parameters.Add(new SqlParameter("@TrangThaiHang", obj.TrangThaiHang));
            comm.Parameters.Add(new SqlParameter("@Model", obj.Model));
            comm.Parameters.Add(new SqlParameter("@ThuongHieu", obj.ThuongHieu));
            comm.Parameters.Add(new SqlParameter("@LinkSPNgungBan", obj.LinkSPNgungBan));
            comm.Parameters.Add(new SqlParameter("@ThoiGianBaoHanh", obj.ThoiGianBaoHanh));
            comm.Parameters.Add(new SqlParameter("@XuatXu", obj.XuatXu));
            comm.Parameters.Add(new SqlParameter("@NguoiXuLy", obj.NguoiXuLy));
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

        #region[Update]
        public bool Update(Products obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_products_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ipid", obj.ipid));
            comm.Parameters.Add(new SqlParameter("@icid", obj.icid));
            comm.Parameters.Add(new SqlParameter("@ID_Hang", obj.ID_Hang));
            comm.Parameters.Add(new SqlParameter("@sanxuat", obj.sanxuat));
            comm.Parameters.Add(new SqlParameter("@Code", obj.Code));
            comm.Parameters.Add(new SqlParameter("@Name", obj.Name));
            comm.Parameters.Add(new SqlParameter("@Brief", obj.Brief));
            comm.Parameters.Add(new SqlParameter("@Contents", obj.Contents));
            comm.Parameters.Add(new SqlParameter("@search", obj.search));
            comm.Parameters.Add(new SqlParameter("@Images", obj.Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", obj.ImagesSmall));
            comm.Parameters.Add(new SqlParameter("@Equals", obj.Equals));
            comm.Parameters.Add(new SqlParameter("@Quantity", obj.Quantity));
            comm.Parameters.Add(new SqlParameter("@Price", obj.Price));
            comm.Parameters.Add(new SqlParameter("@OldPrice", obj.OldPrice));
            comm.Parameters.Add(new SqlParameter("@Chekdata", obj.Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", obj.Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", obj.Modified_Date));
            comm.Parameters.Add(new SqlParameter("@Views", obj.Views));
            comm.Parameters.Add(new SqlParameter("@lang", obj.lang));
            comm.Parameters.Add(new SqlParameter("@News", obj.News));
            comm.Parameters.Add(new SqlParameter("@Home", obj.Home));
            comm.Parameters.Add(new SqlParameter("@Check_01", obj.Check_01));
            comm.Parameters.Add(new SqlParameter("@Check_02", obj.Check_02));
            comm.Parameters.Add(new SqlParameter("@Check_03", obj.Check_03));
            comm.Parameters.Add(new SqlParameter("@Check_04", obj.Check_04));
            comm.Parameters.Add(new SqlParameter("@Check_05", obj.Check_05));
            comm.Parameters.Add(new SqlParameter("@Status", obj.Status));
            comm.Parameters.Add(new SqlParameter("@Titleseo", obj.Titleseo));
            comm.Parameters.Add(new SqlParameter("@Meta", obj.Meta));
            comm.Parameters.Add(new SqlParameter("@Keyword", obj.Keyword));
            comm.Parameters.Add(new SqlParameter("@Anh", obj.Anh));
            comm.Parameters.Add(new SqlParameter("@Noidung1", obj.Noidung1));
            comm.Parameters.Add(new SqlParameter("@Noidung2", obj.Noidung2));
            comm.Parameters.Add(new SqlParameter("@Noidung3", obj.Noidung3));
            comm.Parameters.Add(new SqlParameter("@Noidung4", obj.Noidung4));
            comm.Parameters.Add(new SqlParameter("@Noidung5", obj.Noidung5));
            comm.Parameters.Add(new SqlParameter("@TangName", obj.TangName));
            comm.Parameters.Add(new SqlParameter("@TrangThaiHang", obj.TrangThaiHang));
            comm.Parameters.Add(new SqlParameter("@Model", obj.Model));
            comm.Parameters.Add(new SqlParameter("@ThuongHieu", obj.ThuongHieu));
            comm.Parameters.Add(new SqlParameter("@LinkSPNgungBan", obj.LinkSPNgungBan));
            comm.Parameters.Add(new SqlParameter("@ThoiGianBaoHanh", obj.ThoiGianBaoHanh));
            comm.Parameters.Add(new SqlParameter("@XuatXu", obj.XuatXu));
            comm.Parameters.Add(new SqlParameter("@NguoiXuLy", obj.NguoiXuLy));
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

        #region[Delete]
        public void Delete(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_products_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ipid", Id));
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
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

        #region[Cate_Delete_icid]
        public void Cate_Delete_icid(string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("DELETE FROM [products] WHERE icid IN(" + icid + ")", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@icid", icid));
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
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

        #region[CategoryAdmin]
        public List<Products> CategoryAdmin(string orderby, string searchkeyword, string[] searchfields, string icid, string lang, string Status, string Vitri)
        {
            List<Products> list = new List<Products>();
            int i;
            string shortbydate = "";
            if (orderby.Length < 1)
            {
                shortbydate = "order by Create_Date desc";
            }
            else
            {
                shortbydate = "order by " + orderby;
            }
           // string sql = @"select * from products where icid in (" + icid + ") and lang='" + lang + "' " + Vitri + "";// 
            string sql = @"select * from (
select A.*, case when IDSP is not null then 1 else 0 end as tailieu
from products as A  with(nolock) left join (select distinct  IDSP from TaiLieu_SanPham with(nolock)) 
as B on A.ipid=B.IDSP
 ) as k
 where icid in (" + icid + ") and lang='" + lang + "' " + Vitri + "";// 
            if (!Status.Equals("-1"))
            {
                sql += " and Status=" + Status + " ";
            }
            if ((searchkeyword.Length > 0) && (searchfields.Length > 0))
            {
                sql = sql + " and ";
                string strsearch = "(";
                for (i = 0; i < searchfields.Length; i++)
                {
                    if (i < (searchfields.Length - 1))
                    {
                        strsearch = strsearch + searchfields[i] + " LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(searchkeyword)) + "' or ";
                    }
                    else
                    {
                        strsearch = strsearch + searchfields[i] + " LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(searchkeyword)) + "'";
                    }
                    //if (i < (searchfields.Length - 1))
                    //{
                    //    strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%' or ";
                    //}
                    //else
                    //{
                    //    strsearch = strsearch + searchfields[i] + " like N'%" + searchkeyword + "%'";
                    //}
                }
                strsearch = strsearch + ")";
                sql = sql + strsearch;
            }
            sql += " " + shortbydate + "";
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@icid", icid));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            if (!Status.Equals("-1"))
            {
                comm.Parameters.Add(new SqlParameter("@Status", Status));
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
                return Database.Bind_List_Reader<Products>(comm);
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

        #region products_List_ToolTip
        public static List<Products> List_ToolTip(string lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [products] WHERE [Status]=1 and lang = @Lang", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region CategoryDisplay
        public List<Products> CategoryDisplay(string icid, string lang, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select * from products where icid in(" + icid + ") and lang= @lang  and Status= @Status and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@icid", icid));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region NewxTopNewsAfterNews
        public List<Products> NewxTopNewsAfterNews(string cid, string pid, int top, string lang)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select  top " + top.ToString() + "  * from  products where icid= @cid  and Create_Date < (select Create_Date from products where ipid=@pid)  and (Create_Date<=getdate() and getdate()<=Modified_Date) and lang=@lang order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@cid", cid));
            comm.Parameters.Add(new SqlParameter("@pid", pid));
            comm.Parameters.Add(new SqlParameter("@top", top));
            comm.Parameters.Add(new SqlParameter("@lang", lang));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region GetTopProductInCategory
        public List<Products> GetTopProductInCategory(string top, string cateid, string imcid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select top " + top.ToString() + " * from  products where Home=1 and icid in (" + imcid + ") and Status=1 and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@cateid", cateid));
            comm.Parameters.Add(new SqlParameter("@imcid", imcid));
            comm.Parameters.Add(new SqlParameter("@top", top));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region UpdateViewTimes
        public bool UpdateViewTimes(string ipid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Views=Views + 1 where ipid=@ipid", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
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

        # region Chekdata
        public List<Products> Chekdata(string ipid, string Chekdata, DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Chekdata=@Chekdata,Create_Date=@Create_Date,Modified_Date=@Modified_Date where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Chekdata", Chekdata));
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        # region Update_datetime
        public List<Products> Update_datetime(string ipid,DateTime Create_Date, DateTime Modified_Date)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Create_Date=@Create_Date,Modified_Date=@Modified_Date where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Create_Date", Create_Date));
            comm.Parameters.Add(new SqlParameter("@Modified_Date", Modified_Date));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region Detail_ID
        public void Detail_ID(DataTable dts, string ipid)
        {
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [products] WHERE ipid = " + ipid + "", conn);
            comm.CommandType = CommandType.Text;
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
        }
        #endregion

        #region[Update_Images]
        public bool Update_Images(string ipid, string Images, string ImagesSmall)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Images='',ImagesSmall='' where ipid=@ipid", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            comm.Parameters.Add(new SqlParameter("@Images", Images));
            comm.Parameters.Add(new SqlParameter("@ImagesSmall", ImagesSmall));

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

        #region Chek
        #region Update_Status
        public List<Products> Update_Status(string ipid, string Status)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Status= @Status where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Status", Status));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_News
        public List<Products> Update_News(string ipid, string News)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set News= @News where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@News", News));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Home
        public List<Products> Update_Home(string ipid, string Home)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Home= @Home where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Home", Home));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Check_01
        public List<Products> Update_Check_01(string ipid, string Check_01)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Check_01= @Check_01 where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Check_01", Check_01));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Check_02
        public List<Products> Update_Check_02(string ipid, string Check_02)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Check_02= @Check_02 where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Check_02", Check_02));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Check_03
        public List<Products> Update_Check_03(string ipid, string Check_03)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Check_03= @Check_03 where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Check_03", Check_03));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Check_04
        public List<Products> Update_Check_04(string ipid, string Check_04)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Check_04= @Check_04 where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Check_04", Check_04));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #region Update_Check_05
        public List<Products> Update_Check_05(string ipid, string Check_05)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("update products set Check_05= @Check_05 where ipid= @ipid", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Check_05", Check_05));
            comm.Parameters.Add(new SqlParameter("@ipid", ipid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        #endregion

        #region pro_new
        public List<Products> pro_new(string top)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE News = 1 Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region pro_vip
        public List<Products> pro_vip(string top)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE Check_03 = 1 Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region pro_show
        public List<Products> pro_show(string top)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE Check_04 = 1 Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region pro_mostview
        public List<Products> pro_mostview(string top)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE Check_02 = 1 Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region pro_sellmost
        public List<Products> pro_sellmost(string top)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE Check_01 = 1 Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region SEARCH
        public List<Products> Search(string keyword, string lang)
        {
            string sql = @"select * from products  where (Name like '%'+@keyword1+'%'  or Brief like '%'+@keyword2+'%' or Code like '%'+@keyword3+'%' or Contents like '%'+@keyword4+'%'  or search like '%'+@keyword5+'%') and lang=@Lang and Status=1  and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc";
            List<Products> list = new List<Products>();
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@Lang", lang));
            comm.Parameters.Add(new SqlParameter("@keyword1", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword2", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword3", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword4", keyword));
            comm.Parameters.Add(new SqlParameter("@keyword5", keyword));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region pronew_id
        public List<Products> pronew_id(string top, string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE News = 1 AND icid in (" + icid + ") Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        #region prosellmost_id
        public List<Products> prosellmost_id(string top, string icid)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("SELECT TOP " + top + " * FROM [products] WHERE Check_01 = 1 AND icid in (" + icid + ") Order By Create_Date DESC", conn);
            comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@icid", icid));
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        public List<Products> Name_Text(string Name_Text)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(Name_Text, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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

        public List<Products> SearchNews(string keyword, string lang)
        {
            string sql = SearchApproximate.ApproximateSearch(keyword, lang);
            List<Products> list = new List<Products>();
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                return Database.Bind_List_Reader<Products>(comm);
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
        public class SearchApproximate
        {
            // Phương thức trả về câu lệnh SQL dùng truy vấn dữ liệu
            public static string ApproximateSearch(string keyWord, string lang)
            {
                string sql = "SELECT * FROM products WHERE Name LIKE N'" + Exec(keyWord) + "' OR Brief LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' OR Code LIKE N'" + Exec(ConvertVN.Convert(keyWord)) + "' and lang='" + lang + "' and Status=1  and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc";
                return sql;
            }
            // Phương thức chuyển đổi một chuỗi ký tự: Nếu chuỗi đó có ký tự " " sẽ thay thế bằng "%"
            public static string Exec(string keyWord)
            {
                string[] arrWord = keyWord.Split(' ');
                StringBuilder str = new StringBuilder("%");
                for (int i = 0; i < arrWord.Length; i++)
                {
                    str.Append(arrWord[i] + "%");
                }
                return str.ToString();
            }
        }
        public class ConvertVN
        {
            // Phương thức Convert một chuỗi ký tự Có dấu sang Không dấu
            public static string Convert(string chucodau)
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = chucodau.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(chucodau[index]);
                    chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
                }
                return chucodau;
            }
        }
    }
}