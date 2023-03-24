using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowieAPI.Domain.Entities.Common;

namespace MeowieAPI.Domain.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
