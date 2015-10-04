var homeController = function () {
    function all(context) {
        var loggedUser = data.users.hasUser();
        templates.get('home')
            .then(function (template) {
                return template;
            })
            .then(function (template) {
                if(context.params.category){
                    var category = context.params.category.toLowerCase();
                    data.cookies.category(context.params.category)
                        .then(function (response) {
                            var allCookies = response.result.filter(function (singleCookie) {
                                return singleCookie.category.toLowerCase() === category;
                            });


                            data.cookies.mine()
                                .then(function (mineResponse) {
                                    var mineCookie = mineResponse.result;
                                    context.$element().html(template({
                                        location: 'Home',
                                        cookies: allCookies,
                                        mineCookie: mineCookie,
                                        user: loggedUser
                                    }));
                                });
                        });
                } else {
                    data.cookies.all()
                        .then(function (response) {
                            var allCookies = response.result;

                            data.categories.get()
                                .then(function (categories) {
                                    context.$element().html(template({
                                        location: 'Home',
                                        cookies: allCookies,
                                        user: loggedUser,
                                        categories: categories
                                    }));
                                })
                        });
                }
            });
    }

    function category(context) {
        var loggedUser = data.users.hasUser();
        templates.get('home')
            .then(function (template) {
                return template;
            })
            .then(function (template) {
                var category = context.params.category.toLowerCase();
                data.cookies.category(context.params.category)
                    .then(function (response) {
                        var allCookies = response.result.filter(function (singleCookie) {
                            return singleCookie.category.toLowerCase() === category;
                        });

                        console.log('all ', allCookies);

                        data.cookies.mine()
                            .then(function (mineResponse) {
                                var mineCookie = mineResponse.result;
                                context.$element().html(template({
                                    location: 'Home',
                                    cookies: allCookies,
                                    mineCookie: mineCookie,
                                    user: loggedUser
                                }));
                            });
                    });
            });
    }

    return {
        all: all,
        category: category
    };
}();