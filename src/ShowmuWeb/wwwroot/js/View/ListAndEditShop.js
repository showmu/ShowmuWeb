var shopedit = function () {
    var imgout = false;
    var imgin = false;
    $("#shopPhtoOut").on("change", function () {
        var imgFile = this.files[0];
        var i = imgFile.size / 1024;
        if (i > 800) {
            alert("文件太大！");
            $("#ShopPhtoOut").val("");
            return;
        }
        if (this.files && imgFile) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $("#ShopPhtoOutImg").attr("src", e.target.result);
            }
            reader.readAsDataURL(imgFile);
            imgout = true;
        }

    });
    $("#shopPhtoIn").on("change", function () {
        var imgFile = this.files[0];
        var i = imgFile.size / 1024;
        if (i > 800) {
            alert("文件太大！");
            $("#ShopPhtoOut").val("");
            return;
        }
        if (this.files && imgFile) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $("#ShopPhtoInImg").attr("src", e.target.result);
            }
            reader.readAsDataURL(imgFile);
            imgin = true;
        }

    });
    $("#newShopForm").validate({
        onsubmit: true,// 是否在提交是验证

        rules: {
            shopName: {
                required: true,
                minlength: 6
            },
            shopAddres: {
                required: true,
                minlength: 6
            },
            ShopTel: {
                required: true,
                isPhone: true
            }
        },
        submitHandler: function (form) {  //通过之后回调
            var data = {
                "Shop_ID": $("#Shop_ID").val(),
                "ShopName": $("#shopName").val(),
                "ShopAddres": $("#shopAddres").val(),
                "ShopTel": $("#ShopTel").val(),
                "ShopPhtoOut": "",
                "ShopPhtoIn": ""

            };
            if (imgin) data.ShopPhtoIn = $("#ShopPhtoInImg").attr('src');
            if (imgout) data.ShopPhtoOut = $("#ShopPhtoOutImg").attr('src');
            var d = $.toJSON(data);
            var url = "/ShopSet/SaveShop";
            $.ajax({
                url: url, //请求的url地址
                dataType: "json", //返回格式为html
                async: false, //请求是否异步，默认为异步，这也是ajax重要特性
                type: "POST", //请求方式
                data: d,
                contentType: "application/octet-stream",

                beforeSend: function () {
                    Pace.start();
                },
                success: function (req) {
                    if (req.Sate == 0) {
                        $('#myModal .modal-body').html('');
                        $('#myModal .modal-body').html('<h2>修改成功！</h2>');
                        $("#ShopSaveBt").addClass("hidden");
                    }

                },
                complete: function () {
                    Pace.stop();
                },
                error: function () {
                    Pace.stop();
                }
            });
        },

        invalidHandler: function (form, validator) {  //不通过回调
            return false;
        }
    });
    $("#SavaDelShop").click(function () {

        var url = '/ShopSet/saveDelshop';
        var shopid = $(this).attr("link");
        var data = {
            Shop_ID: shopid,
            ShopName: null,
            ShopAddres: null,
            ShopTel: null,
            ShopPhtoOut: null,
            ShopPhtoIn: null

        };
        var d = $.toJSON(data);
        $.ajax({
            url: url, //请求的url地址
            dataType: "json", //返回格式为html
            async: false, //请求是否异步，默认为异步，这也是ajax重要特性
            type: "POST", //请求方式
            data: d,
            contentType: "application/octet-stream",
            beforeSend: function () {
                Pace.start();
            },
            success: function (req) {


            },
            complete: function (req) {

                Pace.stop();
                if (req.Sate === 0) {
                    $('#myModal .modal-body').html('');
                    $('#myModal .modal-body').html('<h2>删除成功！</h2>');
                    $("#SavaDelShop").addClass("hidden");
                } else {
                    $('#myModal .modal-body').html('');
                    $('#myModal .modal-body').html('<h2>删除失败！</h2><p>错误：' + req.Massge + '</p>');
                    $("#SavaDelShop").addClass("hidden");
                }
            },
            error: function (e) {

                Pace.stop();
            }
        });


    });

}