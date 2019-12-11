namespace PA.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news_group
    {
        [StringLength(200)]
        public long? id { get; set; }

        [StringLength(500)]
        public string name { get; set; }
    }
}
