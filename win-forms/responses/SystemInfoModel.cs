using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace win_forms.responses
{

    public class SystemInfoModel
    {
        public SystemInfoModel(HttpResponseMessage response)
        {
            if (response != null && response.IsSuccessStatusCode)
            {
                IsWebApiAvailable = true;
                IsNasaApiAvailable = true;
            }
            else
            {
                IsWebApiAvailable = false;
                IsNasaApiAvailable = false;
            }
            CheckTime = DateTime.UtcNow;
        }

        public SystemInfoModel()
        {
            IsWebApiAvailable = false;
            IsNasaApiAvailable = false;
            CheckTime = DateTime.UtcNow;
        }

        public bool IsWebApiAvailable { get; set; }
        public bool IsNasaApiAvailable { get; set; }
        public DateTime CheckTime { get; set; }
    }

}
