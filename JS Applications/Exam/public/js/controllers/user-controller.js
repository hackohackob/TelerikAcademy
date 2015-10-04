var userController = function () {
    function login(context) {
        templates.get('login')
            .then(function(template){
                context.$element().html(template());
            });
    }

    function register(context){
        templates.get('register')
            .then(function(template){
                context.$element().html(template());
            });
    }

    function logout(){
        data.users.logout()
            .then(function () {
                console.log('logout successfull');
                document.location.replace('#/');
                document.location.reload(true);
            });
    }

    return {
        login: login,
        logout: logout,
        register: register
    }
}();