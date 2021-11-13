using Engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public ModuleCategory Category { get; set; }
        public double ActivationCost { get; set; }

        public int ArmorActual { get; set; }
        public int ArmorDesign { get; set; }
        public int StructureActual { get; set; }
        public int StructureDesign { get; set; }

        public ModuleStatus Status {
            get
            {
                if (StructureActual > 0)
                    return ModuleStatus.Workable;
                else
                    return ModuleStatus.Destroyed;
            }
        }

        public string Shot(long targetId)
        {
            dynamic serverCommand = new JObject();

            serverCommand.ModuleId = Id;
            serverCommand.OwnerId = OwnerId;
            serverCommand.TypeId = CommandTypes.Fire.ToInt();
            serverCommand.TargetId = targetId;

            return serverCommand.ToString(Formatting.None);
        }

        public void Hit(int damage)
        {
            StructureActual -= damage;
        }
    }
}
