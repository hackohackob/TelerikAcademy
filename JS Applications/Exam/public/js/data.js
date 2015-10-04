var data = function () {
    var LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

    function login(data) {
        var promise = new Promise(function(resolve, reject){
            console.log(data);
            $.ajax({
                url:'api/auth',
                method:'PUT',
                data:JSON.stringify(data),
                contentType:'application/json',
                success:function(response){
                    console.log('all good, user logged in, response', response);
                    var user = response.result;
                    localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                    localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                    resolve(user);
                },
                error: function(error){
                    reject(error);
                }
            })
        });

        return promise;
    }
    function logout() {
        var promise = new Promise(function(resolve, reject) {
            localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
            localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);

            resolve();
        });
        return promise;
    }
    function register(user) {
        var promise = new Promise(function(resolve, reject){
            if(typeof user.username !== 'string'){
                reject({
                    responseText:'Invalid username'
                });
                return;
            } else if(user.username.length < 6 || user.username.length >30 ){
                reject({
                    responseText:'Invalid username length'
                });
                return;
            } else if(!/^[A-z0-9_.]{6,30}$/.test(user.username)){
                reject({
                    responseText:'Invalid symbols in username'
                });
                return;
            } else if(user.password !== user.passwordRepeat){
                reject({
                    responseText:'Passwords doesn\'t match'
                });
                return;
            } else if(user.password.length<3){
                reject({
                    responseText:'Password is too short'
                });
                return;
            }

            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.username + user.password).toString()
            };

            $.ajax({
                url:'api/users',
                method: 'POST',
                contentType:'application/json',
                data: JSON.stringify(reqUser),
                success: function(resp){
                    var user = resp.result;
                    if(user){
                        login(reqUser)
                            .then(function(success){
                                resolve(success);
                            }, function(error){
                                reject(error);
                            })
                    }
                },
                error: function(response){
                    toastr.error(response.responseText);
                }
            });
        });

        return promise;

    }
    function hasUser() {
        return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
            !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
    }

    function cookiesAll() {
        var promise = new Promise(function(resolve, reject){
            $.getJSON('api/cookies', function(cookies){
                resolve(cookies);
            });
        });

        return promise;
    }
    function cookieMine(){
        var promise = new Promise(function(resolve, reject){
            if(hasUser()) {
                $.ajax({
                    url:'api/my-cookie',
                    headers:{
                        'x-auth-key':localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
                    },
                    success: function(cookie){
                        resolve(cookie);
                    }
                });
            } else {
                resolve({result:null});
            }
        });

        return promise;
    }
    function cookieAdd(cookieData) {
        var promise  = new Promise(function(resolve, reject){
            console.log('will add cookie with data',cookieData);
            var nameRegex = /^[\w\W]{6,30}$/,
                urlRegex = /^[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?$/;

            if(nameRegex.test(cookieData.text) && nameRegex.test(cookieData.category) && (cookieData.img.length===0 || (cookieData.img.length>0 && urlRegex.test(cookieData.img)))){
                $.ajax({
                    url:'api/cookies',
                    method:'POST',
                    contentType:'application/json',
                    data: JSON.stringify(cookieData),
                    headers:{
                        'x-auth-key':localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
                    },
                    success: function(cookie){
                        console.log(cookie);
                        resolve(cookie);
                    }
                })
            } else {
                reject({errorMessage:'Invalid data'});
            }


        });

        return promise;

    }
    function categoriesGet() {
        var promise = new Promise(function(resolve, reject){
            $.ajax({
                url:'api/categories',
                success: function(categories){
                    resolve(categories.result);
                }
            })
        });

        return promise;

    }
    function cookieReview(id,type){
        console.log('will give '+type+' to '+id );
        var promise = new Promise(function(resolve, reject){
            $.ajax({
                url:'api/cookies/'+id,
                method:'PUT',
                data:JSON.stringify({type:type}),
                contentType:'application/json',
                headers:{
                    'x-auth-key':localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
                },
                success: function(response){
                    console.log('review response', response);
                    resolve(response);
                }
            })
        });

        return promise;
    }
    function cookieCategory(category){
        var promise = new Promise(function(resolve, reject){
            $.getJSON('api/cookies?category='+category, function(cookies){
                resolve(cookies);
            });
        });

        return promise;
    }

    return {
        users: {
            login: login,
            logout: logout,
            register: register,
            hasUser: hasUser,
        },
        cookies: {
            all: cookiesAll,
            mine: cookieMine,
            add: cookieAdd,
            review: cookieReview,
            category: cookieCategory
        },
        categories: {
            get: categoriesGet
        }
    }
}();
