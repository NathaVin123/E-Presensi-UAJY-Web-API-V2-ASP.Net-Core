using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class PresensiDAO
    {
        // Mendapatkan Kelas Dosen Sesuai NPP By Waktu Sesi
        public dynamic GetListKelasDosen(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);
                // List Kelas Dosen Tanpa Waktu Beacon
                // string query = @"SELECT
                // 					kls.ID_KELAS,
                //                     kls.NAMA_MK,
                // 					kls.KELAS,
                // 					d1.NPP AS NPP_DOSEN1,
                // 					d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
                // 					d2.NPP AS NPP_DOSEN2,
                // 					d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
                // 					d3.NPP AS NPP_DOSEN3,
                // 					d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
                // 					d4.NPP AS NPP_DOSEN4,
                // 					d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
                //                     h1.HARI AS HARI1,
                // 					h2.HARI AS HARI2,
                // 					h3.HARI AS HARI3,
                // 					h4.HARI AS HARI4,
                //                     s1.SESI AS SESI1,
                // 					s2.SESI AS SESI2,
                // 					s3.SESI AS SESI3,
                // 					s4.SESI AS SESI4,
                // 					kls.SKS,
                // 					pdsn.PERTEMUAN_KE,
                // 					r.RUANG,
                //                     b.PROXIMITY_UUID,
                //                     b.NAMA_DEVICE,
                //                     b.JARAK_MIN_DEC,
                // 					kls.KAPASITAS_KELAS,
                //                     pdsn.JAM_MASUK_SEHARUSNYA,
                // 					pdsn.JAM_KELUAR_SEHARUSNYA,
                //                     pdsn.IS_BUKA_PRESENSI
                //               FROM  TBL_KELAS kls
                //                 JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
                //                 FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
                //                 FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
                //                 FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
                // 				FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
                // 				FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
                // 				FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                // 				FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //               WHERE d1.NPP = @npp AND b.ID_BEACON IS NOT NULL AND pdsn.PERTEMUAN_KE IS NOT NULL
                //               ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";
                // List Kelas Dosen By Waktu dengan Jam Device
                // string query = @"SELECT
                // 				kls.ID_KELAS,
                //                 kls.NAMA_MK,
                // 				kls.KELAS,
                // 				d1.NPP AS NPP_DOSEN1,
                // 				d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
                // 				d2.NPP AS NPP_DOSEN2,
                // 				d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
                // 				d3.NPP AS NPP_DOSEN3,
                // 				d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
                // 				d4.NPP AS NPP_DOSEN4,
                // 				d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
                //                 h1.HARI AS HARI1,
                // 				h2.HARI AS HARI2,
                // 				h3.HARI AS HARI3,
                // 				h4.HARI AS HARI4,
                //                 s1.SESI AS SESI1,
                // 				s2.SESI AS SESI2,
                // 				s3.SESI AS SESI3,
                // 				s4.SESI AS SESI4,
                // 				kls.SKS,
                // 				pdsn.PERTEMUAN_KE,
                // 				r.RUANG,
                //                 b.PROXIMITY_UUID,
                //                 b.NAMA_DEVICE,
                //                 b.JARAK_MIN_DEC,
                // 				kls.KAPASITAS_KELAS,
                // 				pdsn.JAM_MASUK_SEHARUSNYA,
                // 				pdsn.JAM_KELUAR_SEHARUSNYA,
                //                 pdsn.IS_BUKA_PRESENSI
                //           FROM  TBL_KELAS kls
                //             JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
                //             FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
                // 			FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
                // 			FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
                // 			FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
                //             FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
                // 			FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
                // 			FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
                // 			FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
                //             FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
                // 			FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
                // 			FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
                // 			FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
                //             FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                // 			FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //           WHERE d1.NPP = @npp AND b.ID_BEACON IS NOT NULL AND pdsn.PERTEMUAN_KE IS NOT NULL AND @tglnow > JAM_MASUK_SEHARUSNYA AND @tglnow < JAM_KELUAR_SEHARUSNYA
                //           ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

                // List Kelas Dosen By Waktu dengan Jam Database Beacon Null Fix
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
		      //                      b.PROXIMITY_UUID,
		      //                      b.NAMA_DEVICE,
        //                            b.JARAK_MIN_DEC,
        //                            b.MAJOR,
        //                            b.MINOR,
								//	kls.KAPASITAS_KELAS,
        //                            CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                            pdsn.IS_BUKA_PRESENSI,
        //                            CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
        //                      FROM  TBL_KELAS kls
	       //                     JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	       //                     FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	       //                     FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	       //                     FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
	       //                     FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
								//FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                      WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(minute,-30,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP < DATEADD(minute,+30,pdsn.JAM_KELUAR_SEHARUSNYA)
        //                      ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

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
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE,
                                    b.JARAK_MIN_DEC,
                                    b.MAJOR,
                                    b.MINOR,
									kls.KAPASITAS_KELAS,
                                    CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI,
                                    CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	                            FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	                            FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
	                            FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
								FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                              WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL
                              ORDER BY pdsn.JAM_MASUK_SEHARUSNYA DESC";

                var param = new { NPP = npp };
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

        

        // Mendapatkan Kelas Mahasiswa Sesuai NPP By Waktu Sesi
        public dynamic GetListKelasMahasiswa(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                // string query = @"SELECT
                // 					kls.ID_KELAS,
                //                     kls.NAMA_MK,
                // 					kls.KELAS,
                // 					d1.NPP AS NPP_DOSEN1,
                // 					d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
                // 					d2.NPP AS NPP_DOSEN2,
                // 					d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
                // 					d3.NPP AS NPP_DOSEN3,
                // 					d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
                // 					d4.NPP AS NPP_DOSEN4,
                // 					d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
                //                     h1.HARI AS HARI1,
                // 					h2.HARI AS HARI2,
                // 					h3.HARI AS HARI3,
                // 					h4.HARI AS HARI4,
                //                     s1.SESI AS SESI1,
                // 					s2.SESI AS SESI2,
                // 					s3.SESI AS SESI3,
                // 					s4.SESI AS SESI4,
                // 					kls.SKS,
                // 					r.RUANG,
                //                     pdsn.PERTEMUAN_KE,
                //                     b.PROXIMITY_UUID,
                //                     b.NAMA_DEVICE,
                //                     b.JARAK_MIN_DEC,
                //                     b.MAJOR,
                //                     b.MINOR,
                // 					kls.KAPASITAS_KELAS,
                //                     CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
                // 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
                // 					CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
                // 					CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                //                     pdsn.IS_BUKA_PRESENSI,
                //                     CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
                //               FROM  TBL_KELAS kls
                //                 JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
                // 				JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
                // 				JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
                //                 FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
                // 				FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
                //                 FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
                // 				FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
                //                 FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
                // 				FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
                // 				FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
                // 				FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //               WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(minute,-15,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP < DATEADD(minute,+15,pdsn.JAM_KELUAR_SEHARUSNYA)
                //               ORDER BY IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

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
		      //                      b.PROXIMITY_UUID,
		      //                      b.NAMA_DEVICE,
        //                            b.JARAK_MIN_DEC,
        //                            b.MAJOR,
        //                            b.MINOR,
								//	kls.KAPASITAS_KELAS,
        //                            CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
								//	CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                            pdsn.IS_BUKA_PRESENSI,
        //                            CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG,
        //                            pmhs.TGL_IN,
        //                            pmhs.TGL_OUT,
        //                            pmhs.status
        //                      FROM  TBL_KELAS kls
	       //                     JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								//JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
								//JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
	       //                      JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	       //                     JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	       //                      JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
	       //                      JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
        //                        JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                        FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm and kls.ID_KELAS = pmhs.id_kelas
								//	and pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
        //                      WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL AND CURRENT_TIMESTAMP > DATEADD(minute,-15,pdsn.JAM_MASUK_SEHARUSNYA) AND CURRENT_TIMESTAMP < DATEADD(minute,+15,pdsn.JAM_KELUAR_SEHARUSNYA)
        //                      ORDER BY IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

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
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE,
                                    b.JARAK_MIN_DEC,
                                    b.MAJOR,
                                    b.MINOR,
									kls.KAPASITAS_KELAS,
                                    CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
									CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
                                    pdsn.IS_BUKA_PRESENSI,
                                    CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG,
                                    pmhs.TGL_IN,
                                    pmhs.TGL_OUT,
                                    pmhs.status
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
								JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
								JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
	                             JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
	                            JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
	                             JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
	                             JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                                JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                                FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm and kls.ID_KELAS = pmhs.id_kelas
									and pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                              WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL
                              ORDER BY pdsn.JAM_MASUK_SEHARUSNYA DESC";

                var param = new { NPM = npm };
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

        // Dosen Membuka Kelas Dengan Mengupdate Status IS_BUKA_PRESENSI
        public dynamic DosenBukaPresensi(int idkelas, int bukapresensi, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN SET IS_BUKA_PRESENSI = @bukapresensi WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, BUKAPRESENSI = bukapresensi, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Menampilkan Peserta Kelas Mahasiswa Yang Ada Di Kelas Dosen
        public dynamic GetListPesertaKelas(int idkelas)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT	mhs.NPM, mhs.NAMA_MHS FROM MST_MHS_AKTIF mhs
                                JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                                JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                                WHERE kls.ID_KELAS = @idkelas
                                ORDER BY mhs.NPM ASC";

                var param = new { IDKELAS = idkelas };
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

        public dynamic GetMahasiswaPresensiManual(int idkelas, int pertemuan, string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
                                    pmhs.STATUS
                                FROM TBL_PRESENSI_MHS pmhs
                                JOIN MST_MHS_AKTIF mhs ON pmhs.NPM = mhs.NPM
                                WHERE pmhs.ID_Kelas = @idkelas AND pmhs.PERTEMUAN_KE = @pertemuan AND pmhs.NPM = @npm";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan, NPM = npm };
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

        // Menampilkan Kehadiran Mahasiswa Yang Ada Di Kelas Dosen
        public dynamic GetListKehadiranPesertaKelas(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
                                    pmhs.NPM,
                                    mhs.NAMA_MHS,
                                    pmhs.STATUS,
                                    CONVERT(varchar,pmhs.TGL_IN, 8) AS JAM_MASUK,
                                    CONVERT(varchar,pmhs.TGL_OUT, 8) AS JAM_KELUAR
                                FROM TBL_PRESENSI_MHS pmhs
                                JOIN MST_MHS_AKTIF mhs ON pmhs.NPM = mhs.NPM
                                WHERE pmhs.ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan AND pmhs.STATUS = 'H'
                                ORDER BY pmhs.TGL_IN DESC";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
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

        public dynamic GetListKetidakhadiranPesertaKelas(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
                                    pmhs.NPM,
                                    mhs.NAMA_MHS,
                                    pmhs.STATUS,
                                    CONVERT(varchar,pmhs.TGL_IN, 8) AS JAM_MASUK,
                                    CONVERT(varchar,pmhs.TGL_OUT, 8) AS JAM_KELUAR
                                FROM TBL_PRESENSI_MHS pmhs
                                JOIN MST_MHS_AKTIF mhs ON pmhs.NPM = mhs.NPM
                                WHERE pmhs.ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan AND pmhs.STATUS = 'A'
                                ORDER BY pmhs.TGL_IN DESC";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
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

        public dynamic GetListIzinPesertaKelas(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
                                    pmhs.NPM,
                                    mhs.NAMA_MHS,
                                    pmhs.STATUS,
                                    CONVERT(varchar,pmhs.TGL_IN, 8) AS JAM_MASUK,
                                    CONVERT(varchar,pmhs.TGL_OUT, 8) AS JAM_KELUAR
                                FROM TBL_PRESENSI_MHS pmhs
                                JOIN MST_MHS_AKTIF mhs ON pmhs.NPM = mhs.NPM
                                WHERE pmhs.ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan AND pmhs.STATUS = 'I'
                                ORDER BY pmhs.TGL_IN DESC";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
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
        public dynamic UpdatePresensiDosen(string keterangan, string materi, int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatmax_121212);

                string query = @"UPDATE TBL_PRESENSI_DOSEN
                                SET JAM_MASUK = CURRENT_TIMESTAMP,
                                JAM_KELUAR = CURRENT_TIMESTAMP,
                                KETERANGAN = @keterangan,
                                MATERI = @materi
                                WHERE ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { KETERANGAN = keterangan, MATERI = materi, IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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


        // Presensi Masuk - Keluar Dosen

        // Presensi Dosen Masuk
        // SPKP
        public dynamic UpdateINPresensiDosen(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatmax_121212);

                string query = @"UPDATE TBL_PRESENSI_DOSEN
                                SET JAM_MASUK = CURRENT_TIMESTAMP
                                WHERE ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Dosen Keluar
        // SPKP
        public dynamic UpdateOUTPresensiDosen(string keterangan, string materi, int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatmax_121212);

                string query = @"UPDATE TBL_PRESENSI_DOSEN
                                SET JAM_KELUAR = CURRENT_TIMESTAMP,
                                KETERANGAN = @keterangan,
                                MATERI = @materi
                                WHERE ID_Kelas = @idkelas AND PERTEMUAN_KE = @pertemuan";

                var param = new { KETERANGAN = keterangan, MATERI = materi, IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk - Keluar Mahasiswa
        public dynamic InsertPresensiMahasiswa(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic InsertPresensiMahasiswaToFBE(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic InsertPresensiMahasiswaToFT(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic InsertPresensiMahasiswaToFH(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic InsertPresensiMahasiswaToFISIP(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic InsertPresensiMahasiswaToFTB(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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
        public dynamic InsertPresensiMahasiswaToFTI(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN,
                                TGL_OUT,
                                STATUS)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP,
                                CURRENT_TIMESTAMP,
                                'H')";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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
        // Presensi Masuk Mahasiswa
        // SPKP
        public dynamic InsertPresensiINMahasiswaToKSI(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"INSERT INTO TBL_PRESENSI_MHS
                                (ID_Kelas,
                                NPM,
                                PERTEMUAN_KE,
                                TGL_IN)
								VALUES
                                (@idkelas,
                                @npm,
                                @pertemuan,
                                CURRENT_TIMESTAMP)";

        //        string query = @"INSERT INTO TBL_PRESENSI_MHS
        //                        (ID_PRESENSI_MHS,
        //                        ID_Kelas,
        //                        NPM,
        //                        PERTEMUAN_KE,
        //                        TGL_IN)
		//						  VALUES
        //                        ('99999',
        //                        @idkelas,
        //                        @npm,
        //                        @pertemuan,
        //                        CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // SPKP
        public dynamic UpdatePresensiOUTMahasiswaToKSI(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToKSI(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FBE
        public dynamic InsertPresensiINMahasiswaToFBE(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FBE
        public dynamic UpdatePresensiOUTMahasiswaToFBE(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFBE(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FH
        public dynamic InsertPresensiINMahasiswaToFH(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FH
        public dynamic UpdatePresensiOUTMahasiswaToFH(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFH(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FISIP
        public dynamic InsertPresensiINMahasiswaToFISIP(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FISIP
        public dynamic UpdatePresensiOUTMahasiswaToFISIP(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFISIP(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FT
        public dynamic InsertPresensiINMahasiswaToFT(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FT
        public dynamic UpdatePresensiOUTMahasiswaToFT(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFT(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FTB
        public dynamic InsertPresensiINMahasiswaToFTB(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FTB
        public dynamic UpdatePresensiOUTMahasiswaToFTB(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFTB(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Masuk Mahasiswa
        // FTI
        public dynamic InsertPresensiINMahasiswaToFTI(int idkelas, string npm, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, TGL_IN)
                                VALUES (@idkelas, @npm, @pertemuan, CURRENT_TIMESTAMP)";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Presensi Keluar Mahasiswa
        // FTI
        public dynamic UpdatePresensiOUTMahasiswaToFTI(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET TGL_OUT = CURRENT_TIMESTAMP,
                                STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        public dynamic UpdateAnulirMahasiswaToFTI(int idkelas, string npm, int pertemuan, string status)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                string query = @"UPDATE TBL_PRESENSI_MHS
                                SET STATUS = @status
                                WHERE ID_Kelas = @idkelas AND NPM = @npm AND PERTEMUAN_KE = @pertemuan";

                var param = new { IDKELAS = idkelas, NPM = npm, PERTEMUAN = pertemuan, STATUS = status };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Dosen Mengeluarkan Mahasiswa Yang Hadir Dengan Menambahkan Jam Keluar
        // SPKP
        public dynamic UpdateOUTMahasiswa(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FBE
        public dynamic UpdateOUTMahasiswaToFBE(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FH
        public dynamic UpdateOUTMahasiswaToFH(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FISIP
        public dynamic UpdateOUTMahasiswaToFISIP(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FT
        public dynamic UpdateOUTMahasiswaToFT(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FTB
        public dynamic UpdateOUTMahasiswaToFTB(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FTI
        public dynamic UpdateOUTMahasiswaToFTI(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                // string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H' FROM MST_MHS_AKTIF mhs
                //                 FULL OUTER JOIN TBL_KRS krs ON mhs.NPM = krs.NPM
                //                 FULL OUTER JOIN TBL_KELAS kls ON kls.ID_KELAS = krs.ID_KELAS
                //                 FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
                //                 FULL OUTER JOIN TBL_PRESENSI_MHS pmhs ON mhs.NPM = pmhs.npm AND kls.ID_KELAS = pmhs.id_kelas AND pmhs.PERTEMUAN_KE = pdsn.PERTEMUAN_KE
                //                 WHERE pdsn.ID_KELAS = @idkelas AND pdsn.PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND pmhs.STATUS IS NULL";

                string query = @"UPDATE TBL_PRESENSI_MHS SET TGL_OUT = CURRENT_TIMESTAMP, STATUS = 'H'
                                WHERE ID_KELAS = @idkelas AND PERTEMUAN_KE = @pertemuan AND TGL_OUT IS NULL AND STATUS IS NULL";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Dosen Mengeluarkan Mahasiswa Yang Tidak Hadir Dengan Generate Dari Tabel KRS
        // SPKP
        public dynamic InsertOUTMahasiswaTidakHadirToKSI(int idkelas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT krs.ID_KELAS, krs.NPM, @pertemuan, 'A'
                                FROM TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                //string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_PRESENSI_MHS, ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                //                SELECT 99999, krs.ID_KELAS, krs.NPM, @pertemuan, 'A'
                //                FROM TBL_KRS krs
                //                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FBE
        public dynamic InsertOUTMahasiswaTidakHadirToFBE(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fbe);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FH
        public dynamic InsertOUTMahasiswaTidakHadirToFH(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fh);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FISIP
        public dynamic InsertOUTMahasiswaTidakHadirToFISIP(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fisip);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FT
        public dynamic InsertOUTMahasiswaTidakHadirToFT(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ft);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FTB
        public dynamic InsertOUTMahasiswaTidakHadirToFTB(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_ftb);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // FTI
        public dynamic InsertOUTMahasiswaTidakHadirToFTI(int idkelas, int idkelasfakultas, int pertemuan)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_fti);

                string query = @"INSERT INTO TBL_PRESENSI_MHS(ID_Kelas, NPM, PERTEMUAN_KE, STATUS)
                                SELECT @idkelasfakultas, krs.NPM, @pertemuan, 'A'
                                FROM SIATMA_UAJY.dbo.TBL_KRS krs
                                WHERE krs.ID_KELAS = @idkelas AND krs.NPM NOT IN (SELECT pmhs.NPM FROM TBL_PRESENSI_MHS pmhs WHERE pmhs.ID_KELAS = @idkelasfakultas and pmhs.NPM = krs.NPM and pmhs.PERTEMUAN_KE = @pertemuan)";

                var param = new { IDKELAS = idkelas, IDKELASFAKULTAS = idkelasfakultas, PERTEMUAN = pertemuan };
                var data = conn.QuerySingleOrDefault<dynamic>(query, param);

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

        // Cadangan

        // public dynamic GetAllListKelasDosen(string npp)
        // {
        //     SqlConnection conn = new SqlConnection();
        //     try
        //     {
        //         conn = new SqlConnection(DBKoneksi.siatma_uajy);

        //         // string query = @"SELECT
        //         // 				kls.ID_KELAS,
        //         //                 kls.NAMA_MK,
        //         // 				kls.KELAS,
        //         // 				d1.NPP AS NPP_DOSEN1,
        //         // 				d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
        //         // 				d2.NPP AS NPP_DOSEN2,
        //         // 				d2.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN2,
        //         // 				d3.NPP AS NPP_DOSEN3,
        //         // 				d3.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN3,
        //         // 				d4.NPP AS NPP_DOSEN4,
        //         // 				d4.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN4,
        //         //                 h1.HARI AS HARI1,
        //         // 				h2.HARI AS HARI2,
        //         // 				h3.HARI AS HARI3,
        //         // 				h4.HARI AS HARI4,
        //         //                 s1.SESI AS SESI1,
        //         // 				s2.SESI AS SESI2,
        //         // 				s3.SESI AS SESI3,
        //         // 				s4.SESI AS SESI4,
        //         // 				kls.SKS,
        //         // 				pdsn.PERTEMUAN_KE,
        //         // 				r.RUANG,
        //         //                 b.PROXIMITY_UUID,
        //         //                 b.NAMA_DEVICE,
        //         //                 b.JARAK_MIN_DEC,
        //         //                 b.MAJOR,
        //         //                 b.MINOR,
        //         // 				kls.KAPASITAS_KELAS,
        //         //                 CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
        //         // 				CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
        //         // 				CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
        //         // 				CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //         //                 pdsn.IS_BUKA_PRESENSI,
        //         //                 CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
        //         //           FROM  TBL_KELAS kls
        //         //             JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
        //         //             FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
        //         // 			FULL OUTER JOIN REF_HARI h2 ON kls.ID_HARI2 = h2.ID_HARI
        //         // 			FULL OUTER JOIN REF_HARI h3 ON kls.ID_HARI3 = h3.ID_HARI
        //         // 			FULL OUTER JOIN REF_HARI h4 ON kls.ID_HARI4 = h4.ID_HARI
        //         //             FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
        //         // 			FULL OUTER JOIN REF_SESI s2 ON kls.ID_SESI_KULIAH2 = s2.ID_SESI
        //         // 			FULL OUTER JOIN REF_SESI s3 ON kls.ID_SESI_KULIAH3 = s3.ID_SESI
        //         // 			FULL OUTER JOIN REF_SESI s4 ON kls.ID_SESI_KULIAH4 = s4.ID_SESI
        //         //             FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
        //         // 			FULL OUTER JOIN MST_DOSEN d2 ON kls.NPP_DOSEN2 = d2.NPP
        //         // 			FULL OUTER JOIN MST_DOSEN d3 ON kls.NPP_DOSEN3 = d3.NPP
        //         // 			FULL OUTER JOIN MST_DOSEN d4 ON kls.NPP_DOSEN4 = d4.NPP
        //         //             FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
        //         // 			FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //         //           WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL
        //         //           ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

        //         string query = @"SELECT
        // 							kls.ID_KELAS,
        //                             kls.NAMA_MK,
        // 							kls.KELAS,
        // 							d1.NPP AS NPP_DOSEN1,
        // 							d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
        //                             h1.HARI AS HARI1,
        //                             s1.SESI AS SESI1,
        // 							kls.SKS,
        // 							pdsn.PERTEMUAN_KE,
        // 							r.RUANG,
        //                             b.PROXIMITY_UUID,
        //                             b.NAMA_DEVICE,
        //                             b.JARAK_MIN_DEC,
        //                             b.MAJOR,
        //                             b.MINOR,
        // 							kls.KAPASITAS_KELAS,
        //                             CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                             pdsn.IS_BUKA_PRESENSI,
        //                             CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
        //                       FROM  TBL_KELAS kls
        //                         JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
        //                         FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
        //                         FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
        //                         FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
        //                         FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
        // 						FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                       WHERE d1.NPP = @npp AND pdsn.PERTEMUAN_KE IS NOT NULL
        //                       ORDER BY pdsn.IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

        //         var param = new { NPP = npp };
        //         var data = conn.Query<dynamic>(query, param).ToList();

        //         return data;
        //     }
        //     catch (Exception)
        //     {
        //         return null;
        //     }
        //     finally
        //     {
        //         conn.Dispose();
        //     }
        // }

        // public dynamic GetAllListKelasMahasiswa(string npm)
        // {
        //     SqlConnection conn = new SqlConnection();
        //     try
        //     {
        //         conn = new SqlConnection(DBKoneksi.siatma_uajy);

        //         string query = @"SELECT
        // 							kls.ID_KELAS,
        //                             kls.NAMA_MK,
        // 							kls.KELAS,
        // 							d1.NPP AS NPP_DOSEN1,
        // 							d1.NAMA_DOSEN_LENGKAP AS NAMA_DOSEN1,
        //                             h1.HARI AS HARI1,
        //                             s1.SESI AS SESI1,
        // 							kls.SKS,
        // 							r.RUANG,
        //                             pdsn.PERTEMUAN_KE,
        //                             b.PROXIMITY_UUID,
        //                             b.NAMA_DEVICE,
        //                             b.JARAK_MIN_DEC,
        //                             b.MAJOR,
        //                             b.MINOR,
        // 							kls.KAPASITAS_KELAS,
        //                             CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 106) AS TGL_MASUK_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 106) AS TGL_KELUAR_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_MASUK_SEHARUSNYA, 8) AS JAM_MASUK_SEHARUSNYA,
        // 							CONVERT(varchar, pdsn.JAM_KELUAR_SEHARUSNYA, 8) AS JAM_KELUAR_SEHARUSNYA,
        //                             pdsn.IS_BUKA_PRESENSI,
        //                             CONVERT(varchar, CURRENT_TIMESTAMP, 21) AS TGL_JAM_SEKARANG
        //                       FROM  TBL_KELAS kls
        //                         JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
        // 						JOIN TBL_KRS krs ON kls.ID_KELAS = krs.ID_KELAS
        // 						JOIN MST_MHS_AKTIF mhs ON krs.NPM = mhs.NPM
        //                         FULL OUTER JOIN REF_HARI h1 ON kls.ID_HARI1 = h1.ID_HARI
        //                         FULL OUTER JOIN REF_SESI s1 ON kls.ID_SESI_KULIAH1 = s1.ID_SESI
        //                         FULL OUTER JOIN MST_DOSEN d1 ON kls.NPP_DOSEN1 = d1.NPP
        //                         FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
        //                         FULL OUTER JOIN SIATMAX_121212.dbo.TBL_PRESENSI_DOSEN pdsn ON kls.ID_KELAS = pdsn.ID_Kelas
        //                       WHERE mhs.NPM = @npm AND pdsn.PERTEMUAN_KE IS NOT NULL
        //                       ORDER BY IS_BUKA_PRESENSI DESC, pdsn.PERTEMUAN_KE ASC, kls.KELAS ASC";

        //         var param = new { NPM = npm };
        //         var data = conn.Query<dynamic>(query, param).ToList();

        //         return data;
        //     }
        //     catch (Exception)
        //     {
        //         return null;
        //     }
        //     finally
        //     {
        //         conn.Dispose();
        //     }
        // }
    }
}