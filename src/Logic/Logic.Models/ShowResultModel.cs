using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class ShowResultModel
    {
        #region properties

        [JsonPropertyName("score")]
        public float Score { get; set; }

        [JsonPropertyName("show")]
        public TelevisionShowModel Show { get; set; } = default!;

        #endregion
    }
}
