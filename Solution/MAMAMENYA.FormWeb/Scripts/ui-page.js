/// <reference path="jquery.js" />
/// <reference path="jquery.form-extensions.js" />
(function($) {
    $.widget("ui.pages", {
        _init: function() {
            this.options = $.extend({}, $.ui.pages.defaults, this.options);
            this.options.event += '.pages'; // namespace event
            this._initPage();
        },
        _addPage: function(p, i, text) {
            var o = this.options;
            if (!text) text = i.toString();
            var item = $('<li><a href="#' + i.toString() + '">' + text + '</a></li>');
            item.addClass(i == o.pageindex ? o.selectCss : o.itemCss);
            p.append(item);
        },
        ui: function(elem, index) {
            return {
                options: this.options,
                elem: elem,
                page: this.element,
                index: index
            };
        },
        _initPage: function() {
            var o = this.options;
            o.pageindex = parseInt(o.pageindex);
            o.pagesize = parseInt(o.pagesize);
            //如果已经加载过了则置空，否则添加
            //            if (this.$page) {
            //                this.$page.empty();
            //            } else {
            //                this.$page = $('<ul/>').addClass(o.ulCss)
            //            }
            var p = this.element;
            p.empty();


            if (o.pageindex < 1) o.pageindex = 1;

            //计算总页数
            var pagecount = Math.ceil(o.total * 1.0 / o.pagesize);
            if (pagecount <= 1 && !o.onepageshow) return;
            //修正当前页的值
            if (o.pageindex > pagecount) {
                o.pageindex = pagecount - 1;
            }

            var showpagecount = o.max; //要显示的项目数量
            if (o.pageindex > 1) {
                this._addPage(p, 1, '首页'); //添加到首页
                this._addPage(p, o.pageindex - 1, '上一页'); //添加到前一页
                showpagecount -= 2; //要显示的数量减2
            }
            //如果不是最末页则要显示的数量减2
            if (o.pageindex < pagecount) {
                showpagecount -= 2;
            }
            //如果要显示的数量大于总页数将要显示的数量置为总页数
            if (showpagecount > pagecount) showpagecount = pagecount;

            //计算显示的起止页
            var startpage = 1, endpage = pagecount;
            if (showpagecount < pagecount) {
                //计算当前页前面要显示的页的起始值
                startpage = o.pageindex - Math.floor((showpagecount - 1) * 1.0 / 2);
                if (startpage < 1) startpage = 1;

                //计算结束的page
                endpage = startpage + showpagecount - 1;
                //末页修正
                if (endpage >= pagecount) {
                    endpage = pagecount;
                    startpage = endpage - showpagecount + 1;

                }
            }

            //添加页码
            for (var i = startpage; i <= endpage; i++) {
                this._addPage(p, i);
            }

            if (o.pageindex < pagecount) {
                this._addPage(p, o.pageindex + 1, '下一页');
                this._addPage(p, pagecount, '尾页');
            }

            //this.element.append(p);

            var self = this;
            $('a', p).click(function() {
                var args = self.ui(this, parseInt(this.hash.substr(1)));
                self._trigger('page', null, args);
                if (o.onpage) o.onpage(args);
                return false;
            });
        },
        getPageindex: function() {
            return this.options.pageindex;
        },
        changepage: function(pageindex, total) {
            this.options.pageindex = pageindex;
            if (total >= 0)
                this.options.total = total;
            this._initPage();
        },

        destroy: function() {
            var o = this.options;
            this.element.unbind('.pages')
			.removeClass(o.ulCss);
            //this.$page = null;
        }
    });
    $.ui.pages.getter = "getPageindex";
    $.ui.pages.defaults = {
        pageindex: 1, //当前页
        pagesize: 20, //每页大小
        max: 20, //最大显示的元素
        total: 0, //记录条数
        url: '',
        onepageshow: false,
        ulCss: 'page', //CSS
        selectCss: 'slt', //当前页的CSS
        itemCss: '' //普通页的CSS
       , onpage: null/* function(ui) { ui.page.changepage(ui.index, ui.options.total); }*/ //切换页的回调函数
    };

    //$.datepicker.setDefaults({ autoSize: true, dateFormat: "yyyy-MM-dd", changeMonth: true, changeYear: true, yearRange: 'c-100:c+10' });
})(jQuery);



