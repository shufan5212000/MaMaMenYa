<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" ValidateRequest="false"
 CodeBehind="BrandAdd.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Products.BrandAdd" %>
<%@ Register Assembly="UEditorControl" Namespace="UEditorControl"  TagPrefix="cc1"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;添加产品产品品牌
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    名称：
                </td>
                <td class="detail">
                    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                </td>
                <td>
                    产品数量：
                </td>
                <td class="td_detail">
                   <asp:TextBox ID="txtProductCount" runat="server"></asp:TextBox>
                </td>
                <td>
                    
                </td>
                <td>
                    
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
                    品牌详情：
                </td>
                <td colspan="5" align="left" style="height: 400px" valign="top">
                            <cc1:UEditor ID="txtProdctContent" runat="server" Width="80%">
                            </cc1:UEditor>
   
                  
                </td>
            </tr>
              <tr>
                <td>
                    图片：
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="/Scripts/Product.js" type="text/javascript" language="javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            Product.Uploader();
        });
</script>
</asp:Content>
