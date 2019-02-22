using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NBodySim.Core;

namespace NBodySim.API.Controllers
{
    public class APIController : Controller
    {
        static PhysicsEngine2D PhysicsEngine2 { get; set; }

        static PhysicsEngine3D PhysicsEngine3D { get; set; }

        static double GC = 6.67 * 0.000000000001;
        static int Count = 100;
        static double MinMass = 10;
        static double MaxMass = 40 * 1000 * 1000 * 10;
        static double BoundingBox = 10;

        static APIController()
        {
            PhysicsEngine2 = new PhysicsEngine2D(GC, Count);
            PhysicsEngine2.Randomize(MinMass, MaxMass, BoundingBox);
            PhysicsEngine3D = new PhysicsEngine3D(1, 5);
            PhysicsEngine3D.Randomize(0, 1, 10);
        }

        [Route("/api/reset2")]
        [HttpPost]
        public IActionResult Reset2()
        {
            PhysicsEngine2 = new PhysicsEngine2D(GC, Count);
            PhysicsEngine2.Randomize(MinMass, MaxMass, BoundingBox);
            return Ok();
        }
        
        [Route("/api/status2")]
        public IActionResult Status2()
        {
            return Content(JsonConvert.SerializeObject(PhysicsEngine2.Particles));
        }

        [Route("/api/next2")]
        public IActionResult Next2()
        {
            PhysicsEngine2.Next();
            return Content(JsonConvert.SerializeObject(PhysicsEngine2.Particles));
        }
    }
}