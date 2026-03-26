using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Services;
using Framework;

namespace VS.E_Commerce.cms.Display.Vote
{
    public partial class Vote : System.Web.UI.UserControl
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
            if (!base.IsPostBack)
            {
                this.Loaddata();
                this.Button1.Text = this.label("l_voteting");
            }
        }
        private void Loaddata()
        {
            DataTable table2 = new DataTable();
            FMenu dt = new FMenu();
            table2 = dt.DataTable_capp_Lang_MoreIn_ID_Status(More.VO, language, "-1", "1");
            if (table2.Rows.Count > 0)
            {
                this.rblvotelist.DataSource = table2;
                this.rblvotelist.DataTextField = "Name";
                this.rblvotelist.DataValueField = "ID";
                this.rblvotelist.DataBind();
                if (MoreAll.MoreAll.GetCookie("Cookievote").Equals(table2.Rows[0]["ID"].ToString()))
                {
                    this.Button1.Enabled = false;
                }
                this.hdvoteid.Value = table2.Rows[0]["ID"].ToString();
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((this.rblvotelist.SelectedItem == null) || (this.rblvotelist.SelectedIndex < 0))
            {
                this.ltmsg.Text = this.label("l_youmustchosevotes");
            }
            else
            {
                SMenu.Name_Text("UPDATE [Menu] SET Views=Views + 1  WHERE id= " + this.rblvotelist.SelectedValue + "");
                List<Entity.Menu> table = SMenu.Detail(this.rblvotelist.SelectedValue);
                if (table.Count > 0)
                {
                    this.ltmsg.Text = this.label("l_thankforvote");
                    string text = this.ltmsg.Text;
                    this.ltmsg.Text = text + "<br>" + this.label("l_have") + " " + table[0].Views.ToString() + " " + this.label("l_samevotewithyou");
                }
                MoreAll.MoreAll.SetCookie("Cookievote", this.hdvoteid.Value, 10);
                {
                    this.Button1.Enabled = false;
                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}