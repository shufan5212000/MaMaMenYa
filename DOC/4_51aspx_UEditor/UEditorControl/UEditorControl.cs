using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace UEditorControl
{
    [Description("UEditorControl.UEditor")]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:UEditor runat=server></{0}:UEditor>")]
    public class UEditor : Panel
    {
        #region 脚本

        private readonly string editor_config = "{0}editor_config.js";
        private readonly string editor_all = "{0}editor_all.js";
        private readonly string editor_css = @"{0}themes/default/ueditor.css";
        private static string temp = string.Empty;

        private readonly string editor_init = @"
        <script type=""text/javascript""> 
                var option = {{
                    minFrameHeight: {2},    //最小高度
                    elementPathEnabled: {3},  //编辑框下部的path部分
                    maximumWords: {4},  //允许的最大字符数
                    autoFloatEnabled: {5},  //工具栏浮动
                    autoHeightEnabled: {6}, //编辑框部分可以随着编辑内容的增加而自动长高
                    textarea: '{12}',   //设置提交时编辑器内容的名字
                    toolbars:{7},   //工具栏设置
                    zIndex:'{8}',    //编辑器z-index的基数
                    autoClearinitialContent: {9}, //自动清理内容
                    wordCount: {10}, //关闭字数统计
                    focus:{11}       //初始化时，是否让编辑器获得焦点true或false
                }};
                var {1} = new baidu.editor.ui.Editor(option);
                {1}.render('{0}');
        </script>
        ";

        #endregion

        [Description("编辑器中的HTML文本")]
        [Category("自定义属性")]
        public string Text
        {
            get
            {
                string s = string.Empty;
                if (DesignMode || !Page.IsPostBack)
                    s = (string)ViewState["Text"];
                else
                    s = Page.Request[this.ClientID];
                return ((s == null) ? string.Empty : s);
            }
            set { ViewState["Text"] = value; }
        }

        /// <summary>
        /// 脚本文件路径
        /// </summary>
        [
        Description("资源目录相对路径"),
        Category("自定义属性"),
        DefaultValue("/UEditor/"),
        ]
        public string ScriptPath
        {
            get
            {
                object o = ViewState["ScriptPath"];
                return (o != null ? (string)o : "/UEditor/");
            }
            set
            {
                ViewState["ScriptPath"] = value;
            }
        }

        /// <summary>
        /// 工具栏配置
        /// </summary>
        [
        Description("工具栏配置名称"),
        Category("自定义属性"),
        DefaultValue("CustomFull"),
        ]
        public string Toolbar
        {
            get
            {
                object o = ViewState["Toolbar"];
                return (o != null ? (string)o : @"[
            ['FullScreen', 'Source', '|', 'Undo', 'Redo', '|',
                'Bold', 'Italic', 'Underline', 'StrikeThrough', 'Superscript', 'Subscript', 'RemoveFormat', 'FormatMatch','AutoTypeSet', '|',
                'BlockQuote', '|', 'PastePlain', '|', 'ForeColor', 'BackColor', 'InsertOrderedList', 'InsertUnorderedList','SelectAll', 'ClearDoc', '|', 'CustomStyle',
                'Paragraph', '|','RowSpacingTop', 'RowSpacingBottom','LineHeight', '|','FontFamily', 'FontSize', '|',
                'DirectionalityLtr', 'DirectionalityRtl', '|', '', 'Indent', '|',
                'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyJustify', '|',
                'Link', 'Unlink', 'Anchor', '|', 'ImageNone', 'ImageLeft', 'ImageRight', 'ImageCenter', '|', 'InsertImage', 'Emotion', 'InsertVideo', 'Attachment', 'Map', 'GMap', 'InsertFrame', 'PageBreak', 'HighlightCode', '|',
                'Horizontal', 'Date', 'Time', 'Spechars','SnapScreen', 'WordImage', '|',
                'InsertTable', 'DeleteTable', 'InsertParagraphBeforeTable', 'InsertRow', 'DeleteRow', 'InsertCol', 'DeleteCol', 'MergeCells', 'MergeRight', 'MergeDown', 'SplittoCells', 'SplittoRows', 'SplittoCols', '|',
                 'Print', 'Preview', 'SearchReplace','Help']
        ]");
            }
            set
            {
                ViewState["Toolbar"] = value;
            }
        }
        /// <summary>
        /// 是否自动清除编辑器初始内容，注意：如果focus属性设置为true,这个也为真，那么编辑器一上来就会触发导致初始化的内容看不到了
        /// </summary>
        [
        Description("是否自动清除编辑器初始内容，注意：如果focus属性设置为true,这个也为真，那么编辑器一上来就会触发导致初始化的内容看不到了"),
        Category("自定义属性"),
        DefaultValue(false),
        ]
        public bool autoClearinitialContent
        {
            get
            {
                object o = ViewState["autoClearinitialContent"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["autoClearinitialContent"] = value;
            }
        }
        /// <summary>
        /// 关闭字数统计
        /// </summary>
        [
        Description("关闭字数统计"),
        Category("自定义属性"),
        DefaultValue(false),
        ]
        public bool wordCount
        {
            get
            {
                object o = ViewState["wordCount"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["wordCount"] = value;
            }
        }

        /// <summary>
        /// 编辑框配置
        /// </summary>
        [
        Description("编辑框下部的path部分"),
        Category("自定义属性"),
        DefaultValue(true),
        ]
        public bool ElementPathEnabled
        {
            get
            {
                object o = ViewState["ElementPathEnabled"];
                return (o != null ? (bool)o : true);
            }
            set
            {
                ViewState["ElementPathEnabled"] = value;
            }
        }

        /// <summary>
        /// 初始化时，是否让编辑器获得焦点true或false
        /// </summary>
        [
        Description("初始化时，是否让编辑器获得焦点true或false"),
        Category("自定义属性"),
        DefaultValue(true),
        ]
        public bool focus
        {
            get
            {
                object o = ViewState["focus"];
                return (o != null ? (bool)o : true);
            }
            set
            {
                ViewState["focus"] = value;
            }
        }

        /// <summary>
        /// 编辑框配置
        /// </summary>
        [
        Description("让编辑器的编辑框部分可以随着编辑内容的增加而自动长高"),
        Category("自定义属性"),
        DefaultValue(false),
        ]
        public bool AutoHeightEnabled
        {
            get
            {
                object o = ViewState["AutoHeightEnabled"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["AutoHeightEnabled"] = value;
            }
        }

        /// <summary>
        /// 编辑框配置
        /// </summary>
        [
        Description("工具栏浮动"),
        Category("自定义属性"),
        DefaultValue(false),
        ]
        public bool AutoFloatEnabled
        {
            get
            {
                object o = ViewState["AutoFloatEnabled"];
                return (o != null ? (bool)o : false);
            }
            set
            {
                ViewState["AutoFloatEnabled"] = value;
            }
        }

        /// <summary>
        /// 编辑框配置
        /// </summary>
        [
        Description("允许的最大字符数"),
        Category("自定义属性"),
        DefaultValue(10000),
        ]
        public int MaximumWords
        {
            get
            {
                object o = ViewState["MaximumWords"];
                return (o != null ? (int)o : 10000);
            }
            set
            {
                ViewState["MaximumWords"] = value;
            }
        }

        /// <summary>
        /// 皮肤名称
        /// </summary>
        [
        Description("皮肤名称"),
        Category("自定义属性"),
        DefaultValue("office2003"),
        ]
        public string SkinName
        {
            get
            {
                object o = ViewState["SkinName"];
                return (o != null ? (string)o : "office2003");
            }
            set { ViewState["SkinName"] = value; }
        }

        /// <summary>
        /// 控件高度
        /// </summary>
        [
        Description("控件高度"),
        Category("自定义属性"),
        DefaultValue("200"),
        ]
        public override Unit Height
        {
            get
            {
                object o = ViewState["Height"];
                return (o != null ? (Unit)o : new Unit(200));
            }
            set
            {
                ViewState["Height"] = value;
            }
        }

        /// <summary>
        /// 控件宽度
        /// </summary>
        [
        Description("控件宽度"),
        Category("自定义属性"),
        DefaultValue("700"),
        ]
        public override Unit Width
        {
            get
            {
                object o = ViewState["Width"];
                return (o != null ? (Unit)o : new Unit(700));
            }
            set
            {
                ViewState["Width"] = value;
            }
        }
        /// <summary>
        /// 控件宽度
        /// </summary>
        [
        Description("控件编辑器z-index的基数"),
        Category("自定义属性"),
        DefaultValue("999"),
        ]
        public String zIndex
        {
            get
            {
                object o = ViewState["zIndex"];
                return (o != null ? Convert.ToString(o) : "999");
            }
            set
            {
                ViewState["zIndex"] = value;
            }
        }
        /// <summary>
        /// CSS样式
        /// </summary>
        [
        Description("样式"),
        Category("自定义属性"),
        DefaultValue("ckeditor"),
        ]
        public override string CssClass
        {
            get
            {
                return base.CssClass;
            }
            set
            {
                base.CssClass = value;
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(
                "<textarea name=\"{0}\" id=\"{0}\" rows=\"4\" cols=\"40\" style=\"width: {1}; height: {2}\" wrap=\"virtual\">{3}</textarea>",
                    this.ClientID,
                    this.Width,
                    this.Height,
                    this.Text);

        }
        /// <summary>
        /// 摘要:如果 System.Web.UI.WebControls.TextBox.AutoPostBack 是 true，则在客户端上呈现之前注册用于生成回发事件的客户端脚本。
        /// 参数:e:
        /// 包含事件数据的 System.EventArgs。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, Width.ToString());
            this.Attributes.CssStyle.Add(HtmlTextWriterStyle.Height, Height.ToString());

            /*注册javacript脚本的几种方法*/
            /*
            string name = "myJavaScriptCode.js";
            Page.ClientScript.RegisterClientScriptInclude("myKey", name);*/
            /*
            // 引入js文件
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.Attributes.Add("language", "JavaScript");
            scriptControl.Attributes.Add("src", "../js/menu.js");
            Page.Header.Controls.Add(scriptControl);
             */

            ClientScriptManager csm = Page.ClientScript;
            string fullPath = ResolveUrl(@"~" + this.ScriptPath);

            string f_editor_css = string.Format(editor_css, fullPath);
            //if (!this.Page.ClientScript.IsStartupScriptRegistered("editor_css"))
            //{
            //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "editor_css", f_editor_css, false);
            //}
            //if (!csm.IsClientScriptIncludeRegistered("editor_css"))
            //    csm.RegisterClientScriptInclude(this.GetType(), "editor_css", f_editor_css);
            HtmlGenericControl _CssFile = new HtmlGenericControl("link");
            _CssFile.ID = "CssFile";
            _CssFile.Attributes["rel"] = "stylesheet";
            _CssFile.Attributes["type"] = "text/css";
            _CssFile.Attributes["href"] = f_editor_css;
            if (this.FindControl(_CssFile.ID) == null)
            {
                this.Page.Header.Controls.Add(_CssFile);
            }

            //注册配置脚本
            string f_editor_config = string.Format(editor_config, fullPath);


            if (!csm.IsClientScriptIncludeRegistered("editor_config"))
                csm.RegisterClientScriptInclude(this.GetType(), "editor_config", f_editor_config);

            //注册功能脚本
            string f_editor_all = string.Format(editor_all, fullPath);
            if (!csm.IsClientScriptIncludeRegistered("editor_all"))
                csm.RegisterClientScriptInclude(this.GetType(), "editor_all", f_editor_all);

            //初始化组件脚本
            string f_editor_init = string.Format(editor_init, this.ClientID, this.ID, Height.Value, ElementPathEnabled.ToString().ToLower(), MaximumWords, AutoFloatEnabled.ToString().ToLower(), AutoHeightEnabled.ToString().ToLower(), Toolbar, zIndex, autoClearinitialContent.ToString().ToLower(), wordCount.ToString().ToLower(), focus.ToString().ToLower(), this.ClientID.ToString());

            csm.RegisterStartupScript(this.GetType(), "editor_init" + this.ClientID, f_editor_init, false);
        }
    }
}
