$(document).ready(function () {
    $('#menu_customers').addClass('active');
    $("#avatar").fileinput({
        overwriteInitial: true,
        maxFileSize: 200,
        showClose: false,
        language: "fa",
        showCaption: false,
        browseLabel: '',
        removeLabel: '',
        browseIcon: '<i class="icon-file-plus ml-0"></i>',
        removeClass: 'btn btn-link btn-icon btn-xs',
        removeIcon: '<i class="icon-trash ml-0"></i>',
        removeTitle: 'حذف',
        browseClass: 'btn bg-slate-700',
        elErrorContainer: '#kv-error',
        msgErrorClass: 'alert alert-block alert-danger',
        defaultPreviewContent: '<img src="/assest/images/logo-placeholder.jpg" alt="لوگو">',
        layoutTemplates: { main2: '{preview} {remove} {browse}' },
        allowedFileExtensions: ["jpg", "gif", "png", "jpeg", "bmp", "gif"]
    });

    var image = $('#Base64Image').val();

    if (image != '' && image != undefined) {
        $(".file-default-preview > img").attr("src", "data:image/jpg;base64," + image);
        $("#submit").html('ویرایش <i class="icon-pencil7 position-right"></i>')
    }

    $('#frm_customers').submit(function () {

        var file = document.getElementById('avatar').files[0];
        if (file == undefined && $('#Base64Image').val() == '') {
            $('#kv-error').html('لطفا لوگو را انتخاب نمایید').show();
            return false;
        }
        if (!CheckFile(file)) {
            return false;
        }

    })

})

function CheckFile(file) {
    var exts = ["jpg", "gif", "png", "jpeg", "bmp", "gif"];
    var get_ext = file.name.split('.');
    get_ext = get_ext.reverse();
    if ($.inArray(get_ext[0].toLowerCase(), exts) > -1) {
        if (file.size > 20480) {
            $('#kv-error').html('حجم مجاز برای لوگو حداکثر 200کیلوبایت میباشد');
            $('#kv-error').show();
            return false;
        }
    }
    else {
        $('#kv-error').html('<span class="close kv-error-close">×</span> فقط فرمت های "jpg, gif, png, bmp, jpeg" مجاز میباشد.');
        $('#kv-error').show();
        return false;
    }
    return true;

}