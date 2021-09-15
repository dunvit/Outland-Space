namespace Universe.Modules
{
    public interface IModule
    {
        int Id { get; set; }
        long OwnerId { get; set; }
        string Name { get; set; }
    }
}