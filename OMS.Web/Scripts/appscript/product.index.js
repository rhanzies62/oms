/// <reference path="../jquery-1.10.2.js" />
/// <reference path="../jquery.datatables.js" />


$(function () {
    var element = {
        $productList: $('#productList'),
        $productForm: $('#productfrm'),
        $newproductModal: $('#newproductModal'),
        $btnAddProduct: $('.btnAddProduct'),
        $txtProductSearch: $('#txtProductSearch'),
        $categoryDrpSearch: $('#categoryDrpSearch')
    };

    var dom = {
        productFormValidator: null,
        productDt: null
    }

    var methods = {
        initProductDT: function () {
            element.$productList.DataTable().clear().destroy();
            dom.productDt = element.$productList.DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "/product/ListProducts",
                    "data": function (d) {
                        d.search = element.$txtProductSearch.val();
                        d.categoryid = element.$categoryDrpSearch.val();
                    }
                },
                "lengthChange": false,
                "filter": false,
                "columnDefs": [
                    {
                        "render": function (data, type, row) {
                            var a = $('<a></a>');
                            a.addClass('btn btn-danger').text('Delete');
                            return '<a class="btn btn-danger btnDeleteProduct">Delete</a>';
                        },
                        "targets": 5
                    },
                    { "visible": false, "targets": [0] }
                ]
            });
        },
        init: function () {
            methods.initProductDT();
            methods.loadCategories();
            dom.productFormValidator = element.$productForm.data('validator');
        },
        loadCategories: function () {
            productController.GetCategory(function (data) {
                common.populateDropdowns($('.categoryDrp'), data);
                common.populateDropdowns($('#categoryDrpSearch'), data);
            });
        }
    };

    methods.init();

    element.$btnAddProduct.on('click', function () {
        methods.loadCategories();
        element.$productForm.find('input').val('');
    });

    element.$txtProductSearch.on('keyup', function () {
        dom.productDt.search($(this).val()).draw();
    });

    element.$categoryDrpSearch.on('change', function () {
        dom.productDt.search($(this).val()).draw();
    });

    element.$productList.find('tbody')
        .on('click', 'tr', function () {
            var data = dom.productDt.row(this).data();
            productController.GetProduct(data[0], function (data) {
                $('#Name', element.$productForm).val(data.Name);
                $('#Description', element.$productForm).val(data.Description);
                $('#Price', element.$productForm).val(data.Price);
                $('#CategoryID', element.$productForm).val(data.CategoryID);
                $('#ID', element.$productForm).val(data.ID);
                element.$newproductModal.modal('show');
            });
        })
        .on('click', '.btnDeleteProduct', function (e) {
            e.stopPropagation();
            if (confirm("Are you sure you want to delete this record?")) {
                var data = dom.productDt.row($(this).closest('tr')).data();
                productController.RemoveProduct(data[0], function (data) {
                    if (data.Success) {
                        element.$newproductModal.modal('hide');
                        methods.initProductDT();
                    } else {
                        common.displayAlert(element.$productForm, 'Error', data.ErrorMessage);
                    }
                });
            }
        });

    element.$newproductModal
        .on('click', '.btnSaveProduct', function (e) {
            if (element.$productForm.valid()) {
                e.preventDefault();
                $.ajax({
                    type: 'POST',
                    url: element.$productForm.attr('action'),
                    data: element.$productForm.serialize(),
                    success: function (data) {
                        if (data.Success) {
                            element.$newproductModal.modal('hide');
                            methods.initProductDT();
                        } else {
                            common.displayAlert(element.$productForm, 'Error', data.ErrorMessage);
                        }
                    }
                });
            }
        });
});