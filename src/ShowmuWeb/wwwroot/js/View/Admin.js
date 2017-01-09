



var clicked = {};


function showModal() {
    var src = $(this).attr("src");
    var img = '<img id="see" src="' + src.replace("Min/", "") + '" class="img-responsive img-rounded"/>';
    var index = $(this).parent("div").attr("data-index");


    clicked.prevImg = parseInt(index) - parseInt(1);
    clicked.nextImg = parseInt(index) + parseInt(1);

    var html = "";
    html += '<div class="modal-header">';


    var result = src.substring(src.lastIndexOf("/") + 1);
    html += '<div id="next" class="btn-group Absolute-Center" role="group" aria-label="...">';
    html += '<button type="button" class="btn btn-default controls previous" link="' +
        (clicked.prevImg) +
        '"><span class="glyphicon glyphicon-chevron-left"></span></button>';
    html += '<button id="bt-goodsname" type="button" class="btn btn-default controls disabled" link="' +
        (parseInt(index)) +
        '">' +
        result.replace(".jpg", "") +
        "</button>";
    html += '<button type="button" class="btn btn-default controls next" link="' +
        (clicked.nextImg) +
        '"><span class="glyphicon glyphicon-chevron-right"></span></button>';
    html += "</div>";
    html += "</div>";
    html += '<div class="modal-body ">';
    html += img;
    html += "</div>";
    html += ' <div class="modal-footer">';

    html += '<a href="#" class="btn btn-success" data-dismiss="modal">关闭</a>';
    html += "</div>";

    $("#myModal").modal();

    $("#myModal .modal-content").html(html);
    showHideControls();

    $("#next")
        .find("button")
        .each(function() {
            $(this).on("click", nextPrevHandler);
        });

    $("#myModal")
        .on("hidden.bs.modal",
            function() {
                $("#myModal .modal-content").html("");
            });
}


function nextPrevHandler() {

    var index = $(this).attr("link");
    var src = $('div[data-index="' + index + '"] img').attr("src");

    $(".modal-body img").attr("src", src.replace("Min/", ""));
    var result = src.substring(src.lastIndexOf("/") + 1);
    $("#bt-goodsname").text(result.replace(".jpg", ""));
    clicked.prevImg = parseInt(index) - 1;
    clicked.nextImg = parseInt(clicked.prevImg) + 2;

    if ($(this).hasClass("previous")) {
        $(this).attr("link", clicked.prevImg);
        $("button.next").attr("link", clicked.nextImg);
    } else {
        $(this).attr("link", clicked.nextImg);
        $("button.previous").attr("link", clicked.prevImg);
    }

    showHideControls();

    return false;

}

function showHideControls() {

    var total = ($("div.thumbnail").length);

    if (total === clicked.nextImg) {
        $("button.next").hide();
    } else {
        $("button.next").show();
    }
    $("#see")
        .click(function() {
            $("#myModal").modal("hide");
        });
    if (clicked.prevImg === -1) {
        $("button.previous").hide();
    } else {
        $("button.previous").show();
    }
}

var ajaxHtml = function(url) {
    var myHtml;

    $.ajax({
        url: url, //请求的url地址
        dataType: "html", //返回格式为html
        async: false, //请求是否异步，默认为异步，这也是ajax重要特性
        type: "GET", //请求方式
        beforeSend: function() {
            Pace.start();
        },
        success: function(req) {
            myHtml = req;
        },
        complete: function(req) {
            Pace.stop();
        },
        error: function(a) {
            myHtml = "<p>出错了</p>";

        }
    });


    return myHtml;
};
var showinf = function() {
    $("#myModal .modal-content").html("");
    var html = "";
    html += '<div class="modal-header">';
    html += "<h2>提示";
    html += "</h2>";
    html += "</div>";
    html += '<div class="modal-body ">';
    html += "<p>正在加载数据.......</p>";
    html += "</div>";
    html += ' <div class="modal-footer">';
    html += '<a href="#" class="btn btn-success" data-dismiss="modal">关闭</a>';
    html += "</div>";
    $("#myModal .modal-content").html(html);
    $("#myModal").modal();
};
var showHtml = function(url) {
    $("#myModal .modal-content").html("");
    var html = "";

    html = ajaxHtml(url);

    $("#myModal .modal-content").html(html);

    $("#myModal").modal();
};
var addTab = function(MyHtml /* 内容 */, t /* 标题 */, ID /* 连接ID*/, Url) {


    var MyID = "#a" + ID;
    var tabcontenthtml = '<div class="tab-pane" id="' + ID + '">' + MyHtml + "</div>";
    if ($(MyID)[0]) {
        $(MyID).attr("link", Url);
        $("#" + ID).remove(); //内容清除
        $("#mytabs-content").append(tabcontenthtml); //内容增加
        $("#mytabs a:first").tab("show");
        $('#mytabs a[href="#' + ID + '"]').tab("show");

    } else {
        var tabhtml = '<li id="li' +
            ID +
            '" class=""><a link="' +
            Url +
            '" aria-expanded="false" id="a' +
            ID +
            '" href="#' +
            ID +
            '" data-toggle="tab">' +
            t +
            '<i id="i' +
            ID +
            '" class="fa fa-times tabsClosei"></i></a></li>';


        $("#mytabs").append(tabhtml);

        $("#mytabs-content").append(tabcontenthtml);
        var a = "#a" + ID;
        $("#mytabs a:last").tab("show");
        $("#i" + ID)
            .click(function() {
                delTab(ID);
            });

    }
};
var addTabAsUrl = function(Url /* 内容 */, t /* 标题 */, ID /* 连接ID*/) {


    var MyID = "#a" + ID;
    var tabcontenthtml = '<div class="tab-pane" id="' +
        ID +
        '"><iframe scrolling="auto" frameborder="0" " src="' +
        Url +
        '"></iframe></div>';
    if ($(MyID)[0]) {
        $("#" + ID).remove(); //内容清除
        $("#mytabs-content").append(tabcontenthtml); //内容增加
        $("#mytabs a:first").tab("show");
        $('#mytabs a[href="#' + ID + '"]').tab("show");

    } else {
        var tabhtml = '<li id="li' +
            ID +
            '" class=""><a link="' +
            Url +
            '" aria-expanded="false" id="a' +
            ID +
            '" href="#' +
            ID +
            '" data-toggle="tab">' +
            t +
            '<i id="i' +
            ID +
            '" class="fa fa-times tabsClosei"></i></a></li>';

        $("#mytabs").append(tabhtml);

        $("#mytabs-content").append(tabcontenthtml);
        var a = "#a" + ID;
        $("#mytabs a:last").tab("show");
        $("#i" + ID)
            .click(function() {
                delTab(ID);
            });

    }
};

