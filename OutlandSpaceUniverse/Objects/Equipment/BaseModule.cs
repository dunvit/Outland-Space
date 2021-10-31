using System;
using Universe.Objects.Equipment;

namespace Universe.Objects
{
    [Serializable()]
    public abstract class BaseModule
    {
        public int Id { get; set; }
        public long OwnerId { get; set; }

        /// <summary>
        /// Property for automatic execute module after finish it work.
        /// </summary>
        public bool IsAutoRun { get; set; } = false;
        public string Name { get; set; }

        public double ReloadTime { get; set; }
        public double Reloading { get; set; }

        public Category Category { get; set; }
        public double ActivationCost { get; set; }
    }
}
