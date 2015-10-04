var cookiesController = function () {
    function add(context) {
        var template;
        templates.get('cookie-add')
            .then(function (templateResult) {
                template = templateResult
                data.categories.get()
                    .then(function(categories){
                        context.$element().html(template());

                        $('#tb-cookie-category').typeahead({
                                hint: true,
                                highlight: true,
                                minLength: 1
                            },
                            {
                                name: 'categories',
                                source: substringMatcher(categories)
                            });
                    });
            });
    }

    function mine(context) {
        var template;
        templates.get('my-cookie')
            .then(function (templateResult) {
                template = templateResult
                data.cookies.mine()
                    .then(function(response){

                        context.$element().html(template({mineCookie:response.result}));

                    });
            });
    }

    return {
        add: add,
        mine: mine

    };
}();