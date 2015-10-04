var sammyApp = Sammy('#container', function(){
    this.get('#/', function(){
        this.redirect('#/home');
    });

    this.get('#/home', homeController.all);
    //this.get('#/home?category=id', homeController.category)
    this.get('#/login', userController.login);
    this.get('#/logout', userController.logout);
    this.get('#/register', userController.register);
    this.get('#/cookies/add', cookiesController.add);
    this.get('#/my-cookie', cookiesController.mine);
    this.get('#/home/category/:category', homeController.category);
});
$(function() {
    sammyApp.run('#/');

    var LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

    if (data.users.hasUser()) {

        $('#btn-logout').removeClass('hidden');
        $('.my-cookie').removeClass('hidden');
        $('#username').removeClass('hidden').html(localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY));

        $('body').on('click', '#add-cookie', function (e) {
            e.preventDefault();
            var cookieData = {
                text:$('#tb-cookie-text').val(),
                category:$('#tb-cookie-category').val(),
                img:$('#tb-cookie-img').val()
            };
            data.cookies.add(cookieData)
                .then(function(){
                    document.location = '#/';
                    document.location.reload(true);
                }, function(err) {
                    toastr.error(err.errorMessage);
                });
        });

        $('body').on('click','.cookie-share', function(e){
            e.preventDefault();

            var cookie = $(e.target).parents('.cookie');
            var cookieData = {
                text: cookie.find('.cookie-text').text(),
                category: cookie.find('.cookie-category').text(),
                img: cookie.find('.cookie-image').attr('src')
            };
            data.cookies.add(cookieData)
                .then(function(){
                    document.location = '#/';
                    document.location.reload(true);
                }, function(err) {
                    toastr.error(err.errorMessage);
                });
        });

        $('body').on('click', '.review', function(e){
            e.preventDefault();
            var type = $(e.target).attr('data-type'),
                id = $(e.target).parents('.cookie').attr('data-id');

            if(type === undefined){
                type = $(e.target).parent().attr('data-type');
            }

            data.cookies.review(id,type)
                .then(function(){
                    document.location = '#/';
                    document.location.reload(true);
                }, function(err) {
                    toastr.error(err.errorMessage);
                });
        });

    } else {

        $('#btn-login').removeClass('hidden');
        $('#btn-register').removeClass('hidden');

        $('body').on('click', '#login', function (e) {
            e.preventDefault();
            var user = {
                username: $('#tb-username').val(),
                passHash: CryptoJS.SHA1($('#tb-username').val() + $('#tb-password').val()).toString()
            };
            data.users.login(user)
                .then(function (user) {
                    document.location = '#/';
                    document.location.reload(true);
                }, function (err) {
                    $('#container-sign-in').trigger("reset");
                    toastr.error(err.responseText);
                });
        });

        $('body').on('click', '#register', function (e) {
            e.preventDefault();
            var user = {
                username: $('#tb-username').val(),
                password: $('#tb-password').val(),
                passwordRepeat: $('#tb-password-repeat').val()
            };

            data.users.register(user)
                .then(function (user) {
                    document.location = '#/';
                    document.location.reload(true);
                }, function (err) {
                    $('#container-sign-in').trigger("reset");
                    toastr.error(err.responseText);
                });
        });
    }

    $('body').on('click','.sort', function(e){
        e.preventDefault();
        var sortBy = $(e.target).attr('data-sort');
        var cookies = $('.cookies-container').find('.panel').clone();
        cookies = cookies.sort(function(x, y){
            if(sortBy==='likes'){
                return +$(x).find('a[data-type="like"]').text() < +$(y).find('a[data-type="like"]').text();
            } else {
                var dateX = +new Date($(x).attr('data-date').split('-').join(' ')),
                    dateY = +new Date($(y).attr('data-date').split('-').join(' '));
                //console.log(+new Date($(x).attr('data-date').split('-').join(' ')), dateY);
                return dateY - dateX;
            }
        });

        $('.cookies-container').find('.panel').detach();
        $('.cookies-container').append(cookies);
    });
}());

function substringMatcher(strs) {
    return function findMatches(q, cb) {
        var matches, substringRegex;
        matches = [];
        substrRegex = new RegExp(q, 'i');

        $.each(strs, function(i, str) {
            if (substrRegex.test(str)) {
                matches.push(str);
            }
        });

        cb(matches);
    };
}