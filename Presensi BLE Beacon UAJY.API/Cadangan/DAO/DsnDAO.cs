// using Dapper;
// using System;
// using System.Collections.Generic;
// using System.Data.SqlClient;
// using System.Linq;

// using Presensi_BLE_Beacon_UAJY.API.Model;

// namespace Presensi_BLE_Beacon_UAJY.API.DAO
// {
//     public class DsnDAO
//     {
//         public dynamic GetProfileDsn(string npp)
//         {
//             SqlConnection conn = new SqlConnection();
//             try
//             {
//                 conn = new SqlConnection(DBKoneksi.koneksi);

//                 string query = @"SELECT D.NPP, D.NAMA_DOSEN_LENGKAP
//                                 FROM MST_DOSEN D
//                                 WHERE D.NPP = @npp AND KD_STATUS_DOSEN ='A'";

//                 var param = new { NPP = npp };
//                 var data = conn.QuerySingleOrDefault<dynamic>(query, param);

//                 return data;
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//             finally
//             {
//                 conn.Dispose();
//             }
//         }

//         public dynamic GetAllDsn(string npp)
//         {
//             OutPutApi output = new OutPutApi();

//             using (SqlConnection conn = new SqlConnection(DBKoneksi.koneksi))
//             {
//                 try
//                 {
//                     string query = @"SELECT D.NPP, D.NAMA_DOSEN_LENGKAP
//                                     FROM MST_DOSEN D
//                                     WHERE KD_STATUS_DOSEN ='A'";
//                     var data = conn.Query<dynamic>(query, new { npp = npp }).ToList();

//                     output.data = data;

//                     return output;
//                 }
//                 catch (Exception ex)
//                 {
//                     output.error = ex.Message;
//                     output.data = new List<string>();
//                     return output;
//                 }
//                 finally
//                 {
//                     conn.Dispose();
//                 }
//             }
//         }
//     }
// }