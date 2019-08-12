class BaseDialog {
    constructor(selector, width, height, showModel, scope, buttons) {
        var me = scope ? eval(scope) : this;
        this.Form = $(selector).dialog({
            autoOpen: false,
            width: width ? width : 900,
            height: height ? height : 600,
            modal: showModel ? showModel : true,
            buttons: buttons,
            open: function () {
                var iconClose = '<span class="icon-close"></span>';
                if ($(this).hasClass('dialog-main')) {
                    var resize = '<span class="icon-resize"></span>';
                    $(this).prev().find('.ui-dialog-title').after(resize);
                }
                $(this).prev().find('.ui-dialog-title').after(iconClose);
            },
            close: function () {
                //if ($(this).hasClass('dialog-main')) {
                //    $(this).prev().find('.icon-resize').remove();
                //}
                $(this).prev().find('.icon-close').remove();
                $(this).dialog({
                    height: height,
                    width: width
                });
                $(this).dialog("option", "position", { my: "center center", at: "center center", of: window });
                $(this).attr('class', '');
            }
        });
    }
    openForm() {
        this.Form.dialog('open');
    }
    closeForm() {
        this.Form.dialog('close');
    }
    resizeDialog() {
        this.Form.dialog("option", "position", { my: "center center", at: "center center", of: window });
        if (this.Form.dialog('option', 'height') === 600) {
            this.Form.dialog({
                height: $(window).height(),
                width: $(window).width()
            });
        } else {
            this.Form.dialog({
                height: 600,
                width: 900
            });
        }
    }
}