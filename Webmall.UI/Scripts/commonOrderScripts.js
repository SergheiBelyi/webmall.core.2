function SaveOrder() {
    var form = $("#orderForm");
    var url = form.attr("action");
    var data = form.serialize();
    $.post(url, data, function () {
    });
}

function ShowComment() {
    $('[name="Order.Comment"]').show();
    $('#btnOrderComment').hide();
}

function SaveComment() {
    var comment = $('[name="Order.Comment"]');
    comment.val(comment.val().substring(0, 200));
    SaveOrder();
    $('#btnSaveOrderComment').hide();
    return false;
}

function AllowNext() {
    $('.nextButton').removeAttr('disabled');
    $('.nextButton').removeClass('submit-inactive');
}

function BlockNext() {
    $('.nextButton').addClass('submit-inactive');
    $('.nextButton').attr('disabled', 'disabled');
    showSecondPage = false;
}

function AllowFinish() {
    $('#finishButton').removeAttr('disabled');
    $('#finishButton').removeClass('submit-inactive');
}

function BlockFinish() {
    $('#finishButton').addClass('submit-inactive');
    $('#finishButton').attr('disabled', 'disabled');
}

function numberMul(a, b, p) {
    var pr = Math.pow(10, p);
    var s = Math.round((a * b) * pr).toString();
    return parseFloat(s) / pr;
}

function CheckAll(id) {
    var checked = $(id.target).is(':checked');
    $(id.target).parents("table").find("[groupId='positions']").prop('checked', checked);
}

function AdjustChecking(id) {
    $(id.target).parents("table").find('#checkAll').prop('checked', $(id.target).parents("table").find("[groupId='positions']:checked").length == $(id.target).parents("table").find("[groupId='positions']").length);
}

function JumpNext(e) {
    var key;
    if (window.event) key = window.event.keyCode; //IE
    else key = e.which; //firefox
    if (key == 13) {
        var element;
        if (e.currentTarget)
            element = e.currentTarget; // ff
        else element = e.srcElement; //IE
        //
        var elements = $("input[name=WareQnt]").length;
        var next = $("input[name=WareQnt]").index(element) + 1;
        if (next < elements)
            $('input[name=WareQnt]:eq(' + next + ')').focus();
        else $("#wareListNextButton").focus();
        return false;
    }
    return true;
}

function UpdateAllPositions() {
    var e = $.Event('change');
    $('input[name=WareQnt]').trigger(e);
    $("#confirmWarehouseName").text($("#Order_WarehouseId > option[value=" + $("#Order_WarehouseId").val() + "]").text());
}

function ExecuteOrder() {
    $("#execute").val(true);
    var paymentId = $("#paymentId").val();
    $("#orderForm").submit();
    return false;
}