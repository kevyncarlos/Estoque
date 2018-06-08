/* Add here all your JS customizations */
PNotify.prototype.options.styling = "bootstrap3";

window.FuncoesIniciais = function () {
    // Tooltip and Popover
    (function ($) {
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').popover();
    })(jQuery);

    // Tabs
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $(this).parents('.nav-tabs').find('.active').removeClass('active');
        $(this).parents('.nav-pills').find('.active').removeClass('active');
        $(this).addClass('active').parent().addClass('active');
    });

    // Bootstrap Datepicker
    if (typeof ($.fn.datepicker) != 'undefined') {
        $.fn.bootstrapDP = $.fn.datepicker.noConflict();
    }

    if ($('[data-toggle="checkbox"]').get(0)) {
        var container = $('[data-toggle="checkbox"]');

        $.each(container, function (i, element) {
            var checkbox = $(element).find($('input[type="checkbox"]'));
            var icon = $(element).find($('i'));
            if ($(checkbox).is(':checked')) {
                icon.attr('class', 'fa fa-check-square')
                $(element).addClass('active')
            }
            else {
                icon.attr('class', 'fa fa-square')
            }
        });

        var checkbox = $(container).find($('input[type=checkbox]'));

        $(checkbox).on('change', function () {

            var icon = $(this).parent().find($('i'));

            if ($(this).is(':checked')) {
                icon.attr('class', 'fa fa-check-square')
            }
            else {
                icon.attr('class', 'fa fa-square')
            }
        });
    }

    $(".datetime").datetimepicker({
        locale: "pt-br"
    });

    $(".time").datetimepicker({
        locale: "pt-br",
        format: 'LT'
    });

    $(".date").datetimepicker({
        locale: "pt-br",
        format: 'L'
    });

    $(".icon-menu").each(function () {
        var a = $(this).find("a").addClass("hvr-grow");
    });

    $("select[readonly]").attr("tabindex", "-1").removeClass("select2");
    /**
    * Chamada dos plugins com data- tags
    */

    $('[data-plugin-maxlength]').each(function () {

        var $this = $(this),
            opts = {};

        if (!this.hasAttribute('maxlength')) {
            $this.attr('maxlength', $this.data('val-maxlength-max'));
        }

        var pluginOptions = $this.data('plugin-options');
        if (pluginOptions)
            opts = pluginOptions;

        $this.themePluginMaxLength(opts);
    });

    $('[data-plugin-masked-input]').each(function () {
        if (!$(this).prop('plugin-masked-input')) {
            $(this).mask($(this).data('input-mask'));
            $(this).prop('plugin-masked-input', true)
        }
    });

    $('[data-plugin-select]').each(function (i) {
        if (!$(this).prop('plugin-select')) {
            $(this).select2();
            $(this).prop('plugin-select', true)
        }
    })

    $('[data-plugin-datetimepicker]').each(function (i) {
        if (!$(this).prop('datepicker')) {
            var input = this

            var type = $(this).data('plugin-datetimepicker')
            var maxDate = $(this).data('options-maxdate')
            var minDate = $(this).data('options-mindate')
            var dateFormat = $(this).data('options-format')

            /**
            * preparando o input para receber o plugin
            */
            if (this.nodeName === 'DIV') {
                var id;
                if ($(this).attr('id')) {
                    id = $(this).attr('id')
                } else {
                    id = 'datetimepicker-id-' + i
                    $(this).attr('id', id)
                }

                if (!$(this).hasClass('input-group'))
                    $(this).addClass('input-group')

                $(this).attr('data-target-input', 'nearest')

                input = $(this).find($('input')).get(0)

                $(input).addClass('datetimepicker-input')
                $(input).attr('data-target', '#' + id)

                var divAppend = $('<div>').addClass('input-group-append input-group-addon').attr('data-target', '#' + id).attr('data-toggle', 'datetimepicker')
                var divIcon = $('<div>').addClass('input-group-text')
                var icon = $('<i>').addClass(type === 'time' ? 'fa fa-clock-o' : 'fa fa-calendar')

                icon.appendTo(divIcon)
                divIcon.appendTo(divAppend)
                divAppend.appendTo(this)
            } else if (this.nodeName === 'INPUT') {
                var id;
                if ($(this).attr('id')) {
                    id = $(this).attr('id')
                } else {
                    id = 'datetimepicker-id-' + i
                    $(this).attr('id', id)
                }

                $(this).addClass('datetimepicker-input').attr('data-target', '#' + id).attr('data-toggle', 'datetimepicker')
            }

            $(input).attr('type', 'text')
            input.value = $(input).attr('value')

            var defaultDate
            if (typeof dateFormat !== 'undefined') {
                defaultDate = moment(input.value, dateFormat)
            } else if (type === 'time') {
                defaultDate = moment(input.value, 'HH:mm')
            } else {
                defaultDate = moment(input.value, 'DD/MM/YYYY HH:mm')
            }
            
            if (!defaultDate.isValid())
                defaultDate = moment(input.value, 'YYYY-MM-DDTHH:mm') 

            var vazio = false

            if (defaultDate.format('DD/MM/YYYY') == '01/01/0001' || input.value == "")
                vazio = true

            $(this).datetimepicker()

            if (type === 'date') {
                $(this).data("DateTimePicker").format('L')
                $(input).attr('data-plugin-mask', 'date')
            } else if (type === 'time') {
                $(this).data("DateTimePicker").format('LT')
                $(input).attr('data-plugin-mask', 'time')
            } else {
                $(input).attr('data-plugin-mask', 'datetime')
            }

            if (typeof maxDate !== 'undefined') {
                var $maxDate = moment(maxDate, type == 'date' ? 'DD/MM/YYYY' : type == 'time' ? 'HH:mm' : 'DD/MM/YYYY HH:mm')

                $(this).data("DateTimePicker").maxDate($maxDate)
            }

            var $minDate
            if (typeof minDate === 'undefined')
                $minDate = moment('01/01/1901 00:00', 'DD/MM/YYYY HH:mm')
            else
                $minDate = moment(minDate, type == 'date' ? 'DD/MM/YYYY' : type == 'time' ? 'HH:mm' : 'DD/MM/YYYY HH:mm')

            $(this).data("DateTimePicker").minDate($minDate)


            if (!vazio || type === 'time') {
                $(input).val(defaultDate.format(type == 'time' ? 'HH:mm' : 'DD/MM/YYYY HH:mm'))
            } else {
                $(input).val("")
            }

            $(this).prop('datepicker', true)
        }
    })

    $('[data-plugin-datatables]').each(function (i) {
        if (!$.fn.DataTable.isDataTable(this)) {
            if ($(this).hasClass('display'))
                $(this).addClass('display')

            var options = {};
            var buttons = $(this).data('options-buttons')
            if (typeof buttons !== 'undefined') {
                var arrBtn = ["pageLength"]

                $.extend(true, options, {
                    buttons: arrBtn.concat(buttons.split(", ")),
                    dom: 'Bfrtip',
                });
            }
            if ($(this).data('options-order'))
                $.extend(true, options, { ordering: true })

            $(this).DataTable()
        }
    })

    $('[data-plugin-checkbox]').each(function (i) {
        if (!$(this).prop('plugin-checkbox')) {
            var text = $(this).data('plugin-checkbox')
            var input = $(this).find('input').get(0)
            var icon = $('<i>').addClass('fa ' + ($(input).is(':checked') ? 'fa-check-square' : 'fa-square'))
            var span = $('<span>').text(' ' + text)

            $(this).parent().addClass('btn-group-toggle').attr('data-toggle', 'buttons')
            $(this).addClass('btn btn-secondary' + ($(input).is(':checked') ? ' active' : ''))

            icon.appendTo(this)
            span.appendTo(this)

            $(input).on('change', function (e) {
                icon.toggleClass('fa-check-square', $(this).is(':checked'))
                icon.toggleClass('fa-square', !$(this).is(':checked'))
            })
            $(this).prop('plugin-checkbox', true)
        }
    });

    $('[data-plugin-mask]').each(function (i) {
        var type = $(this).data('plugin-mask')
        if (type == 'date') {
            $(this).mask('00/00/0000');
            $(this).attr('placeholder', '__/__/____')
        } else if (type == 'time') {
            $(this).mask('00:00');
            $(this).attr('placeholder', '__:__')
        } else if (type == 'datetime') {
            $(this).mask('00/00/0000 00:00');
            $(this).attr('placeholder', '__/__/____ __:__')
        } else if (type == 'cep') {
            $(this).mask('00000-000');
            $(this).attr('placeholder', '_____-___')
        } else if (type == 'phone') {
            $(this).mask('(00) 0000-0000');
            $(this).attr('placeholder', '(__) ____-____')
        } else if (type == 'celphone') {
            var CelPhoneMask = function (val) {
                return val.replace(/\D/g, '').length === 11 ? '(00) 0 0000-0000' : '(00) 0000-00009';
            },
                CelPhoneOptions = {
                    onKeyPress: function (val, e, field, options) {
                        field.mask(CelPhoneMask.apply({}, arguments), options);
                    }
                };

            $(this).mask(CelPhoneMask, CelPhoneOptions);
            $(this).attr('placeholder', '(__) _ ____-____')
        } else if (type == 'cpf') {
            $(this).mask('000.000.000-00', { reverse: true });
            $(this).attr('placeholder', '___.___.___-__')
        } else if (type == 'cnpj') {
            $(this).mask('00.000.000/0000-00', { reverse: true });
            $(this).attr('placeholder', '__.___.___/____-__')
        } else if (type == 'money') {
            $(this).mask('000.000.000.000.000,00', { reverse: true });
            $(this).attr('placeholder', '000,00')
        } else {
            $(this).mask(type)
        }
    })
}

$(function () {
    $.fn.dataTable.moment('DD/MM/YYYY', 'pt-br');
    $.ajaxSetup({
        complete: function () {
            FuncoesIniciais()
        }
    });
    FuncoesIniciais();
});

window.ToggleDate = function (minDate, maxDate) {
    $(minDate).on('dp.change', function (e) {
        $(maxDate).data("DateTimePicker").minDate(e.date)
    })

    $(maxDate).on('dp.change', function (e) {
        $(minDate).data("DateTimePicker").maxDate(e.date)
    })
}