var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            //tat chuc nang href = #
            e.preventDefault();
           //gan btn cho bien this hien tai
            var btn = $(this);
             //lay ra id cua user dang click
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Users/ChangeStatus",
                data: { id: id }, //tham so cua ham ChangStatus tren controller
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                       btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khóa');
                    }
                }
            })
        });
    }
}
user.init(); 