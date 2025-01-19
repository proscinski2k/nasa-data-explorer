using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace win_forms.responses
{
    public class SatelliteResponse
    {
        [JsonPropertyName("@id")]
        public string ResourceId { get; set; }

        [JsonPropertyName("@type")]
        public string ResourceType { get; set; }

        [JsonPropertyName("satelliteId")]
        public int SatelliteId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("date")]
        public DateTime UpdateDate { get; set; }

        [JsonPropertyName("line1")]
        public string TleLine1 { get; set; }

        [JsonPropertyName("line2")]
        public string TleLine2 { get; set; }
    }

    public class SearchParameters
    {
        [JsonPropertyName("search")]
        public string SearchQuery { get; set; }

        [JsonPropertyName("sort")]
        public string SortField { get; set; }

        [JsonPropertyName("sort-dir")]
        public string SortDirection { get; set; }

        [JsonPropertyName("page")]
        public int PageNumber { get; set; }

        [JsonPropertyName("page-size")]
        public int PageSize { get; set; }
    }

    public class SatelliteSearchResponse
    {
        [JsonPropertyName("@context")]
        public string Context { get; set; }

        [JsonPropertyName("@id")]
        public string ResourceId { get; set; }

        [JsonPropertyName("@type")]
        public string ResourceType { get; set; }

        [JsonPropertyName("totalItems")]
        public int TotalItems { get; set; }

        [JsonPropertyName("member")]
        public List<SatelliteResponse> Satellites { get; set; }

        [JsonPropertyName("parameters")]
        public SearchParameters Parameters { get; set; }

        [JsonPropertyName("view")]
        public PaginationView Pagination { get; set; }
    }

    public class PaginationView
    {
        [JsonPropertyName("@id")]
        public string ResourceId { get; set; }

        [JsonPropertyName("@type")]
        public string ResourceType { get; set; }

        [JsonPropertyName("first")]
        public string FirstPage { get; set; }

        [JsonPropertyName("next")]
        public string NextPage { get; set; }

        [JsonPropertyName("last")]
        public string LastPage { get; set; }
    }
}
