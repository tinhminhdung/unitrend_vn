using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using System.Text;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Search_tag : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        string keyword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            if (!IsPostBack)
            {
                CollectionPager1.FirstText = label("trangdau");
                CollectionPager1.LastText = label("trangcuoi");
                if (Request["keywordtg"] != null && !Request["keywordtg"].Equals(""))
                {
                    keyword = Request["keywordtg"].ToString();
                }
            }
            if (Request["keywordtg"] != null && !Request["keywordtg"].Equals(""))
            {
                LoadItems();
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        void LoadItems()
        {
            List<Entity.Products> dt = SProducts.Name_Text("select  * from products  where dbo.fuConvertToUnsign(Noidung1)  LIKE N'" + Exec(Converts(keyword.Replace("-", " "))) + "'  and Status=1   order by Create_Date desc");
            //Response.Write("select  * from products  where dbo.fuConvertToUnsign(Anh)  LIKE N'" + Exec(Converts(keyword.Replace("-", " "))) + "'  and Status=1   order by Create_Date desc");
            //SProducts.SearchNews(keyword.Replace("-", " "), language);
            //SProducts.Search(keyword.Replace("-", " "), language);
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MorePro.Pages());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else
            {
                lterr.Text += "<div class='ttimkiem'><p style='margin-top: 0.33em'>Không tìm thấy <span style='color:Red;'> <b>" + keyword.Replace("-", " ") + "</b></span>  trong tài liệu nào.</p><p style='margin-top: 1em'>Ðề xuất:</p><ul style='margin: 0px 0px 2em 1.3em'> <li>Xin bạn chắc chắn rằng tất cả các từ đều đúng chính tả. </li><li>Hãy thử những từ khoá khác. </li><li>Hãy thử những từ khoá chung hơn.</li></ul></div>";
                lterr.Text += "<div class='ndungtimkiem'>" + MoreAll.Other.Giatri("txttimkiem") + "</div>";
            }
        }

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

        public static string Converts(string chucodau)
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

        public string Giamgia(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {
                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai) / cu) * 100);
                    Tong = System.Math.Round(Tong, 0);
                    Width += " <span class=\"label-sale\">-" + Tong.ToString() + "%</span>";
                }
            }
            return Width.ToString();
        }

    }
}