$.extend(true, $.fn.dataTable.defaults, {
    language: _dtPtBr,
    ordering: false,
    responsive: true,
    theme: "bootstrap",
    lengthMenu: [
        [25, 50, 100, 500, -1],
        [25, 50, 100, 500, "Todos"]
    ],
    pageLength: 50,
    destroy: true
});

$.extend(true, $.fn.datetimepicker.defaults, {
    locale: "pt-br",
    icons: {
        clear: "fa fa-trash-o",
        close: "fa fa-remove",
        date: "fa fa-calendar-arrow-down",
        down: "fa fa-chevron-down",
        next: "fa fa-chevron-right",
        previous: "fa fa-chevron-left",
        time: "fa fa-clock-o",
        today: "fa fa-crosshairs",
        up: "fa fa-chevron-up"
    }
});

$.extend(true, $.fn.select2.defaults.defaults, {
    theme: "bootstrap",
    language: require('select2/src/js/select2/i18n/pt-BR.js'),
    width: "100%"
});

$.validator.setDefaults({
    errorClass: 'text-danger',
    ignore: ':hidden:not("[data-plugin-multiselect]")'
});