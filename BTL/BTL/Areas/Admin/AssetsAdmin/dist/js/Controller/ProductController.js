var product = {
    init: function () {
        product.registerEvent();
    },
    registerEvent: function () {
        $('.btn-images').off('click').on('click', function (e) {
            e.preventDefault();
            $('#imagesManage').modal('show');
            // gan cho ID product hien tai
            var id = $(this).data('id');
            $('#hidProductID').val(id);
            product.loadImages();
        });
        $("#btnChooseImages").off('click').on('click',function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $("#imageList").append('<div style = "float:left"><img src =' + url + ' style="width:100px;height:100px"/><a href="#" class="btn-delImage"><i class = "fa fa-times"></i></a></div>');
                $(".btn-delImage").off('click').on('click', function (e) {
                    e.preventDefault();
                    //xoa the div
                    $(this).parent().remove();
                })
            };
            finder.popup();
        });
        $('#saveImages').off('click').on('click', function () {
            var ID = $('#hidProductID').val();
            var images = [];
            //foreach trong image trong tung img 
            $.each($('#imageList img'), function (i, item) {
                //lay ra 1 mang source image
                images.push($(item).prop('src'));
            });
            $.ajax({
                //double url ???
                url: "SaveImages",
                type: "POST",
                dataType: "json",
                data: {
                    id: ID,
                    images: JSON.stringify(images)
                },
                success: function (response) {
                    //an popup
                    if (response.status) {
                        $('#imagesManage').modal('hide');
                        $("#imageList").html = '';
                        alert("Lưu thành công");
                    }
                    
                }
            });
        })
        
    },
    loadImages: function () {
        var ID = $('#hidProductID').val();
        $.ajax({
            //double url ???
            url: "LoadImages",
            type: "GET",
            dataType: "json",
            data: {
                id: ID,
            },
            success: function (response) {
                //an popup
                    var html = '';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<div style = "float:left"><img src =' + item + ' style="width:100px;height:100px"/><a href="#" class="btn-delImage"><i class = "fa fa-times"></i></a></div>';
                });
                $("#imageList").html(html);
                $(".btn-delImage").off('click').on('click', function (e) {
                    e.preventDefault();
                    //xoa the div
                    $(this).parent().remove();
                })
            }
        });
    }

}
product.init();