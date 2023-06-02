using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.MovieListDTOs;

namespace MeowieAPI.Application.Features.Commands.MovieListCommands.AddMovieToList
{
    public class AddMovieToListCommandResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
