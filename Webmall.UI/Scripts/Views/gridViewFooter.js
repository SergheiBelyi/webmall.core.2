$(function () {
    //var pageSizeEl = $('.show-by-select');
    //if (pageSizeEl) {
    //    pageSizeEl.change(function () {
    //        var url = Url.set(document.location.href, 'pageSize', $(this).val());
    //        document.location.href = url;
    //    });
    //}

    $('.custom-dropdown__link').click(function (el) {
        var url = Url.set(document.location.href, 'pageSize', el.target.text);
        document.location.href = url;
    });

    $("input[name='PageNumber']").change(function () {
        gotoPage(this, $(this).val());
    });
});

function gotoPage(obj, page) {
    $('#CurrentPage').val(page);

    var url = Url.set(document.location.href, 'currentPage', $('#CurrentPage').val());
    document.location.href = url;

    return false;
}

function SortByColumn(obj, column, reqByGet, fixDirection) {
    var colEl = $('#SortColumn');
    var dirEl = $('#SortDir');
    if (!fixDirection) {
        if (colEl.val().toLowerCase() == column.toLowerCase()) {
            if (dirEl.val() == 'Ascending')
                dirEl.val('Descending');
            else
                dirEl.val('Ascending');
        } else {
            colEl.val(column);
            dirEl.val('Ascending');
        }
    } else {
        dirEl.val(fixDirection);
        colEl.val(column);
    }

    $.cookie(document.GridViewFooter_Model_SortTypeCookieName, column, { expires: 365, path: '/' });
    $.cookie(document.GridViewFooter_Model_SortDirCookieName, dirEl.val(), { expires: 365, path: '/' });

    if (reqByGet) {

        var url = Url.set(document.location.href, 'sortColumn', colEl.val());
        url = Url.set(url, 'sortDirection', dirEl.val());

        var brandFilter = document.getElementById('brandFilter');
        if (brandFilter)
            url = Url.set(url, 'BrandFilter', brandFilter.value);

        document.location.href = url;
        return url;
    }

    var frm = $(obj).closest('form');
    $('<input type="hidden"/>').attr('value', true).attr('name', 'IsSortingAction').appendTo($(frm));
    frm.submit();

    return false;
}

function OnBrandClick(value) {

    if (value) {
        var url = Url.set(document.location.href, 'sortColumn', ($('#SortColumn').val()) ? $('#SortColumn').val() : "ClientPrice");
        url = Url.set(url, 'sortDirection', $('#SortDirection').val() ? $('#SortDirection').val() : "Ascending");

        url = Url.set(url, 'BrandFilter', value);
    }
    document.location.href = url;
    return false;
}