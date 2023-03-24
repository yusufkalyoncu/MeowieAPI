using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities;

namespace MeowieAPI.Application.DTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public float UserRating { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}
