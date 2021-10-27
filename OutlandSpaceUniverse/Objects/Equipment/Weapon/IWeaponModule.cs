namespace Universe.Objects.Equipment.Weapon
{
    public interface IWeaponModule
    {
        int AmmoId { get; set; }
        double ReloadTime { get; set; }
        double Reloading { get; set; }
    }
}