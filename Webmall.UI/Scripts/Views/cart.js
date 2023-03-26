var commentId = 0;
var commentText = "";
var editBlock;

function CartAddPositionComment(id, el) {
    commentId = id;
    editBlock = $(el);
}

function CartEditPositionComment(id) {
    commentId = id;
    commentText = $("#comment_" + id).html();
    $("#editPositionCommentText").val(commentText);
}

function SubmitEditPositionComment() {
    var url = document._action_cart_EditComment;
    if ($("#editPositionCommentText").val()) {
        $.post(
            url,
            {
                id: commentId,
                comment: $("#editPositionCommentText").val()
            }
        )
            .done(function () {
                $("#comment_" + commentId).html($("#editPositionCommentText").val());
                $(".modal-win__close").click();
            })
            .fail(function () {
                console.log("error");
                $(".modal-win__close").click();
            });
    }
    $(".modal-win__close").click();
}

var intervalEditComment;
function SubmitEditPositionCommentMobile(el, id) {
    var url = document._action_cart_EditComment;
    clearTimeout(intervalEditComment);
    if ($(el).val()) {
        intervalEditComment = setTimeout(function () {
            $.post(
                url,
                {
                    id: id,
                    comment: $(el).val()
                }
            )
                .done(function () {

                })
                .fail(function () {

                });
        }, 1000);
    }
}

function SubmitAddPositionComment() {
    var url = document._action_cart_EditComment;
    if ($("#addPositionCommentText").val()) {
        $.post(
            url,
            {
                id: commentId,
                comment: $("#addPositionCommentText").val()
            }
        ).done(function () {
            $(editBlock).replaceWith(
                '<div class="custom-comment" data-modal-win-trigger="comment-edited" onclick="CartEditPositionComment(' +
                commentId +
                ')"><div class="custom-comment__desc" id="comment_' +
                commentId +
                '">' +
                $("#addPositionCommentText").val() +
                '</div><ul class="custom-comment__helpers spec-helpers"><li class="spec-helpers__helper"><span class="spec-helpers__link"><svg class="spec-helpers__icon" width="11" height="11" viewBox="0 0 11 11" fill="none" xmlns="http://www.w3.org/2000/svg"><path d="M0.631774 6.93641L0.015424 9.59645C-0.00583801 9.69369 -0.00510913 9.79445 0.0175573 9.89137C0.0402238 9.98829 0.0842552 10.0789 0.146435 10.1566C0.208615 10.2344 0.287373 10.2972 0.376954 10.3406C0.466536 10.384 0.564679 10.4068 0.664213 10.4074C0.710592 10.4121 0.757324 10.4121 0.803703 10.4074L3.47996 9.79108L8.61837 4.67214L5.75072 1.81097L0.631774 6.93641Z" fill="#828282"></path><path d="M10.2338 2.1094L8.31984 0.195476C8.19401 0.0702808 8.02373 0 7.84622 0C7.66872 0 7.49844 0.0702808 7.37261 0.195476L6.30859 1.25949L9.173 4.1239L10.237 3.05988C10.2993 2.9973 10.3486 2.92305 10.3821 2.84139C10.4157 2.75973 10.4328 2.67225 10.4325 2.58397C10.4322 2.49569 10.4145 2.40833 10.3804 2.3269C10.3463 2.24547 10.2965 2.17156 10.2338 2.1094Z" fill="#828282"></path></svg></span></li></ul></div>')
            $(".modal-win__close").click();
        })
            .fail(function () {
                console.log("error");
                $(".modal-win__close").click();
            });
    }
    $(".modal-win__close").click();
}

function UpdateCartDialog(id) {
    var el = document.getElementById("mob-qnt-" + id);
    document.getElementById("saleMultiplicity").innerText = el.dataset.saleQnt > 0 ? el.dataset.saleQnt : 1;
    document.getElementById("onWarehouse").innerText = el.dataset.warehouseQnt > '' ? el.dataset.warehouseQnt : '-';

    var input = document.getElementById("quantityCartDialog");
    input.value = el.innerText;
    input.dataset.id = id;
}

//function MobUpdatePosition(id, qnt) {
//    $("input[name=quantity-mob]").data("positionId", id);
//    $("input[name=quantity-mob]").val(qnt);
//}

