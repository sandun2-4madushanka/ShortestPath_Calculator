using Amplifyn_Test_App.Models;

namespace Amplifyn_Test_App.Data
{
    public static class GraphData
    {
        public static List<Node> GetGraph()
        {
            var a = new Node { Name = "A" };
            var b = new Node { Name = "B" };
            var c = new Node { Name = "C" };
            var d = new Node { Name = "D" };
            var e = new Node { Name = "E" };
            var f = new Node { Name = "F" };
            var g = new Node { Name = "G" };
            var h = new Node { Name = "H" };
            var i = new Node { Name = "I" };

            // Connections
            a.Edges.Add(new Edge { ToNode = b, Distance = 4 });
            b.Edges.Add(new Edge { ToNode = a, Distance = 4 });
            a.Edges.Add(new Edge { ToNode = c, Distance = 6 });
            c.Edges.Add(new Edge { ToNode = a, Distance = 6 });

            b.Edges.Add(new Edge { ToNode = f, Distance = 2 });
            f.Edges.Add(new Edge { ToNode = b, Distance = 2 });

            c.Edges.Add(new Edge { ToNode = d, Distance = 8 });
            d.Edges.Add(new Edge { ToNode = c, Distance = 8 });

            d.Edges.Add(new Edge { ToNode = e, Distance = 4 });
            e.Edges.Add(new Edge { ToNode = d, Distance = 4 });

            e.Edges.Add(new Edge { ToNode = e, Distance = 3 });
            e.Edges.Add(new Edge { ToNode = b, Distance = 2 }); // Not bidirectional

            e.Edges.Add(new Edge { ToNode = i, Distance = 8 });
            i.Edges.Add(new Edge { ToNode = e, Distance = 8 });

            d.Edges.Add(new Edge { ToNode = g, Distance = 1 });
            g.Edges.Add(new Edge { ToNode = d, Distance = 1 });

            f.Edges.Add(new Edge { ToNode = g, Distance = 4 });
            g.Edges.Add(new Edge { ToNode = f, Distance = 4 });

            f.Edges.Add(new Edge { ToNode = h, Distance = 6 });
            h.Edges.Add(new Edge { ToNode = f, Distance = 6 });

            h.Edges.Add(new Edge { ToNode = g, Distance = 5 });
            g.Edges.Add(new Edge { ToNode = h, Distance = 5 });

            g.Edges.Add(new Edge { ToNode = i, Distance = 5 });
            i.Edges.Add(new Edge { ToNode = g, Distance = 5 });

            return new List<Node> { a, b, c, d, e, f, g, h, i };
        }
    }
}
