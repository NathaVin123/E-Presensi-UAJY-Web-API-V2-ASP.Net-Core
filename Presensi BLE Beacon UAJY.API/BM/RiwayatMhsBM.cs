using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class RiwayatMhsBM
    {
        private RiwayatMhsDAO dao;
        private OutPutApi output;

        public RiwayatMhsBM()
        {
            dao = new RiwayatMhsDAO();
            output = new OutPutApi();
        }

        // Riwayat Kelas Mahasiswa
        public OutPutApi RiwayatMhs(string npm)
        {
            var data = dao.GetRiwayatMhs(npm);

            output.data = data;

            return output;
        }

        // Riwayat Kelas
        public OutPutApi RiwayatDsn(string npp)
        {
            var data = dao.GetRiwayatDsn(npp);

            output.data = data;

            return output;
        }
    }
}