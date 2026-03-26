using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Vote
{
    public partial class index : System.Web.UI.Page
    {
        private string language = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region #
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            #endregion
            this.loadvotelist();
        }
        private void loadvotelist()
        {
            int num = 0;
            List<Entity.Menu> table = SMenu.capp_Lang_Parent_ID_Status(More.VO, language, "-1", "1");
            if (table.Count > 0)
            {
                this.ltTitle.Text = table[0].Name.ToString();
            }
            table = SMenu.capp_Lang_Parent_ID_Status(More.VO, language, "-1", "1");
            for (int i = 0; i < table.Count; i++)
            {
                num += Convert.ToInt32(table[i].Views.ToString());
            }
            this.lttotalvote.Text = FomatPrice(num.ToString());
            this.rpvotelist.DataSource = table;
            this.rpvotelist.DataBind();
        }
        public static string FomatPrice(string price)
        {
            if (price.Length > 3)
            {
                for (int i = price.Length - 3; i > 0; i -= 3)
                {
                    price = price.Insert(i, ".");
                }
            }
            return price;
        }
        protected string Statistic(string vote, string color)
        {
            string str = "";
            double num = Convert.ToInt32(this.lttotalvote.Text);
            if (!num.Equals((double)0.0))
            {
                num = (((double)Convert.ToInt32(vote)) / num) * 100.0;
                num = Math.Round(num, 1);
            }
            object obj2 = str;
            return string.Concat(new object[] { obj2, "<td width='180px'><span style='height:22px;display:inline-block;background-color:#", color, ";width:", Math.Round(num, 0), "%'></span></td><td width=63 align='right'><span>&nbsp;<b>", num.ToString(), " %</b>&nbsp;</span></td>" });
        }
    }
}