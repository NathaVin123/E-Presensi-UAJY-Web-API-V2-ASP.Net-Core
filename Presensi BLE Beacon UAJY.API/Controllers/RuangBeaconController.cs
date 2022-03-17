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
    public class RuangBeaconController : ControllerBase
    {
        private RuangBeaconBM bm;

        public RuangBeaconController()
        {
            bm = new RuangBeaconBM();
        }

        [AllowAnonymous]
        public ActionResult Get()
        {
            try
            {
                var data = bm.RuangBeacon();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Menambahkan Data Beacon Ke Server
        [AllowAnonymous]
        [HttpPost("Tambah")]
        public ActionResult TambahBcn([FromForm] UserTambahBeacon utb)
        {
            OutPutApi output = new OutPutApi();
            try
            {
                var data = bm.TambahBeacon(utb.UUID, utb.NAMA_DEVICE, utb.JARAK_MIN, utb.MAJOR, utb.MINOR);

                output.data = "Data Beacon Berhasil Ditambahkan";
                return Ok(output);
            }
            catch (Exception ex)
            {
                output.error = "Data Beacon Gagal Ditambahkan";
                return BadRequest(ex.Message);
            }
        }

        // Tampil Data Beacon
        [AllowAnonymous]
        [HttpGet("Tampil")]
        public ActionResult ListBcn()
        {

            try
            {
                var data = bm.ListBeacon();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Ubah Data Beacon
        [AllowAnonymous]
        [HttpPut("Ubah")]
        public ActionResult UpdateBcn([FromForm] UserUpdateBeacon uub)
        {
            OutPutApi output = new OutPutApi();
            try
            {
                var data = bm.UpdateBeacon(uub.UUID, uub.NAMA_DEVICE, uub.JARAK_MIN, uub.MAJOR, uub.MINOR);
                output.data = "Data Beacon Berhasil Diubah";
                return Ok(output);
            }
            catch (Exception ex)
            {
                output.error = "Data Beacon Gagal Diubah";
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("NamaDevice")]
        public ActionResult ListRngnDevice([FromForm] UserListRuanganNamaDevice ulrnd)
        {
            try
            {
                var data = bm.ListRuanganNamaDevice(ulrnd.RUANG);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Tampil Ruangan Yang Terpasang Beacon
        [AllowAnonymous]
        [HttpGet("TampilRuangan")]
        public ActionResult ListRngn()
        {
            try
            {
                var data = bm.ListRuangan();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Tampil Yang Terpasang Beacon Dengan Tambahan Atribut
        [AllowAnonymous]
        [HttpGet("TampilDetailRuangan")]
        public ActionResult ListDetailRngn()
        {
            try
            {
                var data = bm.ListDetailRuangan();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Mengubah Beacon Pada Ruangan
        [AllowAnonymous]
        [HttpPut("UbahRuangBeacon")]
        public ActionResult UpdateRuangBcn([FromForm] UserUpdateRuangBeacon uurb)
        {
            OutPutApi output = new OutPutApi();
            try
            {
                if(uurb.RUANG != null && uurb.NAMA_DEVICE != null)
                {
                    var data = bm.UpdateRuangBeacon(uurb.RUANG, uurb.NAMA_DEVICE);
                    output.data = "Data Ruangan Berhasil Diubah";
                    return Ok(output);
                }
                else
                {
                    output.error = "Data Ruangan Gagal Diubah";
                    return Ok(output);
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Lepas Beacom Pada Ruangan
        [AllowAnonymous]
        [HttpPut("LepasRuangBeacon")]
        public ActionResult UpdateLepasRuangBcn([FromForm] UserUpdateLepasRuangBeacon uurb)
        {
            OutPutApi output = new OutPutApi();
            try
            {
                if (uurb.RUANG != null)
                {
                    var data = bm.UpdateLepasRuangBeacon(uurb.RUANG);
                    output.data = "Data Ruangan Berhasil Diubah";
                    return Ok(output);
                }
                else
                {
                    output.error = "Data Ruangan Gagal Diubah";
                    return Ok(output);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}