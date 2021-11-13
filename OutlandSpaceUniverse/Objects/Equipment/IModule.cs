namespace Universe.Objects.Equipment
{
    public interface IModule
    {
        int Id { get; set; }
        long OwnerId { get; set; }
        string Name { get; set; }
        ModuleCategory Category { get; set; }
        bool IsAutoRun { get; set; }
        double ActivationCost { get; set; }

        int ArmorActual { get; set; }
        int ArmorDesign { get; set; }

        int StructureActual { get; set; }
        int StructureDesign { get; set; }

        ModuleStatus Status { get; }

        void Hit(int damage);
    }
}