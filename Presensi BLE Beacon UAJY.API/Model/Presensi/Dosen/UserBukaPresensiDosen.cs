using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presensi_BLE_Beacon_UAJY.API.Model
{
    public class UserBukaPresensiDosen
    {
        public int ID_KELAS { get; set; }

        public int IS_BUKA_PRESENSI { get; set; }

        public int PERTEMUAN_KE { get; set; }
    }
}