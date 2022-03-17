// using Presensi_BLE_Beacon_UAJY.API.DAO;
// using Presensi_BLE_Beacon_UAJY.API.Model;

// namespace Presensi_BLE_Beacon_UAJY.API.BM
// {
//     public class DsnBM
//     {
//         private DsnDAO dao;
//         private OutPutApi output;

//         public DsnBM()
//         {
//             dao = new DsnDAO();
//             output = new OutPutApi();
//         }

//         public OutPutApi GetDsnProfil(string npp)
//         {
//             OutPutApi dt = new OutPutApi();
//             //dt.status = true;
//             //dt.pesan = "Berhasil Mengambil data";

//             var data = dao.GetAllDsn(npp); ;
//             if (data != null)
//             {
//                 dt.data = data;
//             }
//             else
//             {
//                 //dt.status = false;
//                 //dt.pesan = "Tidak ada data";
//             }

//             return dt;
//         }
//     }
// }