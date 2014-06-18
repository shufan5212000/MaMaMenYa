<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="BrandBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.BrandBaLaManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Brand.js" type="text/javascript" language="javascript"></script>
    
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
            Brand.Init();
//            Product.InitData();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;请填写查询条件
                </td>
            </tr>
        </thead>
     
        <tbody>
            <tr>
                <td>
                    广告标题
                </td>
                <td class="td_detail">
                    <input id="txtTitle" name="txtTitle" />
                </td>
                <td>
                    广告类别
                </td>
                <td class="detail">
                   
                </td>
                <td>
                    <a class="btn btn-inverse " id="AddBrand" href="BrandAdd.aspx">添加品牌</a> <a class="btnsearch btn btn-inverse "
                        href="BrandList.aspx">查询</a>
                </td>
                <td>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="PageContent">
    </div>
    <div id="Pager">
    </div>
</asp:Content>
