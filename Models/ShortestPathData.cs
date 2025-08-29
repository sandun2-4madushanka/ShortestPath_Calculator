namespace Amplifyn_Test_App.Models
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; } = new List<string>();
        public int Distance { get; set; }

        public ShortestPathData(List<string> nodeNames, int distance)
        {
            NodeNames = nodeNames;
            Distance = distance;
        }
    }
}
