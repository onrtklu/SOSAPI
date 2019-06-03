namespace SOS.DataObjects.Entities
{
    using SOS.Core.Entities;
    using System;

    public class Event : BaseEntity
    {
        public int? HallID { get; set; }

        public int? PlayID { get; set; }

        public DateTime? EventDate { get; set; }
    }
}
