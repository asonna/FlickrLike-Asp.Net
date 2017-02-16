using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlickrLike.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Image(string name, byte[] photo, ApplicationUser user)
        {
            Name = name;
            Photo = photo;
            User = user;
        }
        public Image() { }
    }
}
