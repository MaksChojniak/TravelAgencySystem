using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.DataModel
{
    public class Room
    {
        public Guid Id { get; set; }
        public Guid AccomodationId { get; set; }
        public Guid ReservationId { get; set; }
        public bool IsAvaiable { get; set; }
        public int Floor {  get; set; }
        public int Number {  get; set; }
        public int SpaceCount { get; set; }
        public double Price { get; set; }
    }
}
