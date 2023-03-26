$(function () {
    $("#dialog-fiting").dialog({
        autoOpen: false,
        resizable: false,
        draggable: true,
        width: "auto",
        minHeight: 50,
        show: {
            effect: "fade",
            duration: 100
        },
        hide: {
            effect: "explode",
            duration: 500
        }
    }
    );
});

function ViewInfo(obj) {
    var title = (obj.attributes["title"]) ? obj.attributes["title"].value : $(obj).parent().parent().prev().text();
    $('#dialog-fiting').dialog("option", "title", title);
    $("#dialog-fiting").dialog("open");
    $('#dialog-fiting').dialog("widget").position({
        my: "left top",
        at: "right bottom",
        of: obj
    });
}

function UpdateInfo(obj) {
    var id = obj.id;
    var modifId = (obj.attributes.modifid) ? obj.attributes.modifid.value : null;
    updatePannel(document._action_GetWareProps + "?Id=" + id + "&modif=" + modifId, "dialog-fiting-content", "dialog-fiting-loader", ViewInfo, obj);
}

function UpdateAnalogues(obj) {
    var id = obj.attributes.wareid.value;
    var modifId = (obj.attributes.modifid) ? obj.attributes.modifid.value + '' : null;
    ViewInfo(obj);
    $('#dialog-fiting-content').empty();
    updatePannel(document._action_GetWareReplacements + "?Id=" + id + "&inPopup=true" + "&modif=" + modifId, "dialog-fiting-content", "dialog-fiting-loader", function () {
        window.setYourPriceVisibility();
        applySpinnerWidget();
    });
}

function UpdateActionInfo(obj) {
    // disabled 
    return;
    var id = obj.id;
    var discGroupTypeId = (obj.attributes.discgrouptypeid) ? obj.attributes.discgrouptypeid.value : null;
    updatePannel(document._action_GetWareActionInfo + "?Id=" + id + "&discGroupTypeId=" + discGroupTypeId, "dialog-fiting", null, ViewInfo, obj);
}
