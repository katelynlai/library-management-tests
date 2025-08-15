using NUnit.Framework;
using LibraryManagement;

namespace LibraryManagement.Tests
{
    public class LibraryTests
    {
        private Book book1;
        private Book book2;
        private Book book3;

        private Patron patron1;
        private Patron patron2;

        private Library library;

        [SetUp]
        public void Setup()
        {
            book1 = new Book("Pride and Prejudice", "Jane Austen");
            book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            book3 = new Book("To Kill a Mockingbird", "Harper Lee");

            patron1 = new Patron("Katelyn");
            patron2 = new Patron("Bob");

            library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            library.AddPatron(patron1);
            library.AddPatron(patron2);
        }

        [Test]
        public void BorrowBook_AndReturnBook_WorksCorrectly()
        {
            var borrowResult = library.BorrowBook(patron1, book1);
            Assert.That(borrowResult, Is.True);
            Assert.That(book1.IsAvailable, Is.False);
            Assert.That(patron1.BorrowedBooks, Has.Member(book1));

            var returnResult = library.ReturnBook(patron1, book1);
            Assert.That(returnResult, Is.True);
            Assert.That(book1.IsAvailable, Is.True);
            Assert.That(patron1.BorrowedBooks, Does.Not.Contain(book1));
        }

        [Test]
        public void BorrowBook_AlreadyBorrowed_ReturnsFalse()
        {
            library.BorrowBook(patron1, book1);

            var result = library.BorrowBook(patron2, book1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void AddAndRemoveBook_WorksCorrectly()
        {
            var book4 = new Book("New Book", "New Author");
            library.AddBook(book4);
            Assert.That(library.Books, Has.Member(book4));

            library.RemoveBook(book4);
            Assert.That(library.Books, Does.Not.Contain(book4));
        }

        [Test]
        public void AddAndRemovePatron_WorksCorrectly()
        {
            var patron3 = new Patron("Charlie");
            library.AddPatron(patron3);
            Assert.That(library.Patrons, Has.Member(patron3));

            library.RemovePatron(patron3);
            Assert.That(library.Patrons, Does.Not.Contain(patron3));
        }

        [Test]
        public void SearchBook_ByTitleAndAuthor_ReturnsCorrectBook()
        {
            Assert.That(library.GetBookByTitle("Pride and Prejudice"), Is.EqualTo(book1));
            Assert.That(library.GetBookByAuthor("Jane Austen"), Is.EqualTo(book1));
        }

        [Test]
        public void SearchBook_NotFound_ReturnsNull()
        {
            Assert.That(library.GetBookByTitle("Nonexistent Title"), Is.Null);
            Assert.That(library.GetBookByAuthor("Unknown Author"), Is.Null);
        }
    }
}
