(function($) {
    $.sessionManager = function(o) {
        var sessionManager = {
            options: $.extend({
                redirectUrl: 'Security/Login',
                logoutUrl: 'Security/Logout',
                keepAliveUrl: 'Security/KeepAlive',

                warnMessage: 'You session is getting expired, you may logoff or extend session. Session end in @@{TIMER}',

                warnWhenLeft: 20 * 60 * 1000,
                sessionTime: 30 * 60 * 1000,

                autoRedirectOnSessionEnd: true,

                warnPanelId: 'session-manager-warn-panel',
                warnLabelId: 'session-manager-warn-label',

                buttonClasses: undefined,

                logoffButtonText: 'Logoff',
                logoffButtonId: 'session-manager-btn-logoff',

                extendButtonText: 'Extend',
                extendButtonId: 'session-manager-btn-extend',
            }, o),

            startTime: undefined,
            warnTimer: undefined,
            logoffTimer: undefined,
            countDownTimer: undefined,

            setCallback: function() {
                var that = this;
                var options = that.options;

                that.startTime = new Date();

                that.setWarnPanelVisibility(false);

                if (that.warnTimer != undefined) {
                    clearTimeout(that.warnTimer);
                }

                if (that.countDownTimer != undefined) {
                    clearTimeout(that.countDownTimer);
                }

                if (options.warnWhenLeft > 0) {
                    that.warnTimer = setTimeout(function() {
                        if (options.warnMessage.indexOf("@@{TIMER}") != -1) {
                            that.countDownTimer = setInterval(function() {
                                that.updateWarnLabelText();
                            }, 100);
                        }

                        that.updateWarnLabelText();
                        that.setWarnPanelVisibility(true);

                    }, options.sessionTime - options.warnWhenLeft);
                }

                if (options.autoRedirectOnSessionEnd) {
                    // запуск таймера на окончание сессии
                    if (that.logoffTimer != undefined) {
                        clearTimeout(that.logoffTimer);
                    }
                    that.logoffTimer = setTimeout(function() {
                        document.location.href = options.redirectUrl;
                    }, options.sessionTime);
                }
            },

            getUTCTimeString: function (time) {
                if (!time) return "00:00:00";

                var h = time.getUTCHours();
                if (h < 10) h = '0' + h;

                var m = time.getUTCMinutes();
                if (m < 10) m = '0' + m;

                var s = time.getUTCSeconds();
                if (s < 10) s = '0' + s;

                return h + ':' + m + ':' + s;
            },

            initAjaxHandler: function () {
                var that = this;
                $(document).ajaxComplete(function () {
                    that.setCallback();
                });
            },

            init: function() {
                this.initPanel();
                this.initAjaxHandler();
                this.setCallback();
            },

            setWarnPanelVisibility: function(visibility) {
                $('#' + this.options.warnPanelId).css('display', visibility ? 'table' : 'none');
                $('#' + this.options.warnPanelId).css('z-index', '100000');
            },

            initPanel: function() {
                var that = this;
                var options = that.options;

                var dv = $('<div/>').appendTo('body');
                dv.attr('id', options.warnPanelId);
                dv.css({
                    position: 'fixed',
                    top: 0,
                    width: '100%',
                    background: '#FFFFCC',
                    borderBottom: '1px solid #dadada',
                    zIndex: 10000,
                    display: 'table'
                });

                dv.append(
                    $('<span />').css({
                        display: 'table-cell',
                        width: '20px',
                        padding: '0 3px',
                        verticalAlign: 'center'
                    }).append($('<span class="ui-icon ui-icon-alert"></span>').css({
                        display: 'inline-block',
                        position: 'relative',
                        top: '3px',
                    }))
                );

                $('<span/>').attr('id', options.warnLabelId).appendTo(dv).text(options.warnMessage).css({
                    color: '#000',
                    fontSize: '16px',
                    fontFamily: 'Courier',
                    verticalAlign: 'center',
                    display: 'table-cell',
                    padding: '3px'
                });

                var btnCss = {
                    display: 'table-cell',
                    width: '1px',
                    padding: '5px',
                    whiteSpace: 'nowrap',
                };

                if (options.logoffButtonText) {
                    $('<span/>').css(btnCss).appendTo(dv).append(
                        $('<button/>').attr('id', options.logoffButtonId).append(options.logoffButtonText).click(function() {
                            that.logoffSession();
                        })[options.buttonClasses ? "addClass" : "button"](options.buttonClasses ? options.buttonClasses : undefined)
                    );
                }

                if (options.extendButtonText) {
                    $('<span/>').css(btnCss).appendTo(dv).append(
                        $('<button/>').attr('id', options.extendButtonId).append(options.extendButtonText).click(function() {
                            that.extendSession();
                        })[options.buttonClasses ? "addClass" : "button"](options.buttonClasses ? options.buttonClasses : undefined)
                    );
                }
            },

            extendSession: function() {
                var that = this;
                $.ajax({
                    url: that.options.keepAliveUrl
                }).done(function() {
                    that.setCallback();
                });
            },

            logoffSession: function() {
                document.location.href = this.options.logoutUrl;
            },

            updateWarnLabelText: function() {
                var that = this;

                var date = new Date(that.startTime);
                var endTime = date.setMilliseconds(that.startTime.getMilliseconds() + that.options.sessionTime);
                var time = new Date(endTime - new Date());

                var timeLeft = time < 0 ? "00:00:00" : that.getUTCTimeString(time);

                $('#' + this.options.warnLabelId).html(this.options.warnMessage.replace("@@{TIMER}", timeLeft));
            }
        };

        sessionManager.init();
        return sessionManager;
    };
})
(jQuery);