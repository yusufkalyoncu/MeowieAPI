﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Application.DTO.UserDTOs;

namespace MeowieAPI.Application.Features.Queries.GetUserRating
{
    public class GetUserRatingQueryResponse
    {
        public List<UserRatedMovieCardDTO> RatedMovies { get; set; }
    }
}
