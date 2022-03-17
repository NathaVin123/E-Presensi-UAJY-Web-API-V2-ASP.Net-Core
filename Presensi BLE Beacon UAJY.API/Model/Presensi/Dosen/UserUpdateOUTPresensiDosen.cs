using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserUpdateOUTPresensiDosen
    {
        public string JAM_KELUAR {get; set;}
        public string KETERANGAN {get; set;}
        public string MATERI {get; set;}
        public int ID_KELAS {get; set;}
        public int PERTEMUAN_KE {get; set;}
    }
}