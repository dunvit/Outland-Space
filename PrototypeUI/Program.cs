using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototypeUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Debug.WriteLine("Roles:");
            foreach (var role in Role.List())
            {
                Debug.WriteLine($"Role: {role.Name} ({role.Value})");
            }


            Debug.WriteLine("Roles 2:");

            foreach (var role in Role.AllRoles)
            {
                Debug.WriteLine($"Role: {role.Name} ({role.Value})");
            }

            Debug.WriteLine("Job Titles:");

            foreach (var title in JobTitle.AllTitles)
            {
                Debug.WriteLine($"Title: {title.Name} ({title.Value})");
            }

            Debug.WriteLine("--Smart Enums--");
            Debug.WriteLine("Smart Foo:");
            foreach (var smartFoo in SmartFoo.List)
            {
                Debug.WriteLine($"Foo: {smartFoo}");
            }
            Debug.WriteLine("Smart Bar:");
            foreach (var smartBar in SmartBar.List)
            {
                Debug.WriteLine($"Bar: {smartBar}");
            }
            Debug.WriteLine("Smart Baz:");
            foreach (var smartBaz in SmartBaz.List)
            {
                Debug.WriteLine($"Baz: {smartBaz}");
            }

            var module = SpaceShipModules.Shields;

            var xxx = SpaceShipModules.Weapon.Value;

            var xx = WeaponModules.Missiles;

            var battleship = SpaceShips.Battleship;

            var x = battleship.Value;

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    
}
