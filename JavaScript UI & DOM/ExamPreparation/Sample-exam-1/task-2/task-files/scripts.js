$.fn.tabs = function () {
    var $this = this;
    $this.addClass('tabs-container');
    $this.css('font-size',0);
    $this.find('*').css('font-size','initial');

    $this.find('.tab-item').eq(0).addClass('current');

    var tabs =  $this.find('.tab-item');

    var titles = $this.find('.tab-item-title');

    var contents = $this.find('.tab-item:not(\'.current\')').find('.tab-item-content');
    contents.hide();

    titles.on('click',function(ev){
       $('.tab-item.current').removeClass('current');
        $('.tab-item-content:visible').hide();
        $(this).parent().addClass('current');
        $(this).parent().find('.tab-item-content').show();
    });

};