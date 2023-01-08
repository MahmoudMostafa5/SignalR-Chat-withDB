namespace SignalRChatDay1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column("Message")]
        [StringLength(50)]
        public string Message1 { get; set; }

        public DateTime? Date { get; set; }
    }
}
