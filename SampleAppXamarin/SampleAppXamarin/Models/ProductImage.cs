using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAppXamarin.Models
{
    public class ProductImage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public string UrlThubnail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
