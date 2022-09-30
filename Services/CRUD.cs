using BookManagementSystem.Models;

namespace BookManagementSystem.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on our Book Inventory 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public class CRUD : ICRUD
    {
        private List<Book> books; //declare a list of books to represent a book database

        public CRUD()
        {
            books = new List<Book>();

            //DUMMY DATA
            books.Add(new Book()
            {
                ISBN = 9780439358071,
                Title = "Harry Potter And The Order Of The Phoenix",
                Author = "Rowling, J.K.",
                Description = "Harry is furious that he has been abandoned at the Dursleys' house for the summer, for he suspects that Voldemort is gathering an army, that he himself could be attacked, and that his so-called friends are keeping him in the dark. Finally rescued by wizard bodyguards, he discovers that Dumbledore is regrouping the Order of the Phoenix - a secret society first formed years ago to fight Voldemort. But the Ministry of Magic is against the Order, lies are being spread by the wizards' tabloid, the Daily Prophet, and Harry fears that he may have to take on this epic battle against evil alone.",
                Genre = BookGenres.Fantasy,
                CoverImage = "9780439358071.jpg"
            });

            //DUMMY DATA
            books.Add(new Book()
            {
                ISBN = 9780340681060,
                Title = "Five on a Treasure Island (Famous Five)",
                Author = "Blyton, Enid",
                Description = "Meet Julian, Dick, Anne, George and Timothy. Together they are THE FAMOUS FIVE. 'There was something else out on the sea by the rocks - something dark that seemed to lurch out of the waves ... What could it be?' Julian, Dick and Anne are spending the holidays with their tomboy cousin George and her dog, Timothy. One day, George takes them to explore nearby Kirrin Island, with its rocky little coast and old ruined castle on the top. Over on the island, they make a thrilling discovery, which leads them deep into the dungeons of Kirrin Castle on a dangerous adventure. Who - and what - will they find there?",
                Genre = BookGenres.Mystery,
                CoverImage = "9780340681060.jpg"
            });

            //DUMMY DATA
            books.Add(new Book()
            {
                ISBN = 9780312577223,
                Title = "The Nightingale",
                Author = "Kristin Hannah ",
                Description = "A #1 New York Times bestseller, Wall Street Journal Best Book of the Year, and soon to be a major motion picture, this unforgettable novel of love and strength in the face of war has enthralled a generation.\r\n\nFrance, 1939 - In the quiet village of Carriveau, Vianne Mauriac says goodbye to her husband, Antoine, as he heads for the Front. She doesn't believe that the Nazis will invade France ... but invade they do, in droves of marching soldiers, in caravans of trucks and tanks, in planes that fill the skies and drop bombs upon the innocent. When a German captain requisitions Vianne's home, she and her daughter must live with the enemy or lose everything. Without food or money or hope, as danger escalates all around them, she is forced to make one impossible choice after another .",
                Genre = BookGenres.Historical,
                CoverImage = "9780312577223.jpg"
            });
        }
        public void AddRecord(Book book)
        {
            books.Add(book);
        }

        public void DeleteRecord(long? ISBN)
        {
            Book? b = books.Find(x=>x.ISBN == ISBN); 
            if(b != null)
                books.Remove(b);
        }

        public Book? GetRecord(long? ISBN)
        {
            Book? b = books.Find(x => x.ISBN == ISBN);
            if(b == null)
                return null;
            else
                return b;
        }

        public List<Book> GetRecords()
        {
            return books;
        }

        public void UpdateISBN(long oldISBN, long newISBN)
        {
            //Since ISBN is a primary key, we will not directly update it
            //Instead we will create a new record with the new ISBN and then delete the old one

            Book? oldBook = books.Find(x => x.ISBN == oldISBN);
            if (oldBook != null)
            {
                //copy contents of oldBook into a new Book variable, but use new isbn
                Book newBook = new Book();
                newBook.ISBN = newISBN; //update to the newISBN
                newBook.Title = oldBook.Title;
                newBook.Author= oldBook.Author;
                newBook.Description = oldBook.Description;
                newBook.Genre = oldBook.Genre;
                newBook.CoverImage = oldBook.CoverImage;

                //delete old book
                books.Remove(oldBook);

                //add new updated book to records
                books.Add(newBook);
            }
        }

        public void UpdateRecord(Book book)
        {
            Book? bookToUpdate = books.Find(x => x.ISBN == book.ISBN);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Genre = book.Genre;
                bookToUpdate.CoverImage = book.CoverImage;
            }
        }
    }
}
