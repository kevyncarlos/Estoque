﻿window.Popper = require('popper.js').default;

window.$ = window.jQuery = require('jquery');
window.Highcharts = require('highcharts');
require('highcharts/highcharts-3d')(Highcharts);
window.moment = require('moment');
window._dtPtBr = require('./datatables.ptBr');
window.PNotify = require('pnotify');
window.alertify = require('alertifyjs');

require('bootstrap');

require('datatables.net-bs4');
require('datatables.net-buttons-bs4');
require('datatables.net-buttons/js/buttons.html5');
require('datatables.net-buttons/js/buttons.print');
require('datatables.net-responsive-bs4');
require('bootstrap4-datetimepicker');
require('jquery-mask-plugin');
require('bootstrap-maxlength');
require('select2');
require('jquery-validation');
require('./CustomDefaultPlugins');
require('./custom');