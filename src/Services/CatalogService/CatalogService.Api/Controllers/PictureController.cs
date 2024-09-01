using CatalogService.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly CatalogContext catalogContext;

        public PictureController(IWebHostEnvironment env, CatalogContext catalogContext)
        {
            this.env = env;
            this.catalogContext = catalogContext;
        }

        //[HttpGet]
        //[Route("api/v1/catalog/items/{catlogItemId:int}/pic")]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> GetImageAsync(int catalogItemId)
        //{
        //    if (catalogItemId == 0)
        //        return BadRequest();

        //    var item = await catalogContext.CatalogItems.SingleOrDefaultAsync(ci => ci.Id == catalogItemId);
            
        //    if (item != null)
        //    {
        //        var webRoot = env.WebRootPath;
        //        var path = Path.Combine(webRoot, item.PictureFileName);

        //        string imageFileExtension = Path.GetExtension(item.PictureFileName);
        //        string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

        //        var buffer = await System.IO.File.ReadAllBytesAsync(path);

        //        return File(buffer, mimetype);
        //    }
        //    return NotFound();
        //}

    }
}
