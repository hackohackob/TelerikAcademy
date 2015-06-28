/* Task Description */
/*
 * Create an object domElement, that has the following properties and methods:
 * use prototypal inheritance, without function constructors
 * method init() that gets the domElement type
 * i.e. `Object.create(domElement).init('div')`
 * property type that is the type of the domElement
 * a valid type is any non-empty string that contains only Latin letters and digits
 * property innerHTML of type string
 * gets the domElement, parsed as valid HTML
 * <type attr1="value1" attr2="value2" ...> .. content / children's.innerHTML .. </type>
 * property content of type string
 * sets the content of the element
 * works only if there are no children
 * property attributes
 * each attribute has name and value
 * a valid attribute has a non-empty string for a name that contains only Latin letters and digits or dashes (-)
 * property children
 * each child is a domElement or a string
 * property parent
 * parent is a domElement
 * method appendChild(domElement / string)
 * appends to the end of children list
 * method addAttribute(name, value)
 * throw Error if type is not valid
 * method removeAttribute(attribute)
 * throw Error if attribute does not exist in the domElement
 */


/* Example

 var meta = Object.create(domElement)
 .init('meta')
 .addAttribute('charset', 'utf-8');

 var head = Object.create(domElement)
 .init('head')
 .appendChild(meta)

 var div = Object.create(domElement)
 .init('div')
 .addAttribute('style', 'font-size: 42px');

 div.content = 'Hello, world!';

 var body = Object.create(domElement)
 .init('body')
 .appendChild(div)
 .addAttribute('id', 'cuki')
 .addAttribute('bgcolor', '#012345');

 var root = Object.create(domElement)
 .init('html')
 .appendChild(head)
 .appendChild(body);

 console.log(root.innerHTML);
 Outputs:
 <html><head><meta charset="utf-8"></meta></head><body bgcolor="#012345" id="cuki"><div style="font-size: 42px">Hello, world!</div></body></html>
 */


function solve() {
    var domElement = (function () {
        var domElement = Object.create(Object.prototype);

        Object.defineProperties(domElement, {
            init: {
                value: function (type) {
                    this.type = type;
                    this.attributesArray = [];
                    this.children = [];
                    return this;
                }
            },
            type: {
                get: function () {
                    return this._type;
                },
                set: function (type) {
                    if (/^[A-z0-9]+$/.test(type) && typeof(type) === 'string') {
                        this._type = type;
                    } else {
                        throw Error('Type must be a string with only latin letters or digits');
                    }
                }
            },
            innerHTML: {
                get: function (self) {
                    self = self || this;
                    return '<' + this.type + this.innerHTMLattributes() + '>'
                        + this.content + '</' + this.type + '>';
                }
            },
            innerHTMLattributes: {
                value: function () {
                    var attrString = ' ';
                    for (var singleAttr in this.attributesArray) {
                        attrString += singleAttr + '="' + this.attributesArray[singleAttr] + '" ';
                    }
                    attrString = attrString.trim();
                    if (attrString.length > 0) {
                        attrString = ' ' + attrString;
                    }
                    return attrString;
                }
            },
            content: {
                get: function () {
                    var result = '';
                    for (var i = 0; i < this.children.length; i++) {
                        if (typeof(this.children[i]) === 'string') {
                            result += this.children[i];
                        } else {
                            var childHTML = this.children[i].innerHTML;
                            result += childHTML;
                        }
                    }
                    return result || this._content || '';
                },
                set: function (value) {
                    this._content = value;
                }
            },
            attributes: {},
            children: {
                value: [],
                writable: true
            },
            parent: {
                value: null,
                writable: true,
                enumerable:true
            },
            appendChild: {
                value: function (child) {
                    this.children.push(child);
                    child.parent = this;
                    return this;
                }
            },
            addAttribute: {
                value: function (attrName, attrValue) {
                    if (/^[A-z0-9-]+$/.test(attrName) && typeof(attrName) === 'string') {
                        this.attributesArray[attrName] = attrValue;
                        return this;
                    } else {
                        throw Error('Invalid attribute data');
                    }
                }
            },
            attributesArray: {
                set: function (value) {
                    this._attributesArray = value;
                },
                get: function () {
                    var newArray = [],
                        sortedKeys = Object.keys(this._attributesArray).sort();

                    for (var i = 0; i < sortedKeys.length; i++) {
                        newArray[sortedKeys[i]] = this._attributesArray[sortedKeys[i]];
                    }
                    this._attributesArray = newArray;
                    return this._attributesArray;
                },
                enumerable:false
            },
            removeAttribute: {
                value: function (attrName) {
                    if (!this.attributesArray[attrName] || !/^[A-z0-9-]+$/.test(attrName) || typeof(attrName) !== 'string') {
                        throw Error('Invalid attribute name');
                    } else {
                        delete this.attributesArray[attrName];
                    }
                    return this;
                }
            }
        });

        return domElement;
    }());


    var child = Object.create(domElement)
            .init('child'),
        middle = Object.create(domElement)
            .init('middle')
            .appendChild(child),
        parent = Object.create(domElement)
            .init('parent')
            .appendChild(middle);
    child.content='Some text here';
    console.log(parent);
    console.log(parent.innerHTML);

    return domElement;
}

solve();

module.exports = solve;
