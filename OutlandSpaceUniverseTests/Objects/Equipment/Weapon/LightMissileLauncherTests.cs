using Engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Weapon;

namespace Tests.Universe.Objects.Equipment.Weapon
{
    [TestFixture]
    public class LightMissileLauncherTests
    {
        [Test]
        public void LightMissileLauncherBaseShotCommandShouldBeCorrect()
        {
            var missileLauncher = EquipmentFactory.Create(1, ModulesType.WeaponModuleLightMissileLauncher);

            var command = ((IWeaponModule)missileLauncher).Shot(201);

            dynamic serverCommand = new JObject();

            serverCommand.ModuleId = missileLauncher.Id;
            serverCommand.OwnerId = 1;
            serverCommand.TypeId = CommandTypes.Fire.ToInt();
            serverCommand.TargetId = 201;

            var expected = serverCommand.ToString(Formatting.None);

            Assert.AreEqual(expected, command);
        }
    }
}
