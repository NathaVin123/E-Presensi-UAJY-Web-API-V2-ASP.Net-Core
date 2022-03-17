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
    public class JadwalMhsController : ControllerBase
    {
        private JadwalMhsBM bm;

        public JadwalMhsController()
        {
            bm = new JadwalMhsBM();
        }

        // Jadwal Mahasiswa

        [AllowAnonymous]
        [HttpPost("PostGetAll")]
        public ActionResult JadwalMhs([FromForm] UserJadwalMhs ujm)
        {
            try
            {
                var data = bm.JadwalMhs(ujm.NPM);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Jadwal Dosen

        [AllowAnonymous]
        [HttpPost("PostGetAllDosen")]
        public ActionResult JadwalDsn([FromForm] UserJadwalDsn ujd)
        {
            try
            {
                var data = bm.JadwalDsn(ujd.NPP);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}