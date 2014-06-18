<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true"
    CodeBehind="ProductAddBal.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.ProductAddBal"  %>
    <%@ Register Assembly="UEditorControl" Namespace="UEditorControl"  TagPrefix="cc1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/jquery.form.js" type="text/javascript" language="javascript"></script>
<script src="/Scripts/Product.js" type="text/javascript" language="javascript"></script>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        Product.Uploader();
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;添加产品信息
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    产品名称：
                </td>
                <td class="detail">
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td>
                    产品类别：
                </td>
                <td class="td_detail">
                    <asp:DropDownList ID="drpProductClass" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    所属平台：
                </td>
                <td>
                    <asp:DropDownList ID="drpPlantform" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    产品价格：
                </td>
                <td>
                    <div class="input-append">
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td>
                    商家名称：
                </td>
                <td>
                    <asp:TextBox ID="txtShopName" runat="server"></asp:TextBox>
                </td>
                <td>
                    商家信誉：
                </td>
                <td>
                    <asp:DropDownList ID="drpCreting" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    库存数量：
                </td>
                <td>
                    <div class="input-append">
                        <asp:TextBox ID="txtInventory" runat="server"></asp:TextBox>
                    </div>
                </td>
                <td>
                    卖出数量：
                </td>
                <td>
                    <asp:TextBox ID="txtBuyCount" runat="server"></asp:TextBox>
                </td>
                <td>所属品牌：
                </td>
                <td>
                      <asp:DropDownList ID="drpBrand" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    产品关键词：
                </td>
                <td colspan="5" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtKeyword" Width="60%" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    产品简介：
                </td>
                <td colspan="5" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtSummary" TextMode="MultiLine" Rows="5" Width="80%" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    产品链接：
                </td>
                <td colspan="5" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtProductUrl" Width="80%" runat="server"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    产品详情：
                </td>
                <td colspan="5" align="left" style="height: 400px" valign="top">
                            <cc1:UEditor ID="txtProdctContent" runat="server" Width="80%">
                            </cc1:UEditor>
   
                  
                </td>
            </tr>
              <tr>
                <td>
                    产品图片：
                </td>
                <td colspan="5" align="left">
                    <div class="input-append">
                        <asp:TextBox ID="txtPicUrl" Width="60%" name="picUrl" realName="picUrl" runat="server"></asp:TextBox>
                        <input id="idFile"   name="idFile" type="file" />
                        <input class="btn btn-inverse" type="button" id="btnUPloadPic" value="上传图片" />
                      
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click  " Text="确认保存" />
                </td>
            </tr>
        </tbody>
    </table>
  <div id="UploaderContent">
      <div id="pagecontent"></div>
  </div>
   </asp:Content>