function RemoveCartPosition(el, positionId) {
    var par = $(el).parent().parent().parent();
    var url = document._action_cart_DeletePosition;

    $.get(url,
        {
            id: positionId,
            returnUrl: window.location.pathname
        }
    )
        .done(function () {
            $(el).parent().parent().remove();
            if ($(par).children().length === 0) {
                window.location.reload();
            }
            RecalcSelected();
            RecalcSelectedMobile();
        })
        .fail(function () {
            console.log("error remove cart position");
        });
}

function RemoveCartPositionMob(el, positionId) {
    var par = $(el).parent().parent().parent();
    var url = document._action_cart_DeletePosition;

    $.get(url,
        {
            id: positionId,
            returnUrl: window.location.pathname
        }
    )
        .done(function () {
            $(par).remove();
            if ($(".orders-list__mob-order").length === 0) {
                window.location.reload();
            }
            RecalcSelected();
            RecalcSelectedMobile();
        })
        .fail(function () {
            console.log("error remove cart position");
        });

}

function Delete(action) {
    event.preventDefault();

    if ($('input[name=selected]:checked').length === 0) {
        alert(document._message_NothingChecked);
        return false;
    }

    if (!confirm(document._message_DeleteSelectedPositions)) return false;
    var formData = new FormData(document.getElementById("desktopForm"));
    //var form = $("#saveContactForm");

    $.ajax(document._action_cart_DeletePositions, {
        type: "POST",
        data: formData,
        contentType: false,
        processData: false
    }).done(function (data) {
        location.reload();
    });
    return false;
}

$(function () {
    $('[name=selected], [name=is-opt-0]').change(function (event) {
        var id = "m-" + event.target.id;
        document.getElementById(id).checked = event.target.checked;
        RecalcSelected();
        RecalcSelectedMobile();
    });
    $('[name=m-selected], [name=m-is-opt-0]').change(function (event) {
        var id = event.target.id.replace("m-", "");
        document.getElementById(id).checked = event.target.checked;
        RecalcSelected();
        RecalcSelectedMobile();
    });
    RecalcSelected();
    RecalcSelectedMobile();
});

function group() {
    var url = document._action_cart_Index + '?group=' + $('#group').attr("checked");
    document.location.href = url;
}

function JumpNext(e, id) {
    var key;
    if (window.event)
        key = window.event.keyCode; //IE
    else
        key = e.which; //firefox

    if (key === 13) {
        var element;
        if (e.currentTarget)
            element = e.currentTarget; // ff
        else element = e.srcElement; //IE
        UpdatePosition(element, id);

        //
        //var next = $("input[type=text]").index(element) + 1;
        //$("input[type=text]:eq(" + next + ")").focus();
        return false;
    }
    return true;
}

function UpdatePosition(ctrl, id) {

    if (!id) id = document.getElementById("quantityCartDialog").dataset.id; //$("input[name=quantity-mob]").data("positionId");

    var value = $(ctrl).val();
    var url = document._action_cart_UpdatePostition;
    if (!value || value < 1)
        return;
    $.post(
        url,
        { positionId: id, value: value },
        function (data) {
            var position = data.position;

            $("#mob-qnt-" + position.Id).text(value);
            //$("#inp-mob-qnt-" + position.Id).value(value);
            $("#inp-qnt-" + position.Id).val(value);

            var posSum = (position.ClientPrice).toFixed(2) * position.WareQnt;
            $("#position" + id).text(moneyShow(posSum));
            $("#positionMobile" + id).text(moneyShow(posSum));

            RecalcSelected();
            RecalcSelectedMobile();
        });
}

function CheckPosisionsCount() {
    if ($('input[name=selected]:checked').length === 0) {
        alert(document._message_NothingChecked);
        return false;
    }
    if ($('input[name=selected]:checked').length > 1000) {
        alert(document._message_MaxCartPositionMessage);
        return false;
    }

    return true;
}

function CheckAll(el) {
    var checked = $(el.srcElement).is(':checked');
    $('input[name=selected]').attr('checked', checked);
    $('input[name=selected]').trigger(checked ? 'check' : 'uncheck');
    RecalcSelected();
    RecalcSelectedMobile();
}

function AdjustChecking() {
    if ($('#checkAll').is(':checked')) {
        $('#checkAll').attr("checked", false);
        $('#checkAll').trigger('uncheck');
    }
    if ($('input[name=selected]:checked').length === $('input[name=selected]').length && (!$('#checkAll').is(':checked'))) {
        $('#checkAll').attr('checked', true);
        $('#checkAll').trigger('check');
    }
    RecalcSelected();
}

