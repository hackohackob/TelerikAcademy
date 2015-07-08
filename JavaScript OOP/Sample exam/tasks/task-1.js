function solve() {
    var helpers = {
        findIdInCollection: function (id, collection) {
            var i, len;
            for (i = 0, len = collection.length; i < len; i += 1) {
                if (collection[i].id === id) {
                    return i;
                }
            }

            return -1;
        },
        getSortingFunction: function (param1, param2) {
            return function (x, y) {
                if (x[param1] < y[param1]) {
                    return -1;
                } else if (x[param1] > y[param1]) {
                    return 1;
                } else {
                    if (x[param2] < y[param2]) {
                        return -1;
                    } else if (x[param2] > y[param2]) {
                        return 1;
                    } else {
                        return null;
                    }
                }
            }
        }
    };
    var validator = {
        validateUndefined: function (value) {
            if (value === undefined) {
                throw new Error('Value is undefined!');
            }
        },
        validateString: function (value) {
            this.validateUndefined(value);
            if (typeof value !== 'string' || value.length < 3 || value.length > 25) {
                throw new Error('Value is not a string!');
            }
        },
        validateNumber: function (value) {
            this.validateUndefined(value);
            if (typeof value !== 'number') {
                throw new Error('Value is not a number!');
            }
        },
        validateId: function (value) {
            this.validateUndefined(value);
            this.validateNumber(value);
            if (value <= 0) {
                throw new Error('Invalid ID!');
            }
        },
        validatePageAndSize: function (page, size, max) {
            this.validateUndefined(page);
            this.validateUndefined(size);
            this.validateNumber(page);
            this.validateNumber(size);
            if (page < 0 || size <= 0 || page * size > max) {
                throw new Error('Paging parameters are invalid!');
            }
        },
        validateName: function (value) {
            this.validateUndefined(value);
            this.validateString(value);
        },
        validateTitle: function (value) {
            this.validateUndefined(value);
            this.validateString(value);
        },
        validateAuthor: function (value) {
            this.validateUndefined(value);
            this.validateString(value);
        },
        validateLength: function (value) {
            this.validateUndefined(value);
            this.validateNumber(value);
            if (value <= 0) {
                throw Error('Length is less than 0!');
            }
        },
        validateRating: function (value) {
            this.validateUndefined(value);
            this.validateNumber(value);
            if (value < 1 || value > 5) {
                throw Error('Rating must be between 1 and 5');
            }
        },
    };

    var player = (function () {

        var playerId = 0,
            player = Object.create({});

        Object.defineProperties(player, {
            init: {
                value: function (name) {
                    this._id = ++playerId;
                    this.name = name;
                    this._playlists = [];

                    return this;
                }
            },
            id: {
                get: function () {
                    return this._id;
                }
            },
            name: {
                get: function () {
                    return this._name
                },
                set: function (value) {
                    validator.validateName(value);
                    this._name = value;
                }
            },
            addPlaylist: {
                value: function (playlist) {
                    this._playlists.push(playlist);

                    return this;
                }
            },
            getPlaylist: {
                value: function (id) {
                    return this.getPlaylistById(id);
                }
            },
            getPlaylistById: {
                value: function (id) {
                    var index = helpers.findIdInCollection(id, this._playlists);
                    if (index < 0) {
                        return null;
                    } else {
                        return this._playlists[index];
                    }
                }
            },
            removePlaylist: {
                value: function (idOrPlaylist) {
                    var id = idOrPlaylist.id || idOrPlaylist;
                    validator.validateId(id);

                    var index = helpers.findIdInCollection(id, this._playlists);
                    if (index < 0) {
                        throw new Error('Playlist with the selected id is not found!');
                    } else {
                        this._playlists.splice(index, 1);
                    }
                }
            },
            listPlaylists: {
                value: function (page, size) {
                    validator.validatePageAndSize(page, size, this._playlists.length);

                    return this._playlists
                        .slice()
                        .splice(page * size, size);
                }
            },
            contains: {
                value: function (playable, playlist) {
                    var result = playlist.getPlayableById(playable.id);
                    return result !== null;
                }
            },
            search: {
                value: function (pattern) {
                    return this._playlists
                        .slice()
                        .filter(function (playlist) {
                            return playlist.listPlayables(0, 99999999999).some(function (playable) {
                                return playable.title.indexOf(pattern) >= 0;
                            });
                        })
                        .map(function (playlist) {
                            return {
                                id: playlist.id,
                                title: playlist.name
                            }
                        })
                }
            }
        });

        return player;
    }());

    var playlist = (function () {
        var playlistId = 0,
            playlist = Object.create({});

        Object.defineProperties(playlist, {
            init: {
                value: function (name) {
                    this._id = ++playlistId;
                    this.name = name;
                    this._playables = [];
                    return this;
                }
            },
            id: {
                get: function () {
                    return this._id;
                }
            },
            name: {
                get: function () {
                    return this._name;
                },
                set: function (value) {
                    validator.validateName(value);
                    this._name = value;
                }
            },
            addPlayable: {
                value: function (playable) {
                    this._playables.push(playable);

                    return this;
                }
            },
            getPlayableById: {
                value: function (id) {
                    var index = helpers.findIdInCollection(id, this._playables);
                    if (index < 0) {
                        return null;
                    } else {
                        return this._playables[index];
                    }
                }
            },
            removePlayable: {
                value: function (idOrPlayable) {
                    var id = idOrPlayable.id || idOrPlayable;

                    validator.validateId(id)

                    var index = helpers.findIdInCollection(id, this._playables);
                    if (index < 0) {
                        throw new Error('There is no such playable to delete!');
                    } else {
                        this._playables.splice(index, 1);
                    }
                }
            },
            listPlayables: {
                value: function (page, size) {
                    validator.validatePageAndSize(page, size, this._playables.length);
                    return this._playables
                        .slice()
                        .sort(helpers.getSortingFunction('title', 'id'))
                        .splice(page * size, size);
                }
            }
        })

        return playlist;
    }());

    var playable = (function () {
        var playableId = 0,
            playable = Object.create({});

        Object.defineProperties(playable, {
            init: {
                value: function (title, author) {
                    this._id = ++playableId;
                    this.title = title;
                    this.author = author;

                    return this;
                }
            },
            id: {
                get: function () {
                    return this._id;
                }
            },
            title: {
                get: function () {
                    return this._title;
                },
                set: function (title) {
                    validator.validateTitle(title);
                    this._title = title;
                }
            },
            author: {
                get: function () {
                    return this._author;
                },
                set: function (author) {
                    validator.validateAuthor(author);
                    this._author = author;
                }
            },
            play: {
                value: function () {
                    return this.id + '. ' + this.title + ' - ' + this.author;
                }
            }
        });

        return playable;
    }());

    var audio = (function (parent) {
        var audio = Object.create(playable);

        Object.defineProperties(audio, {
            init: {
                value: function (title, author, length) {
                    parent.init.call(this, title, author);
                    validator.validateLength(length);
                    this.length = length;

                    return this;
                }
            },
            length: {
                get: function () {
                    return this._length;
                },
                set: function (value) {
                    validator.validateLength(value);
                    this._length = value;
                }
            },
            play: {
                value: function () {
                    return parent.play.call(this) + ' - ' + this.length;
                }
            }
        });

        return audio;
    }(playable));

    var video = (function (parent) {
        var video = Object.create(playable);

        Object.defineProperties(video, {
            init: {
                value: function (title, author, imdbRating) {
                    parent.init.call(this, title, author);
                    validator.validateRating(imdbRating);
                    this.imdbRating = imdbRating;
                    return this;
                }
            },
            imdbRating: {
                get: function () {
                    return this._imdbRating;
                },
                set: function (value) {
                    validator.validateRating(value);
                    this._imdbRating = value;
                }
            },
            play: {
                value: function () {
                    return parent.play.call(this) + ' - ' + this.imdbRating;
                }
            }
        });

        return video;
    }(playable));

    var module = (function () {
        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        };
    }());


    return module;

}

