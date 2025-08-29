using Amplifyn_Test_App.Data;
using Amplifyn_Test_App.Models;
using Amplifyn_Test_App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Amplifyn_Test_App.Controllers
{
    public class PathController : Controller
    {
        private readonly PathFinder _pathFinder = new PathFinder();
        private readonly List<Node> _graph = GraphData.GetGraph();
        public IActionResult Index()
        {
            ViewBag.Nodes = _graph.Select(n => n.Name).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string fromNode, string toNode)
        {
            var result = _pathFinder.ShortestPath(fromNode, toNode, _graph);
            ViewBag.Nodes = _graph.Select(n => n.Name).ToList();
            ViewBag.Result = result;
            return View("Index");
        }
    }
}
