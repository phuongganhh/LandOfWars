namespace PA.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(200)]
        public long? id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public long? new_group_id { get; set; }

        [StringLength(500)]
        public string title { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public bool? active { get; set; }

        public DateTime? create_time { get; set; }

        public string body_text { get; set; }

        [Column(TypeName = "text")]
        public string body_html { get; set; }
        
        public bool? pin { get; set; }
        public long views { get; set; }
        public string image { get; set; }
    }
}
