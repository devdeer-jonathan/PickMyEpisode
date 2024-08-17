using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class TelevisionShowModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string? PremierDate { get; set; }
    }
}
