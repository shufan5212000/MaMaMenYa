<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="ActivityAdd.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ActivityAdd" %>
<%@ Register TagPrefix="cc1" Namespace="UEditorControl" Assembly="UEditorControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">
                    &nbsp;添加亲子活动信息
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td width="100">
                    标题：
                </td>
                <td class="detail">
				<input name="Title" id="Title" size="50" type="text" />
                   
                </td>
                <td>
                    人数：
                </td>
                <td class="td_detail">
                   <input name="TotleUser" style="width:50%"  id="TotleUser" type="text" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>报名电话：
                </td>
                <td>
                    <div class="input-append">
                    <input name="Tel" id="Tel" size="40" type="text" />
                    </div>
                </td>
                 <td>
                    推荐：
                                     </td>
                <td>
                      <input type="radio" name="radiobutton" value="1" />普通
					  <input type="radio" name="radiobutton" value="2" />推荐
                </td>
                <td>
                    置顶：
                </td>
                <td>
                   <%-- <asp:CheckBox ID="chkIsTop" runat="server" />--%>
                </td>
               
            </tr>
            <tr>
                <td>
                    活动地址：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                       <input name="Address" size="50" id="Title" type="text" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    页面描述：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                      <textarea name="Descrp" id="Descrp"></textarea>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    图片：
                </td>
                <td colspan="6" align="left">
                    <div class="input-append">
                        <asp:FileUpload ID="fileUploadPic" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    内容：
                </td>
                <td colspan="6" align="left" style="height: 400px" valign="top">
                    <cc1:UEditor ID="ActivityContent" runat="server" Width="80%">
                    </cc1:UEditor>
                </td>
            </tr>
            <tr>
                <td colspan="6" align="left"><label>
                     <input type="submit" class="btnsearch" name="Submit" value="保存" />
                </label></td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
