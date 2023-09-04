﻿using System;
namespace bleakshiz.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Art
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}

