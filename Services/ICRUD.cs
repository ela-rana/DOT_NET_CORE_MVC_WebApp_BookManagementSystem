using BookManagementSystem.Models;

namespace BookManagementSystem.Services
{
    /// <summary>
    /// Defines all types of actions that can be performed on our Book Inventory 
    /// including CRUD- create, read, update, delete
    /// </summary>
    public interface ICRUD
    {
        /// <summary>
        /// Adds the passed record object to the database
        /// </summary>
        /// <param name="book">record to be added</param>
        void AddRecord(Book book);

        /// <summary>
        /// Retrieves the record for the passed ISBN
        /// </summary>
        /// <param name="ISBN">ISBN of the record to be retrieved</param>
        /// <returns>the record that matches passed ISBN or null if the ISBN is not found in database</returns>
        Book? GetRecord(long? ISBN);

        /// <summary>
        /// to get all Book records from the database
        /// </summary>
        /// <returns>a list of all books in the database</returns>
        List<Book> GetRecords();

        /// <summary>
        /// updates the record that has the passed ISBN
        /// </summary>
        /// <param name="book">the record with its fields updated</param>
        void UpdateRecord(Book book);

        /// <summary>
        ///updates the ISBN for a book record
        /// </summary>
        /// <param name="oldISBN">The old ISBN that is currently stored for the record</param>
        /// <param name="newISBN">New ISBN value to update</param>
        void UpdateISBN(long oldISBN, long newISBN);

        /// <summary>
        /// deletes the record that has the passed ISBN
        /// </summary>
        /// <param name="ISBN">the ISBN of the record to be deleted</param>
        void DeleteRecord(long? ISBN);
    }
}
