$(function () {
    var methods = {
        loadEmployeeModal: function (url) {
            Loader.show('Loading');
            LoadModal(url,'Add New Employee', function () {
                Loader.hide();
            });
        }
    };
    $('.btnAddEmployee').on('click', function () {
        var $this = $(this);
        methods.loadEmployeeModal($this.data('modal-url'));
    });
});