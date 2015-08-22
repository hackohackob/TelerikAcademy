function solve() {
    return function (selector) {
        var select = $(selector),
            options = select.find('option');

        select.hide();

        var dropdown = $('<div />')
            .addClass('dropdown-list');

        var current = $('<div />')
            .addClass('current')
            .attr('data-value','')
            .html(options.eq(0).html());

        var optionsContainer = $('<div />')
            .addClass('options-container')
            .css('position','absolute')
            .css('display','none');

        for(var i=0;i<options.length;i++){
            var newOption = $('<div />')
                .addClass('dropdown-item')
                .attr('data-value',options.eq(i).attr('value'))
                .attr('data-index',i)
                .html(options.eq(i).html());
            optionsContainer.append(newOption);
        }

        addEvents();

        dropdown.append(select.clone());
        dropdown.append(current);
        dropdown.append(optionsContainer);

        select.replaceWith(dropdown);

        function addEvents(){
            dropdown.on('click','.current',function(){
                optionsContainer.css('display','');
            });

            dropdown.on('click','.dropdown-item',function(ev){
                var dropdownItem = $(ev.target);
                current.attr('data-value',dropdownItem.attr('data-value'));
                current.html(dropdownItem.html());
                optionsContainer.css('display','none');
                $(selector).val(dropdownItem.attr('data-value'));
            });
        }
    };
}

module.exports = solve;