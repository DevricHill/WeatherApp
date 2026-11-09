using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Media;

namespace WeatherApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AviationRoot
    {
        public string icaoId { get; set; }
        public string receiptTime { get; set; }
        public int obsTime { get; set; }
        public string reportTime { get; set; }
        public double temp { get; set; }
        public double dewp { get; set; }
        public object? wdir { get; set; }
        public int wspd { get; set; }
        public int wgst { get; set; }
        public object? visib { get; set; }
        public double altim { get; set; }
        public double slp { get; set; }
        public string wxString { get; set; }
        public object presTend { get; set; }
        public double maxT { get; set; }
        public double minT { get; set; }
        public double maxT24 { get; set; }
        public double minT24 { get; set; }
        public double precip { get; set; }
        public double pcp3hr { get; set; }
        public double pcp6hr { get; set; }
        public double pcp24hr { get; set; }
        public int snow { get; set; }
        public int vertVis { get; set; }
        public string metarType { get; set; }
        public string rawOb { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public int elev { get; set; }
        public string name { get; set; }
        public List <CloudInfo> clouds { get; set; }
        public string fltCat { get; set; }
    }
        

        public class CloudInfo
        {
            [JsonPropertyName("cover")]
            public string Cover { get; set; } = string.Empty;

            [JsonPropertyName("base")]
            public int? Base { get; set; }

            public override string ToString()
            {
                return Base.HasValue ? $"{Cover} at {Base.Value} ft" : Cover;
            }
        }
}
