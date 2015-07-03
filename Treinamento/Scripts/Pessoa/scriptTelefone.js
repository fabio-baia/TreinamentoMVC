﻿function ScriptTelefone(idPessoa, urlAdicionar, urlRemover, urlListar) {

    var dialog = $("#dialogTelefone");
    var campoId = $("#TelefoneId");
    var campoNumero = $("#TelefoneNumero");

    var tab = ("#tab-telefone");
    var form = ("form", dialog);

    this.abrirDialog = function () {
        dialog.dialog("open");
    }

    function fecharDialog() {
        campoId.val(0);
        campoNumero.val("");
        dialog.dialog("close");
    }

    function atualizar() {
        tab.load(urlListar);
    }

    function adicionar() {
        if (form.valid())
            return;

        $.post(urlAdicionar, {
            Id: campoId.val(),
            IdPessoa: idPessoa,
            Numero: campoNumero.val()
        }, function(data) {
            if (data.Status) {
                atualizar();
                fecharDialog();
            }
            if (data.Message) {
                alert(data.Message);
            }
        });
    }

    this.excluir = function() {
        if (confirm("Você tem certeza que deseja excluir esse item?"))
            $.get(urlRemover, {Id:id}, function(data) {
                atualizar();
                if (data.Message)
                    alert(data.Message);
            });
    }

    this.alterar = function(id, numero) {
        campoId.val(id);
        campoNumero.val(numero);

        this.abrirDialog();
    }

    this.iniciar = function () {
        dialog.dialog({
            title: "Adicionar Telefone",
            autoOpen: false,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": adicionar,
                "Fechar": fecharDialog
            },
            close: function() {
                form.validate().resetForm();
            }
        });

        form.submit(function(event) {
            adicionar();
            event.preventDefault();
        });
    }
}