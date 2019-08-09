var buttons = {
    buttonAlert: [
        {
            html: '<div href="#"><span class="glyphicon glyphicon-save"></span><span class="text-button">' + Resource.textButton.save + '</span></div>',
            class: 'btn-save',
            click: function () {
                $('#dialog-main').dialog('close');
                $(this).dialog('close');
            }
        },
        {
            html: '<div href="#"><span class="glyphicon glyphicon-noSave"></span><span class="text-button">' + Resource.textButton.noSave + '</span></div>',
            class: 'btn-noSave',
            click: function () {
                $('#dialog-main').dialog('close');
                $(this).dialog('close');
            }
        },
        {
            html: '<div href="#"><span class="glyphicon-agree"></span><span class="text-button">' + Resource.textButton.agree + '</span></div>',
            class: 'btn-agree',
            click: function () {
                $(this).dialog('close');
            }
        },
        {
            html: '<div href="#"><span class="glyphicon glyphicon-delete"></span><span class="text-button">' + Resource.textButton.delete + '</span></div>',
            class: 'btn-delete',
            click: function () {
                $(this).dialog('close');
            }
        },
        {
            html: '<div href="#"><span class="glyphicon glyphicon-cancel"></span><span class="text-button">' + Resource.textButton.cancel + '</span></div>',
            class: 'btn-cancel',
            click: function () {
                $(this).dialog('close');
            }
        }
    ]
};