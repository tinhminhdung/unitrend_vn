using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreAll;
using Services;

namespace Advertisings
{
    public class Ad_vertisings
    {
        public static string Advhome(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    #region Type
                    strb += ("<div class=\"col-md-4 col-sm-4 col-xs-12\">");
                    strb += ("<div class=\"banner-center\">");
                    strb += ("<a target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img class=\"img-responsive\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                    strb += ("</div>");
                    strb += ("</div>");
                    #endregion
                }
            }
            return strb.ToString();
        }

        public static string Banner(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    #region Type
                    strb += ("<div class=\"item\"><a target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a></div>");
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Contents(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    #region Type
                    strb += Contents;
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_A_Images(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    strb += ("<a target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                }
            }
            return strb.ToString();
        }

        public static string Advertisings(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<a target=" + Opentype + " href='/Cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + Text;
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_LI(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><a target=" + Opentype + " href='/Cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a></li>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + Text;
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'></li>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }


        public static string targets(string target)
        {
            if (target.Equals("0"))
            {
                return "_self";
            }
            return "_blank";
        }

        public static string _Youtube(string url, string Width, string Height)
        {
            #region Youtube
            string FormattedUrl = MoreVideoClip.GetYouTubeID(url);
            string str = "";
            str += "<object style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'><param name='movie' value='" + FormattedUrl + "'></param>";
            str += "<param name='allowFullScreen' value='true'></param>";
            str += "<param name='allowscriptaccess' value='always'></param>";
            str += "<embed src='" + FormattedUrl + "' type='application/x-shockwave-flash' allowscriptaccess='always' allowfullscreen='true' style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'>";
            str += "</embed>";
            str += "</object>";
            return str.ToString();
            #endregion
        }

        public static string label(string ID)
        {
            return Captionlanguage.GetLabel(ID, MoreAll.MoreAll.Language);
        }
    }
}
