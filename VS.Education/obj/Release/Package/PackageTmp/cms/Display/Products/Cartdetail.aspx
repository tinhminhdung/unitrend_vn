<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cartdetail.aspx.cs" Inherits="VS.E_Commerce.cms.Display.Products.Cartdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title><%=label("l_orderdetail")%></title>
	<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="C#" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link rel="stylesheet" type="text/css" href="../../../cs/common.css">
	   <link href="Resources/admin/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
       
       <style type="text/css">

td
	{border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
            color:black;
	        font-size:11.0pt;
	        font-weight:400;
	        font-style:normal;
	        text-decoration:none;
	        font-family:Calibri, sans-serif;
	        text-align:general;
	        vertical-align:bottom;
	        white-space:nowrap;
	}
        .style1
        {
            height: 17.25pt;
            width: 26pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style2
        {
            width: 47pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style3
        {
            width: 210pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style4
        {
            width: 238pt;
            color: black;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style5
        {
            width: 48pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style6
        {
            height: 17.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style7
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style8
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style9
        {
            color: black;
            font-size: 12.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style10
        {
            height: 13.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style11
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style12
        {
            height: 24.0pt;
            color: black;
            font-size: 12.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style13
        {
            height: 19.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style14
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style15
        {
            height: 6.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style16
        {
            height: 33.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style17
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style18
        {
            width: 210pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style19
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style20
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style21
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style22
        {
            width: 100px;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style23
        {
            width: 150pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top: 1.0pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style24
        {
            height: 21.0pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style25
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style26
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style27
        {
            width: 49pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: .5pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style28
        {
            width: 57pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style29
        {
            width: 113pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: normal;
            border-left: .5pt solid windowtext;
            border-right: 1.0pt solid windowtext;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style30
        {
            height: 24.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style31
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style32
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: .5pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: .5pt solid windowtext;
            padding: 0px;
        }
        .style33
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border: .5pt solid windowtext;
            padding: 0px;
        }
       
.style34 {
    border-color: windowtext -moz-use-text-color windowtext windowtext;
     border: .5pt solid windowtext;
    border-width: 0.5pt 1px 0.5pt 0.5pt;
    color: black;
    font-family: "Times New Roman",serif;
    font-size: 10pt;
    font-style: normal;
    font-weight: 700;
    padding: 0;
    text-align: center;
    text-decoration: none;
    vertical-align: middle;
    white-space: nowrap;
}
        .style35
        {
            height: 29.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left: 1.0pt solid windowtext;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style36
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: italic;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style37
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
        }
        .style38
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right: 1.0pt solid windowtext;
            border-top: .5pt solid windowtext;
            border-bottom: 1.0pt solid windowtext;
            padding: 0px;
               width: 113pt;
           }
        .style39
        {
            height: 12.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style40
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: left;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style41
        {
            height: 20.25pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style42
        {
            height: 22.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
        .style43
        {
            height: 22.5pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 700;
            font-style: normal;
            text-decoration: underline;
            font-family: "Times New Roman", serif;
            text-align: right;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style44
        {
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: general;
            vertical-align: middle;
            white-space: nowrap;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: .5pt solid windowtext;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 0px;
        }
        .style45
        {
            height: 12.75pt;
            color: black;
            font-size: 10.0pt;
            font-weight: 400;
            font-style: normal;
            text-decoration: none;
            font-family: "Times New Roman", serif;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
            border-style: none;
            border-color: inherit;
            border-width: medium;
            padding: 0px;
        }
           .style46
           {
               height: 20pt;
               color: black;
               font-size: 10.0pt;
               font-weight: 400;
               font-style: normal;
               text-decoration: none;
               font-family: "Times New Roman", serif;
               text-align: left;
               vertical-align: middle;
               white-space: nowrap;
               border-style: none;
               border-color: inherit;
               border-width: medium;
               padding: 0px;
           }
           .style47
           {
               color: black;
               font-size: 10.0pt;
               font-weight: 400;
               font-style: normal;
               text-decoration: none;
               font-family: "Times New Roman", serif;
               text-align: left;
               vertical-align: middle;
               white-space: nowrap;
               border-style: none;
               border-color: inherit;
               border-width: medium;
               padding: 0px;
               width: 113pt;
           }
           .style48
           {
               color: black;
               font-size: 10.0pt;
               font-weight: 700;
               font-style: normal;
               text-decoration: none;
               font-family: "Times New Roman", serif;
               text-align: left;
               vertical-align: middle;
               white-space: nowrap;
               border-style: none;
               border-color: inherit;
               border-width: medium;
               padding: 0px;
               width: 113pt;
           }
    </style>

<table border="0" cellpadding="0" cellspacing="0" style="border-collapse:
 collapse;width:569pt" width="758">
    <colgroup>
        <col style="mso-width-source:userset;mso-width-alt:1280;width:26pt" 
            width="35" />
        <col style="mso-width-source:userset;mso-width-alt:2304;width:47pt" 
            width="63" />
        <col style="mso-width-source:userset;mso-width-alt:10240;width:210pt" 
            width="280" />
        <col style="mso-width-source:userset;mso-width-alt:1938;width:40pt" 
            width="53" />
        <col style="mso-width-source:userset;mso-width-alt:1828;width:38pt" 
            width="50" />
        <col style="mso-width-source:userset;mso-width-alt:2377;width:49pt" 
            width="65" />
        <col style="mso-width-source:userset;mso-width-alt:2779;" />
        <col style="mso-width-source:userset;mso-width-alt:2633;width:54pt" 
            width="72" />
        <col style="width:48pt" width="64" />
    </colgroup>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td align="left" height="23" style="height:17.25pt;width:26pt" valign="top" 
            width="35">
            
            <span style="mso-ignore:vglayout;
  position:absolute;z-index:1;margin-left:4px;margin-top:3px;width:255px;
  height:73px">
           	<%=MoreAll.Banner.Banners() %></span><![endif]><span 
                style="mso-ignore:vglayout2">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="style1" height="23" width="35">
                    </td>
                </tr>
            </table>
            </span>
        </td>
        <td class="style2" width="63">
        </td>
        <td class="style3" width="280">
        </td>
        <td class="style4" colspan="5">
            www.linhkienchatluong.vn</td>
        <td class="style5" width="64">
        </td>
    </tr>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td class="style6" height="23">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style9" colspan="5">
            25A Hạ Đình - Thanh Xuân - Hà Nội</td>
        <td class="style8">
        </td>
    </tr>
    <tr height="23" style="mso-height-source:userset;height:17.25pt">
        <td class="style6" height="23">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style9" colspan="5">
            ĐT/Fax: 04.66858855 - 0946.386693</td>
        <td class="style8">
        </td>
    </tr>
    <tr height="18" style="mso-height-source:userset;height:13.5pt">
        <td class="style10" height="18">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style11" colspan="5">
        </td>
        <td class="style11">
        </td>
    </tr>
    <tr height="32" style="mso-height-source:userset;height:24.0pt">
        <td class="style12" colspan="8" height="32">
            BẢNG CHI TIẾT LINH KIỆN ĐIỆN TỬ</td>
        <td class="style11">
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
            Khách hàng: <asp:Literal ID="ltname" runat="server"></asp:Literal></td>
        <td class="style8" colspan="6">
            Mã số: <asp:Literal ID="ltmaso" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
            Điện thoại liên hệ: <asp:Literal ID="ltphone" runat="server"></asp:Literal></td>
        <td class="style14" colspan="6">
            Email:  <asp:Literal ID="ltemail" runat="server"></asp:Literal>
        </td>
    </tr>
    <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="9" height="26" style="mso-ignore: colspan">
            Địa chỉ: <asp:Literal ID="ltdiachi" runat="server"></asp:Literal></td>
    </tr>
     <tr style="mso-height-source:userset;">
        <td class="style46" colspan="3" style="mso-ignore: colspan">
            Hình thức thanh toán: <asp:Literal ID="ltthanhtoan" runat="server"></asp:Literal></td>
        <td class="style46" colspan="6">
        Phương thức giao hàng: <asp:Literal ID="ltphuongthuc" runat="server"></asp:Literal>
        </td>
    </tr>
     <tr height="26" style="mso-height-source:userset;height:19.5pt">
        <td class="style13" colspan="3" height="26" style="mso-ignore: colspan">
           Ghi chú: <asp:Literal ID="ltghichu" runat="server"></asp:Literal></td>
        <td class="style14">
        </td>
        <td class="style7">
            &nbsp;</td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="9" style="mso-height-source:userset;height:6.75pt">
        <td class="style15" height="9">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="45" style="mso-height-source:userset;height:33.75pt;  background: #d7d7d7 none repeat scroll 0 0;">
        <td class="style16" height="45">
            STT</td>
        <td class="style17">
            Mã LK</td>
        <td class="style18" width="280">
            Tên linh kiện</td>
        <td class="style19" width="53">
            Số lượng</td>
        <td class="style20" width="50">
            Đ.V<br />
            tính</td>
         <td class="style20" width="50">
           Trọng lượng</td>
        <td class="style21" width="65">
            Đơn<br />
            <span style="mso-spacerun:yes">&nbsp;</span>giá</td>
        <td class="style22" width="76" style=" border: 1px solid #000">
            Thành tiền</td>
       <%-- <td class="style23">
            Kho lưu trữ</td>--%>
        <td class="style8" style='  background:#fff'>
        </td>
    </tr>
    <asp:Repeater ID="rpcartdetail" runat="server">
	<ItemTemplate>
      <tr height="28" style="mso-height-source:userset;height:21.0pt">
        <td class="style24" height="28" style='border:1px solid #000'><%=i++ %></td>
        <td class="style7"  style='border:1px solid #000'><%#Code(Eval("PID").ToString())%></td>
        <td class="style25" style='border:1px solid #000'><%#Eval("Name")%></td>
        <td class="style26"  style='border:1px solid #000'><%#DataBinder.Eval(Container.DataItem, "Quantity")%></td>
        <td class="style26"  style='border:1px solid #000'><%#Donvitinh(Eval("PID").ToString())%> </td>
           <td class="style26"  style='border:1px solid #000'><%#Eval("trongluong")%></td>
        <td class="style27" width="65"  style='border:1px solid #000'><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Price").ToString())%> </td>
        <td class="style28" width="76"  style='border:1px solid #000'><%#MoreAll.MorePro.FormatMoney_Cart(Eval("Money").ToString())%></td>
     <%--   <td class="style29" width="72"  style='border:1px solid #000'><%#Kho(Eval("PID").ToString())%></td>--%>
        <td class="style8"  style='border:none'> </td>
    </tr>
	</ItemTemplate>
</asp:Repeater>
    <tr height="33" style="mso-height-source:userset;height:24.75pt;  background: #d7d7d7 none repeat scroll 0 0;">
        <td class="style30" height="33">
            &nbsp;</td>
        <td class="style31">
            Tổng tiền</td>
        <td class="style32">
            &nbsp;</td>
        <td class="style33">
            <asp:Literal ID="ltProdinCart" runat="server"></asp:Literal></td>
        <td class="style33" colspan="4">
            <asp:Literal ID="lttong" runat="server"></asp:Literal></td>
        <td class="style8" style='  background:#fff'>
        </td>
    </tr>
     <tr height="33" style="mso-height-source:userset;height:24.75pt;  background: #d7d7d7 none repeat scroll 0 0;">
        <td class="style30" height="33">
            &nbsp;</td>
        <td class="style31">
            Trọng lượng</td>
        <td class="style33" colspan="6">
            <asp:Literal ID="lttongtrongluong" runat="server"></asp:Literal> Gram</td>
        <td class="style8" style='  background:#fff'>
        </td>
    </tr>
     <tr height="33" style="mso-height-source:userset;height:24.75pt;  background: #d7d7d7 none repeat scroll 0 0;">
        <td class="style30" height="33">
            &nbsp;</td>
        <td class="style31">
            Tổng số tiền thanh toán </td>
        <td class="style33" colspan="6">
          <%if (Session["Tongthanhtoan"] != null)
            { %>
                <%=MoreAll.MorePro.FormatMoney_Cart_Total(Session["Tongthanhtoan"].ToString()) %>
          <%} %>
        </td>
        <td class="style8" style='  background:#fff'>
        </td>
    </tr>
    
   <tr height="39" style="mso-height-source:userset;height:29.25pt">
        <td class="style35" height="39">
            &nbsp;</td>
        <td class="style36" colspan="5" style="mso-ignore: colspan">
            Tổng số tiền (viết bằng chữ): <asp:Literal ID="ltvietchu" runat="server"></asp:Literal></td>
        <td class="style37">
            &nbsp;</td>
        <td class="style38">
            &nbsp;</td>
        <td class="style8">
        </td>
    </tr>
    <tr height="17" style="mso-height-source:userset;height:12.75pt">
        <td class="style39" height="17">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style40">
        </td>
        <td class="style48">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
            Khách hàng</td>
             <td class="style8">
             <div style=" text-align:center; margin-left:200px">Kế toán</div>
        </td>
         <td class="style8">
            </td>
        <td class="style7">
            &nbsp;</td>
             <td class="style8">
        </td>
        <td class="style7">
            Người xuất</td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="27" style="mso-height-source:userset;height:20.25pt">
        <td class="style41" height="27">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="30" style="mso-height-source:userset;height:22.5pt">
        <td class="style42" height="30">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
            Ngày:<span style="mso-spacerun:yes">&nbsp; </span><%=MoreAll.MoreAll.FormatDate(DateTime.Now)%></td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="30" style="mso-height-source:userset;height:22.5pt">
        <td class="style43" colspan="2" height="30" 
            style="text-underline-style: single;">
            Chú ý:<span style="mso-spacerun:yes">&nbsp;</span></td>
        <td class="style44" colspan="6" style="mso-ignore: colspan">
            Thời gian giải quyết thắc mắc, khiếu nại của khách hàng là 48 tiếng (2 ngày) 
            tính từ thời điểm nhận được hàng</td>
        <td class="style8">
        </td>
    </tr>
    <tr height="17" style="height:12.75pt">
        <td class="style45" height="17">
        </td>
        <td class="style7">
        </td>
        <td class="style8" colspan="5" style="mso-ignore: colspan">
            Chi tiết vui lòng liên hệ: 04.66858855 - 0946386693 - Email: 
            linhkienchatluong@gmail.com</td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
    <tr height="17" style="height:12.75pt">
        <td class="style45" height="17">
        </td>
        <td class="style7">
        </td>
        <td class="style8">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style7">
        </td>
        <td class="style47">
        </td>
        <td class="style8">
        </td>
    </tr>
</table>
<div><a onClick="window.print();return false"><img src="/Resources/images/printer-icon.png" style=" width:70px" /></a></div>

    </form>
</body>
</html>