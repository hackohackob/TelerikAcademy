/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];
        var bookTitleRegex = /^[\w\W\d ]{2,100}$/;
        var bookIsbnRegex = /^([\d]{10}|[\d]{13})$/;

		function listBooks(filter) {
            filter = filter || {};
            var category = filter.category;
            var toReturnBooks=books;

            for(var filterName in filter){
                toReturnBooks = toReturnBooks.filter(function(book){
                    if(book[filterName]===filter[filterName]){
                        return true;
                    } else {
                        return false;
                    }
                }).sort(function(x,y){
                    return x[filterName]<y[filterName];
                });
            }

            return toReturnBooks;
		}

		function addBook(book) {
			if(!bookTitleRegex.test(book.title) || !bookIsbnRegex.test(book.isbn) || book.author.length<1){
                throw new Error('Invalid data');
            }

            books.forEach(function(currentBook){
               if(currentBook.title === book.title || currentBook.isbn === book.isbn){
                   throw new Error('Book with this title/isbn exists');
               }
            });

            categories[book.category]=1;

			book.ID = books.length + 1;
			books.push(book);
			return book;
		}

		function listCategories() {
            var toReturn=[];
			 for(var cat in categories){
                 toReturn.push(cat);
             }

            return toReturn;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;



