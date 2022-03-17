// using Presensi_BLE_Beacon_UAJY.API.BM;
// using Presensi_BLE_Beacon_UAJY.API.Model;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using System;

// namespace Presensi_BLE_Beacon_UAJY.API.Controllers
// {
//     [Serializable]
//     [Route("api/[controller]")]
//     [ApiController]
//     public class MahasiswaRuangKelasController : ControllerBase
//     {
//         private MahasiswaRuangKelasBM bm;

//         public MahasiswaRuangKelasController()
//         {
//             bm = new MahasiswaRuangKelasBM();
//         }

//         [AllowAnonymous]
//         [HttpPost("PostGetAll")]
//         public ActionResult RuangKelasMhs([FromForm] UserRuangKelasMhs urk)
//         {
//             try
//             {
//                 var data = bm.RuangBeacon(urk.NPM);

//                 return Ok(data);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }