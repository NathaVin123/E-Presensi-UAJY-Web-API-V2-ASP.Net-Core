// using Dapper;
// using System;
// using System.Collections.Generic;
// using System.Data.SqlClient;
// using System.Linq;

// namespace Presensi_BLE_Beacon_UAJY.API.DAO
// {
//     public class MahasiswaRuangKelasDAO
//     {
//         public dynamic GetRuangKelas(string npm)
//         {
//             SqlConnection conn = new SqlConnection();
//             try
//             {
//                 conn = new SqlConnection(DBKoneksi.siatma_uajy);

//                 string query = @"SELECT 
//                                         kls.NAMA_MK,
//                                         dsn1.NAMA_DOSEN_LENGKAP,
//                                         kls.NPP_DOSEN1,
//                                         r.RUANG,
//                                         h.HARI,
//                                         s.SESI,
//                                         bcn.PROXIMITY_UUID,
//                                         kls.IS_BUKA_PRESENSI
//                                     FROM TBL_KRS krs
//                                     JOIN TBL_KELAS kls ON krs.ID_KELAS = kls.ID_KELAS
//                                     JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
//                                     JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
//                                     JOIN MST_DOSEN dsn1 ON kls.NPP_DOSEN1 = dsn1.NPP
//                                     JOIN REF_HARI h ON kls.ID_HARI1 = h.ID_HARI
//                                     JOIN REF_SESI s ON kls.ID_SESI_KULIAH1 = s.ID_SESI
//                                     JOIN SIATMAX_121212.dbo.REF_BEACON bcn ON r.ID_BEACON = bcn.ID_BEACON
//                                     WHERE (mhs.NPM = @npm)";

//                 var param = new { NPM = npm };
//                 var data = conn.Query<dynamic>(query,param).ToList();

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
//     }
// }