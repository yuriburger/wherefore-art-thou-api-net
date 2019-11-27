using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System.Diagnostics;

namespace Wherefore.WebApi.Controllers
{
    public class MetaController : BaseApiController
    {
        private readonly IFeatureManager _featureManager;

        public MetaController(IFeatureManagerSnapshot featureManager)
        {
            _featureManager = featureManager;
        }


        [HttpGet("/info")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"{version}, updated: {creationDate}, Beta:{_featureManager.IsEnabled("Beta").ToString()}");
        }
     }
}
