$(function () {
    $.getJSON('@Url.Action("GetVariant", "Variant")', function (result) {
        var ddl = $('#SiteId');
        ddl.empty();
        $(result).each(function () {
            ddl.append(
                $('<option/>', {
                    value: this.Id
                }).html(this.Nome)
            );
        });
    });
});



$(function () {
    var myvariantlist = $("#myvariantlist");
    myvariantlist.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: "POST",
        url: "/Admin/JsonListVariant",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            myvariantlist.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function () {
                myvariantlist.append($("<option></option>").val(this['ID']).html(this['Name']));
            });
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
});