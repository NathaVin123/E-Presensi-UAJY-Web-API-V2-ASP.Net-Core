using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserUpdatePresensiOUTToKSI
    {
        public int ID_KELAS {get; set;}

        public string NPM {get; set;}

        public int PERTEMUAN {get; set;}

        public string TGLOUT {get; set;} 

        public string STATUS {get; set;}   
    }
}