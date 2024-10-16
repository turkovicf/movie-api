﻿using System.ComponentModel.DataAnnotations;

namespace Movie.Application.Dtos.Genre
{
    public class GenreUpdateDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre name cannot be empty.")]
        [MaxLength(50)]
        public required string Name { get; set; }
    }
}
