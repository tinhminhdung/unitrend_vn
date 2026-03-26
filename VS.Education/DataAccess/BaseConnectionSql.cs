using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Globalization;
using System.Reflection;
using System.Text;
using Entity;
using System.Collections;

public class BaseConnectionSql
{
    private static readonly Hashtable ParamCache = Hashtable.Synchronized(new Hashtable());
    public static DataTable Execute_Table<Tkey>(string Stored, Tkey item)
    {
        DataSet ds = new DataSet();
        StringBuilder str = new StringBuilder();
        try
        {
            var strCons = (ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            using (var con = new SqlConnection(strCons))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Stored, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                PropertyInfo[] props = typeof(Tkey).GetProperties();
                object value1;
                foreach (PropertyInfo prop in props)
                {
                    value1 = prop.GetValue(item, null);
                    if (value1 != null)
                    {
                        var p = new System.Data.SqlClient.SqlParameter
                        {
                            ParameterName = prop.Name,
                            Value = value1
                        };
                        if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
                        {
                            //ignore
                        }
                        else
                        {
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
                        }
                    }
                }

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
                con.Close();
                return ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            return ds.Tables[0];
        }
    }
    public static bool Execute_Update_Insert<TValue>(string Stored, TValue item)
    {
        StringBuilder str = new StringBuilder();
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        var kq = new List<TValue>();
        try
        {
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Stored, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                PropertyInfo[] props = typeof(TValue).GetProperties();
                object value1;
                foreach (PropertyInfo prop in props)
                {
                    value1 = prop.GetValue(item, null);
                    if (value1 != null)
                    {
                        var p = new System.Data.SqlClient.SqlParameter
                        {
                            ParameterName = prop.Name,
                            Value = value1
                        };
                        if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
                        {
                            //ignore
                        }
                        else
                        {
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
                        }
                    }
                }
                var reader = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }
        catch (Exception ex)
        {
            con.Close();
            return false;
        }
    }
    public static bool Execute_Update_Insert_V1(string Stored, params object[] parameterValues)
    {
        StringBuilder str = new StringBuilder();
        var con = new SqlConnection((ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString));

        try
        {
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Stored, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;

                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    var commandParameters = GetSpParameterSet((ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString), Stored);

                    //Số lượng tham số không khớp với số lượng Giá trị tham số
                    if (commandParameters.Length != parameterValues.Length)
                    {
                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
                    }
                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
                    for (int i = 0, j = commandParameters.Length; i < j; i++)
                    {
                        // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
                        if (parameterValues[i] == null)
                        {
                            var p = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = DBNull.Value
                            };
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
                        }
                        else
                        {
                            var p = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = parameterValues[i]
                            };
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
                        }
                    }
                }

