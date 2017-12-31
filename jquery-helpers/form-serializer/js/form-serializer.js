/**
 * form-serializer v0.1
 */
;(function(main) {
    main(window, jQuery);
})(function(window, $) {

    'use strict';

    /**
     * Used for converting serialize jquery form data
     * @param formSerializeArray
     * @returns {Object}
     */
    function convertToFormData(formSerializeArray) {

        var fsa = formSerializeArray;
        var data = {};

        fsa.forEach(function(i) {
            data[i.name] = i.value;
        });

        return data;
    }

    /**
     * Used for serializing form data
     * @param callback
     */
    $.fn.formSerializer = function(callback) {

        var _this = this;

        _this.on('submit', function(e) {

            e.preventDefault();

            var _this = $(this);
            var data = convertToFormData(_this.serializeArray());

            if(typeof callback === 'function') {
                callback(data, e);
            }

        });

    };

});