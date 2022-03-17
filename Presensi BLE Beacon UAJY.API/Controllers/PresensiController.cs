using Presensi_BLE_Beacon_UAJY.API.BM;
using Presensi_BLE_Beacon_UAJY.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presensi_BLE_Beacon_UAJY.API.Controllers
{
    [Serializable]
    [Route("api/[controller]")]
    [ApiController]
    public class PresensiController : ControllerBase
    {
        private PresensiBM bm;

        public PresensiController()
        {
            bm = new PresensiBM();
        }

        // Mendapatkan Kelas Dosen Sesuai NPP By Waktu Sesi
        [AllowAnonymous]
        [HttpPost("PostGetListKelas")]
        public ActionResult ListKelasDsn([FromForm] UserListKelasDsn ulkd)
        {
            try
            {
                var data = bm.ListKelasDsn(ulkd.NPP);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // Mendapatkan Kelas Mahasiswa Sesuai NPP By Waktu Sesi
        [AllowAnonymous]
        [HttpPost("PostGetListKelasMhs")]
        public ActionResult ListKelasMhs([FromForm] UserListKelasMhs ulkm)
        {
            try
            {
                var data = bm.ListKelasMhs(ulkm.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Dosen Membuka Kelas Dengan Mengupdate Status IS_BUKA_PRESENSI
        [AllowAnonymous]
        [HttpPut("BukaPresensiDosen")]
        public ActionResult BukaKelasDsn([FromForm] UserBukaPresensiDosen ubpd)
        {
            try
            {
                var data = bm.DosenBukaPresensi(ubpd.ID_KELAS, ubpd.IS_BUKA_PRESENSI, ubpd.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Menampilkan Peserta Kelas Mahasiswa Yang Ada Di Kelas Dosen
        [AllowAnonymous]
        [HttpPost("PostGetListPesertaKelas")]
        public ActionResult ListKelasMhs([FromForm] UserListPesertaKelas ulpk)
        {
            try
            {
                var data = bm.ListPesertaKelasDsn(ulpk.ID_KELAS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetListMahasiswaManual")]
        public ActionResult ListMahasiswaManuak([FromForm] UserMahasiswaManual umm)
        {
            try
            {
                var data = bm.ListMahasiswaManual(umm.ID_KELAS, umm.PERTEMUAN_KE, umm.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Menampilkan Kehadiran Mahasiswa Yang Ada Di Kelas Dosen
        [AllowAnonymous]
        [HttpPost("PostGetListKehadiranPesertaKelas")]
        public ActionResult ListKehadiranKelasMhs([FromForm] UserListKehadiranPesertaKelas ulkpk)
        {
            try
            {
                var data = bm.ListKehadiranPesertaKelasDsn(ulkpk.ID_KELAS, ulkpk.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetListKetidakhadairanPesertaKelas")]
        public ActionResult ListKetidakhadiranKelasMhs([FromForm] UserListKehadiranPesertaKelas ulkpk)
        {
            try
            {
                var data = bm.ListKetidakhadiranPesertaKelasDsn(ulkpk.ID_KELAS, ulkpk.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostGetListIzinPesertaKelas")]
        public ActionResult ListIzinKelasMhs([FromForm] UserListKehadiranPesertaKelas ulkpk)
        {
            try
            {
                var data = bm.ListIzinPesertaKelasDsn(ulkpk.ID_KELAS, ulkpk.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk - Keluar Dosen

        [AllowAnonymous]
        [HttpPut("PutPresensiDosen")]
        public ActionResult UpdatePresensiDsn([FromForm] UserUpdatePresensiDosen uupd)
        {

            try
            {

                var data = bm.UpdatePresensiDosen(uupd.KETERANGAN, uupd.MATERI, uupd.ID_KELAS, uupd.PERTEMUAN_KE);

                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Presensi Dosen Masuk
        // SPKP
        [AllowAnonymous]
        [HttpPut("PutINPresensiDosen")]
        public ActionResult UpdateINPresensiDsn([FromForm] UserUpdateINPresensiDosen uuipd)
        {
            try
            {
                var data = bm.UpdateINPresensiDosen(uuipd.ID_KELAS, uuipd.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Dosen Keluar
        // SPKP
        [AllowAnonymous]
        [HttpPut("PutOUTPresensiDosen")]
        public ActionResult UpdateOUTPresensiDsn([FromForm] UserUpdateOUTPresensiDosen uuopd)
        {

            try
            {

                var data = bm.UpdateOUTPresensiDosen(uuopd.KETERANGAN, uuopd.MATERI, uuopd.ID_KELAS, uuopd.PERTEMUAN_KE);

                return Ok(data);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Presensi Masuk - Keluar Mahasiswa
        [AllowAnonymous]
        [HttpPost("PostMhs")]
        public ActionResult InsertPresensiMhs([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhs(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFBE")]
        public ActionResult InsertPresensiMhsToFBE([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFBE(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFT")]
        public ActionResult InsertPresensiMhsToFT([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFT(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFISIP")]
        public ActionResult InsertPresensiMhsToFISIP([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFISIP(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFH")]
        public ActionResult InsertPresensiMhsToFH([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFH(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFTB")]
        public ActionResult InsertPresensiMhsToFTB([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFTB(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("PostMhsFTI")]
        public ActionResult InsertPresensiMhsToFTI([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiMhsToFTI(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // SPKP
        [AllowAnonymous]
        [HttpPost("PostInMhsToKSI")]
        public ActionResult InsertINPresensiMhsToKSI([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToKSI(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // SPKP
        [AllowAnonymous]
        [HttpPut("PutOutMhsToKSI")]
        public ActionResult UpdateOUTPresensiMhsToKSI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToKSI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToKSI")]
        public ActionResult UpdateAnulirMhsToKSI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToKSI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FBE
        [AllowAnonymous]
        [HttpPost("PostInMhsToFBE")]
        public ActionResult InsertINPresensiMhsToFBE([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFBE(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FBE
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFBE")]
        public ActionResult UpdateOUTPresensiMhsToFBE([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFBE(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFBE")]
        public ActionResult UpdateAnulirMhsToFBE([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFBE(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FH
        [AllowAnonymous]
        [HttpPost("PostInMhsToFH")]
        public ActionResult InsertINPresensiMhsToFH([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFH(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FH
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFH")]
        public ActionResult UpdateOUTPresensiMhsToFH([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFH(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFH")]
        public ActionResult UpdateAnulirMhsToFH([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFH(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FISIP
        [AllowAnonymous]
        [HttpPost("PostInMhsToFISIP")]
        public ActionResult InsertINPresensiMhsToFISIP([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFISIP(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FISIP
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFISIP")]
        public ActionResult UpdateOUTPresensiMhsToFISIP([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFISIP(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFISIP")]
        public ActionResult UpdateAnulirMhsToFISIP([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFISIP(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FT
        [AllowAnonymous]
        [HttpPost("PostInMhsToFT")]
        public ActionResult InsertINPresensiMhsToFT([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFT(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FT
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFT")]
        public ActionResult UpdateOUTPresensiMhsToFT([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFT(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFT")]
        public ActionResult UpdateAnulirMhsToFT([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFT(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FTB
        [AllowAnonymous]
        [HttpPost("PostInMhsToFTB")]
        public ActionResult InsertINPresensiMhsToFTB([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFTB(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FTB
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFTB")]
        public ActionResult UpdateOUTPresensiMhsToFTB([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFTB(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFTB")]
        public ActionResult UpdateAnulirMhsToFTB([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFTB(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Masuk Mahasiswa
        // FTI
        [AllowAnonymous]
        [HttpPost("PostInMhsToFTI")]
        public ActionResult InsertINPresensiMhsToFTI([FromForm] UserInsertPresensiINToKSI presensiin)
        {
            try
            {
                var data = bm.InsertPresensiINMhsToFTI(presensiin.ID_KELAS, presensiin.NPM, presensiin.PERTEMUAN);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Presensi Keluar Mahasiswa
        // FTI
        [AllowAnonymous]
        [HttpPut("PutOutMhsToFTI")]
        public ActionResult UpdateOUTPresensiMhsToFTI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdatePresensiOUTMhsToFTI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut("PutAnulirMhsToFTI")]
        public ActionResult UpdateAnulirMhsToFTI([FromForm] UserUpdatePresensiOUTToKSI presensiout)
        {
            try
            {
                var data = bm.UpdateAnulirMhsToFTI(presensiout.ID_KELAS, presensiout.NPM, presensiout.PERTEMUAN, presensiout.STATUS);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Dosen Mengeluarkan Mahasiswa Yang Hadir Dengan Menambahkan Jam Keluar
        // SPKP
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswa")]
        public ActionResult UpdateOutMhs([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswa(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FBE
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFBE")]
        public ActionResult UpdateOutMhsToFBE([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFBE(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FH
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFH")]
        public ActionResult UpdateOutMhsToFH([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFH(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FISIP
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFISIP")]
        public ActionResult UpdateOutMhsToFISIP([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFISIP(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FT
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFT")]
        public ActionResult UpdateOutMhsToFT([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFT(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FTB
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFTB")]
        public ActionResult UpdateOutMhsToFTB([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFTB(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FTI
        [AllowAnonymous]
        [HttpPut("PutOutMahasiswaToFTI")]
        public ActionResult UpdateOutMhsToFTI([FromForm] UserUpdateOutMahasiswa uuom)
        {
            try
            {
                var data = bm.UpdateOUTMahasiswaToFTI(uuom.ID_KELAS, uuom.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Dosen Mengeluarkan Mahasiswa Yang Tidak Hadir Dengan Generate Dari Tabel KRS
        // SPKP
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadir")]
        public ActionResult InsertOutMhs([FromForm] UserInsertOutMhsTidakHadir uiomth)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadir(uiomth.ID_KELAS, uiomth.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FBE
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFBE")]
        public ActionResult InsertOutMhsToFBE([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFBE(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FH
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFH")]
        public ActionResult InsertOutMhsToFH([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFH(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FISIP
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFISIP")]
        public ActionResult InsertOutMhsToFISIP([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFISIP(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FT
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFT")]
        public ActionResult InsertOutMhsToFT([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFT(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FTB
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFTB")]
        public ActionResult InsertOutMhsToFTB([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFTB(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // FTI
        [AllowAnonymous]
        [HttpPost("PostOutMahasiswaTidakHadirToFTI")]
        public ActionResult InsertOutMhsToFTI([FromForm] UserInsertOutMhsTidakHadirFakultas uiomthf)
        {
            try
            {
                var data = bm.InsertOUTMahasiswaTidakHadirToFTI(uiomthf.ID_KELAS,uiomthf.ID_KELAS_FAKULTAS, uiomthf.PERTEMUAN_KE);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Backup
        // Mendapatkan Semua Kelas

        // [AllowAnonymous]
        // [HttpPost("PostGetAllListKelas")]
        // public ActionResult ListAllKelasDsn([FromForm] UserListKelasDsn ulkd)
        // {
        //     try
        //     {
        //         var data = bm.ListAllKelasDsn(ulkd.NPP);

        //         return Ok(data);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }

        // Mendapatkan Semua Kelas Mahasiswa 

        // [AllowAnonymous]
        // [HttpPost("PostGetAllListKelasMhs")]
        // public ActionResult ListAllKelasMhs([FromForm] UserListKelasMhs ulkm)
        // {
        //     try
        //     {
        //         var data = bm.ListAllKelasMhs(ulkm.NPM);

        //         return Ok(data);
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }
    }
}