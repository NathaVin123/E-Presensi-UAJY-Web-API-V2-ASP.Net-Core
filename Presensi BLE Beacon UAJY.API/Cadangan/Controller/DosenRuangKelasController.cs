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
//     public class DosenRuangKelasController : ControllerBase
//     {
//         private DosenRuangKelasBM bm;

//         public DosenRuangKelasController()
//         {
//             bm = new DosenRuangKelasBM();
//         }

//         [AllowAnonymous]
//         [HttpPost("PostGetAll")]
//         public ActionResult RuangKelasDsn([FromForm] UserRuangKelasDsn urk)
//         {
//             try
//             {
//                 var data = bm.RuangBeacon(urk.NPP);

//                 return Ok(data);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }