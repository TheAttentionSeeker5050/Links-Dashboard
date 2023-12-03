using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppProject3.Models
{

    /*public enum Category
    {
        Technology, School, Play, Data
    }*/

    public class LinkModel
    {
        // fields: linkId, faviconPath, linkPath, categoryId foreign key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LinkId { get; set; } = 0;
        public string FaviconSrc { get; set; } = "";
        public string LinkLabel { get; set; } = "";
        public string LinkHref { get; set; } = "";
        public bool IsPinned { get; set; } = false;

        public CategoryModel LinkCategory { get; set; } = new CategoryModel();
    }

    // category model
    public class CategoryModel
    {
        // fields: categoryId, categoryName
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } = 0;
        public string CategoryName { get; set; } = "";
    }

}
