var templates = function() {
    var handlebars = window.handlebars || window.Handlebars,
        Handlebars = window.handlebars || window.Handlebars,
        cache = {};

    handlebars.registerHelper('dateTime', function(dateTimeString) {
        return new Date(dateTimeString).toString().split(' ').join('-');
    });

    handlebars.registerHelper('dateTimePrint', function(dateTimeString) {
        var monthNames = [
            "January", "February", "March",
            "April", "May", "June", "July",
            "August", "September", "October",
            "November", "December"
        ];

        var date=new Date(dateTimeString);
        var day = date.getDate();
        var monthIndex = date.getMonth();
        var year = date.getFullYear();

        return date.getHours()+':'+date.getMinutes()+' '+day+' '+monthNames[monthIndex]+' '+ year;
    });

    function get(name) {
        console.log('will get template',name);
        var promise = new Promise(function(resolve, reject) {
            if (cache[name]) {
                resolve(cache[name]);
                return;
            }
            var url = 'templates/'+name+'.handlebars';
            $.get(url, function(html) {
                var template = handlebars.compile(html);
                cache[name] = template;
                resolve(template);
            });
        });
        return promise;
    }

    return {
        get: get
    };
}();