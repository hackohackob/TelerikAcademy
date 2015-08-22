function solve() {
    return function (selector, isCaseSensitive) {
        isCaseSensitive = isCaseSensitive || false;

        var container = document.querySelector(selector);

        var fragment = document.createDocumentFragment();

        var input = document.createElement('div');
        input.className+='add-controls';
        var inputSearch = document.createElement('input');
        var inputAdd = document.createElement('div');
        inputAdd.className+='button';
        inputAdd.innerHTML='Add';

        var label = document.createElement('label');
        label.innerHTML = 'Enter text';
        input.appendChild(label);
        input.appendChild(inputSearch);
        input.appendChild(inputAdd);

        addInputFunctionality(inputSearch,inputAdd);


        var search = document.createElement('div');
        search.className+='search-controls';
        var searchInput = document.createElement('input');

        //TODO: check if semicolon needed
        var labelSearch = document.createElement('label');
        labelSearch.innerHTML = 'Search';
        search.appendChild(labelSearch);
        search.appendChild(searchInput);

        addSearchFunctionality(searchInput);

        var results = document.createElement('div');
        results.className+='result-controls';
        var itemsList = document.createElement('div');
        itemsList.className+='items-list';

        addDeletionFunctionality(itemsList);

        results.appendChild(itemsList);

        fragment.appendChild(input);
        fragment.appendChild(search);
        fragment.appendChild(results);

        var wrapper = document.createElement('div');
        wrapper.className+='items-control';
        wrapper.appendChild(fragment);
        container.appendChild(wrapper);

        function addSearchFunctionality(input){
            input.addEventListener('change',searchFunction,false);

            function searchFunction() {
                var searchValue = input.value;
                var items = itemsList.children;

                for (var i = 0; i < items.length; i++) {
                    var currentItem = items[i];
                    var itemText = currentItem.innerHTML.slice(0,currentItem.innerHTML.indexOf('<'));
                    console.log(itemText);
                    if ((isCaseSensitive && itemText.indexOf(searchValue) >= 0) ||
                        (!isCaseSensitive && itemText.toLowerCase().indexOf(searchValue.toLowerCase()) >= 0)) {
                        currentItem.style.display = '';
                    } else {
                        currentItem.style.display = 'none';
                    }
                }
            }
        }

        function addInputFunctionality(input,button){
            button.addEventListener('click',function(){
                var valueToAdd = input.value;
                input.value='';

                addItem(valueToAdd);
            },false);
        }

        function addItem(value){
            var item = document.createElement('div');
            item.className+='list-item';
            var x = document.createElement('div');
            x.className+='button';
            x.innerHTML='X';
            item.innerHTML=value;
            item.appendChild(x);
            itemsList.appendChild(item);

        }

        //for(var  i=0;i<5;i++){
        //    addItem(i);
        //}

        function addDeletionFunctionality(itemsList){
            itemsList.addEventListener('click',function(ev){
                var target = ev.target;
                if(target.className.indexOf('button')>=0){
                    var item = target.parentNode;
                    item.parentNode.removeChild(item);
                }
            },false);
        }
    };
}

module.exports = solve;