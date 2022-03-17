using Dapper;
using System;

using System.Data.SqlClient;

namespace Presensi_BLE_Beacon_UAJY.API.DAO
{
    public class AuthDAO
    {

        // Login Mahasiswa
        public dynamic GetLoginMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);
                string query = @"SELECT TOP (1)
                                    m.NPM,
                                    m.NAMA_MHS,
                                    m.PASSWORD,
                                    m.KD_STATUS_MHS
                                FROM MST_MHS_AKTIF m
                                WHERE (m.NPM = @npm) AND m.KD_STATUS_MHS ='A'";

                var param = new { npm = npm };
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

        // Mendapatkan Profil Mahasiswa
        public dynamic GetProfileMhs(string npm)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                string query = @"SELECT TOP (1)
	                                m.NPM,
	                                m.NAMA_MHS,
	                                f.FAKULTAS,
	                                p.PRODI
                                FROM MST_MHS_AKTIF m
	                                JOIN REF_PRODI p ON m.ID_PRODI = p.ID_PRODI
	                                JOIN REF_FAKULTAS f ON p.ID_FAKULTAS = f.ID_FAKULTAS
                                WHERE (m.NPM = @npm)";

                var param = new { NPM = npm };
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

        // Login Dosen
        public dynamic GetLoginDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);
                string query = @"SELECT TOP (1)
                                    d.NPP,
                                    d.NAMA_DOSEN_LENGKAP,
                                    k.PASSWORD,
                                    d.KD_STATUS_DOSEN
                                FROM MST_DOSEN d
                                    JOIN SIATMAX_121212.simka.MST_KARYAWAN k ON d.NPP = k.NPP
                                WHERE (d.NPP = @npp) AND d.KD_STATUS_DOSEN ='A'";

                var param = new { npp = npp };
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

        // Mendapatkan Profil Dosen
        public dynamic GetProfileDsn(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatma_uajy);

                
                 string query = @"SELECT TOP (1)
	                                d.NPP,
	                                d.NAMA_DOSEN_LENGKAP,
	                                p.PRODI,
	                                f.FAKULTAS,
                                    d.KD_STATUS_DOSEN
                                FROM MST_DOSEN d
	                                JOIN REF_PRODI p ON d.ID_PRODI = p.ID_PRODI
	                                JOIN REF_FAKULTAS f ON p.ID_FAKULTAS = f.ID_FAKULTAS
                                WHERE (D.NPP = @npp)";

                var param = new { NPP = npp };
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

        // Login Admin
        public dynamic GetLoginAdm(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatmax_121212);
                string query = @"SELECT TOP (1) 
                                    NPP,
                                    PASSWORD
                                FROM simka.MST_KARYAWAN
                                WHERE (NPP = @npp)";

                var param = new { npp = npp };
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

        // Mendapatkan Profil Admin
        public dynamic GetProfileAdm(string npp)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(DBKoneksi.siatmax_121212);
                 string query = @"SELECT TOP (1) 
                                    NPP,
                                    NAMA_LENGKAP_GELAR
                                FROM simka.MST_KARYAWAN
                                WHERE (NPP = @npp)";

                var param = new { NPP = npp };
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