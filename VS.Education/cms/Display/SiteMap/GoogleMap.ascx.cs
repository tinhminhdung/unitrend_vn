using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.SiteMap
{
    public partial class GoogleMap : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
       

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
                ltjavascript.Text = CssJavaScrip();
                ltbando.Text = load();
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        protected string CssJavaScrip()
        {
            string Degrees = GoogleMaps.Degrees();
            string Zoom = GoogleMaps.Zoom();
            string MapImg = GoogleMaps.MapGooglepath();
            string str = "";
            {
                str += "<script type=\"text/javascript\">	";
                str += "function ugm_newgmap(){function k(){if(h)for(j in h)h[j].setMap(null)}var d=[";
                List<Entity.GoogleMap> dt = SGoogleMap.Category(language, "1");
                int i;
                if (dt.Count > 0)
                {
                    for (i = 0; i < dt.Count; i++)
                    {
                        string img = "";
                        img +=  dt[i].vimg.ToString();
                        if (i < dt.Count - 1)
                        {
                            str += " ['" + dt[i].Name.ToString() + "'," + dt[i].Degrees.ToString() + ",0,'" + dt[i].vimg.ToString() + "',0,'nn'," + i + "],";
                        }
                        else
                        {
                            str += " ['" + dt[i].Name.ToString() + "'," + dt[i].Degrees.ToString() + ",0,'" + dt[i].vimg.ToString() + "',0,'nn'," + i + "]";
                        }
                    }
                }
                str += " ],m=[],b,a,e,h,i,g=new google.maps.InfoWindow,l=new google.maps.LatLng(" + Degrees + ");a={scrollwheel:!1,zoom:" + Zoom + ",center:l,disableDefaultUI:!1,mapTypeId:google.maps.MapTypeId.ROADMAP};var c=new google.maps.Map(document.getElementById(\"ugm_map\"),a);c.getZoom();for(a=0;a<d.length;a++){switch(d[a][6]){case \"nn\":e=";
                str += " 0.5;b=1;h=30;i=76;break;default:b=e=0}e*=h;b*=i;b=new google.maps.MarkerImage(\"/Uploads/pic/Map/" + MapImg + "\",new google.maps.Size(h,i),new google.maps.Point(0,0),new google.maps.Point(e,b));b=new google.maps.Marker({position:new google.maps.LatLng(d[a][1],d[a][2]),icon:b,title:d[a][0],map:c});google.maps.event.addListener(b,\"click\",function(b,a){return function(){c.setZoom(17);c.setCenter(this.position);$(\".ugm_link1\").text();$(\".ugm_link2\").text();$(\".ugm_link3\").text();var e='<div style=\"text-align:center;margin-bottom:3px;font-weight:bold;\">'+";
                str += " d[a][0]+'</div><div>";
                str += "<img style=\"border:1px solid #444\" src=\"'+d[a][4]+'\" align=\"middle\">";
                str += "</div>';1==d[a][5]&&(e+=\"\");g.setContent(e);g.open(c,b)}}(b,a));m.push(b)}var f=[];google.maps.event.addListener(c,\"click\",function(){g.close()});$(\".ugm_li-store\").css({cursor:\"pointer\"}).hover(function(){$(this).css({\"background-color\":\"transparent\"})},function(){$(this).css({\"background-color\":\"transparent\"})});$(\".ugm_li-store\").click(function(){\"ugm_list-l\"==";
                str += " $(this).parent().parent().attr(\"id\")?($(this).removeClass(\"ugm_active-m\").addClass(\"ugm_active-l\").siblings().addClass(\"ugm_active-m\"),$(\"#ugm_list-r li\").addClass(\"ugm_active-m\")):($(this).removeClass(\"ugm_active-m\").addClass(\"ugm_active-r\").siblings().addClass(\"ugm_active-m\"),$(\"#ugm_list-l li\").addClass(\"ugm_active-m\"));var a=$(this).attr(\"rel\"),b=d[a][1],a=d[a][2];c.getZoom();b=new google.maps.LatLng(b,a);c.panTo(b);c.setZoom(13);c.setCenter(b);a=new google.maps.MarkerImage(\"\",new google.maps.Size(14,";
                str += " 14),new google.maps.Point(0,0),new google.maps.Point(7,7));markerX=new google.maps.Marker({position:b,icon:a,map:c});k();f.push(markerX)});$(\".ugm_see-all\").css({cursor:\"pointer\"}).click(function(){$(\".ugm_li-store\").each(function(){$(this).removeClass(\"ugm_active-l\").removeClass(\"ugm_active-r\").addClass(\"ugm_active-m\")});c.setZoom(6);c.setCenter(l);g.close();k()})}ugm_newgmap();";
                str += "</script>";
            }
            return (str);
        }

        protected string load()
        {
            string str = "";
            List<Entity.GoogleMap> table = SGoogleMap.Category(language, "1");
            for (int i = 0; i < table.Count; i++)
            {
                str += " <li rel='" + i + "' class='ugm_li-store' style='cursor: pointer;'><span>" + table[i].Orders.ToString() + "</span> " + table[i].Name.ToString() + "</li>";
            }
            return (str + "");
        }
    }
}