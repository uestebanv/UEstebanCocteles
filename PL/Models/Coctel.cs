namespace PL.Models
{
    public class Coctel
    {
        public int IdCoctel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Preparacion { get; set; }
        public string Image { get; set; }
        public string buscar { get; set; }
        public List<object> Cocteles { get; set; }
        public Exception Exception { get; set; }
        public PL.Models.Ingredientes Ingredientes { get; set;}
    }
}
