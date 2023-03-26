$(function () {
    var vinValidationRules = {
        rules: {
            vin: {
                required: '#frame:blank',
                minlength: 17,
                maxlength: 17
            },
            frame: {
                required: '#vin:blank',
                minlength: 6,
                maxlength: 14
            }
        }
    };

    $("#vinForm").validate(vinValidationRules);
});