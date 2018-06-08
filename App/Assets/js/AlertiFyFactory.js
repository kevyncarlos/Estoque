/*
*Fabricando alertas customizados
*
*/
/**
 * Confirm dialog object
 *
 *	alertify.confirmCustom(message);
 *	alertify.confirmCustom(message, onok);
 *	alertify.confirmCustom(message, onok, oncancel);
 *	alertify.confirmCustom(title, message, onok, oncancel);
 */
if (!alertify.confirmSingular) {
    alertify.dialog('confirmApp', function factory() {

        var autoConfirm = {
            timer: null,
            index: null,
            text: null,
            duration: null,
            task: function (event, self) {
                if (self.isOpen()) {
                    self.__internal.buttons[autoConfirm.index].element.innerHTML = autoConfirm.text + ' (&#8207;' + autoConfirm.duration + '&#8207;) ';
                    autoConfirm.duration -= 1;
                    if (autoConfirm.duration === -1) {
                        clearAutoConfirm(self);
                        var button = self.__internal.buttons[autoConfirm.index];
                        var closeEvent = createCloseEvent(autoConfirm.index, button);

                        if (typeof self.callback === 'function') {
                            self.callback.apply(self, [closeEvent]);
                        }
                        //close the dialog.
                        if (closeEvent.close !== false) {
                            self.close();
                        }
                    }
                } else {
                    clearAutoConfirm(self);
                }
            }
        };

        function clearAutoConfirm(self) {
            if (autoConfirm.timer !== null) {
                clearInterval(autoConfirm.timer);
                autoConfirm.timer = null;
                self.__internal.buttons[autoConfirm.index].element.innerHTML = autoConfirm.text;
            }
        }

        function startAutoConfirm(self, index, duration) {
            clearAutoConfirm(self);
            autoConfirm.duration = duration;
            autoConfirm.index = index;
            autoConfirm.text = self.__internal.buttons[index].element.innerHTML;
            autoConfirm.timer = setInterval(delegate(self, autoConfirm.task), 1000);
            autoConfirm.task(null, self);
        }


        return {
            
            main: function (_title, _message, _onok, _oncancel) {
                var title, message, onok, oncancel;
                switch (arguments.length) {
                    case 1:
                        message = _title;
                        break;
                    case 2:
                        message = _title;
                        oncancel = _message;
                        break;
                    case 3:
                        message = _title;
                        oncancel = _message;
                        onok = _onok;
                        break;
                    case 4:
                        title = _title;
                        message = _message;
                        oncancel = _onok;
                        onok = _oncancel;
                        break;
                }
                this.set('title', title);
                this.set('message', message);
                this.set('onok', onok);
                this.set('oncancel', oncancel);
                return this;
            },
            setup: function () {
                return {
                    buttons: [
                        {
                            text: "<i class=\"fa fa-times-circle\"></i> Cancelar",
                            key: 27,
                            invokeOnClose: true,
                            className: "btn btn-danger btn-sm",
                            escope: 'secondary'
                        },
                        {
                            text: "<i class=\"fa fa-check-circle\"></i> Confirmar",
                            key: 13,
                            className: "btn btn-dark btn-sm",
                        }
                    ],
                    focus: {},
                    options: {
                        maximizable: false,
                        resizable: false
                    }
                };
            },
            build: function () {
                this.setHeader("<i class=\"fa fa-warning\" style=\"color: #ffc107\"></i> Atenção!")
                $(this.elements.header).addClass("bg-dark text-white")
            },
            prepare: function () {
                //nothing
            },
            setMessage: function (message) {
                this.setContent(message);
            },
            settings: {
                message: null,
                labels: null,
                onok: null,
                oncancel: null,
                defaultFocus: null,
                reverseButtons: null,
            },
            settingUpdated: function (key, oldValue, newValue) {
                switch (key) {
                    case 'message':
                        this.setMessage(newValue);
                        break;
                    case 'labels':
                        if ('ok' in newValue && this.__internal.buttons[0].element) {
                            this.__internal.buttons[0].text = newValue.ok;
                            this.__internal.buttons[0].element.innerHTML = newValue.ok;
                        }
                        if ('cancel' in newValue && this.__internal.buttons[1].element) {
                            this.__internal.buttons[1].text = newValue.cancel;
                            this.__internal.buttons[1].element.innerHTML = newValue.cancel;
                        }
                        break;
                    case 'reverseButtons':
                        if (newValue === true) {
                            this.elements.buttons.primary.appendChild(this.__internal.buttons[0].element);
                        } else {
                            this.elements.buttons.primary.appendChild(this.__internal.buttons[1].element);
                        }
                        break;
                    case 'defaultFocus':
                        this.__internal.focus.element = newValue === 'ok' ? 0 : 1;
                        break;
                }
            },
            callback: function (closeEvent) {
                clearAutoConfirm(this);
                var returnValue;
                switch (closeEvent.index) {
                    case 0:
                        if (typeof this.get('onok') === 'function') {
                            returnValue = this.get('onok').call(this, closeEvent);
                            if (typeof returnValue !== 'undefined') {
                                closeEvent.cancel = !returnValue;
                            }
                        }
                        break;
                    case 1:
                        if (typeof this.get('oncancel') === 'function') {
                            returnValue = this.get('oncancel').call(this, closeEvent);
                            if (typeof returnValue !== 'undefined') {
                                closeEvent.cancel = !returnValue;
                            }
                        }
                        break;
                }
            },
            autoOk: function (duration) {
                startAutoConfirm(this, 0, duration);
                return this;
            },
            autoCancel: function (duration) {
                startAutoConfirm(this, 1, duration);
                return this;
            }
        };
    });
}
if (!alertify.alertSingular) {
    alertify.dialog('alertApp', function () {
        return {
            main: function (_title, _message, _onok) {
                var title, message, onok;
                switch (arguments.length) {
                case 1:
                    message = _title;
                    break;
                case 2:
                    if (typeof _message === 'function') {
                        message = _title;
                        onok = _message;
                    } else {
                        title = _title;
                        message = _message;
                    }
                    break;
                case 3:
                    title = _title;
                    message = _message;
                    onok = _onok;
                    break;
                }
                this.set('title', title);
                this.set('message', message);
                this.set('onok', onok);
                return this;
            },
            setup: function () {
                return {
                    buttons: [
                        {
                            text: "<i class=\"fa fa-check-circle\"></i> OK",
                            key: 27,
                            invokeOnClose: true,
                            className: "btn btn-dark btn-sm",
                        }
                    ],
                    focus: {
                        element: 0,
                        select: false
                    },
                    options: {
                        maximizable: false,
                        resizable: false
                    }
                };
            },
            build: function () {
                this.setHeader("<i class=\"fa fa-warning\" style=\"color: #ffc107\"></i> Atenção!")
                $(this.elements.header).addClass("bg-dark text-white")
            },
            prepare: function () {
                //nothing
            },
            setMessage: function (message) {
                this.setContent(message);
            },
            settings: {
                message: undefined,
                onok: undefined,
                label: undefined,
            },
            settingUpdated: function (key, oldValue, newValue) {
                switch (key) {
                case 'message':
                    this.setMessage(newValue);
                    break;
                case 'label':
                    if (this.__internal.buttons[0].element) {
                        this.__internal.buttons[0].element.innerHTML = newValue;
                    }
                    break;
                }
            },
            callback: function (closeEvent) {
                if (typeof this.get('onok') === 'function') {
                    var returnValue = this.get('onok').call(this, closeEvent);
                    if (typeof returnValue !== 'undefined') {
                        closeEvent.cancel = !returnValue;
                    }
                }
            }
        };
    });
}