using System;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    [Serializable]
    public class OutPutApi
    {
        public string error { get; set; }
        public dynamic data { get; set; }
    }
}