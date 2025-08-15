using NUnit.Framework;
using LibraryManagement;

namespace LibraryManagement.Tests
{
    public class PatronTests
    {
        private Book book1;
        private Book book2;
        private Book book3;

        private Patron patron1;
        private Patron patron2;

        [SetUp]
        public void Setup()
        {
            book1 = new Book("Pride and Prejudice", "Jane Austen");
            book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            book3 = new Book("To Kill a Mockingbird", "Harper Lee");

            patron1 = new Patron("Katelyn");
            patron2 = new Patron("Bob");
        }

        [Test]
        public void BorrowBook_AddsBook()
        {
            var result = patron1.BorrowBook(book1);

            Assert.That(result, Is.True);
            Assert.That(patron1.BorrowedBooks, Has.Member(book1));
        }

        [Test]
        public void BorrowBook_AlreadyBorrowedBook()
        {
            patron1.BorrowBook(book1);

            var result = patron2.BorrowBook(book1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnBook_RemovesBook()
        {
            patron1.BorrowBook(book1);

            var result = patron1.ReturnBook(book1);

            Assert.That(result, Is.True);
            Assert.That(patron1.BorrowedBooks, Does.Not.Contain(book1));
        }

        [Test]
        public void ReturnBook_BookNotBorrowed()
        {
            var result = patron1.ReturnBook(book1);

            Assert.That(result, Is.False);
        }
    }
}
