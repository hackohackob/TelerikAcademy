function solve(args) {
    var modelVarsNumber = +args[0];
    var model = {};
    var templates = {};
    var escapeCount= -1;
    var html = args.slice(2 + modelVarsNumber).join('\n');
    for (var i = 0; i < modelVarsNumber; i++) {
        var keyValuePair = args[i + 1].split('-');
        if (keyValuePair[1] === 'true') {
            keyValuePair[1] = true;
        } else if (keyValuePair[1] === 'false') {
            keyValuePair[1] = false;
        } else if (keyValuePair[1].indexOf(';') > -1) {
            keyValuePair[1] = keyValuePair[1].split(';');
        }
        model[keyValuePair[0]] = keyValuePair[1];
    }
    while(html.indexOf('{{') > -1){
        replace(html.indexOf('{{'),html.indexOf('}}')+2,handleEscape(html.indexOf('{{'),html.indexOf('}}')+2));

    }

    while(html.indexOf('<nk-template name=') > -1){
        replace(html.indexOf('<nk-template name='),html.indexOf('</nk-template>')+14, handleTemplates(html.indexOf('<nk-template name='),html.indexOf('</nk-template>')+14));
    }

    while(html.indexOf('<nk-template render=') > -1){
        replace(html.indexOf('<nk-template render='),html.indexOf('/>',html.indexOf('<nk-template render='))+2,
            handleTemplatesRendering(html.indexOf('<nk-template render='),html.indexOf('/>',html.indexOf('<nk-template render='))+2));
    }




    while(html.indexOf('<nk-if') > -1){
        replace(html.indexOf('<nk-if'),html.indexOf('</nk-if>')+8, handleIfs(html.indexOf('<nk-if'),html.indexOf('</nk-if>')+8));
    }

    html = html.trim();

    while(html.indexOf('<nk-repeat') > -1){
        replace(html.indexOf('<nk-repeat'),html.indexOf('</nk-repeat>')+12, handleLoops(html.indexOf('<nk-repeat'),html.indexOf('</nk-repeat>')+12));
    }

    while(html.indexOf('<nk-model')> -1) {
        replace(html.indexOf('<nk-model'), html.indexOf('</nk-model>') + 11, handleVars(html.indexOf('<nk-model'), html.indexOf('</nk-model>') + 11));
        //console.log(html);
    }

    while(html.indexOf('<nk-modee')> -1) {
        replace(html.indexOf('<nk-modee'), html.indexOf('</nk-modee>') + 11, handleVars(html.indexOf('<nk-modee'), html.indexOf('</nk-modee>') + 11));

    }

    while(html.indexOf('DELETE HERE')>-1){
        var htmlFront = html.slice(0,html.indexOf('DELETE HERE'));
        var htmlRear = html.slice(html.indexOf('DELETE HERE')+12);
        html = htmlFront+htmlRear;
    }
    console.log(html);
    //}

    function handleTemplates(firstIndex,lastIndex) {
        var htmlPart=html.slice(firstIndex,lastIndex);
        var startTemplateTagEnds = htmlPart.indexOf('>');
        var endTemplateTagStarts = htmlPart.lastIndexOf('</');
        var templateName = htmlPart.slice(htmlPart.indexOf('name="')+6, htmlPart.indexOf('"',htmlPart.indexOf('name="')+7));
        var templateContent = htmlPart.slice(startTemplateTagEnds+2,endTemplateTagStarts-1);
        templates[templateName] = templateContent;
        return '';
    }

    function handleTemplatesRendering(firstIndex, lastIndex) {
        var htmlPart =  html.slice(firstIndex,lastIndex);
        var templateName = htmlPart.slice(htmlPart.indexOf("\"")+1,htmlPart.indexOf("\"",htmlPart.indexOf("\"")+1));
        return templates[templateName];

    }


    function handleEscape(firstIndex, lastIndex) {
        escapeCount+=1;
        var htmlPart = html.slice(firstIndex,lastIndex);
        var escapedHtml = html.slice(firstIndex+2,lastIndex-2);
        model['escaped'+escapeCount] = escapedHtml;
        return '<nk-modee>escaped'+escapeCount+'</nk-modee>';
    }

    function handleIfs(firstIndex,lastIndex) {
        var htmlPart = html.slice(firstIndex,lastIndex);
        if(htmlPart.indexOf('</nk-if')<0){
            return htmlPart;
        }
        var ifCondition = htmlPart.slice(htmlPart.indexOf('condition="')+11, htmlPart.indexOf('"',htmlPart.indexOf('condition="')+11));

        var toReturn ='';
        if(model[ifCondition]){
            toReturn=  htmlPart.slice(htmlPart.indexOf('>')+1,htmlPart.lastIndexOf('</'));
            toReturn+='DELETE HERE';
        }

        return 'DELETE HERE'+toReturn;

    }

    function handleLoops(firstIndex,lastIndex) {
        var htmlPart = html.slice(firstIndex,lastIndex);
        if(htmlPart.indexOf('</nk-repeat')<0){
            return htmlPart;
        }
        var loopWholeCondition = htmlPart.slice(htmlPart.indexOf('for="')+5,htmlPart.indexOf('"',htmlPart.indexOf('for="')+5));
        loopWholeCondition = loopWholeCondition.split(' in ');
        htmlPart = htmlPart.slice(htmlPart.indexOf('>')+1,htmlPart.lastIndexOf('</'));
        var htmlSplited = htmlPart.split(loopWholeCondition[0]);

        var loopResult = '';
        for(var i=0;i<model[loopWholeCondition[1]].length;i++){
            var joindexHtml = htmlSplited.join(loopWholeCondition[0]+i);
            model[loopWholeCondition[0]+i] = model[loopWholeCondition[1]][i];
            loopResult+=joindexHtml+'DELETE HERE';
        }

        return 'DELETE HERE'+loopResult;
    }


    function handleVars(firstIndex, lastIndex) {
        var keyValue = html.slice(firstIndex+10,lastIndex-11);
        return model[keyValue];
    }

    function replace(firstIndex,lastIndex,value) {
        htmlFrom =  html.slice(0,firstIndex);
        htmlTo =  html.slice(lastIndex);
        html = htmlFrom+value+htmlTo;
    }
}


var input2 =[
'0',
'15',
'<div>',
'<p>',
'{{<nk-if condition="pesho">}}',
'{{escaped}} dude',
'</p>',
'<p>',
'{{<nk-template render="pesho">}}',
'</p>',
'<p>',
'{{<nk-repeat for="pesho in peshos">}}',
'{{escaped}} in comment',
'</p>',
'</div>'
];
var input1 = [
    '6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '    <nk-template name="menu">',
    '    <ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '    <footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '<nk-template render="menu" />',
    '',
    '    <h1><nk-model>title</nk-model></h1>',
    '<nk-if condition="showSubtitle">',
    '    <h2><nk-model>subTitle</nk-model></h2>',
    '<div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',
    '',
    '<ul>',
    '    <nk-repeat for="student in students">',
    '        <li>',
    '        <nk-model>student</nk-model>',
    '        </li>',
    '        <li>Multiline <nk-model>title</nk-model></li>',
    '    </nk-repeat>',
    '    </ul>',
    '    <nk-if condition="showMarks">',
    '        <div>',
    '        <nk-model>marks</nk-model>',
    '        </div>',
    '        </nk-if>',
    '',
    '<nk-template render="footer" />',
    '        </body>',
    '        </html>'
];

solve(input2);