class Main {
    constructor() {
        this.mainDialog = new BaseDialog('#dialog-main', 900, 700, true);
        this.warnDialog = new BaseDialog('#dialog-warn', 400, 156, true, null, buttons.buttonAlert, false);
        this.initEvent();
    }
    //Khởi tạo sự kiện
    //Created by NVMANH 7/8/2019
    initEvent() {
        this.setButton();
    }
    //Gắn các sự kiện
    //Created by NVMANH 7/8/2019
    setButton() {
        $('.content-toolbar .item-add').on('click', this.showDialogAdd);
        $('.content-toolbar .item-duplicate').on('click', this.showDialogDuplicate);
        $('.content-toolbar .item-view').on('click', this.showDialogView);
        $('.content-toolbar .item-edit').on('click', this.showDialogEdit);
        $('.content-toolbar .item-delete').on('click', this.showDialogDelete);
        $('body').on('click', '[aria-describedby="dialog-main"] .ui-dialog-titlebar .icon-close', this.showDialogSave);
        $('body').on('click', '#show-dialog-alert', this.showDialogError);
        $('body').on('click', '[aria-describedby="dialog-main"] .icon-resize', this.resizeDialog);
        $('body').on('click', '[aria-describedby="dialog-warn"] .ui-dialog-titlebar .icon-close', this.closeDialogAlert);
    }
    //Hiển thị dialog thêm mới
    //Created by NVMANH 7/8/2019
    showDialogAdd() {
        $('#dialog-main').addClass('add');
        $("#dialog-main").dialog("option", "title", Resource.titleDialog.titleAdd);
        main.showDialog();
    }
    //Hiển thị dialog sửa
    //Created by NVMANH 7/8/2019
    showDialogEdit() {
        $('#dialog-main').addClass('edit');
        $("#dialog-main").dialog("option", "title", Resource.titleDialog.titleEdit);
        main.showDialog();
    }
    //Hiển thị dialog xem
    //Created by NVMANH 7/8/2019
    showDialogView() {
        $('#dialog-main').addClass('view');
        $("#dialog-main").dialog("option", "title", Resource.titleDialog.titleView);
        main.showDialog();
    }
    //Hiển thị dialog nhân bản
    //Created by NVMANH 7/8/2019
    showDialogDuplicate() {
        $('#dialog-main').addClass('duplicate');
        $("#dialog-main").dialog("option", "title", Resource.titleDialog.titleDuplicate);
        main.showDialog();
    }
    //Hiển thị dialog xóa
    //Created by NVMANH 7/8/2019
    showDialogDelete() {
        $('#dialog-warn').addClass('delete');
        $('#dialog-warn .text-alert').text(Resource.textAlert.multiDelete);
        main.showDialogAlert();
    }
    //Hiển thị dialog lưu
    //Created by NVMANH 7/8/2019
    showDialogSave() {
        $('#dialog-warn').addClass('save');
        $('#dialog-warn .text-alert').text(Resource.textAlert.saveAlert);
        main.showDialogAlert();
    }
    //Hiển thị dialog lỗi
    //Created by NVMANH 8/8/2019
    showDialogError() {
        $('#dialog-warn').addClass('error');
        $('#dialog-warn .text-alert').text(Resource.textAlert.detailSave);
        main.showDialogAlert();
    }
    //Hiển thị dialog chính
    //Created by NVMANH 7/8/2019
    showDialog() {
        main.mainDialog.openForm();
    }
    //Đóng dialog chính
    //Created by NVMANH 7/8/2019
    closeDialog() {
        main.mainDialog.closeForm();
    }
    //Hiển thị dialog cảnh báo
    //Created by NVMANH 7/8/2019
    showDialogAlert() {
        $("#dialog-warn").dialog("option", "title", Resource.titleDialog.titleAlert);
        $("#dialog-warn").dialog("option", "resizable", false);
        main.warnDialog.openForm();
    }
    //Đóng dialog cảnh báo
    //Created by NVMANH 7/8/2019
    closeDialogAlert() {
        main.warnDialog.closeForm();
    }
    //Thay đối kích thước dialog
    //Người tạo NVMANH 7/8/2019
    resizeDialog() {
        main.mainDialog.resizeDialog();
    }
}
var main = new Main();