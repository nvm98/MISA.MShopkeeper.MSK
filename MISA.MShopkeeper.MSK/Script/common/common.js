class Common {
    //Hàm khởi tạo
    //Created by NVMANH 9/8/2019
    constructor() {
        this.initEvent();
    }
    //Khởi tạo sự kiện
    //Created by NVMANH 9/8/2019
    initEvent() {
        this.initDatePicker();
        this.showComboBox();
        this.autoCompleteSelectType();
        //this.setToday();
    }
    //Các sự kiện của button
    //Created by NVMANH 9/8/2019
    eventButton() {

    }
    //Khởi tạo DateTimePicker
    //Created by NVMANH 9/8/2019
    initDatePicker() {
        $('[fieldSelect="Date"]').datepicker({
            dateFormat: "dd/mm/yy",
            showOtherMonths: true,
            showOn: "button",
            buttonImage: '/Content/icons/date-picker-icon.png',
            yearRange: "1900:2099",
            showButtonPanel: true
        }).mask("99/99/9999");
    }
    //Hiển thị COmbobox
    //Created by NVMANH 9/8/2019
    showComboBox() {
        $('.arrow-down').on('click', function (event) {
            $(this).find('.combobox-item').toggle();
        });
    }
    //Mặc định hiện ngày hôm nay
    //Created by NVMANH 10/8/2019
    setToday() {
        $('[fieldSelect="Date"]').datepicker('setDate', new Date());
    }
    //Auto complete chọn loại chứng từ
    //Created by NVMANH 10/8/2019
    autoCompleteSelectType() {
        var source = [
            'Tất cả', 'Phiếu thu tiền mặt', 'Phiếu thu nợ - tiền mặt', 'Phiếu thu đặt cọc -tiền mặt',
            'Phiếu chi tiền mặt', 'Phiếu trả nợ - tiền mặt', 'Phiếu nhập hàng - tiền mặt',
            'Phiếu trả lại hàng mua - tiền mặt'
        ];
        $('.select-type').autocomplete({
            source: source,
            minLength: 0,
            select: function (event, ui) {
                $('.select-type').val(ui.item.label);
            }
        });
    }
    //Chỉ cho phép nhập các kí tự số
    //Created by NVMANH 11/8/2019
    isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode === 59 || charCode === 46)
            return true;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    //Định dạng tiền tệ
    //Created by NVMANH 11/8/2019
    formatMoney(money) {
        return money.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.');
    }
    //Chuyển từ chuối sang số
    //Created by NVMANH 11/8/2019
    convertStringJSToNumber(strNumber) {
        var removeDot = parseInt(strNumber.replace(/\./g, ''), 10);
        return removeDot;
    }
}
var common = new Common();
//Chỉnh ngôn ngữ tiếng việt cho datetimepicker
//Created by NVMANH 9/8/2019
$.datepicker.regional["vi-VN"] =
    {
        closeText: "Đóng",
        prevText: "Trước",
        nextText: "Sau",
        currentText: "Hôm nay",
        monthNames: ["Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"],
        monthNamesShort: ["Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín", "Mười", "Mười một", "Mười hai"],
        dayNames: ["Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy"],
        dayNamesShort: ["CN", "Hai", "Ba", "Tư", "Năm", "Sáu", "Bảy"],
        dayNamesMin: ["CN", "T2", "T3", "T4", "T5", "T6", "T7"],
        weekHeader: "Tuần",
        dateFormat: "dd/mm/yyyy",
        firstDay: 0,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ""
    };
$.datepicker.setDefaults($.datepicker.regional["vi-VN"]);
//Lấy ngày hôm nay cho datetime picker
//Created by NVMANH 9/8/2019
$.datepicker._gotoToday = function (id) {
    var inst = this._getInst($(id)[0]);

    var date = new Date();
    this._selectDay(id, date.getMonth(), date.getFullYear(), inst.dpDiv.find('td.ui-datepicker-today'));
};
//Kiểm tra ngày có giá trị không
//Created by NVMANH 10/8/2019
Date.prototype.isValid = function () {
    return this.getTime() === this.getTime();
};
//Hàm hiểm tra có thanh cuộn
//Created by NVMANH 10/8/2019
(function ($) {
    $.fn.hasScrollBar = function () {
        return this.get(0).scrollHeight > this.height();
    };
})(jQuery);
//giao diện autocomplete cho bảng chi tiết đối tượng
//Created by NVMANH 10/8/2019
$.widget("custom.objectcomplete", $.ui.autocomplete, {
    _create: function () {
        this._super();
        this.widget().menu("option", "items", "> tr:not(.ui-autocomplete-header)");
    },
    _renderMenu(ul, items) {
        var self = this;
        ul.addClass("ac-search-table");
        //Định nghĩa bảng
        ul.append("<table><thead><tr><th>Mã</th><th>Tên</th><th>Loại</th></tr></thead><tbody></tbody></table>");
        $.each(items, function (index, item) {
            self._renderItemData(ul, ul.find("table tbody"), item);
        });
    },
    _renderItemData(ul, table, item) {
        return this._renderItem(table, item).data("ui-autocomplete-item", item);
    },
    _renderItem(table, item) {
        return $("<tr class='ui-menu-item object-detail-item' role='presentation'></tr>")
            .append("<td >" + item.Code + "</td>" + "<td>" + item.Name + "</td>" + "<td>" + item.TypeName + "</td>")
            .appendTo(table);
    }
});
//Hàm lấy ngày hiện tại
//Created by NVMANH 11/8/2019
Date.prototype.getFullTimeCurrent = function () {
    let formatted = (this.getHours() < 10 ? "0" + this.getHours() : this.getHours()) +
        ":" + (this.getMinutes() < 10 ? "0" + this.getMinutes() : this.getMinutes()) +
        ":" + (this.getSeconds() < 10 ? "0" + this.getSeconds() : this.getSeconds());
    return " " + formatted;
};
//Kiểm tra ngày có giá trị không
//Created by NVMANH 11/8/2019
Date.prototype.isValid = function () {
    return this.getTime() === this.getTime();
};