using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.MovieListDTOs;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.DTO.UserDTOs
{
    public class UserProfileDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string ProfileImage { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public int CommentCount { get; set; }
        public int FollowCount { get; set; }
        public int LikedMovieListCounts { get; set; }
        public int MovieListCount { get; set; }

    }
}
