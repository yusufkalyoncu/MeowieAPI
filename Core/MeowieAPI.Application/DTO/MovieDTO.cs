using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<string> Genres { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float UserRating { get; set; }
        public float ImdbRating { get; set; }
        public TimeSpan Duration { get; set; }
        public string ImageURL { get; set; }
        public string BannerURL { get; set; }
    }
}
