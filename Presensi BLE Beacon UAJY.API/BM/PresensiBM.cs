using Presensi_BLE_Beacon_UAJY.API.DAO;
using Presensi_BLE_Beacon_UAJY.API.Model;

namespace Presensi_BLE_Beacon_UAJY.API.BM
{
    public class PresensiBM
    {
        private PresensiDAO dao;
        private OutPutApi output;

        public PresensiBM()
        {
            dao = new PresensiDAO();
            output = new OutPutApi();
        }

        // Mendapatkan Kelas Dosen Sesuai NPP By Waktu Sesi
        public OutPutApi ListKelasDsn(string npp)
        {
            var data = dao.GetListKelasDosen(npp);

            output.data = data;

            return output;
        }

        // Mendapatkan Kelas Mahasiswa Sesuai NPP By Waktu Sesi
        public OutPutApi ListKelasMhs(string npm)
        {
            var data = dao.GetListKelasMahasiswa(npm);

            output.data = data;

            return output;
        }

        // Dosen Membuka Kelas Dengan Mengupdate Status IS_BUKA_PRESENSI
        public OutPutApi DosenBukaPresensi(int idkelas, int bukapresensi, int pertemuan)
        {
            var data = dao.DosenBukaPresensi(idkelas, bukapresensi, pertemuan);

            output.data = data;

            return output;
        }

        // Menampilkan Peserta Kelas Mahasiswa Yang Ada Di Kelas Dosen
        public OutPutApi ListPesertaKelasDsn(int idkelas)
        {
            var data = dao.GetListPesertaKelas(idkelas);

            output.data = data;

            return output;
        }

        public OutPutApi ListMahasiswaManual(int idkelas, int pertemuan, string npm)
        {
            var data = dao.GetMahasiswaPresensiManual(idkelas, pertemuan, npm);

            output.data = data;

            return output;
        }

