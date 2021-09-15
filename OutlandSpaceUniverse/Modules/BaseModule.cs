
using System;

namespace Universe.Modules
{
    [Serializable]
    public class BaseModule
    {
        public int Id { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; }
    }
}
