var AddDivShow;
if (!AddDivShow) {
    AddDivShow = {};

}


AddDivShow.PageAdmin = function() {

    $('#btnAddAdmin').click(function() {
        $('#AddContent').show('slow');
    });

};


AddDivShow.PageProductClass = function () {
    $('#btnAddProductClass').click(function () {

        $('#AddProductClassContent').show('slow');
    });


    $('.Del').live('click', function () {
        var result = confirm("确定删除这条产品分类吗？");
        var id = this.name;

        if (result) {
            $.get("/AjaxHandler/BalaAjax.aspx?action=DelProductClass&ObjectId=" + id, function (data) {
                alert(data);
                window.location.reload();
            });
            
        }
    });


};


AddDivShow.PageArticleClass = function () {
    
    $('#btnAddArticleClass').click(function () {
        $('#AddArticleClassContent').show('slow');
    });


    $('.Del').live('click', function () {
        var result = confirm("确定删除该分类吗？");
        var id = this.name;

        if (result) {
            $.get("/AjaxHandler/BalaAjax.aspx?action=DelArticleClass&ObjectId=" + id, function (data) {
                alert(data);
                window.location.reload();
            });
           
        }
    });
};
