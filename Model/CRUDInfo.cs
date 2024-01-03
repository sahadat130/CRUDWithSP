using System.ComponentModel.DataAnnotations;

namespace CRUDWithSP.Model
{
    public partial class CRUDInfo
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; }
        public string Mobile { get; set; }
    }
}