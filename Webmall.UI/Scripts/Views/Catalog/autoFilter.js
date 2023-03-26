$(function() {
    $('#AutoModel').combogrid({
        width: 300,
        panelWidth: 550,
        value: window.SelectionByAutoMarkModel_AutoModel,
        mode: 'local',
        loadMsg: "Loading..",
        idField: 'Id',
        textField: 'Name',
        valueField: "Id",
        url: window.url_GetModelListByMark,
        queryParams: { markId: window.markId },
        fitColumns: true,
        columns: [
            [
                { field: 'Id', title: 'Id', hidden: true },
                { field: 'Name', title: window.sr_ModelOfCar, width: 326 },
                { field: 'Start', title: window.sr_StartYear, width: 101 },
                { field: 'End', title: window.sr_EndYear, width: 101 }
            ]
        ],
        onShowPanel: function() {
            this.oldValue = window.SelectionByAutoMarkModel_AutoModel;
            if (!window.wasEmptied &&
            ((this.oldValue == 0 && $(this).combogrid("getText") == window.sr_SelectModel) ||
                (this.oldValue != 0 && this.oldValue == $(this).combogrid("getValue")))) {
                this.oldText = $(this).combogrid("getText");
                $(this).combogrid("setText", String.Empty);
                window.wasEmptied = true;
            }
        },
        onHidePanel: function() {
            window.wasEmptied = false;
            var newValue = $(this).combogrid("getValue");
            if (newValue != this.oldValue) {
                return false;
            }
            if (this.oldValue == 0) {
                $(this).combogrid("setText", this.oldText);
            }
            return false;
        },
        onSelect: AutoModelSelected
    });

    $('#AutoModif').combogrid({
        width: 300,
        panelWidth: 650,
        value: window.SelectionByAutoMarkModel_AutoModif,
        mode: 'local',
        loadMsg: "Loading..",
        idField: 'Id',
        textField: 'Name',
        valueField: "Id",
        url: window.url_GetModifListByModel,
        queryParams: { modelId: window.SelectionByAutoMarkModel_AutoModel },
        fitColumns: true,
        columns: [
            [
                { field: 'Id', title: 'Id', hidden: true },
                { field: 'Name', title: window.s_EngineNumber, width: 150 },
                { field: 'Start', title: window.sr_StartYear, width: 100 },
                { field: 'End', title: window.sr_EndYear, width: 100 },
                { field: 'Volume', title: window.sr_VolumeCm, width: 100 },
                { field: 'PowerHp', title: window.sr_PowerHp, width: 100 },
                { field: 'PowerKwt', title: window.sr_PowerKw, width: 100 }
            ]
        ],
        onShowPanel: function() {
            this.oldValue = window.SelectionByAutoMarkModel_AutoModif;
            if (!window.wasEmptied &&
            ((this.oldValue == 0 && $(this).combogrid("getText") == window.sr_SelectModification) ||
                (this.oldValue != 0 && this.oldValue == $(this).combogrid("getValue")))) {
                this.oldText = $(this).combogrid("getText");
                $(this).combogrid("setText", String.Empty);
                window.wasEmptied = true;
            }
        },
        onHidePanel: function() {
            window.wasEmptied = false;
            var newValue = $(this).combogrid("getValue");
            if (newValue != this.oldValue) {
                return false;
            }
            if (this.oldValue == 0) {
                $(this).combogrid("setText", this.oldText);
            }
            return false;
        },
        onSelect: AutoModifSelected
    });
});
$.extend($.fn.combobox.defaults.inputEvents,
{
    focus: function(e) {
        var target = this;
        var len = $(target).val().length;
        setTimeout(function() {
                if (target.setSelectionRange) {
                    target.setSelectionRange(0, len);
                } else if (target.createTextRange) {
                    var range = target.createTextRange();
                    range.collapse();
                    range.moveEnd('character', len);
                    range.moveStart('character', 0);
                    range.select();
                }
            },
            0);
    }
});

if (window.SelectionByAutoMarkModel_AutoModel) {
    AutoModelSelected(true);
}

function AutoMarkSelected(obj) {
    var grid = $('#AutoModel').combogrid('grid');
    grid.datagrid({
        queryParams: {
            markId: obj.value,
        }
    });
    $('#AutoModel').combogrid('setValue', 0);
    return false;
}

function AutoMarkHidePannel() {
    var data = $('#AutoMark').combobox('getData');
    var value = $('#AutoMark').combobox('getValue');
    data.forEach(function(item) {
        if (item.value == value) {
            AutoMarkSelected(item);
        }
    });
    return false;
}

function AutoModelSelected(keepModifValue) {
    var grid = $('#AutoModif').combogrid('grid');
    grid.datagrid({
        queryParams: {
            modelId: $('#AutoModel').combotree('getValue')
        }
    });

    if (keepModifValue !== true)
        $('#AutoModif').combogrid('setValue', 0);
    return false;
}

function AutoModifSelected() {
    //var grid = $('#AutoModif').combogrid('grid');
    //grid.datagrid({
    //    queryParams: {
    //        modelId: obj.value,
    //    }
    //});
    //$('#AutoModif').combogrid('setValue', 0);
    return false;
}
