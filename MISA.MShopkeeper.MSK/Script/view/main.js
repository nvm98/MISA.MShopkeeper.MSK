class Main {
    constructor() {
        this.mainDialog = new BaseDialog('#dialog-main', 900, 600, true);
        this.warnDialog = new BaseDialog('#dialog-warn', 400, 156, true, null, buttons.buttonAlert, false);
        this.initEvent();
    }
    //Khởi tạo sự kiện
    //Created by NVMANH 7/8/2019
    initEvent() {
        this.setButton();
        this.loadDataGridMain();
        this.autoCompleteObject();
        this.setHotKey();
        this.setFocus();
    }
    //Gắn các sự kiện
    //Created by NVMANH 7/8/2019
    setButton() {
        $('.content-toolbar .add-collect').on('click', this.showDialogAdd);
        $('.content-toolbar .item-duplicate').on('click', this.showDialogDuplicate);
        $('.content-toolbar .item-view').on('click', this.showDialogView);
        $('body').on('click', '.item-cell[fieldName="ReceiptCode"] a', this.clickReceiptCode);
        $('.content-toolbar .item-edit').on('click', this.showDialogEdit);
        $('.content-toolbar .item-delete').on('click', this.showDialogDelete);
        $('body').on('click', '[aria-describedby="dialog-main"] .ui-dialog-titlebar .icon-close', this.showDialogSave);
        $('body').on('click', '#show-dialog-alert', this.showDialogError);
        $('body').on('click', '[aria-describedby="dialog-main"] .icon-resize', this.resizeDialog);
        $('body').on('click', '[aria-describedby="dialog-warn"] .ui-dialog-titlebar .icon-close', this.closeDialogAlert);
        $(document).mouseover(this.checkScrollBar);
        $('.item-header-check').on('click', this.checkAll);
        $('body').on('click', '.item-cell-check', this.checkColTable);
        $('body').on('click', '.row-grid-main', this.clickRowTable);
        $('body').on('click', '.wrap-table-detail-body .row-grid-detail', this.clickRowTableDetail);
        $('body').on('click', '.object-detail .arrow-down', this.showListObject);
        $('body').on('focus click', '.row-dialog-grid input, .row-dialog-grid button', this.selectRowTableDialog);
        $('body').on('focus click', '.row-dialog-grid', this.focusRowTableDialog);
        $('body').on('focusout', '.row-dialog-grid', this.focusoutRowTableDialog);
        $('body').on('click', '.row-dialog-grid button', this.deleteRowTableDialog);
        $('body').on('focusout', '.wrap-dialog-grid-body .row-dialog-grid:last [fieldName="ReceiptDetailMoney"]', this.tabInputMoney);
        $('body').on('keyup focusout', '.wrap-dialog-grid-body [fieldName="ReceiptDetailMoney"]', this.calcMoney);
        $('body').on('keypress', '.wrap-dialog-grid-body [fieldName="ReceiptDetailMoney"]', common.isNumberKey);
    }
    //Hiển thị dialog thêm mới
    //Created by NVMANH 7/8/2019
    showDialogAdd() {
        $('#dialog-main').addClass('add');
        $("#dialog-main").dialog("option", "title", Resource.titleDialog.titleAdd);
        main.showDialog();
        $('[field="ReceiptDate"]').datepicker('setDate', new Date());
        main.addRow();
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
        main.loadDataToDialog();
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
        if ($('#dialog-main').hasClass('view')) {
            main.closeDialog();
        } else {
            $('#dialog-warn').addClass('save');
            $('#dialog-warn .text-alert').text(Resource.textAlert.saveAlert);
            main.showDialogAlert();
        }
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
        $('.dialog-grid-body .wrap-dialog-grid-body').html('');
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
    //Load data cho bảng chính
    //Created by NVMANH 10/8/2019
    loadDataGridMain() {
        var uri = '/receipt';
        serviceAjax.get(uri, {}, true, function (response) {
            if (response.Success) {
                $.each(response.Data, function (index, itemData) {
                    var rowClone = $('.row-grid-main-clone [fieldName]');
                    $.each(rowClone, function (index, item) {
                        var fieldName = $(this).attr('fieldName');
                        var fieldData = $(this).attr('fieldData');
                        if (fieldData === 'money') {
                            $(this).text(common.formatMoney(itemData[fieldName]));
                        } else if (fieldData === 'date') {
                            $(this).text(new Date(itemData[fieldName]).toLocaleDateString('en-GB'));
                        } else if (fieldData === 'code') {
                            $(this).find('a').text(itemData[fieldName]);
                        } else {
                            $(this).text(itemData[fieldName]);
                        }
                    });
                    $('.item-content-grid.content-grid-body .wrap-content-grid-body').append($('.row-grid-main-clone').html());
                    $('.wrap-content-grid-body .row-grid-main:last-child').data('ReceiptID', itemData['ReceiptID']);
                });
                $('.wrap-content-grid-body .row-grid-main:first').trigger('click');
            }
        });
    }
    //Load data cho bảng chi tiết
    //Created by NVMANH 10/8/2019
    loadDataGridDetail() {
        $('.wrap-table-detail-body').html('');
        var id = $('.row-grid-main.selected').data('ReceiptID');
        var uri = '/detail/' + id;
        serviceAjax.get(uri, {}, true, function (response) {
            if (response.Success) {
                $.each(response.Data, function (index, itemData) {
                    var rowClone = $('.row-grid-detail-clone [fieldName]');
                    $.each(rowClone, function (index, item) {
                        var fieldName = $(this).attr('fieldName');
                        var fieldData = $(this).attr('fieldData');
                        if (fieldData === 'money') {
                            $(this).text(itemData[fieldName]);
                        } else if (fieldData === 'date') {
                            $(this).text(itemData[fieldName]);
                        } else if (fieldData === 'code') {
                            $(this).find('a').text(itemData[fieldName]);
                        } else {
                            $(this).text(itemData[fieldName]);
                        }
                    });
                    $('.item-table-detail.table-detail-body .wrap-table-detail-body').append($('.row-grid-detail-clone').html());
                    $('.wrap-table-detail-body .row-grid-detail:last-child').data('ReceiptDetailID', itemData['ReceiptDetailID']);
                });
            }
        });
    }
    loadDataToDialog() {
        var id = $('.row-grid-main.selected').data('ReceiptID');
        var uri = '/receiptview/' + id;
        var uriDetail = '/detail/' + id;
        serviceAjax.get(uri, {}, true, function (response) {
            if (response.Success) {
                var itemData = response.Data;
                var rowClone = $('.form-information [showView]');
                $.each(rowClone, function (index, item) {
                    var fieldName = $(this).attr('showView');
                    var fieldData = $(this).attr('fieldData');
                    if (fieldData === 'money') {
                        $(this).val(itemData[fieldName]);
                    } else if (fieldData === 'date') {
                        $(this).val(new Date(itemData[fieldName]).toLocaleDateString('en-GB'));
                    } else if (fieldData === 'code') {
                        $(this).find('a').val(itemData[fieldName]);
                    } else {
                        $(this).val(itemData[fieldName]);
                    }
                });
            }
        });
        serviceAjax.get(uriDetail, {}, true, function (response) {
            if (response.Success) {
                $.each(response.Data, function (index, itemData) {
                    var rowClone = $('.row-grid-view-clone [fieldName]');
                    $.each(rowClone, function (index, item) {
                        var fieldName = $(this).attr('fieldName');
                        var fieldData = $(this).attr('fieldData');
                        if (fieldData === 'money') {
                            $(this).text(itemData[fieldName]);
                        } else if (fieldData === 'date') {
                            $(this).text(itemData[fieldName]);
                        } else if (fieldData === 'code') {
                            $(this).find('a').text(itemData[fieldName]);
                        } else {
                            $(this).text(itemData[fieldName]);
                        }
                    });
                    $('.wrap-grid-view-body').append($('.row-grid-view-clone').html());
                });
            }
        });
    }
    //Xử lý cột check tất cả dòng của bảng
    //Created by NVMANH 10/8/2019
    checkAll() {
        $(this).toggleClass('checked');
        if ($('.item-header-check').hasClass('checked')) {
            $('.item-cell-check').addClass('checked');
            $('.row-grid-main').addClass('selected');
        }
        else {
            $('.item-cell-check').removeClass('checked');
            $('.row-grid-main').removeClass('selected');
        }
    }
    //Xử lý cột check ở đầu dòng
    //Created by NVMANH 10/8/2019
    checkColTable(event) {
        $(this).toggleClass('checked');
        if ($(this).hasClass('checked')) {
            $(this).parent().addClass('selected');
        } else {
            $(this).parent().removeClass('selected');
        }
        if ($('.wrap-content-grid-body .checked').length === $('.wrap-content-grid-body .item-cell-check').length) {
            $('.item-header-check').addClass('checked');
        } else {
            $('.item-header-check').removeClass('checked');
        }
        event.stopPropagation();
    }
    //Chọn một dòng trong bảng
    //Created by NVMANH 10/8/2019
    clickRowTable() {
        $('.row-grid-main').removeClass('selected');
        $(this).addClass('selected');
        main.loadDataGridDetail();
    }
    //Click vào mã phiếu thu
    //Created by NVMANH 11/8/2019
    clickReceiptCode() {
        $('.row-grid-main').removeClass('selected');
        $(this).closest('.row-grid-main').addClass('selected');
        main.loadDataGridDetail();
        main.showDialogView();
    }
    //Click chọn dòng trong bảng chi tiết
    //Created by NVMANH 10/8/2019
    clickRowTableDetail() {
        $('.wrap-table-detail-body .row-grid-detail').removeClass('selected');
        $(this).addClass('selected');
    }
    //Kiểm tra thanh cuộn trên các bảng
    //Created by NVMANH 10/8/2019
    checkScrollBar() {
        main.eventScroll('.item-content-grid.content-grid-body .wrap-content-grid-body', '.content-grid .content-grid-header');
        main.eventScroll('.item-table-detail.table-detail-body .wrap-table-detail-body', '.table-detail .table-detail-header');
        main.eventScroll('.item-dialog-grid-content.dialog-grid-body .wrap-dialog-grid-body', '.item-dialog-grid-content.dialog-grid-header');
        main.eventScroll('.wrap-grid-view-body', '.item-dialog-grid-view.grid-view-header');
    }
    //Sự kiện cho thanh cuộn bảng
    //Created by NVMANH 11/8/2019
    eventScroll(wrap, header) {
        if ($(wrap).hasScrollBar()) {
            $(header).addClass('hasScroll');
        } else {
            $(header).removeClass('hasScroll');
        }
    }
    //Autocomplete loại đối tượng
    //Created by NVMANH 10/8/2019
    autoCompleteObject() {
        var source = [];
        var uri = '/object';
        serviceAjax.get(uri, {}, false, function (response) {
            if (response.Success) {
                source = response.Data.map(function (item) {
                    return {
                        label: item.Code + item.Name,
                        value: item.Name,
                        Code: item.Code,
                        Name: item.Name,
                        TypeName: item.TypeName
                    };
                });
            }
        });
        $('#auto-object').objectcomplete({
            source: source,
            minLength: 0,
            open: function (event, ui) {
                $('.object-detail-item:first').focus();
            },
            select: function (event, ui) {
                $('[field="Name"]').val(ui.item.Name);
            }
        });
    }
    //click vào hiển thị danh sách chi tiết đối tượng
    //Created by NVMANH 11/8/2019
    showListObject() {
        if (!$('.ac-search-table').css('display') === 'none') {
            $('#auto-object').objectcomplete('disable');
        } else {
            $('#auto-object').objectcomplete('search', '');
        }
    }
    //Chọn dòng trong bảng trên dialog
    //Created by NVMANH 11/8/2019
    selectRowTableDialog() {
        $(this).closest('.row-dialog-grid').addClass('choose-select');
        $(this).closest('.row-dialog-grid').find('input , button').not(this).addClass('not-choose');
        $(this).closest('.row-dialog-grid').find('input , button').not(this).attr('placeholder', '');
        $(this).removeClass('not-choose');
        var fieldName = $(this).attr('fieldName');
        if (fieldName === 'Reason') {
            $(this).attr('placeholder', 'Nhập diễn giải');
        } else if (fieldName === 'ReceiptDetailMoney') {
            $(this).attr('placeholder', 'Nhập số tiền');
        } else {
            $(this).attr('placeholder', 'Nhập mục thu chi');
        }

    }
    //focus cào dòng trong bảng trên dialog
    //Created by NVMANH 11/8/2019
    focusRowTableDialog() {
        $('.item-dialog-grid-content.dialog-grid-body').find('.row-dialog-grid').not(this).removeClass('choose-select');
        $('.item-dialog-grid-content.dialog-grid-body').find('.row-dialog-grid').not(this).find('input , button').removeClass('not-choose');
    }
    //Focusout ra ngoài dòng trên dialog
    //Created by NVMANH 11/8/2019
    focusoutRowTableDialog() {
        $('.item-dialog-grid-content.dialog-grid-body').find('.row-dialog-grid').removeClass('choose-select');
        $('.item-dialog-grid-content.dialog-grid-body').find('.row-dialog-grid').find('input , button').removeClass('not-choose');
        $('.item-dialog-grid-content.dialog-grid-body').find('.row-dialog-grid').find('input , button').attr('placeholder', '');
    }
    //Xóa một dòng trong bảng chi tiết trên dialog
    //Created by NVMANH 11/8/2019
    deleteRowTableDialog() {
        $(this).closest('.row-dialog-grid').remove();
    }
    //Phím tắt
    //Created by NVMANH 11/8/2019
    setHotKey() {
        $(window).keydown(function () {
            //Nhấn Del để xóa dòng
            if (event.keyCode === 46) {
                if ($("#dialog-main").dialog("isOpen") && !$('#dialog-warn').dialog('isOpen')) {
                    $('.row-dialog-grid.choose-select').remove();
                }
                event.preventDefault();
            }
            if (event.ctrlKey && event.keyCode === 82) {
                if ($("#dialog-main").dialog("isOpen") && !$('#dialog-warn').dialog('isOpen')) {
                    main.addRowTableDialog();
                }
                event.preventDefault();
            }
        });
    }
    //tab index trên dialog
    //Created by NVMANH 11/8/2019
    setFocus() {
        $('.end-tab').focus(function () {
            $('.wrap-dialog-grid-body .row-dialog-grid input:first').focus();
        });
        $('.start-tab').focus(function () {
            $('.wrap-dialog-grid-body .row-dialog-grid button:last').focus();
        });
    }
    //Thêm một dòng mới trên dialog
    //Created by NVMANH 11/8/2019
    addRowTableDialog() {
        $('.dialog-grid-body .wrap-dialog-grid-body').append($('.row-dialog-grid-clone .row-dialog-grid').clone(true));
        $('.dialog-grid-body .wrap-dialog-grid-body .row-dialog-grid:last').find('input:first').focus();
    }
    //Thêm mới dòng khi load dialog
    //Created by NVMANH 12/8/2019
    addRow() {
        $('.dialog-grid-body .wrap-dialog-grid-body').append($('.row-dialog-grid-clone .row-dialog-grid').clone(true));
    }
    //Thêm dòng mới khi tab số tiền lớn hơn 0
    //Created by NVMANH 11/8/2019
    tabInputMoney() {
        if ($(this).val() > 0) {
            $('.dialog-grid-body .wrap-dialog-grid-body').append($('.row-dialog-grid-clone .row-dialog-grid').clone(true));
        }
    }
    //Tính tổng tiền cho chi tiết trên dialog
    //Created by NVMANH 11/8/2019
    calcMoney() {
        if ($(this).val() !== '') {
            var cellMoney = $('.item-dialog-grid-content.dialog-grid-body [fieldName="ReceiptDetailMoney"]');
            var totalMoney = 0;
            $.each(cellMoney, function (index, item) {
                if ($(this).val() !== '') {
                    totalMoney += common.convertStringJSToNumber($(this).val());
                }
            });
            $('#total-money').text(common.formatMoney(totalMoney));
        } else {
            $('#total-money').text(0);
        }
    }
}
var main = new Main();