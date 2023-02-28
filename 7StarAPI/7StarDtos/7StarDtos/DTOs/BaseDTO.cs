 using System; 
using System.Text.Json.Serialization;
 
namespace SevenStarDtos.DTOs
{
    public class BaseDTO
    {
        public int TotalRecords { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [JsonIgnore]
        public Nullable<int> UserIdC { get; set; }
        [JsonIgnore]
        public string Mode { get; set; }
        [JsonIgnore]
        public int PageNumber { get; set; }
        [JsonIgnore]
        public int PageSize { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore]
        public string RoleName { get; set; }


    }
}
