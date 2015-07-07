(function(){
    var Playlist= (function(parent){
        var Playlist = Object.create(parent);
        Object.defineProperties(Playlist,{
            'init':{
                value:function(){

                    return this;
                }
            },
            'list':{
                configurable:false,
                get: function(){
                    return this._list.slice(0);
                }
            }
        });


        return Playlist;
    }(Object));

    var play1= Playlist.init();
    console.log(play1);
    console.log('-----');
    console.log(play1.prototype);
    //var play1= Playlist.init();
    //console.log(play1.list);

}());

