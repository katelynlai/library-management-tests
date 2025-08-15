using NUnit.Framework;
using LibraryManagement;

namespace LibraryManagement.Tests
{
    public class LibraryTests
    {
        [Test]
        public void BorrowBook_WhenAvailable_ReturnsTrue()
        {
            // Arrange
            var library = new Library();
            var patron = new Patron("Katelyn");
            var book = new Book("Pride and Prejudice", "Jane Austen");
            library.AddBook(book);
            library.AddPatron(patron);

            // Act
            var result = library.BorrowBook(patron, book);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(book.IsAvailable, Is.False);
            Assert.That(patron.BorrowedBooks, Has.Member(book));

        }
    }
}
