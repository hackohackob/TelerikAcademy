function solve() {
    return function () {
        $.fn.listview = function (data) {
            var $this = this,
                result = '';
            var $templateScript = $('#' + $this.attr('data-template'));
            var $templateHTML = $templateScript.html();

            for (var i = 0; i < data.length; i++) {
                var $newTemplateHTML = $templateHTML;
                $newTemplateHTML = makeEaches($newTemplateHTML, data,i);

                $newTemplateHTML = $newTemplateHTML.split('{{this}}').join(data[i].toString());
                for (var j = 0; j < Object.keys(data[i]).length; j++) {
                    var key = Object.keys(data[i])[j];
                    $newTemplateHTML = $newTemplateHTML.split('{{' + key + '}}').join(data[i][key]);

                }
                result += $newTemplateHTML;
            }

            this.html(result);

            function makeEaches($newTemplateHTML, data,i) {
                if ($newTemplateHTML.indexOf('{{#each ') < 0) {
                    return $newTemplateHTML;
                }

                var eachStatement = $newTemplateHTML.slice($newTemplateHTML.indexOf('{{#each'), $newTemplateHTML.indexOf('{{/each}}') + 9);
                var eachCollection = eachStatement.slice(8,eachStatement.indexOf('}}'));
                var template = eachStatement.slice(eachStatement.indexOf('}}')+2,eachStatement.lastIndexOf('{{'));
                var rendered ='';
                data=data[i];

                for(var i=0;i<data[eachCollection].length;i++){
                    var currentTemplate = template;
                    currentTemplate = currentTemplate.split('{{this}}').join(data[eachCollection][i]);
                    rendered+=currentTemplate;
                }

                return $newTemplateHTML.slice(0,$newTemplateHTML.indexOf('{{#each '))
                    +rendered
                    +$newTemplateHTML.slice($newTemplateHTML.indexOf('{{/each}}')+9);
            }
        };
    };
}

module.exports = solve;