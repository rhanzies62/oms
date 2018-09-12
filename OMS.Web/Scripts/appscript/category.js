$(function () {
    var elements = {
        $categoryList: $('#categoryList'),
        $categoryModal: $('#categoryModal'),
        $categoryForm: $('#categoryForm')
    }

    var dom = {
        categoryValidator: null,
        categoryDt: null
    }
    var methods = {
        initializeDt: function () {
            elements.$categoryList.DataTable().clear().destroy();
            dom.categoryDt = elements.$categoryList.DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": "/admin/ListCategory",
                "lengthChange": false,
                "filter": false,
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            var a = $('<a></a>');
                            a.addClass('btn btn-danger').text('Delete');
                            return '<a class="btn btn-danger btnDeleteProduct">Delete</a>';
                        },
                        "targets": 3
                    },
                    { "visible": false, "targets": [0] }
                ]
            });
        },
        init: function () {
            methods.initializeDt();
            dom.categoryValidator = elements.$categoryForm.data('validator');
        }
    }

    $('#categorybtn').on('click', function () {
        methods.init();
    });

    elements.$categoryList.find('tbody')
        .on('click', 'tr', function () {
            var data = dom.categoryDt.row(this).data();
            Loader.show('Retrieving Category Details. Please Wait');
            categoryController.GetCategory(data[0], function (data) {
                Loader.hide();
                $('#Name', elements.$categoryForm).val(data.Name);
                $('#Description', elements.$categoryForm).val(data.Description);
                $('#ID', elements.$categoryForm).val(data.ID);
                $('.btnNew', elements.$categoryModal).show();
            });
        }).on('click', '.btnDeleteProduct', function (e) {
            e.stopPropagation();
            if (confirm("Are you sure you want to delete this record?")) {
                var data = dom.categoryDt.row($(this).closest('tr')).data();
                Loader.show('Deleting Category. Please Wait');
                categoryController.DeleteCategory(data[0], function (data) {
                    Loader.hide();
                    if (data.Success) {
                        methods.initializeDt();
                    } else {
                        common.displayAlert(element.$categoryForm, 'Error', data.ErrorMessage);
                    }
                });
            }
        });

    elements.$categoryModal
        .on('click', '.btnSave', function (e) {
            if (elements.$categoryForm.valid()) {
                e.preventDefault();
                Loader.show('Saving Category Please wait');
                $.ajax({
                    type: 'POST',
                    url: elements.$categoryForm.attr('action'),
                    data: elements.$categoryForm.serialize(),
                    success: function (data) {
                        Loader.hide();
                        if (data.Success) {
                            methods.initializeDt();
                        } else {
                            common.displayAlert(elements.$categoryForm, 'Error', data.ErrorMessage);
                        }
                    }
                });
            }
        })
        .on('click', '.btnNew', function () {
            elements.$categoryForm.find('input').val('');
            $(this).hide();
        });
});