/* globals $ */

/* 

Create a function that takes an id or DOM element and:
  

*/

function solve(){
  return function (selector) {
      var inputElement,
          ok=true;


      if (selector.nodeType) {
          inputElement = selector;
      } else if (document.getElementById(selector).nodeType) {
          inputElement = document.getElementById(selector);

          if(!inputElement.nodeType){
              ok=false;
              throw new Error('Selector doesn\'t catch anything');
          }
      } else {
          ok=false;
          throw  new Error('The provided first parameter is neither string or existing DOM selector');
      }

      var buttons = inputElement.getElementsByClassName('button');
      var contents = inputElement.getElementsByClassName('content');

      for(var i=0;i<buttons.length;i+=1){
          var button = buttons[i];
          button.innerHTML = 'hide';


          button.addEventListener('click',function(ev){
              var button = ev.target;
              var nextContent;
              var nextCandidateContent=button;
              while(true){

                  nextCandidateContent = nextCandidateContent.nextElementSibling;

                  if(nextCandidateContent.className.indexOf('content')>=0){
                      nextContent=nextCandidateContent;
                      break;
                  } else if(nextCandidateContent && nextCandidateContent.className.indexOf('button')>=0){
                      nextContent=false;

                      break
                  } else if(nextCandidateContent === null){
                      break;
                  }
              }

              if(nextContent){
                  if(button.innerHTML==='hide') {
                          button.innerHTML = 'show';
                          nextContent.style.display = 'none';
                  } else {
                          button.innerHTML = 'hide';
                          nextContent.style.display = '';
                  }
              }
          });

      }
  };
}

module.exports = solve;