using System;
using System.ComponentModel.DataAnnotations;

namespace books_api.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author{ get; set; }
        public DateTime? DateAdded { get; set; }
    }
}