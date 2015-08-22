/* globals $ */

/* 

 Create a function that takes an id or DOM element and an array of contents

 * if an id is provided, select the element
 * Add divs to the element
 * Each div's content must be one of the items from the contents array
 * The function must remove all previous content from the DOM element provided
 * Throws if:
 * The provided first parameter is neither string or existing DOM element
 * The provided id does not select anything (there is no element that has such an id)
 * Any of the function params is missing
 * Any of the function params is not as described
 * Any of the contents is neither `string` or `number`
 * In that case, the content of the element **must not be** changed
 */

module.exports = function () {

    return function (element, contents) {
        var ok=true;
        if(!element || !contents){
            ok=false;
            throw new Error('Any of the function params is missing');
        }

        if(!Array.isArray(contents)){
            ok=false;
            throw new Error('Any of the function params is not as described');
        }

        var inputElement;

        if (element.nodeType) {
            inputElement = element;
        } else if (document.getElementById(element).nodeType) {
            inputElement = document.getElementById(element);

            if(!inputElement.nodeType){
                ok=false;
                throw new Error('Selector doesn\'t catch anything');
            }
        } else {
            ok=false;
            throw  new Error('The provided first parameter is neither string or existing DOM element');
        }

        if(ok) {
            var domBuilder = document.createDocumentFragment();
            var div = document.createElement('div');
            for (var i = 0; i < contents.length; i++) {
                if(typeof  contents[i]!=='string' && typeof contents[i]!=='number'){
                    throw  new Error('Something is not a string or a number');
                    ok=false;
                }
                div.innerHTML = contents[i];
                domBuilder.appendChild(div.cloneNode(true));
            }

            if(ok) {
                inputElement.innerHTML = '';
                inputElement.appendChild(domBuilder);
            }
        }
    };
};