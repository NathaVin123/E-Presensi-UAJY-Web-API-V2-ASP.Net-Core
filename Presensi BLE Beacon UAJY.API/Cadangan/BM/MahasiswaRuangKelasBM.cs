// using Presensi_BLE_Beacon_UAJY.API.DAO;
// using Presensi_BLE_Beacon_UAJY.API.Model;

// namespace Presensi_BLE_Beacon_UAJY.API.BM
// {
//     public class MahasiswaRuangKelasBM
//     {
//         private MahasiswaRuangKelasDAO dao;
//         private OutPutApi output;

//         public MahasiswaRuangKelasBM()
//         {
//             dao = new MahasiswaRuangKelasDAO();
//             output = new OutPutApi();
//         }

//         public OutPutApi RuangBeacon(string npm)
//         {
//             var data = dao.GetRuangKelas(npm);

//             output.data = data;

//             return output;
//         }
//     }
// }