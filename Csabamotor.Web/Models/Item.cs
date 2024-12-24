using System.ComponentModel.DataAnnotations;

namespace Csabamotor.Web.Models
{
    public class Item
    {
        [Key]
        public Int32 Id { get; set; }

        public String Name { get; set; } = null!;
        [DataType(DataType.MultilineText)]
        public String? Description { get; set; }
        public UInt32 Price { get; set; }
        public DateTime UploadTime { get; set; }

        public byte[]? Image { get; set; }
        public Int32 ListId { get; set; }
        public virtual List List { get; set; } = null!;
    }
}
