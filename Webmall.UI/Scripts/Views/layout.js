$(function() {
    // Смена текущего клиента
    $("#currentClient").change(function() {
        var id = $("#currentClient").val();
        var url = document._action_ChangeCurrentClient;
        var currentUrl = document._currentUrl;
        document.location.href = url + "?id=" + id + "&returnUrl=" + currentUrl;
    });

    $("#askForm").validate({
        rules: {
            email: {
                required: true,
                maxlength: 50
            },
            name: {
                required: true,
                maxlength: 50
            },

        }
    });

    $(".header-banner__close").click(function () {
        var expire = new Date();
        expire.setTime(new Date().getTime() + 3600000 * 24 * 7);
        
        document.cookie = "informer=" + ($(this).data("id") || "") + "; Expires=" + expire.toGMTString() +"; Path=/";
    });

    document.logOnValidationRules = {
        errorClass: "error__desc",
        errorElement: "small",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
            $(element).parent().addClass('error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
            $(element).parent().parent().removeClass('error');
        },
        rules: {
            UserName: {
                required: true
            },
            Pass: {
                required: true
            }
        }
    };

    $("#form-logon").validate(document.logOnValidationRules);

});

//function openQuestionDialog(errorDialog) {
//    html2canvas(document.body, {
//        onrendered: function (canvas) {
//            //var data = canvas.toDataURL('image/png').replace(/data:image\/png;base64,/, '');
//            //$('#img').val(data);
//            ////все возникшие проблемы решились удалением canvas
//            //$('canvas').remove();
//            $('#dialog-question').dialog("option", "title", errorDialog ? "@SharedResources.ReportAboutError" : "@SharedResources.AskManager");
//            $('#questionLabel').text(errorDialog ? "@SharedResources.DescribeError" : "@SharedResources.Question");
//            $('#dialog-question').dialog('open');
//        }
//    });
//}

function removeCar(id) {
    if (!confirm(window.areYouSure)) return false;

    $.post(`/Garage/Delete?id=${id}`, null, function () {
        $(`#user-car-${id}`).remove();
        $(`#cont-${id}`).remove();
    });
    return false;
}

function selectCar(id) {
    $.post(`/Garage/Select?id=${id}`, null, function () {
        location.reload();
    });
}
