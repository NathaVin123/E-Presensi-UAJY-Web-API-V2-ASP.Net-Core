using Dapper;
using Presensi_BLE_Beacon_UAJY.API.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class RuangBeaconDAO
    {
        public dynamic GetBeacon()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT
		                            kls.NAMA_MK,
		                            d.NAMA_DOSEN_LENGKAP,
		                            h.HARI,
		                            s.SESI,
		                            r.RUANG,
		                            b.PROXIMITY_UUID,
		                            b.NAMA_DEVICE
                              FROM  TBL_KELAS kls
	                            JOIN MST_RUANG r ON kls.RUANG1 = r.RUANG
	                            JOIN REF_HARI h ON kls.ID_HARI1 = h.ID_HARI
	                            JOIN REF_SESI s ON kls.ID_SESI_KULIAH1 = s.ID_SESI
	                            JOIN MST_DOSEN d ON kls.NPP_DOSEN1 = d.NPP
	                            JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
                              WHERE r.ID_BEACON IS NOT NULL";

                var data = conn.Query<dynamic>(query).ToList();

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

        // Menambahkan Data Beacon Ke Server
        public dynamic TambahBeacon(string uuid, string nama_device, float jarak_min, int major, int minor)
        {
            OutPutApi output = new OutPutApi();
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"INSERT INTO SIATMAX_121212.dbo.REF_BEACON 
                                    (PROXIMITY_UUID, NAMA_DEVICE, JARAK_MIN_DEC, MAJOR, MINOR) 
                                    VALUES 
                                    (@uuid, @nama_device, @jarak_min, @major, @minor)";

                var param = new { UUID = uuid,  NAMA_DEVICE = nama_device, JARAK_MIN = jarak_min, MAJOR = major, MINOR = minor};
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

        // Tampil Data Beacon
        public dynamic GetListBeacon()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT PROXIMITY_UUID, NAMA_DEVICE, JARAK_MIN_DEC, MAJOR, MINOR 
                                FROM SIATMAX_121212.dbo.REF_BEACON 
                                ORDER BY JARAK_MIN_DEC DESC";

                var data = conn.Query<dynamic>(query).ToList();

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

        // Ubah Data Beacon
        public dynamic UpdateBeacon(string uuid, string nama_device, float jarak_min, int major, int minor)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE SIATMAX_121212.dbo.REF_BEACON SET NAMA_DEVICE = @nama_device, JARAK_MIN_DEC = @jarak_min, MAJOR = @major, MINOR = @minor 
                                WHERE PROXIMITY_UUID = @uuid";

                var param = new { UUID = uuid, NAMA_DEVICE = nama_device, JARAK_MIN = jarak_min, MAJOR = major, MINOR = minor };
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

        public dynamic PostListRuanganNamaDevice(string ruang)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT b.NAMA_DEVICE FROM MST_RUANG r 
                                    JOIN REF_FAKULTAS f ON r.ID_FAKULTAS = f.ID_FAKULTAS 
                                    JOIN REF_PRODI p ON r.ID_PRODI = p.ID_PRODI 
                                    FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON
									WHERE r.RUANG = @ruang";

                var param = new { RUANG = ruang };
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

        // Tampil Ruangan Yang Terpasang Beacon
        public dynamic GetListRuangan()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                // string query = @"SELECT r.RUANG, f.FAKULTAS, p.PRODI, b.NAMA_DEVICE FROM MST_RUANG r 
                //                     JOIN REF_FAKULTAS f ON r.ID_FAKULTAS = f.ID_FAKULTAS 
                //                     JOIN REF_PRODI p ON r.ID_PRODI = p.ID_PRODI
                //                     FULL OUTER JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON";
                string query = @"SELECT r.RUANG, f.FAKULTAS, p.PRODI FROM MST_RUANG r 
                                    JOIN REF_FAKULTAS f ON r.ID_FAKULTAS = f.ID_FAKULTAS 
                                    JOIN REF_PRODI p ON r.ID_PRODI = p.ID_PRODI";

                var data = conn.Query<dynamic>(query).ToList();

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

        // Tampil Yang Terpasang Beacon Dengan Tambahan Atribut
        public dynamic GetListDetailRuangan()
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT r.RUANG, f.FAKULTAS, p.PRODI, b.NAMA_DEVICE, b.PROXIMITY_UUID, b.JARAK_MIN_DEC FROM MST_RUANG r 
                                    JOIN REF_FAKULTAS f ON r.ID_FAKULTAS = f.ID_FAKULTAS 
                                    JOIN REF_PRODI p ON r.ID_PRODI = p.ID_PRODI 
                                    JOIN SIATMAX_121212.dbo.REF_BEACON b ON r.ID_BEACON = b.ID_BEACON";

                var data = conn.Query<dynamic>(query).ToList();

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

        // Mengubah Beacon Pada Ruangan
        public dynamic UpdateRuangBeacon(string ruang, string nama_device)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE MST_RUANG SET ID_BEACON = 
                                (SELECT ID_BEACON FROM SIATMAX_121212.dbo.REF_BEACON WHERE NAMA_DEVICE = @nama_device)
                                FROM MST_RUANG 
                                WHERE RUANG = @ruang";

                var param = new { RUANG = ruang, NAMA_DEVICE = nama_device };
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


        // Lepas Beacon Dari Ruangan
        public dynamic UpdateLepasRuangBeacon(string ruang)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"UPDATE MST_RUANG SET ID_BEACON = NULL
                                WHERE RUANG = @ruang";

                var param = new { RUANG = ruang };
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
    }
}