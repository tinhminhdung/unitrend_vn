using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framwork;
using Entity;
using System.Data.SqlClient;
using System.Data;

namespace Services
{
    public class SessionCarts
    {
        #region "Cart"
        public static void ShoppingCreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(Int32));
            dt.Columns.Add("Vimg", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("VATPercent", typeof(float));    // VAT %
            dt.Columns.Add("VATAmount", typeof(float));     // Tiền VAT
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Money", typeof(float));
            dt.Columns.Add("Ghichu", typeof(String));
            dt.Columns.Add("Trongluong", typeof(Int32));
            dt.Columns.Add("TongTrongluong", typeof(float));
            dt.Columns.Add("TienTrongluong", typeof(float));
            dt.Columns.Add("Tongsocan", typeof(float));
            System.Web.HttpContext.Current.Session["cart"] = dt;
        }

        static void ShoppingCart_CreateCart()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PID", typeof(Int32));
            dt.Columns.Add("Vimg", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Price", typeof(float));
            dt.Columns.Add("VATPercent", typeof(float));    // VAT %
            dt.Columns.Add("VATAmount", typeof(float));     // Tiền VAT
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Money", typeof(float));
            dt.Columns.Add("Ghichu", typeof(String));
            dt.Columns.Add("Trongluong", typeof(Int32));
            dt.Columns.Add("TongTrongluong", typeof(float));
            dt.Columns.Add("TienTrongluong", typeof(float));
            dt.Columns.Add("Tongsocan", typeof(float));
            System.Web.HttpContext.Current.Session["cart"] = dt;
        }




