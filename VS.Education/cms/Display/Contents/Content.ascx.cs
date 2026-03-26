using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Display.Contents
{
    public partial class Content : System.Web.UI.UserControl
    {
        protected string app = "";
        private string p = "-1";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        string nav = "";
        string Type = "0";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
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
            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion
            #region Request
            #endregion
            List<MNews> table = new List<MNews>();
            if (!base.IsPostBack)
            {
                if (Request["e"] != null)
                {
                    if (Request["e"].ToString() == "load")
                    {
                        Type = MoreAll.Other.RequestMenu(Request["hp"]);
                    }
                }
                //#region Module
                //if (Request["e"] != null)
                //{
                //    if (Request["e"].ToString() == "load")
                //    {
                //        var Giatri1 = db.Menus.Where(s => s.TangName == Request["hp"].ToString()).ToList();
                //        var Giatri2 = db.Menus.Where(s => s.TangName == Giatri1[0].TangName).FirstOrDefault();
                //        if (Giatri1.Count > 0 || Giatri2 != null)
                //        {
                //            Type = Giatri1 != null ? Giatri2.Styleshow.ToString() : Giatri1[0].Styleshow.ToString();
                //        }
                //    }
                //}
                //#endregion

                #region MyRegion
                List<Entity.Menu> dt = SMenu.GETBYID(More.TangNameicid(hp));
                if (dt.Count > 0)
                {
                    ltcatename.Text = dt[0].Name.ToString();
                }
                #endregion
            }

            #region 0
            if (this.Type.Equals("0"))
            {
                if (this.p.Equals("-1"))
                {
                    table = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                    if (table.Count > 0)
                    {
                        this.lttitle.Text = table[0].Title.ToString();
                        this.ltcontent.Text = table[0].Contents.ToString();
                    }
                }
                else
                {
                    table = SMNews.GET_BY_ID(this.p);
                    if (table.Count > 0)
                    {
                        this.lttitle.Text = table[0].Title.ToString();
                        this.ltcontent.Text = table[0].Contents.ToString();
                    }
                }
                if (table.Count > 0)
                {
                    table = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                    this.rpOtherPage.DataSource = table;
                    this.rpOtherPage.DataBind();
                }
                this.MultiView1.SetActiveView(this.vwpage);
            }
            #endregion
            #region 1
            else if (this.Type.Equals("1"))
            {
                table = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                this.rppages.DataSource = table;
                this.rppages.DataBind();
                this.MultiView1.SetActiveView(this.vwpages);
            }
            #endregion
            #region 2
            else if (this.Type.Equals("2"))
            {
                table = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                if (table.Count > 0)
                {
                    this.rp_pagetitlelist.Visible = true;
                    this.rp_pagetitlelist.DataSource = table;
                    this.rp_pagetitlelist.DataBind();
                }
                else
                {
                    this.rp_pagetitlelist.Visible = false;
                }
                this.MultiView1.SetActiveView(this.vwpagetitlelist);
            }
            #endregion
            #region 3
            else if (this.Type.Equals("3"))
            {
                table = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                this.rpPageCollap.DataSource = table;
                this.rpPageCollap.DataBind();
                this.MultiView1.SetActiveView(this.vwpageCollap);
            }
            #endregion
            #region 4
            else if (this.Type.Equals("4"))
            {
                //  List<MNews> dt = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
                List<MNews> dt = SMNews.CATEGORY(More.TangNameicid(hp), language, "1");
               // List<MNews> dt = SMNews.Name_Text("select * from MNews");
                if (dt.Count > 0)
                {
                    string ab = dt[0].TangName;

                    CollectionPager1.DataSource = dt;
                    CollectionPager1.MaxPages = 10000;
                    CollectionPager1.BindToControl = rpcates;
                    CollectionPager1.PageSize = int.Parse("12");//////////////////
                    rpcates.DataSource = CollectionPager1.DataSourcePaged;
                    rpcates.DataBind();
                }
                else lterr.Text = "<div class='Checkdata'>Dữ liệu chưa được cập nhật</div>";
                this.MultiView1.SetActiveView(this.ViewListNews);
            }
            #endregion
            List<Entity.Menu> tb = new List<Entity.Menu>();
            #region #
            try
            {
                if (SMenu.Detail(More.TangNameicid(hp))[0].ShowID.ToString().Equals("1"))
                {
                    tb = SMenu.LOAD_CATESPARENT_ID(More.MN, this.language, More.TangNameicid(hp), "1");
                    if (tb.Count > 0)
                    {
                        this.rpchildcate.DataSource = tb;
                        this.rpchildcate.DataBind();
                        this.rpchildcate.Visible = true;
                    }
                    else
                    {
                        this.rpchildcate.Visible = false;
                    }
                }

            }
            catch (Exception)
            { }
            #endregion
        }

        protected string MenuLink(string type, string icid, string name, string link, string contentmenutype)
        {
            if (type.Trim().Equals("1"))
            {
                return ("/" + name + ".html");
            }
            if (type.Equals("2"))
            {
                return ("/" + link).Replace("//", "/");
            }
            return link;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}