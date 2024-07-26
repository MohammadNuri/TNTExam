"use strict";
 
// Class definition
var KTSearchHorizontal = function () {
    // Private functions
    var initAdvancedSearchForm = function () {
       var form = document.querySelector('#kt_advanced_search_form');

       // Init tags
       var tags = form.querySelector('[name="tags"]');
       new Tagify(tags);
    }

    var handleAdvancedSearchToggle = function () {
        var link = document.querySelector('#kt_horizontal_search_advanced_link');

        link.addEventListener('click', function (e) {
            e.preventDefault();
            
            if (link.innerHTML === "جستجوی پیشرفته") {
                link.innerHTML = "پنهان کردن جستجوی پیشرفته";
            } else {
                link.innerHTML = "جستجوی پیشرفته";
            }
        })
    }

    // Public methods
    return {
        init: function () {
            initAdvancedSearchForm();
            handleAdvancedSearchToggle();
        }
    }     
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
    KTSearchHorizontal.init();
});
