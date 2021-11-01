namespace Universe.Objects.Equipment
{
    public interface IModule
    {
        int Id { get; set; }
        long OwnerId { get; set; }
        string Name { get; set; }
        Category Category { get; set; }
        bool IsAutoRun { get; set; }
        double ActivationCost { get; set; }

        
    }
}