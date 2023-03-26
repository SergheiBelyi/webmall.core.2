function attachAjaxRef(srcSelect, dstSelect, url) {
    $(function () {
        $('#' + srcSelect).change(function () {
            var id = $("#" + srcSelect).val();
            $.getJSON(url + id, { date: (new Date().getTime()) }, function (items) {
                $("#" + dstSelect).text("");
                $.each(items, function (item) {
                    $("#" + dstSelect).append("<option value=\"" + this.Value + "\" " + (this.Selected == 'true' ? "selected=\"selected\"" : "") + ">" + this.Text + "</option>");
                });
                $("#" + dstSelect).change();
            });
        });
    });
}

function submit(tag) {
    $(tag).closest('form').submit();
}

function updatePannel(url, pannelId, progressId, onSuccess, successParam, dontShow) {
    if (!url) return;
    var timeoutId = setTimeout(function () {
        if (progressId)
            if (dontShow) {
                $('#' + progressId).show();
            } else {
                $('#' + pannelId).fadeOut('fast',
                    function () {
                        $('#' + progressId).show();
                    });
            }
    }, 300);
    var qIndex = url.indexOf('?', 0);
    var noCacheUrl = url + (qIndex == -1 ? '?' : "&") + 'rndIndex=' + new Date().getTime();
    $.get(noCacheUrl, function (response) {
        clearTimeout(timeoutId);

        var pannel = $('#' + pannelId);
        pannel.removeClass('skeleton');
        pannel.css({ opacity: 0.1 });
        pannel.empty();
        pannel.append(response);
        try { initialize(); } catch (e) { }
        //$('#' + pannelId).hide();
        if (progressId) $('#' + progressId).hide();
        if (!dontShow) {
            $('#' + pannelId).show();
        }
        $('#' + pannelId).css({ opacity: 1 });
        if (onSuccess) {
            if (typeof onSuccess === "function")
                onSuccess(successParam);
            else {
                executeFunctionByName(onSuccess, window, pannelId);
            }
        }
        setTimeout(function () {
            if (progressId) $('#' + progressId).hide();
            //$('#' + pannelId).fadeIn('fast');
            if (!dontShow) {
                $('#' + pannelId).show();
            }
        }, 200);
    });
}

function executeFunctionByName(functionName, context) {
    var args = Array.prototype.slice.call(arguments, 2);
    var namespaces = functionName.split(".");
    var func = namespaces.pop();
    for (var i = 0; i < namespaces.length; i++) {
        context = context[namespaces[i]];
    }
    return context[func] ? context[func].apply(context, args) : null;
}

String.prototype.trim = function () {
    return this.replace(/^\s+|\s+$/g, '');
};
String.Empty = "";

String.prototype.isNull = function () {
    return this == undefined || this == null;
};
String.prototype.isNullOrEmpty = function () {
    return this.isNull() || this == String.Empty;
};
String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }
    return s;
};

function isDigit(aChar) {
    var myCharCode = aChar.charCodeAt(0);
    if ((myCharCode > 47) && (myCharCode < 58)) {
        return true;
    }
    return false;
}
function getDecimalDelimitier() {
    var s = (1 / 2) + '';
    for (var i = 0; i < 10; i++) s = s.replace(i + '', '');
    return s;
}

function getNumeric(v) {
    v = $.trim(v);
    v = v.toString().replace('.', getDecimalDelimitier());
    v = v.toString().replace(',', getDecimalDelimitier());
    v = v.replace(/\s/, "");
    var v2 = "";
    for (var i = 0; i < v.length; i++) {
        var c = v.charAt(i);
        if (isDigit(c) || c == '.' || c == ',' || c == '-' || c == '+')
            v2 = v2 + c;
    }
    v = v2;
    var reg = /^[-]?[\d| ]*\.?\d*/;
    //if (getDecimalDelimitier() == '.') reg = /^[-]?[\d| ]*\.?\d*/;
    if (getDecimalDelimitier() == ',') reg = /^[-]?[\d| ]*\,?\d*/;
    if (!v.toString().match(reg)) return 0;
    var n = parseFloat(v);
    if (isNaN(n)) n = 0;
    return n;
}
function moneyShow(s) {
    return parseFloat(s).toLocaleString('ru-RU', { minimumFractionDigits: 0 });
}
function setBackground(el, url) {
    el.style.backgroundImage = url;
}
function stopEvent(event) {
    event.stopPropagation();
    return false;
}

document.addEventListener('DOMContentLoaded',
    function () {
        lazyLoading();
    });

$(document).ready(function () {
    var options = {
        url: function (phrase) {
            var el = document.getElementsByName("searchType")[0];
            var searchtype = el ? el.value : null;
            return "/CatalogService/AvailableNumbers?search=" + phrase + "&searchType=" + searchtype;
        },
        requestDelay: 250,
        list: {
            maxNumberOfElements: 30,
            onChooseEvent: function () {
                document.getElementById('producers').value = $("#search-input").getSelectedItemData().ProducerId;
                document.getElementById('search-form').submit();
            }
        },
        adjustWidth: false,
        getValue: "Number",
        template: {
            type: "custom",
            method: function (value, item) {
                var el = document.getElementsByName("searchType")[0];
                var searchType = el ? el.value : "0";
                return searchType === "0"
                    ? item.Number + ", " + item.ProducerName + '<div class="search-wareName">' + item.WareName + '</div>'
                    : item.ProducerName;
            }
        }
    };

    $("#search-input").easyAutocomplete(options);
    document.getElementById("searchCriteria").addEventListener(
        'change',
        function () {
            var input = document.getElementById("search-input");
             input.placeholder = input.dataset[this.value];
        },
        false
    );
});

var getNextSibling = function (elem, selector) {

    // Get the next sibling element
    var sibling = elem.nextElementSibling;

    // If there's no selector, return the first sibling
    if (!selector) return sibling;

    // If the sibling matches our selector, use it
    // If not, jump to the next sibling and continue the loop
    while (sibling) {
        if (sibling.matches(selector)) return sibling;
        sibling = sibling.nextElementSibling;
    }

    return null;
};

var lazyLoading = function () {

    var lazyElements = $(".lazyLoading");

    lazyElements.each(function (index, el) {
        var initElementId = el.dataset.lazyinit;
        if (initElementId) {
            var initEl = document.getElementById(initElementId);
            if (initEl) {
                initEl.onclick = function () {
                    var loaded = initEl.dataset.loaded;
                    if (loaded)
                        return;
                    updatePannel(el.dataset.url, el.id, null, el.dataset.callback, null, false);
                    initEl.dataset.loaded = true;
                };
            }
        }
        else
            updatePannel(el.dataset.url, el.id, null, el.dataset.callback, null, false);
    });
};

function SortPannelByColumn(pannelId, column, actionUrl, onSuccess) {

    var pan = $('#' + pannelId);
    var col = pan.find('#SortColumn').val();
    var dirEl = pan.find('#SortDir');
    if (col.toLowerCase() == column.toLowerCase()) {
        if (dirEl.val() == 'Ascending')
            dirEl.val('Descending');
        else
            dirEl.val('Ascending');
    }

    var sortDirection = dirEl.val();
    var qIndex = actionUrl.indexOf('?', 0);
    var url = actionUrl + (qIndex == -1 ? '?' : "&") + 'SortColumn=' + column + '&SortDirection=' + sortDirection;
    updatePannel(url, pannelId, 'progress', onSuccess);
}

function refresh() {
    window.location.reload();
}

function back() {
    window.location.back();
}