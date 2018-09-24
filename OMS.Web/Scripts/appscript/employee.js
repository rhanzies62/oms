$(function () {
    var methods = {
        loadEmployeeModal: function (url) {
            LoadModal(url,'Add New Employee', function () {

            });
        }
    };
    $('.btnAddEmployee').on('click', function () {
        var $this = $(this);
        methods.loadEmployeeModal($this.data('modal-url'));
    });
});