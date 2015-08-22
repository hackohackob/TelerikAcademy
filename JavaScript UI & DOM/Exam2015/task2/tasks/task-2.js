function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };
        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
        var date = new Date();

        var $this = this;
        var input = $this.clone().addClass('datepicker');
        var wrapper = $('<div />')
            .addClass('datepicker-wrapper')
            .html(input);

        initializeCalendar();

        wrapper.find('input').on('click',function(){
           wrapper.find('.picker').addClass('picker-visible');
        });

        this.replaceWith(wrapper);


        fillCalendarWithMonth(new Date().getMonth()+1);
        function fillCalendarWithMonth(monthIndex){

            wrapper.find('.current-month').html(MONTH_NAMES[monthIndex]+' '+2015);
            var first = new Date(2015,monthIndex,1);
            var last = new Date(2015,monthIndex+1,0);

            var row=0;
            var col=0;

            var currentDay = first;

            col=currentDay.getDay();


            while(true){
                if(currentDay.getDate()<last.getDate() && currentDay.getMonth()===last.getMonth()){
                    var currentDate = currentDay.getDate();
                    //var currentRow =  currentDate/7|0;
                    var col = currentDay.getDay();
                    if(col===0){
                        row++;
                    }
                    $('tr[data-week="'+row+'"] td[data-day="'+col+'"]').addClass('current-month').html(currentDate);
                    currentDay.setDate(currentDay.getDate()+1);
                } else {
                    break;
                }
            }
        }

        function initializeCalendar(){
            var picker = $('<div />').addClass('picker');
            var controls = $('<div />').addClass('controls');
            var prev = $('<span />').addClass('btn').html('<').css('display','inline-block');
            prev.css('line-height','30px');
            prev.css('text-align','center');
            var currentMonth = $('<span />').addClass('current-month').html(new Date().getMonthName()+' '+new Date().getFullYear());
            var next = $('<span />').addClass('btn').html('>').css('display','inline-block');
            next.css('line-height','30px');
            next.css('text-align','center');
            controls.append(prev).append(currentMonth).append(next);

            var calendar = $('<div />').addClass('calendar');
            var monthTable = generateMonthTable();
            calendar.append(monthTable);

            var currentDate =  $('<div />').addClass('current-date');
            currentDate.html(new Date().getDate()+' '+new Date().getMonthName()+' '+new Date().getFullYear());
            picker.append(controls).append(calendar).append(currentDate);

            wrapper.append(picker);
        }

        function generateMonthTable(){
            var table = $('<table />');
            var headers= '<tr>';
            for(var i=0;i<WEEK_DAY_NAMES.length;i++){
                headers+='<th>'+WEEK_DAY_NAMES[i]+'</th>';
            }
            headers+='</tr>';
            table.append(headers);

            var week = $('<tr />').addClass('week').attr('data-week',-1);
            var day = $('<td />').addClass('day').attr('data-day',-1);
            for(var i=0;i<7;i++){
                week.append(day.clone(true).attr('data-day',i));
            }

            for(var i=0;i<6;i++){
                table.append(week.clone().attr('data-week',i));
            }


            return table;
        }

        //$('.picker').addClass('picker-visible')
        return this;
    };
}

module.exports = solve;