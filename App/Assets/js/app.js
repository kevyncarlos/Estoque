window.Popper = require('popper.js').default;

window.$ = window.jQuery = require("jquery");
window.Highcharts = require('highcharts');
require('highcharts/highcharts-3d')(Highcharts);
window.dtPtBr = require('./datatables.ptBr');
window.PNotify = require('pnotify');
window.alertify = require('alertifyjs');

PNotify.defaults.styling = 'bootstrap4';
PNotify.defaults.icons = 'fontawesome4';

require('bootstrap');
require('jquery-mask-plugin');
require('bootstrap-maxlength');
require('select2');
require('select2/dist/js/i18n/pt-BR');
require('jquery-validation');

$.extend(true, $.fn.dataTable.defaults, { language: dtPtBr, "ordering": false, responsive: true, theme: "bootstrap", "lengthMenu": [[25, 50, 100, 500, -1], [25, 50, 100, 500, "Todos"]], "pageLength": 50, destroy: true });
$.fn.datetimepicker.Constructor.Default = $.extend({}, $.fn.datetimepicker.Constructor.Default, { locale: "pt-br" });
$.fn.select2.defaults.set("theme", "bootstrap");
$.validator.setDefaults({ errorClass: 'text-danger' });

require('./custom');