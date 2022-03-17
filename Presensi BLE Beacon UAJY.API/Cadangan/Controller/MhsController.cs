// using Presensi_BLE_Beacon_UAJY.API.BM;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Linq;

// namespace Presensi_BLE_Beacon_UAJY.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class MhsController : ControllerBase
//     {
//         private MhsBM bm;

//         public MhsController()
//         {
//             bm = new MhsBM();
//         }

//         public ActionResult Get()
//         {
//             try
//             {
//                 var npm = User.Claims
//                         .Where(c => c.Type == "username")
//                             .Select(c => c.Value).SingleOrDefault();

//                 var data = bm.GetMhsProfil(npm);
//                 return Ok(data);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }