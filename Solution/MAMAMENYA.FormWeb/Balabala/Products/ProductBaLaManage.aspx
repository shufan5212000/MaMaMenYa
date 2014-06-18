<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true"
    CodeBehind="ProductBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.ProductBaLaManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Product.js" type="text/javascript" language="javascript"></script>
    
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $(".datepicker").datepicker();
            Product.Manage();
            Product.InitData();
           
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
                    名称
                </td>
                <td class="detail">
                    <input id="formid" />
                </td>
                <td>
                    类别
                </td>
                <td class="td_detail">
                    <asp:DropDownList ID="drpProductClass" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    状态
                </td>
                <td>
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option value="10389">第三营销事业部</option>
                        <option value="11153">第五营销事业部</option>
                        <option value="11158">数据事业部</option>
                        <option value="11159">IT中心</option>
                        <option value="11160">ZTE全球售后服务中心</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    更新时间
                </td>
                <td>
                    <div class="input-append">
                        <asp:TextBox ID="txtStartTime" CssClass="span2 datepicker" runat="server"></asp:TextBox>
                        <span class="add-on"><i
                            class="icon-calendar"></i></span>至<asp:TextBox ID="txtEndTime" CssClass="span2 datepicker" runat="server"></asp:TextBox><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                <td>
                    
                    所属平台
                </td>
                <td>
                    <asp:DropDownList ID="drpPlantform" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    所属项目
                </td>
                <td><a  class="btnsearch btn btn-inverse "  href="ProductList.aspx">查询</a>
                   <%--<input class="btn btn-inverse" id="btnSearch" type="button" value="查询" />--%>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="PageContent">
        
    </div>
    
     <div id="Pager">
        


    </div>
    
</asp:Content>
