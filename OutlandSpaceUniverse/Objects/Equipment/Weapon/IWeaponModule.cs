namespace Universe.Objects.Equipment.Weapon
{
    public interface IWeaponModule
    {
        int AmmoId { get; set; }

        int BaseAccuracy { get; set; }

        string Shot(long targetId);
    }
}