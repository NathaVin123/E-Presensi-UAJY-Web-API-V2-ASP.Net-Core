// using Presensi_BLE_Beacon_UAJY.API.DAO;
// using Presensi_BLE_Beacon_UAJY.API.Model;

// namespace Presensi_BLE_Beacon_UAJY.API.BM
// {
//     public class DosenRuangKelasBM
//     {
//         private DosenRuangKelasDAO dao;
//         private OutPutApi output;

//         public DosenRuangKelasBM()
//         {
//             dao = new DosenRuangKelasDAO();
//             output = new OutPutApi();
//         }

//         public OutPutApi RuangBeacon(string npp)
//         {
//             var data = dao.GetRuangKelas(npp);

//             output.data = data;

//             return output;
//         }
//     }
// }