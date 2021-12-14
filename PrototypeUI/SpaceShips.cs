using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Ardalis.SmartEnum;

namespace PrototypeUI
{
    class Tests
    {
        private static void V()
        {
            //SpaceShips.Battleship.Value.
            //
        }

    }

    public struct A
    {
        public StarShipsTypes Types;
    }

    public enum StarShipsTypes
    {
        Battleship,
        Frigate
    }

    public enum StarShipsModules
    {
        Weapon,
        Shields
    }

    public sealed class SpaceShips: SmartEnum<SpaceShips>
    {
        public static readonly SpaceShips Battleship = new SpaceShips("Battleship", 1, SpaceShipModule.AllModules);
        public static readonly SpaceShips Frigate = new SpaceShips("Frigate", 1, SpaceShipModule.AllModules);

        public List<SpaceShipModule> Modules { get; set; }

        public SpaceShips(string name, int cannons, List<SpaceShipModule> modules) : base(name, cannons)
        {
            Modules = modules;
        }

    }

    public sealed class SpaceShipModule : SmartEnum<SpaceShipModule>
    {
        public static List<SpaceShipModule> AllModules { get; } = new List<SpaceShipModule>();

        public static readonly SpaceShipModule Shields = new SpaceShipModule("Shields", 100);
        public static readonly SpaceShipModule Weapon = new SpaceShipModule("Weapon", 20);

        private SpaceShipModule(string name, int cannons) : base(name, cannons)
        {
            AllModules.Add(this);
        }
    }
}