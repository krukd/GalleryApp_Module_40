using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gallery_App.Data.Tables
{

    [Table("Photos")]
    public class Photo
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
    }
}
