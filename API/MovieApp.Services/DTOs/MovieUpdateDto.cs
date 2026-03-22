using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.DTOs
{
    public class MovieUpdateDto: MovieCreateDto
    {
        public int Id { get; set; }
    }
}
