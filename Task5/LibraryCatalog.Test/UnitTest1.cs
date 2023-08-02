using System;
using System.Collections.Generic;
using Xunit;

namespace LibraryCatalog.Class.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void AddBook_ShouldAddBookToLibrary()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            Book book = new Book("Test Book", "Test Author", "1234567890", "2023");

            // Act
            library.AddBook(book);

            // Assert
            Assert.Contains(book, library.GetBooks());
        }

        [Fact]
        public void AddMediaItem_ShouldAddMediaItemToLibrary()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            MediaItem mediaItem = new MediaItem("Test Media", "Test Type", 120);

            // Act
            library.AddMediaItem(mediaItem);

            // Assert
            Assert.Contains(mediaItem, library.GetMediaItems());
        }
        // Add more test cases for other methods of the Library class as needed...
        [Fact]
        public void RemoveBook_ShouldRemoveBookFromLibrary()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            Book book = new Book("Test Book", "Test Author", "1234567890", "2023");
            library.AddBook(book);

            // Act
            library.RemoveBook("1234567890");

            // Assert
            // it returns There are no books in the library.
            Assert.DoesNotContain(book, library.GetBooks());
        }
        [Fact]
        public void RemoveMediaItem_ShouldRemoveMediaItemFromLibrary()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            MediaItem mediaItem = new MediaItem("Test Media", "Test Type", 120);
            library.AddMediaItem(mediaItem);

            // Act
            library.RemoveMediaItem("Test Media");

            // Assert
            Assert.DoesNotContain(mediaItem, library.GetMediaItems());
        }

        [Fact]
        public void SearchBooksByTitle_ShouldReturnMatchingBook()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            Book book = new Book("Test Book", "Test Author", "1234567890", "2023");
            library.AddBook(book);

            // Act
            Book result = library.SearchBooksByTitle("Test Book");

            // Assert
            Assert.Equal(book, result);
        }

        [Fact]
        public void SearchMediaItemsByTitle_ShouldReturnMatchingMediaItem()
        {
            // Arrange
            Library library = new Library("Test Library", "Test Address");
            MediaItem mediaItem = new MediaItem("Test Media", "Test Type", 120);
            library.AddMediaItem(mediaItem);

            // Act
            MediaItem result = library.SearchMediaItemsByTitle("Test Media");

            // Assert
            Assert.Equal(mediaItem, result);
        }
    }
}
