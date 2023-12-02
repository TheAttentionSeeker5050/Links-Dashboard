using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProject3.Models
{
    // ('Technology'), ('School'), ('Play'), ('Data');
    public enum Category
    {
        Technology, School, Play, Data
    }

    public class LinkModel
    {
        // fields: linkId, faviconPath, linkPath, categoryId foreign key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; } = 0;
        public string FaviconPath { get; set; } = "";
        public string LinkPath { get; set; } = "";
        public string LinkName { get; set; } = "";
        public Category? LinkCategory { get; set; } = null;
    }

}
