function solve(args) {
    //var result =;
    var wholeCSS=args.join('\n');
    wholeCSS= wholeCSS.trim();
    var toReturn='';
    var objectWhole = {};

    var bySelectors=wholeCSS.split('}');
    bySelectors = bySelectors.map(function(item){
        return (item+'}').trim();
    });

    for (var i = 0; i < bySelectors.length; i++) {
        var wholeRule = bySelectors[i];
        var selector = wholeRule.slice(0,wholeRule.indexOf('{'));
        var properties = wholeRule.slice(wholeRule.indexOf('{'));

        selector = fixSelector(selector);
        properties = fixProperties(properties);
        if(selector.length>0) {
            if(objectWhole[selector]){
                objectWhole[selector]=mergeProperties(selector,properties);
            }else {
                objectWhole[selector] = properties;
            }
        }

    }

    for(var key in objectWhole){
        toReturn+=key+objectWhole[key];
    }

    console.log(toReturn);

    function mergeProperties(selector, properties) {
        var objectProperties = objectWhole[selector].replace(/({|})/g,'');
        var comingProperties = properties.replace(/({|})/g,'');
        var objectPropertiesArray = objectProperties.split(';');
        var comingPropertiesArray = comingProperties.split(';');

        for (var i = 0; i < objectPropertiesArray.length; i++) {
            for (var j = 0; j < comingPropertiesArray.length; j++) {
                var objectSel =  objectPropertiesArray[i].split(':')[0];
                var comingSel =  comingPropertiesArray[j].split(':')[0];

                if(objectSel == comingSel){
                    objectPropertiesArray[i] = objectSel+':'+comingPropertiesArray[j].split(':')[1];
                    objectPropertiesArray.splice(i,1);
                    //comingPropertiesArray = comingPropertiesArray.splice(j,1);
                }
            }
        }

        objectPropertiesArray = objectPropertiesArray.concat(comingPropertiesArray);
        return '{'+objectPropertiesArray.join(';')+'}';
    }


    function fixSelector(selector) {
        selector = selector.replace(/[\s ]+/g,'');
         selector = (selector.replace(/(\w|\d)\./g,'$1 .')).trim();
        return selector;
    }

    function fixProperties(properties) {
        var propertiesArray = properties.split(';');
        propertiesArray = propertiesArray.map(function(item){
           return item.replace(/[\s ]+/g,'');
        });
        propertiesArray = propertiesArray.join(';');
        propertiesArray=propertiesArray.slice(0,propertiesArray.lastIndexOf(';'))+propertiesArray.slice(propertiesArray.lastIndexOf(';')+1);
        return propertiesArray;
    }

}

var input1 = ['#the-big-b{',
    'color: yellow;',
    'size: big;',
    '}',
    '.muppet{',
    '    powers: all;',
    '    skin: fluffy;',
    '}',
    '.water-spirit         {',
    '    powers: water;',
    '    alignment    : not-good;',
    '}',
    'all{',
    '    meant-for: nerdy-children;',
    '}',
    '.muppet      {',
    '    powers: everything;',
    '}',
    'all            .muppet {',
    '    alignment             :             good                             ;',
    '}',
    '.muppet+             .water-spirit{',
    '    power: everything-a-muppet-can-do-and-water;',
    '}'
];

var input2 = ['#the-big-b{',
    'color: yellow;',
    'size: big;',
    '}',
    '.muppet{',
    '    powers: all;',
    '    skin: fluffy;',
    '}',
    '.water-spirit         {',
    '    powers: water;',
    '    alignment    : not-good;',
    '}',
    'all{',
    '    meant-for: nerdy-children;',
    '}',
    '.muppet      {',
    '    powers: everything;',
    '    makes_it_good    :         true;    ',
    '}',
    'all            .muppet {',
    '    alignment             :             good                             ;',
    '}',
    '.muppet {',
    '    powers: something;',
    '}',
    '.muppet+             .water-spirit{',
    '    power: everything-a-muppet-can-do-and-water;',
    '}'
];

solve(input2);