using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class JadwalMhsDAO
    {
        // Jadwal Mahasiswa
        public dynamic GetJadwalMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
									kls.ID_KELAS,
		                            kls.NAMA_MK,
									kls.KELAS,
									d1.NPP AS NPP_DOSEN1,
									d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		                            h1.HARI AS HARI1,
		                            s1.SESI AS SESI1,	
									kls.SKS,
									r.RUANG,
                                    pdsn.PERTEMUAN_KE,
									kls.KAPASITAS_KELAS,
                                    CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
								JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
	                            FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	                            FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	                            FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
                                FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL 
                              ORDER BY pdsn.JAM_MASUK_SEHARUSNYA DESC";

                var param = new { NPM = npm};
                var data = conn.Query<dynamic>(query, param).ToList();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Dispose();
            }
        }

        //public dynamic GetJadwalMhs(string npm)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        conn = new SqlConnection(DBKoneksi.siatma_uajy);

        //        string query = @"SELECT
								//	kls.ID_KELAS,
		      //                      kls.NAMA_MK,
								//	kls.KELAS,
								//	d1.NPP AS NPP_DOSEN1,
								//	d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		      //                      h1.HARI AS HARI1,
		      //                      s1.SESI AS SESI1,	
								//	kls.SKS,
								//	r.RUANG,
        //                            pdsn.PERTEMUAN_KE,
								//	kls.KAPASITAS_KELAS,
        //                            CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                            pdsn.IS_BUKA_PRESENSI
        //                      FROM  TBL_KELAS kls
	       //                     JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								//JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
								//JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
	       //                     FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	       //                     FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	       //                     FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
        //                        FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                      WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(DAY,-1,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP < DATEADD(WEEK,+1,pdsn.JAM_MASUK_SEHARUSNYA) 
        //                      ORDER BY CONVERT(date,JAM_MASUK_SEHARUSNYA) ASC";

        //        var param = new { NPM = npm };
        //        var data = conn.Query<dynamic>(query, param).ToList();

        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Dispose();
        //    }
        //}

        // Jadwal Dosen
        public dynamic GetJadwalDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
									kls.ID_KELAS,
		                            kls.NAMA_MK,
									kls.KELAS,
									d1.NPP AS NPP_DOSEN1,
									d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		                            h1.HARI AS HARI1,
		                            s1.SESI AS SESI1,
									kls.SKS,
									pdsn.PERTEMUAN_KE,
									r.RUANG,
									kls.KAPASITAS_KELAS,
                                    CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                                    JAM_MASUK,
                                    (SELECT COUNT(mhs.NPM) FROM MST_MHS_AKTIF mhs JOIN TBL_KRS krs ON mhs.NPM = krs.NPM JOIN TBL_KELAS klss ON kls.ID_KELAS = krs.ID_KELAS WHERE klss.ID_KELAS = kls.ID_KELAS) AS Total,
                                    pdsn.IS_BUKA_PRESENSI
                              FROM TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	                            FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	                            FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
								FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL 
                              ORDER BY pdsn.JAM_MASUK_SEHARUSNYA DESC";

                var param = new { NPP = npp};
                var data = conn.Query<dynamic>(query, param).ToList();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                conn.Dispose();
            }
        }

        //public dynamic GetJadwalDsn(string npp)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        conn = new SqlConnection(DBKoneksi.siatma_uajy);

        //        string query = @"SELECT
								//	kls.ID_KELAS,
		      //                      kls.NAMA_MK,
								//	kls.KELAS,
								//	d1.NPP AS NPP_DOSEN1,
								//	d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
		      //                      h1.HARI AS HARI1,
		      //                      s1.SESI AS SESI1,
								//	kls.SKS,
								//	pdsn.PERTEMUAN_KE,
								//	r.RUANG,
								//	kls.KAPASITAS_KELAS,
        //                            CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                            pdsn.IS_BUKA_PRESENSI
        //                      FROM TBL_KELAS kls
	       //                     JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	       //                     FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	       //                     FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	       //                     FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
								//FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                      WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(DAY,-1,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP < DATEADD(WEEK,+1,pdsn.JAM_MASUK_SEHARUSNYA) 
        //                      ORDER BY CONVERT(date,JAM_MASUK_SEHARUSNYA) ASC";

        //        var param = new { NPP = npp };
        //        var data = conn.Query<dynamic>(query, param).ToList();

        //        return data;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Dispose();
        //    }
        //}
    }
}