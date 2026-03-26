using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Entity;
using System.Data.SqlClient;

namespace Framwork
{
    public class FCartDetail
    {
        #region[GetById]
        public List<CartDetail> GetById(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.Add(new SqlParameter("@Id", Id));
            try
            {
                return Database.Bind_List_Reader<CartDetail>(comm);
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
        public List<CartDetail> GetByAll()
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_GetByAll", conn);
            comm.CommandType = CommandType.StoredProcedure;

            try
            {
                return Database.Bind_List_Reader<CartDetail>(comm);
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
        public bool Insert(CartDetail obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("INSERT INTO [CartDetail]([ID_Cart], [ipid], [Price], [Quantity], [Money],[Ghichu],[Donvitinh],[Trongluong])	VALUES(@ID_Cart, @ipid, @Price, @Quantity, @Money, @Ghichu,@Donvitinh,@Trongluong)", conn);
            comm.CommandType = CommandType.Text;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID_Cart", obj.ID_Cart));
            comm.Parameters.Add(new SqlParameter("@ipid", obj.ipid));
            comm.Parameters.Add(new SqlParameter("@Price", obj.Price));
            comm.Parameters.Add(new SqlParameter("@Quantity", obj.Quantity));
            comm.Parameters.Add(new SqlParameter("@Money", obj.Money));
            comm.Parameters.Add(new SqlParameter("@Ghichu", obj.Ghichu));
            comm.Parameters.Add(new SqlParameter("@Donvitinh", obj.Donvitinh));
            comm.Parameters.Add(new SqlParameter("@Trongluong", obj.Trongluong));
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
        public bool Update(CartDetail obj)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_Update", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlTransaction tran = conn.BeginTransaction();
            comm.Transaction = tran;
            comm.Parameters.Add(new SqlParameter("@ID", obj.ID));
            comm.Parameters.Add(new SqlParameter("@ID_Cart", obj.ID_Cart));
            comm.Parameters.Add(new SqlParameter("@ipid", obj.ipid));
            comm.Parameters.Add(new SqlParameter("@Price", obj.Price));
            comm.Parameters.Add(new SqlParameter("@Quantity", obj.Quantity));
            comm.Parameters.Add(new SqlParameter("@Money", obj.Money));

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
            SqlCommand comm = new SqlCommand("S_CartDetail_Delete", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Id", Id));
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

        #region Detail_ID_Cart
        public List<CartDetail> Detail_ID_Cart(string ID_Cart)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_List_inCart", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID_Cart", ID_Cart));
            try
            {
                return Database.Bind_List_Reader<CartDetail>(comm);
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

        #region DetailID
        public List<CartDetail> DetailID(string Id)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_GetById", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@Id", Id));
            try
            {
                return Database.Bind_List_Reader<CartDetail>(comm);
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

        #region Delete_ID_Cart
        public void Delete_ID_Cart(string ID_Cart)
        {
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("S_CartDetail_Delete_by_CartID", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@ID_Cart", ID_Cart));
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

        #region CartDetail_List_Cart_Pro
        public void CartDetail_List_Cart_Pro(DataTable dts, string ID_Cart)
        {
            SqlDataAdapter VSda;
            SqlConnection conn = Database.Connection();
            SqlCommand comm = new SqlCommand("select pc.*,p.Name from CartDetail as pc left join  products  as p ON pc.ipid = p.ipid where pc.ID_Cart=@ID_Cart", conn);
            comm.Parameters.Add(new SqlParameter("@ID_Cart", ID_Cart));
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

        public List<CartDetail> Name_Text(string Text)
        {
            List<CartDetail> list;
            SqlConnection connection = Database.Connection();
            SqlCommand command = new SqlCommand(Text, connection)
            {
                CommandType = CommandType.Text
            };
            try
            {
                list = Database.Bind_List_Reader<CartDetail>(command);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                connection.Close();
            }
            return list;
        }
    }
}