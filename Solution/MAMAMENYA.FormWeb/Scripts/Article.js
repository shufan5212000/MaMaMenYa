﻿var Article;
if (!Article) {
    Article = {};
}

Article.Manage = function () {

    $('.Del').live("click", function () {
        var objId = $(this).attr("name");
        $('body').alert(
            { type: 'confirm',
                buttons: [
                    { id: 'yes', name: '确定', callback: function () {

                        $.get("/AjaxHandler/BalaAjax.aspx?action=DelArtile&ObjectId=" + objId, function () {
                            window.location.reload();
                        });
                    }
                    },
                    { id: 'no', name: '取消' }
                ]
            });
    });
};