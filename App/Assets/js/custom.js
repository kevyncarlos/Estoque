var ptBr = {
    "sEmptyTable": "Nenhum registro encontrado",
    "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
    "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
    "sInfoFiltered": "(Filtrados de _MAX_ registros)",
    "sInfoPostFix": "",
    "sInfoThousands": ".",
    "sLengthMenu": "_MENU_ resultados por página",
    "sLoadingRecords": "Carregando...",
    "sProcessing": "Processando...",
    "sZeroRecords": "Nenhum registro encontrado",
    "sSearch": "Pesquisar",
    "sSearchPlaceholder": "Pesquisar...",
    "oPaginate": {
        "sNext": "Próximo",
        "sPrevious": "Anterior",
        "sFirst": "Primeiro",
        "sLast": "Último"
    },
    "oAria": {
        "sSortAscending": ": Ordenar colunas de forma ascendente",
        "sSortDescending": ": Ordenar colunas de forma descendente"
    }
}

//PNotify.defaults.styling = 'bootstrap4';
//PNotify.defaults.icons = 'fontawesome4';

$.extend(true, $.fn.dataTable.defaults, { language: ptBr, "ordering": false, responsive: true, theme: "bootstrap", "lengthMenu": [[25, 50, 100, 500, -1], [25, 50, 100, 500, "Todos"]], "pageLength": 50, destroy: true });
$.fn.datetimepicker.Constructor.Default = $.extend({}, $.fn.datetimepicker.Constructor.Default, { locale: "pt-br" });
$.fn.select2.defaults.set("theme", "bootstrap");
$.validator.setDefaults({ errorClass: 'text-danger' });