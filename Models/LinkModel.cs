using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProject3.Models
{

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
        public string FaviconSrc { get; set; } = "";
        public string LinkLabel { get; set; } = "";
        public string LinkHref{ get; set; } = "";
        public string LinkName { get; set; } = "";
        public bool IsPinned { get; set; } = false;
        public Category? LinkCategory { get; set; } = null;
    }

}
