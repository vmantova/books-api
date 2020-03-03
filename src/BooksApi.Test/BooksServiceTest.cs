using System;
using System.Linq;
using books_api.Model;
using books_api.Services.Impl;
using FizzWare.NBuilder;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using NUnit.Framework;

namespace books_api_test{

    [TestFixture]
    public class BooksServiceTest{

        private BookService service;
        private Mock<BooksContext> context;
        
        [SetUp]
        public void Setup()
        {
            context = new Mock<BooksContext>();
            service = new BookService(context.Object);
        }

        [Test]
        public void ShoudlReturnAllBooks()
        {
            var books = Builder<Book>.CreateListOfSize(10).Build().AsQueryable();

            context
                .Setup(c => c.Books)
                .Returns(books.BuildMockDbSet().Object);

            var result = service.GetAllBooks();

            Assert.That(Is.Equals(result.Count(),10));
        }

        [Test]
        public void ShouldAddBook()
        {
            var book  = Builder<Book>.CreateNew().Build();
            
            context.Setup(t => t.Add(It.IsAny<Book>()));

            service.AddBook(book);

            context.Verify(c => c.Add(It.IsAny<Book>()),Times.Once);
        }
        
    }
}