                var reader = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }
        catch (Exception ex)
        {
            con.Close();
            return false;
        }
    }
    public static DataTable ExecuteDataTable_V1(string Stored, params object[] parameterValues)
    {
        DataSet ds = new DataSet();
        StringBuilder str = new StringBuilder();
        try
        {
            var strCons = (ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); ;
            using (var con = new SqlConnection(strCons))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Stored, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;

                if ((parameterValues != null) && (parameterValues.Length > 0))
                {
                    var commandParameters = GetSpParameterSet((ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString), Stored);

                    //Số lượng tham số không khớp với số lượng Giá trị tham số
                    if (commandParameters.Length != parameterValues.Length)
                    {
                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
                    }
                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
                    for (int i = 0, j = commandParameters.Length; i < j; i++)
                    {
                        // Nếu giá trị mảng hiện tại xuất phát từ IDbDataParameter, thì hãy gán thuộc tính Giá trị của nó
                        if (parameterValues[i] == null)
                        {
                            var p = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = DBNull.Value
                            };
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + DBNull.Value + "));");
                        }
                        else
                        {
                            var p = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = parameterValues[i]
                            };
                            cmd.Parameters.Add(p);
                            str.Append("cmd.Parameters.Add(new SqlParameter(" + commandParameters[i].ToString() + ", " + parameterValues[i] + "));");
                        }
                    }
                }

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds);
                }
                con.Close();
                return ds.Tables[0];
            }
        }
        catch (Exception ex)
        {
            return ds.Tables[0];
        }
    }
    public static bool Execute_Stored(string Stored)
    {
        string chuoi = "";
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        try
        {
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Stored, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 30000;
                var reader = cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
        }
        catch (Exception ex)
        {
            con.Close();
            return false;
        }
    }
    public static List<TValue> ExecuteList_V1<TValue>(string Stored, params object[] parameterValues) where TValue : new()
    {
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        var kq = new List<TValue>();
        StringBuilder str = new StringBuilder();
        try
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Stored, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Parameters

                    if (parameterValues == null || parameterValues.Length == 0)
                    {
                        throw new ArgumentException("Không có giá trị tham số nào, không cần xử lý gì.");
                    }

                    var commandParameters = GetSpParameterSet(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, Stored);

                    // Thiếu thông tin về các tham số, ném ra một ArgumentException.
                    if (commandParameters.Length != parameterValues.Length)
                    {
                        throw new ArgumentException("Số lượng tham số không khớp với số lượng Giá trị tham số.");
                    }

                    // Lặp lại thông qua SqlParameters, gán các giá trị từ vị trí tương ứng trong
                    for (int i = 0, j = commandParameters.Length; i < j; i++)
                    {
                        var currentValue = parameterValues[i]; // Giá trị hiện tại của tham số.

                        if (currentValue is IDbDataParameter dbParam) // Kiểm tra tham số có phải là IDbDataParameter.
                        {
                            var sqlParam = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = dbParam.Value ?? DBNull.Value
                            };
                            cmd.Parameters.Add(sqlParam);
                            str.Append($"cmd.Parameters.Add(new SqlParameter({commandParameters[i]}, {dbParam.Value ?? DBNull.Value}));");
                        }
                        else // Tham số không phải là IDbDataParameter, xử lý bình thường.
                        {
                            var sqlParam = new SqlParameter
                            {
                                ParameterName = commandParameters[i].ToString(),
                                Value = currentValue ?? DBNull.Value
                            };
                            cmd.Parameters.Add(sqlParam);
                            str.Append($"cmd.Parameters.Add(new SqlParameter({commandParameters[i]}, {currentValue ?? DBNull.Value}));");
                        }
                    }

                    //while
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                            while (reader.Read())
                            {
                                TValue obj = new TValue(); // Cần khai báo obj ở đây để tránh lỗi CS0103

                                foreach (var column in columns)
                                {
                                    var property = typeof(TValue).GetProperty(column, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                                    if (property == null || reader[column] is DBNull) continue;

                                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                    object value = Convert.ChangeType(reader[column], targetType);
                                    property.SetValue(obj, value, null);
                                }

                                kq.Add(obj);
                            }
                            return kq;
                        }
                    }
                    catch (Exception ex)
                    { }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return kq;
        }
        catch (Exception ex)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
            return kq;
        }
    }
    public static List<TValue> ExecuteList<Tkey, TValue>(string Stored, Tkey item) where TValue : new()
    {
        var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        var kq = new List<TValue>();
        StringBuilder str = new StringBuilder();
        try
        {
            try
            {
                using (con)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(Stored, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Parameters

                    PropertyInfo[] props = typeof(Tkey).GetProperties();
                    object value1;
                    foreach (PropertyInfo prop in props)
                    {
                        value1 = prop.GetValue(item, null);
                        if (value1 != null)
                        {
                            var p = new System.Data.SqlClient.SqlParameter
                            {
                                ParameterName = prop.Name,
                                Value = value1
                            };
                            if (prop.PropertyType == typeof(DateTime) && (DateTime)value1 == DateTime.MinValue)
                            {
                                //ignore
                            }
                            else
                            {
                                cmd.Parameters.Add(p);
                                str.Append("cmd.Parameters.Add(new SqlParameter(" + prop.Name + ", " + value1 + "));");
                            }
                        }
                    }

                    //while
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                            while (reader.Read())
                            {
                                TValue obj = new TValue(); // Cần khai báo obj ở đây để tránh lỗi CS0103

                                foreach (var column in columns)
                                {
                                    var property = typeof(TValue).GetProperty(column, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                                    if (property == null || reader[column] is DBNull) continue;

                                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                    object value = Convert.ChangeType(reader[column], targetType);
                                    property.SetValue(obj, value, null);
                                }

                                kq.Add(obj);
                            }
                            return kq;
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return kq;
        }
        catch (Exception ex)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            LogBuild.CreateLogger(str.ToString(), Stored + "_Param");
            LogBuild.CreateLogger("Error: " + ex.ToString(), Stored);
            return kq;
        }

    }
    public static List<objCombox> objCombox_Text(string Text)
    {
        SqlConnection conn = Database.Connection();
        SqlCommand comm = new SqlCommand(Text, conn);
        comm.CommandType = CommandType.Text;
        try
        {
            return Database.Bind_List_Reader<objCombox>(comm);
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
    public static List<objTaiLieuSP> objTaiLieuSP_Text(string Text, int ipid)
    {
        SqlConnection conn = Database.Connection();
        SqlCommand comm = new SqlCommand(Text, conn);
        comm.CommandType = CommandType.StoredProcedure;
        comm.Parameters.Add(new SqlParameter("@ipid", ipid));
        try
        {
            return Database.Bind_List_Reader<objTaiLieuSP>(comm);
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

    #region SqlParameter[]
    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName)
    {
        return GetSpParameterSet(connectionString, spName, false);
    }
    public static SqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
    {
        if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException("connectionString");
        if (string.IsNullOrEmpty(spName)) throw new ArgumentNullException("spName");

        using (var connection = new SqlConnection(connectionString))
        {
            return GetSpParameterSetInternal(connection, spName, includeReturnValueParameter);
        }
    }
    private static SqlParameter[] GetSpParameterSetInternal(SqlConnection connection, string spName, bool includeReturnValueParameter)
    {
        if (connection == null) throw new ArgumentNullException("connection");

        if (spName == "") throw new ArgumentNullException("spName");

        string hashKey = connection.ConnectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

        SqlParameter[] cachedParameters = ParamCache[hashKey] as SqlParameter[] ?? new SqlParameter[1];

        if (cachedParameters.Length == 1)
        {
            if (cachedParameters[0] == null)
            {
                cachedParameters = DiscoverSpParameterSet(connection, spName, includeReturnValueParameter);
                ParamCache[hashKey] = cachedParameters;
            }
        }
        return CloneParameters(cachedParameters);
    }
    private static SqlParameter[] DiscoverSpParameterSet(SqlConnection connection, string spName, bool includeReturnValueParameter)
    {
        if (connection == null) throw new ArgumentNullException("connection");
        if (string.IsNullOrEmpty(spName)) throw new ArgumentNullException("spName");

        var cmd = new SqlCommand(spName, connection) { CommandType = CommandType.StoredProcedure };

        connection.Open();
        SqlCommandBuilder.DeriveParameters(cmd);
        connection.Close();

        if (!includeReturnValueParameter)
        {
            cmd.Parameters.RemoveAt(0);
        }

        var discoveredParameters = new SqlParameter[cmd.Parameters.Count];

        cmd.Parameters.CopyTo(discoveredParameters, 0);

        // Init the parameters with a DBNull value
        foreach (var discoveredParameter in discoveredParameters)
        {
            discoveredParameter.Value = DBNull.Value;
        }

        return discoveredParameters;
    }
    private static SqlParameter[] CloneParameters(IList<SqlParameter> originalParameters)
    {
        var clonedParameters = new SqlParameter[originalParameters.Count];

        for (int i = 0, j = originalParameters.Count; i < j; i++)
        {
            clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();
        }

        return clonedParameters;
    }
    #endregion

    // Name_Text
    //var dt = BaseConnectionSql.Name_Text<Entity.Menu>("select * from Menu where capp='PR' ");
    //string chuoi = "";
    //foreach (var item in dt)
    //{
    //    chuoi += item.Name + "<br>";
    //}
    //ViewBag.chuoi = chuoi;

    // BaseConnectionSql.Execute_Update_Insert_V1("update  Menu set Name=N'Tin tức & sự kiện' where id=786 ");

    //var item = new Entity.News()
    //{
    //    Title = "",
    //    Brief="",
    //};
    //var btsave = BaseConnectionSql.Execute_Update_Insert<Entity.News>("Execute_Update_Insert", btsave);
    //if (btsave)
    //{
    //}

}