        public static void ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
        }

        public static void Cart_UpdateNumber(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["Quantity"] = quantity;
                        float price = 0;
                        int Soluong = int.Parse(quantity);
                        List<Products> iitem = SProducts.GetById(pid);
                        if (iitem.Count > 0)
                        {
                            if (quantity.ToString().Length > 0)
                            {
                                price += Convert.ToSingle(iitem[0].Price.ToString());
                            }
                        }
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(price);
                        dtcart.Rows[i]["price"] = Convert.ToDouble(price);
                        return;
                    }
                }
            }
        }
        public static void Cart_UpdateGhichu(ref DataTable dtcart, string pid, string Ghichu)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["Ghichu"] = Ghichu;
                        return;
                    }
                }
            }
        }
        public static void Cart_Updatequantity(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        int Soluong = int.Parse(quantity);
                        float price = 0;         // Giá chưa VAT
                        float vatPercent = 0;    // VAT %
                        float kg = 0;            // Trọng lượng

                        List<Products> iitem = SProducts.GetById(pid);
                        if (iitem.Count > 0)
                        {
                            price = Convert.ToSingle(iitem[0].Price); // Giá chưa VAT
                            float.TryParse(iitem[0].Noidung4, out vatPercent); // VAT %
                            float.TryParse(iitem[0].Noidung2, out kg);          // Trọng lượng
                        }

                        // ✅ Tính tiền VAT và tổng tiền
                        float vatAmount = (float)Math.Round(price * vatPercent / 100f, 0); // Làm tròn tiền VAT
                        float priceWithVAT = price + vatAmount;
                        float money = Soluong * priceWithVAT;

                        // ✅ Trọng lượng
                        float tongTrongluong = kg;
                        float tienTrongluong = Soluong * tongTrongluong;
                        float tongSocan = Soluong * kg;

                        // ✅ Cập nhật lại DataTable
                        dtcart.Rows[i]["Quantity"] = Soluong;
                        dtcart.Rows[i]["Price"] = price;             // Giá chưa VAT
                        dtcart.Rows[i]["VATPercent"] = vatPercent;   // VAT phần trăm
                        dtcart.Rows[i]["VATAmount"] = vatAmount;     // Số tiền VAT
                        dtcart.Rows[i]["Money"] = money;             // Tổng tiền gồm VAT
                        dtcart.Rows[i]["TongTrongluong"] = tongTrongluong;
                        dtcart.Rows[i]["TienTrongluong"] = tienTrongluong;
                        dtcart.Rows[i]["Tongsocan"] = tongSocan;

                        return;
                    }
                }
            }
        }



        public static void ShoppingCart_AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                ShoppingCart_CreateCart();
                ShoppingCart_AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    string VAT = dt[0].Noidung4.ToString();  // Ví dụ: "10" hoặc "8"
                    string Trongluong = dt[0].Noidung2;

                    float price = Convert.ToSingle(dt[0].Price); // Giá gốc chưa VAT
                    float vatPercent = 0;
                    float.TryParse(VAT, out vatPercent);
                    float priceWithVAT = price * (1 + vatPercent / 100f); // Giá sau VAT
                    float tongTrongluong = Convert.ToSingle(dt[0].Noidung2);
                    float kg = tongTrongluong;


                    // Tính VAT thực tế
                    float vatPercent2 = 0;
                    float.TryParse(VAT, out vatPercent2);

                    // Tính tiền VAT tròn
                    double vatAmount = Math.Round(price * vatPercent2 / 100.0, 0);  // Làm tròn đến 1,000
                    double priceDaVAT = price + vatAmount;


                    float money = priceWithVAT * quantity;
                    float tienTrongluong = tongTrongluong * quantity;

                    DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                    bool hasincart = false;

                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                        {
                            hasincart = true;
                            quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                            dtcart.Rows[i]["Quantity"] = quantity;

                            // Cập nhật lại Money theo VAT
                            float priceOld = Convert.ToSingle(dtcart.Rows[i]["Price"]);
                            float vatOld = 0;
                            float.TryParse(dtcart.Rows[i]["VAT"].ToString(), out vatOld);
                            float priceWithVAT_Old = priceOld * (1 + vatOld / 100f);
                            dtcart.Rows[i]["Money"] = quantity * priceWithVAT_Old;

                            dtcart.Rows[i]["TienTrongluong"] = quantity * Convert.ToSingle(dtcart.Rows[i]["TongTrongluong"]);
                            dtcart.Rows[i]["Tongsocan"] = quantity * Convert.ToSingle(kg);

                            System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            break;
                        }
                    }

                    if (!hasincart)
                    {
                        if (dtcart != null)
                        {
                            DataRow dr = dtcart.NewRow();
                            dr["PID"] = pid;
                            dr["Vimg"] = vimg;
                            dr["Name"] = name;
                            dr["Price"] = price;              // Giá gốc
                            dr["VATPercent"] = vatPercent;      // VAT phần trăm (10)
                            dr["VATAmount"] = vatAmount;
                            dr["Quantity"] = quantity;
                            dr["Money"] = money;             // Giá đã có VAT * số lượng
                            dr["Trongluong"] = Trongluong;
                            dr["TongTrongluong"] = tongTrongluong;
                            dr["TienTrongluong"] = tienTrongluong;
                            dr["Tongsocan"] = kg;

                            dtcart.Rows.Add(dr);
                            System.Web.HttpContext.Current.Session["cart"] = dtcart;
                        }
                    }
                }
            }
        }

        public static void ShoppingCart_AddProduct_old(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                ShoppingCart_CreateCart();
                ShoppingCart_AddProduct_old(pid, quantity);
            }
            else
            {
                List<Products> dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    string VAT = dt[0].Noidung4.ToString();  // Ví dụ: "10" hoặc "8"
                    string Trongluong = dt[0].Noidung2;

                    float price = Convert.ToSingle(dt[0].Price); // Giá gốc chưa VAT
                    float vatPercent = 0;
                    float.TryParse(VAT, out vatPercent);
                    float priceWithVAT = price * (1 + vatPercent / 100f); // Giá sau VAT
                    float tongTrongluong = Convert.ToSingle(dt[0].Noidung2);
                    float kg = tongTrongluong;

                    float money = priceWithVAT * quantity;
                    float tienTrongluong = tongTrongluong * quantity;

                    DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                    bool hasincart = false;

                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                        {
                            hasincart = true;
                            quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                            dtcart.Rows[i]["Quantity"] = quantity;

                            // Cập nhật lại Money theo VAT
                            float priceOld = Convert.ToSingle(dtcart.Rows[i]["Price"]);
                            float vatOld = 0;
                            float.TryParse(dtcart.Rows[i]["VAT"].ToString(), out vatOld);
                            float priceWithVAT_Old = priceOld * (1 + vatOld / 100f);
                            dtcart.Rows[i]["Money"] = quantity * priceWithVAT_Old;

                            dtcart.Rows[i]["TienTrongluong"] = quantity * Convert.ToSingle(dtcart.Rows[i]["TongTrongluong"]);
                            dtcart.Rows[i]["Tongsocan"] = quantity * Convert.ToSingle(kg);

                            System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            break;
                        }
                    }

                    if (!hasincart)
                    {
                        if (dtcart != null)
                        {
                            DataRow dr = dtcart.NewRow();
                            dr["PID"] = pid;
                            dr["Vimg"] = vimg;
                            dr["Name"] = name;
                            dr["Price"] = price;              // Giá gốc
                            dr["VAT"] = vatPercent;          // VAT %
                            dr["Quantity"] = quantity;
                            dr["Money"] = money;             // Giá đã có VAT * số lượng
                            dr["Trongluong"] = Trongluong;
                            dr["TongTrongluong"] = tongTrongluong;
                            dr["TienTrongluong"] = tienTrongluong;
                            dr["Tongsocan"] = kg;

                            dtcart.Rows.Add(dr);
                            System.Web.HttpContext.Current.Session["cart"] = dtcart;
                        }
                    }
                }
            }
        }

        public static void AddProduct_Old(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                // create session cart.
                ShoppingCart_CreateCart();
                AddProduct_Old(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string name = dt[0].Name.ToString();
                    string vimg = dt[0].Images.ToString();
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        float prices = 0;
                        if (quantity.ToString().Length > 0)
                        {
                            prices += Convert.ToSingle(dt[0].Price);
                        }
                        float money = prices * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(prices);

                                //
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = prices;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float price = Convert.ToSingle(0);
                        float money = price * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);

                                float prices = 0;
                                if (quantity.ToString().Length > 0)
                                {
                                    prices += Convert.ToSingle(dt[0].Price);
                                }
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(prices);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Cart_Calculate_Cart
        public static void Cart_Calculate_Cart(List<CartDetail> dtcart, ref string inumofproducts, ref string totalvnd)
        {
            try
            {
                if (dtcart.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    for (int i = 0; i < dtcart.Count; i++)
                    {
                        num += Convert.ToDouble(dtcart[i].Money.ToString());
                        num2 += Convert.ToInt32(dtcart[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                    inumofproducts = num2.ToString();
                }
            }
            catch (Exception)
            { }
        }
        #endregion


        public static string LoadCart()
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable cartdetail = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (cartdetail.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    // S_Product_Carts.Cart_Calculate_Cart(ref cartdetail, ref inumofproducts, ref totalvnd);
                    if (cartdetail.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < cartdetail.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(cartdetail.Rows[i]["Money"].ToString());
                            num2 += Convert.ToInt32(cartdetail.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    return inumofproducts;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
    }
}