var delTab = function(ID) {
    $("#li" + ID).remove(); //标题清除
    $("#" + ID).remove(); //内容清除
    $("#mytabs a:last").tab("show"); //切换到最后一和tab
};
var searchGoodsurl = function(url, tile, id) {
    $.ajax({
        url: url, //请求的url地址
        dataType: "html", //返回格式为html
        async: true, //请求是否异步，默认为异步，这也是ajax重要特性
        type: "GET", //请求方式
        beforeSend: function() {

            Pace.start();
        },
        success: function(req) {
            addTab(req, tile, id, url);
        },
        complete: function() {

            $("#myModal1")
                .find("div.thumbnail")
                .each(function(i) {
                    $(this).attr("data-index", i);
                    var img = $(this).find("img");
                    img.on("click", showModal);
                });

            $("#myModal .modal-content").html("");
            $("#MyPageNav" + id)
                .find("li")
                .not(".disabled")
                .each(function() {
                    var url = $(this).find("a").attr("link");
                    $(this)
                        .find("a")
                        .click(function() {
                            searchGoodsurl(url, tile, id);

                        });
                });
            $("#newShop")
                .click(function() {
                    addTabAsUrl("/Shopset/Addshop", "添加店面", "AddShop");
                });
            //绑定编辑事件
            $("#ShopList")
                .find("a")
                .each(function() {
                    var link = $(this).attr("link");
                    $(this)
                        .click(function() {
                            $("#myModal").addClass("bs-example-modal-lg");
                            showHtml(link);
                            shopedit();


                        });

                });
            //绑定新建员工
            $("#newShoper")
                .click(function() {
                    var link = $(this).attr("link");
                    $("#myModal").addClass("bs-example-modal-lg");
                    showHtml(link);
                    newshoperval(); //验证
                });
            ShoperIndex(tile, id);


        },
        error: function(a) {
            //请求出错处理

        }
    });
};
var ShoperIndex = function(tile, ID) {
    $("#shoper_seacherbt")
        .click(function() {
            var q = $("#shop_Input").val();
            if (q === null) {

            } else {
                var url = "/Shoper/Index?q=" + q + "&page=1";
                searchGoodsurl(url, tile, ID);
            }


        });
};
$(document)
    .ajaxStart(function() {
        Pace.start();
    });
$(document)
    .ajaxComplete(function() {
        Pace.stop();
    });


$(document)
    .ready(function() {
        //初始化

        $("#webaside").html(ajaxHtml("/AdminManage/AdminAside"));

        $("#webheader").html(ajaxHtml("/AdminManage/AdminTop"));
        $("#mytabs").tabdrop();
        $(".sidebar-menu")
            .find("a[link]")
            .each(function(i) {
                $(this)
                    .click(function() {
                        var url = $(this).attr("link");
                        var linkType = $(this).attr("type");
                        var title = $(this).html().toString().replace("<i class=\"fa fa-circle-o\"></i>", "");
                        if (url !== "#" && url !== "") {

                            if (linkType === "html") {
                                searchGoodsurl(url + "&id=left" + i, title, "left" + i);

                            } else {
                                addTabAsUrl(url, title, "left" + i);
                            }
                        }
                    });
            }); //end each

        $(".user-footer")
            .find("a[link]")
            .each(function(i) {
                $(this)
                    .click(function() {
                        var url = $(this).attr("link");
                        var linkType = $(this).attr("type");
                        var title = $(this).html().toString().replace("<i class=\"fa fa-circle-o\"></i>", "");
                        if (url !== "#" && url !== "") {

                            if (linkType === "html")
                                searchGoodsurl(url, title, "Top" + i);
                            else {
                                addTabAsUrl(url, title, "Top" + i);
                            }
                        }
                    });
            }); //end each
        $("#myModal")
            .on("hidden.bs.modal",
                function() {
                    $("#myModal .modal-content").html("");
                });
        $("#search-btn")
            .click(function() {
                var searchword = $("input[name=q]").val();
                var url = "/Goods/GoodsSeacherActionResult?q=" + searchword + "&page=1";
                searchGoodsurl(url + "&id=search", "产品搜索", "search");
            });
    });
    
                   


