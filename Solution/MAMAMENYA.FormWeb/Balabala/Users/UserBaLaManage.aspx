<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="UserBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Users.UserBaLaManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <table class="table table-striped table-bordered table-condensed">
        <thead>
            <tr>
                <td colspan="6" class="auto-style2">&nbsp;请填写查询条件 </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>登录账号</td>
                <td class="detail">
                    <input id="txtLoginName" />
                </td>
                <td>电话</td>
                <td class="td_detail">
                    <input id="txtTel" /></td>
                <td>状态 </td>
                <td>
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        
                    </select>
                </td>
            </tr>
            <tr>
                <td>提交日期起 </td>
                <td>
                    <div class="input-append">
                        <input class="span2 datepicker" size="16" type="text" id="startime" /><span class="add-on"><i class="icon-calendar"></i></span>至<input id="endtime" class="span2 datepicker" size="16" type="text" /><span class="add-on"><i class="icon-calendar"></i></span>
                    </div>
                </td>
                <td>报销人 </td>
                <td>
                    <select size="1" name="select2" id="baoxiaoren">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        
                    </select></td>
                <td>所属项目</td>
                <td>
                    <select id="xiangmu" size="1" name="select3">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                    </select></td>
            </tr>

            <tr>
                <td colspan="6" align="right">
                     <a  class="btnsearch btn btn-inverse "  href="UserList.aspx">查询</a>
                    <input class="btn btn-inverse" type="button" value="清空" /></td>
            </tr>
        </tbody>
    </table>
    
       <div id="PageContent">
        
    </div>
    
     <div id="Pager">
        


    </div>
</asp:Content>