        // Menampilkan Kehadiran Mahasiswa Yang Ada Di Kelas Dosen
        public OutPutApi ListKehadiranPesertaKelasDsn(int idkelas, int pertemuan)
        {
            var data = dao.GetListKehadiranPesertaKelas(idkelas,pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi ListKetidakhadiranPesertaKelasDsn(int idkelas, int pertemuan)
        {
            var data = dao.GetListKetidakhadiranPesertaKelas(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi ListIzinPesertaKelasDsn(int idkelas, int pertemuan)
        {
            var data = dao.GetListIzinPesertaKelas(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi UpdatePresensiDosen(string keterangan, string materi, int idkelas, int pertemuan)
        {
            var data = dao.UpdatePresensiDosen(keterangan, materi, idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Masuk - Keluar Dosen

        // Presensi Dosen Masuk
        // SPKP
        public OutPutApi UpdateINPresensiDosen(int idkelas, int pertemuan)
        {
            var data = dao.UpdateINPresensiDosen(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Dosen Keluar
        // SPKP
        public OutPutApi UpdateOUTPresensiDosen(string keterangan, string materi, int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTPresensiDosen(keterangan, materi, idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Masuk - Keluar Mahasiswa

        public OutPutApi InsertPresensiMhs(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswa(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFBE(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFBE(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFT(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFT(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFTB(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFTB(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFISIP(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFISIP(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFH(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFH(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        public OutPutApi InsertPresensiMhsToFTI(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiMahasiswaToFTI(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // SPKP
        public OutPutApi InsertPresensiINMhsToKSI(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToKSI(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // SPKP
        public OutPutApi UpdatePresensiOUTMhsToKSI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToKSI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToKSI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToKSI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FBE
        public OutPutApi InsertPresensiINMhsToFBE(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFBE(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FBE
        public OutPutApi UpdatePresensiOUTMhsToFBE(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFBE(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToFBE(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFBE(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FH
        public OutPutApi InsertPresensiINMhsToFH(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFH(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FH
        public OutPutApi UpdatePresensiOUTMhsToFH(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFH(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToFH(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFH(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FISIP
        public OutPutApi InsertPresensiINMhsToFISIP(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFISIP(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FISIP
        public OutPutApi UpdatePresensiOUTMhsToFISIP(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFISIP(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToFISIP(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFISIP(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FT
        public OutPutApi InsertPresensiINMhsToFT(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFT(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FT
        public OutPutApi UpdatePresensiOUTMhsToFT(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFT(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToFT(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFT(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FTB
        public OutPutApi InsertPresensiINMhsToFTB(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFTB(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FTB
        public OutPutApi UpdatePresensiOUTMhsToFTB(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFTB(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        public OutPutApi UpdateAnulirMhsToFTB(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFTB(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Presensi Masuk Mahasiswa
        // FTI
        public OutPutApi InsertPresensiINMhsToFTI(int idkelas, string npm, int pertemuan)
        {
            var data = dao.InsertPresensiINMahasiswaToFTI(idkelas, npm, pertemuan);

            output.data = data;

            return output;
        }

        // Presensi Keluar Mahasiswa
        // FTI
        public OutPutApi UpdatePresensiOUTMhsToFTI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdatePresensiOUTMahasiswaToFTI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;


        }

        public OutPutApi UpdateAnulirMhsToFTI(int idkelas, string npm, int pertemuan, string status)
        {
            var data = dao.UpdateAnulirMahasiswaToFTI(idkelas, npm, pertemuan, status);

            output.data = data;

            return output;
        }

        // Dosen Mengeluarkan Mahasiswa Yang Hadir Dengan Menambahkan Jam Keluar
        // SPKP
        public OutPutApi UpdateOUTMahasiswa(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswa(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FBE
        public OutPutApi UpdateOUTMahasiswaToFBE(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFBE(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FH
        public OutPutApi UpdateOUTMahasiswaToFH(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFH(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FISIP
        public OutPutApi UpdateOUTMahasiswaToFISIP(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFISIP(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FT
        public OutPutApi UpdateOUTMahasiswaToFT(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFT(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FTB
        public OutPutApi UpdateOUTMahasiswaToFTB(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFTB(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FTI
        public OutPutApi UpdateOUTMahasiswaToFTI(int idkelas, int pertemuan)
        {
            var data = dao.UpdateOUTMahasiswaToFTI(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // Dosen Mengeluarkan Mahasiswa Yang Tidak Hadir Dengan Generate Dari Tabel KRS
        // SPKP
        public OutPutApi InsertOUTMahasiswaTidakHadir(int idkelas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToKSI(idkelas, pertemuan);

            output.data = data;

            return output;
        }

        // FBE
        public OutPutApi InsertOUTMahasiswaTidakHadirToFBE(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFBE(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // FH
        public OutPutApi InsertOUTMahasiswaTidakHadirToFH(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFH(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // FISIP
        public OutPutApi InsertOUTMahasiswaTidakHadirToFISIP(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFISIP(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // FT
        public OutPutApi InsertOUTMahasiswaTidakHadirToFT(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFT(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // FTB
        public OutPutApi InsertOUTMahasiswaTidakHadirToFTB(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFTB(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // FTI
        public OutPutApi InsertOUTMahasiswaTidakHadirToFTI(int idkelas, int idkelasfakultas, int pertemuan)
        {
            var data = dao.InsertOUTMahasiswaTidakHadirToFTI(idkelas, idkelasfakultas, pertemuan);

            output.data = data;

            return output;
        }

        // Cadangan

        // Mendapatkan Semua Kelas
        // public OutPutApi ListAllKelasDsn(string npp)
        // {
        //     var data = dao.GetAllListKelasDosen(npp);

        //     output.data = data;

        //     return output;
        // }

        // Mendapatkan Semua Kelas Mahasiswa 
        // public OutPutApi ListAllKelasMhs(string npm)
        // {
        //     var data = dao.GetAllListKelasMahasiswa(npm);

        //     output.data = data;

        //     return output;
        // }
    }
}