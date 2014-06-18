

$(function () {
    var pageSummary = function () {

        if ($("#list") == null) {
            return;
        }
        var pageCount = parseInt($("#list").attr("pagecount"));

        var pageIndex = parseInt($("#list").attr("pageindex"));
        var pageSize = $('#list').attr("pagesize");
        var recordCount = $("#list").attr("recordcount");

        if (pageCount > 1) {

            var pagerHtml = "<a class='badge badge-inverse' href='#1'>首页</a>";
            var prevPage = pageIndex - 1;
            if (prevPage <= 1) {
                prevPage = 1;
            }
            pagerHtml += "<a class='badge badge-inverse' href='#" + prevPage + "'>上一页</a>";
            //大于一页时再分页
            var startPageIndex = pageIndex - 4;
            if (startPageIndex <= 0) {
                startPageIndex = 1;
            }
            var j = 0;
            for (var i = startPageIndex; i <= pageCount; i++) {
                j++;
                if (j > 5) {
                    break;
                }
                if (pageIndex == i) {
                    pagerHtml += "<a class='badge badge-warning' href='#" + i + "'>" + i + "</a>";
                } else {
                    pagerHtml += "<a class='badge badge-inverse' href='#" + i + "'>" + i + "</a>";
                }

            }
            var nextPage = pageIndex + 1;
            if (pageCount < nextPage) {
                nextPage = pageCount;
            }
            pagerHtml += "<a class='badge badge-inverse' href='#" + nextPage + "'>下一页</a>";

            pagerHtml += "<a class='badge badge-inverse' href='#" + pageCount + "'>尾页</a>";

            $('#Pager').html(pagerHtml);
        }


    };


    $('a.badge-inverse').live('click', function () {
        var href = $('a.btnsearch').attr('href');
        var pageIndex = parseInt(this.hash.substr(1));
        $.get(href + "?pageIndex=" + pageIndex, function (data) {
            $('#PageContent').html(data);


            pageSummary();
        });
    });


    $('a.btnsearch').each(function () {
        var self = $(this);
        var oPage = $("#Pager");
        var href = self.attr("href");
        var pramers = "";
        $(':input').each(function () {
            pramers += "";
        });


        $.get(href + "?" + pramers, function (data) {
            $('#PageContent').html(data);

            //            var dataTable = $('#PageContent').children();
            //            var oPage = $("#Pager");
            //oPage.pages('changepage', dataTable.attr("pageindex"), dataTable.attr("recordcount"));


            pageSummary();
        });



    });
});
