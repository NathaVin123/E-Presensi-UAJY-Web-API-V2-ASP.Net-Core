// using Presensi_BLE_Beacon_UAJY.API.BM;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Linq;

// namespace Presensi_BLE_Beacon_UAJY.API.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class DsnController : ControllerBase
//     {
//         private DsnBM bm;

//         public DsnController()
//         {
//             bm = new DsnBM();
//         }

//         public ActionResult Get()
//         {
//             try
//             {
//                 var npp = User.Claims
//                         .Where(c => c.Type == "username")
//                             .Select(c => c.Value).SingleOrDefault();

//                 var data = bm.GetDsnProfil(npp);
//                 return Ok(data);
//             }
//             catch (Exception ex)
//             {
//                 return BadRequest(ex.Message);
//             }
//         }
//     }
// }