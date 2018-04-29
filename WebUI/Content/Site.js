
$(function () {

    //ENABLE LOADING MESSAGE
    $("form").submit(function (event) {
        $('#LoadingModal').modal({ backdrop: 'static', keyboard: false });

        if ($(".input-validation-error").length > 0) {
            $('#LoadingModal').modal('hide');
        }
    });
    //**********************/

});

// FUNCTION USED TO SUBMIT AntiForgeryToken BY AJAX
AddAntiForgeryToken = function (data) {
    data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
    return data;
};


function customAutoComplete(url, searchControl, resultControl) {

    $(searchControl).autocomplete({
        minLength: 1,
        source: url,
        select: function (event, ui) {
            $(searchControl).val(ui.item.c2).trigger('change');
            $(resultControl).val(ui.item.c1).trigger('change');

            return false;
        }

    }).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<a>" + item.c2 + "</a>")
            .appendTo(ul);
    };;
}

function postData(url, data, fsuccess) {
    $.ajax({
        type: "post",
        dataType: "html",
        url: url,
        data: { "cod": data },
        success: fsuccess,
        error: function (jqXHR, textStatus, errorThrown) {
            alert($.parseJSON(jqXHR.responseText).error);
            $(obj).attr('checked', false);
        }
    });
}

$(".confirmDelete").confirm({

    text: "Deseja realmente excluir este item?",
    confirm: function (button) {

        $('#LoadingModal').modal({ backdrop: 'static', keyboard: false });

        var action = $(button).attr("data-action");
        var redirect = $(button).attr("data-redirect");
        var fsuccess = function (response) {

            if (redirect != null) {
                location.href = redirect;
            }
            else {
                location.reload(true);
            }
        }
        var data = $(button).data("id");
        postData(action, data, fsuccess);
    },
    cancel: function (button) {

        //Do nothing
    },
    confirmButton: "Sim",
    cancelButton: "N&#227o"
});