result = solve();

var audio = result.getAudio('AudioT', 'AudioA', 2);

var video = result.getVideo('VideoT', 'VideoA', 4.5);
var playlist1 = result.getPlaylist('playlist1');
var player1 = result.getPlayer('Player1');

playlist1.addPlayable(audio);
playlist1.addPlayable(video);
player1.addPlaylist(playlist1);

console.log(player1.search('Aud'));

module.exports = solve;

//player1.addPlaylist(playlist1);
//console.log(player1.addPlaylist(playlist1))
//console.log(player1.addPlaylist(playlist1).getPlaylistById(playlist1.id));
//playlist1.addPlayable(audio);
//playlist1.addPlayable(video);
//console.log(audio);
//console.log(playlist1.addPlayable(audio).getPlayableById(1));
//console.log(playlist2);
//console.log(audio);
//console.log(video);

//var name, player, playlist, returnedPlaylist;
//name = 'Rock and Roll';
//player = result.getPlayer(name);
//playlist = result.getPlaylist(name);
//returnedPlaylist = player.addPlaylist(playlist).getPlaylistById(playlist.id);
//console.log(returnedPlaylist===playlist);

//var name, player, playlist, returnedPlayer;
//name = 'Rock and roll';
//player = result.getPlayer(name);
//playlist = result.getPlaylist(name);
//returnedPlayer = player.addPlaylist(playlist);
//console.log(typeof  player.addPlaylist);
//console.log(player.addPlaylist.length);
//console.log(returnedPlayer===player);
//
//var count, i, ids, invalidID, j, name, player, playlist, ref;
//name = 'Rock and Roll';
//player = result.getPlayer(name);
//console.log(player.getPlaylist(2)===null);
//count = 5;
//ids = {};
//for (i = j = 0, ref = count; 0 <= ref ? j <= ref : j >= ref; i = 0 <= ref ? ++j : --j) {
//    playlist = result.getPlaylist(name + i);
//    player.addPlaylist(playlist);
//    ids[playlist.id] = true;
//}
//invalidID = (Math.random() * 100000000) | 0;
//while (ids[invalidID]) {
//    invalidID = (Math.random() * 100000000) | 0;
//}
//console.log(player.getPlaylist(invalidID) === null);
