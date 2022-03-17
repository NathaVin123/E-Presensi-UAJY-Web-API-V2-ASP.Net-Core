using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserUpdateBeacon
    {
        public string UUID { get; set; }

        public string NAMA_DEVICE { get; set; }

        public float JARAK_MIN { get; set; }

        public int MAJOR { get; set; }

        public int MINOR { get; set; }
    }
}