function AdjustCheckingMobile() {
    if ($('#checkAllMobile').is(':checked')) {
        $('#checkAllMobile').attr("checked", false);
        $('#checkAllMobile').trigger('uncheck');
    }
    if ($('input[name=selected]:checked').length === $('input[name=selected]').length && (!$('#checkAllMobile').is(':checked'))) {
        $('#checkAllMobile').attr('checked', true);
        $('#checkAllMobile').trigger('check');
    }
    RecalcSelectedMobile();
}

function RecalcSelected() {
    var sum = 0;
    var qnt = 0;

    $.each($('input[name=selected]:checked'), function (index, value) {
        var row = value.closest('.stock-table__row');
        var itemQnt = getNumeric(row.querySelectorAll("input.counter__input")[0].value);
        qnt += itemQnt;
        var itemSum = getNumeric(row.querySelectorAll(".cart-sum")[0].innerText);
        sum += itemSum;
    });

    //$.each($('#desktopForm .orders-list__total'), function (index, value) {
    //    var itemSum = getNumeric($(value).text());
    //    sum += itemSum;
    //});

    //$.each($('#desktopForm input[name=quantity]'), function (index, value) {
    //    var itemQnt = getNumeric($(value).val());
    //    qnt += itemQnt;
    //});

    var spanSum = $('#totalSelectedSum');
    var spanQnt = $('#totalQnt');
    spanSum.text(moneyShow(sum));
    spanQnt.text(moneyShow(qnt));

}

function RecalcSelectedMobile() {
    var sum = 0;
    var qnt = 0;
    $.each($('input[name=m-selected]:checked'), function (index, value) {
        var row = value.closest('.stock-mob-table__row');
        var itemQnt = getNumeric(row.querySelectorAll(".stock-mob-table__counter-trigger.input")[0].innerText);
        qnt += itemQnt;
        var itemSum = getNumeric(row.querySelectorAll(".stock-mob-table__price-primary")[0].innerText);
        sum += itemSum;
    });

    var spanSum = $('#totalSelectedSumMobile');
    var spanQnt = $('#totalQntMobile');
    spanSum.text(moneyShow(sum));
    spanQnt.text(moneyShow(qnt));
}

function ShowMessageCart() {
    var contentm = document.getElementById("show-message-cart");
    var showcartError = new Modal({ content: contentm });
    showcartError.open();
}

$(function () {
    var textUploadFileLabel = $(".upload-file__label").html();
    document.jurValidationRules = {
        errorClass: "error__desc",
        errorElement: "small",
        highlight: function (element, errorClass, validClass) {
            $(element).addClass(errorClass).removeClass(validClass);
            var parent = $(element).parent('.main-form__field');
            if (!parent.length)
                parent = $(element).parent().parent('.main-form__field');
            parent.addClass('error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass(errorClass).addClass(validClass);
            var parent = $(element).parent('.main-form__field');
            if (!parent.length)
                parent = $(element).parent().parent('.main-form__field');
            parent.removeClass('error');
        },
        rules: {

            UploadFile: {
                required: true,
                extension: "xlsx|xls|xlsm"
            }
        }
    };
    $("#upload-import-cart-form").validate(document.jurValidationRules);

    $('#UploadFile').on('change', function () {
        if ($("#upload-import-cart-form").valid() == true) {
            $("#importRowSettings").show();
        }
    });

    $("#upload-import-cart-form").submit(function (event) {

        if ($("#upload-import-cart-form").valid() == true) {
            $(".modal-win__close").click();

            var formData = new FormData($("#upload-import-cart-form")[0]);

            $.ajax({
                url: document._action_cart_ImportToExele,
                data: formData,
                processData: false,
                contentType: false,
                type: 'POST',
                success: function (data) {
                    setTimeout(() => {
                        var content = document.getElementById("show-message-cart");
                        var showcartError = new Modal({ content: content });
                        showcartError.open();
                        $(".cart").replaceWith(data);
                        RecalcSelected();
                        RecalcSelectedMobile();
                        setTimeout(() => {
                            showcartError.close();
                        },
                            2500);
                    },
                        1000);
                }
            });

            $("#importRowSettings").hide();
            $("#UploadFile").val("");
            $(".upload-file__label").html(textUploadFileLabel);

            return false;
        }
        return false;
    });
    return false;
});