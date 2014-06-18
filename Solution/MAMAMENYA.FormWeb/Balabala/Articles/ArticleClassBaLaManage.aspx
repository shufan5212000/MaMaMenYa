<%@ Page Title="" Language="C#" MasterPageFile="~/MAMAYA.Master" AutoEventWireup="true" CodeBehind="ArticleClassBaLaManage.aspx.cs" Inherits="MAMAMENYA.FormWeb.Balabala.Articles.ArticleClassBaLaManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" language="javascript" src="/Scripts/AddDivShow.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            AddDivShow.PageArticleClass();
        })
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
                <td>单据号</td>
                <td class="detail">
                    <input id="formid" />
                </td>
                <td>单据类型</td>
                <td class="td_detail">
                    <input id="formtype" /></td>
                <td>部门 </td>
                <td>
                    <select size="1" name="ENTPdept" id="bumen">
                        <option value="10401"></option>
                        <option value="10388">第二营销事业部</option>
                        <option
                            value="10389">第三营销事业部</option>
                        <option
                            value="11153">第五营销事业部</option>
                        <option
                            value="11158">数据事业部</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
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
                            value="10390">第一营销事业部</option>
                        <option
                            value="10391">康讯公司</option>
                        <option
                            value="11159">IT中心</option>
                        <option
                            value="11160">ZTE全球售后服务中心</option>
                    </select></td>
            </tr>

            <tr>
                <td colspan="6" align="right">
                    <input class="btn btn-inverse" id="find" type="button" value="查询" />
                    <input class="btn btn-inverse" type="button" id="btnAddArticleClass" value="添加" /></td>
            </tr>
        </tbody>
    </table>
    
    <table class="table table-striped table-bordered table-condensed" id="list">
        <thead>
            <tr class="tr_detail">
                <td>分类名称 </td>
                <td>上级分类</td>
                <td>关键词</td>
                <td>备注 </td>
                <td>操作 </td>
            </tr>
        </thead>
        <tbody>
            
            <%
                int i = 0;
                foreach (var articleClass in PageData)
                {
                    i += 1;
            %>
    <tr <% if (i%2 == 0)
           { %>class="even"<% } %>>
                <td><%=articleClass.Name%></td>
                <td><%if(articleClass.Parent!=null)
                          Response.Write(articleClass.Parent.Name);%></td>
                <td><%=articleClass.Keyword%> </td>
                <td><%=articleClass.Remark%></td>
                <td>
                 <input class="btn btn-inverse Del" type="button"  id="btnDel<%=articleClass.Id %>" name="<%=articleClass.Id %>" value="删除" />
                
                 <input class="btn btn-inverse Modify" type="button"  id="btnModify<%=articleClass.Id %>" name="<%=articleClass.Id %>" value="修改" />
                </td>
                
            </tr>
  <%
                } %>
          
            <tr class="even">
          
         
            <tr class="tr_pagenumber">
                <td colspan="100">
                      <asp:Button ID="btnFirstPage" runat="server" CssClass="badge badge-inverse"   Text="首页" />
                    <asp:Button ID="btnPrevious" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click" Text="上一页" />
                    <asp:Button ID="btnNext" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click" Text="下一页" />
                    <asp:Button ID="btnLastpage" runat="server" CssClass="badge badge-inverse" OnClick="OnPageChange_Click" Text="尾页" />
                    

                </td>
            </tr>
        </tbody>
    </table>
    
        <div id="AddArticleClassContent" style="display: none" align="center">
        <table width="200" class="table table-striped table-bordered table-condensed" >
  <tr>
    <td>分类名称：</td>
    <td>&nbsp;<asp:TextBox ID="txtClassName" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td>分类关键词：</td>
    <td>&nbsp;<asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td>描述：</td>
    <td>&nbsp;<asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td>上级分类：</td>
    <td>&nbsp;
    <asp:DropDownList ID="drpClassPageData" runat="server"> </asp:DropDownList>
    </td>
  </tr>
   <tr>
    <td>备注：</td>
    <td>&nbsp;<asp:TextBox ID="txtRemark" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
    <td colspan="2">
        <asp:Button ID="btnAdd" runat="server" OnClick="btnSave_Click" Text="确定" />

    </td>
 
  </tr>
</table>

    </div>

</asp:Content>
