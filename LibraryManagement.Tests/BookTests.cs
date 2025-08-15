using NUnit.Framework;
using LibraryManagement;

namespace LibraryManagement.Tests
{
    public class BookTests
    {
        private Book book1;
        private Book book2;
        private Book book3;

        [SetUp]
        public void Setup()
        {
            book1 = new Book("Pride and Prejudice", "Jane Austen");
            book2 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            book3 = new Book("To Kill a Mockingbird", "Harper Lee");
        }

        [Test]
        public void Borrow_AvailableBook()
        {
            var result = book1.Borrow();

            Assert.That(result, Is.True);
            Assert.That(book1.IsAvailable, Is.False);
        }

        [Test]
        public void Borrow_AlreadyBorrowedBook()
        {
            book1.Borrow();

            var result = book1.Borrow();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Return_Book_MakesItAvailable()
        {
            book1.Borrow();
            book1.Return();

            Assert.That(book1.IsAvailable, Is.True);
        }
    }
}
