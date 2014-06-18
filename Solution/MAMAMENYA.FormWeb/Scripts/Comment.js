var Comment;
if (!Comment) {
    Comment = {};
}


Comment.Init = function () {

    $('.Del').live('click', function () {
        var re = confirm("确定要删除这则评论吗？");
        if (re) {
            var id = $(this).attr('name');
            $.get("/AjaxHandler/BalaAjax.aspx?action=DelComment&ObjectId=" + id, function (data) {
                alert(data);
                window.reload();
            });
        }

    });

    $('.Pass').live('click', function () {
        var re = confirm("确定要将这则评论通过审核吗？");
        if (re) {
            var id = $(this).attr('name');
            AuditComment("1", id);
        }

    });

    $('.UnPass').live('click', function () {
        var id = $(this).attr('name');
        AuditComment("0", id);
    });


    var AuditComment = function (a, id) {
        $.get("/AjaxHandler/BalaAjax.aspx?action=DelComment&ObjectId=" + id, function (data) {
            alert(data);
            window.reload();
        });
    };
};