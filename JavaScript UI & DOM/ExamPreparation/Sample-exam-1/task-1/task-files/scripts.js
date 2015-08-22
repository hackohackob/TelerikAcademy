function createCalendar(selector,events){
    var calendar = document.querySelector(selector);
    var calendarFragment = document.createDocumentFragment();
    var daysInWeek = ['Sun','Mon','Tue','Wed','Thu','Fri','Sat'];
    var currentDayInWeek = 0;
    var day = document.createElement('div');
    day.style.display = 'inline-block';
    day.style.width='150px';
    day.style.height='70px';
    day.style.border ='1px solid black';
    day.style.float='left';
    var dayTitle = document.createElement('h3');
    dayTitle.style.height='20px';
    dayTitle.style.margin=0;
    dayTitle.style.height='20px';
    dayTitle.style['border-bottom']='1px solid black';
    dayTitle.style['background-color']='#ccc';
    dayTitle.style['text-align']='center';
    dayTitle.style['font-size']='14px';
    dayTitle.style['line-height']='20px';
    var dayBody =  document.createElement('div');
    day.appendChild(dayTitle);
    day.appendChild(dayBody);

    for(var i=0;i<30;i++){
        dayTitle.innerHTML = daysInWeek[currentDayInWeek]+' '+(i+1)+' June 2014';
        var newDay = day.cloneNode(true);
        newDay.setAttribute('data-day',i+1);
        currentDayInWeek++;
        if(currentDayInWeek>6){
            currentDayInWeek=0;
        } else  if(currentDayInWeek===1){
            newDay.style.clear='left';
        }


        calendarFragment.appendChild(newDay);
    }

    addEvents(calendarFragment,events);

    calendar.appendChild(calendarFragment);
    addEventListeners(calendar);

    function addEvents(calendar,events){
        for(var i=0;i<events.length;i++){
            var event = events[i];
            var title=event.title,
                date = event.date,
                hour = event.hour,
                duration = event.duration;

            var dayOfEvent = calendar.querySelector('div[data-day="'+date+'"]');
            dayOfEvent.getElementsByTagName('div')[0].innerHTML = hour+' '+title;
            console.log('hour',hour);
            console.log('title',title);
        }
    }

    function addEventListeners(calendar){
        calendar.addEventListener('click',function(ev){
           if(ev.target.getAttribute('data-day')){
               var selectedDays = calendar.getElementsByClassName('selected');
               for(var i=0;i<selectedDays.length;i++){
                   selectedDays[i].style['background-color']='';
                   selectedDays[i].classList.remove('selected');
               }

               ev.target.classList.add('selected');
               ev.target.style['background-color']='#aaa';
           }
        });

        calendar.addEventListener('mouseover',function(ev){
            if(ev.target.getAttribute('data-day')) {
                ev.target.querySelector('h3').style['background-color'] = '#888';
            } else{
                ev.target.parentElement.querySelector('h3').style['background-color'] = '#888';
            }
        });

        calendar.addEventListener('mouseout',function(ev){
            if(ev.target.getAttribute('data-day')) {
                ev.target.querySelector('h3').style['background-color'] = '#ccc';
            } else{
                    ev.target.parentElement.querySelector('h3').style['background-color'] = '#ccc';
            }
        });
    }
}