using System.Collections.Generic;
using books_api.Controllers;
using books_api.Model;
using books_api.Services;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace books_api_test
{
    [TestFixture]
    public class BooksControllerTest
    {
        private BooksController controller;
        private Mock<IBookService> service;
        private Mock<ILogger<BooksController>> logger;

        [SetUp]
        public void Setup()
        {
            service = new Mock<IBookService>();
            logger = new Mock<ILogger<BooksController>>();
            controller = new BooksController(service.Object,logger.Object);
        }

        [Test]
        public void ShouldReturnOk()
        {
            var books = Builder<Book>.CreateListOfSize(10).Build();

            service
                .Setup(s => s.GetAllBooks())
                .Returns(books);

            var result = controller.Get();
            Assert.That(result,Is.Not.Null);
        }
    }
}