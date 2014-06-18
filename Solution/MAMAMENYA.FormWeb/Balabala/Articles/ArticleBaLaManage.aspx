<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="ArticleBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ArticleBaLaManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript" src="../../Scripts/ChurAlert.min.js?skin=blue"></script>
    <script type="text/javascript" src="../../Scripts/chur-alert.1.0.js"></script>
    <link rel="stylesheet" type="text/css" href="../../Styles/chur.css" />
    <script type="text/javascript" src="../../Scripts/Article.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            Article.Manage();
        });
    </script>
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
                <td>文章类别</td>
                <td class="detail">
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="">----请选择----</option>
                        <% foreach (var articleClass in AllClass)
                           {
  %>
   <option value="<%=articleClass.Id %>"><%=articleClass.Name %></option>
  <%
                           } %>
                       
                        
                    </select>
                </td>
                <td>单据类型</td>
                <td class="td_detail">
                    <input id="formtype" /></td>
                <td>部门 </td>
                <td>
                    
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
                        
                        <option
                            value="10400">市场中心</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select></td>
                <td>所属项目</td>
                <td>
                    <select id="xiangmu" size="1" name="select3">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option
                            value="10389">第三营销事业部</option>
                        <option
                            value="10387">本部事业部</option>
                        <option
                            value="10006">技术中心IC所</option>
                        <option
                            value="11005">中兴通讯学院</option>
                        <option
                            value="11015">第四营销事业部</option>
                        <option
                            value="11153">第五营销事业部</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select></td>
            </tr>

            <tr>
                <td colspan="6" align="right">
                    <a  class="btnsearch btn btn-inverse "  href="ArticleList.aspx">查询</a>
                    </td>
            </tr>
        </tbody>
    </table>
        <div id="PageContent">
        
        

    </div>
    
     <div id="Pager">
        


    </div>
    
</asp:Content>
