using Engine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Universe.Objects.Equipment;
using Universe.Objects.Equipment.Weapon;

namespace OutlandSpaceUniverse.Tests.Objects.Equipment.Weapon
{
    [TestFixture]
    public class LightMissileLauncherTests
    {
        [Test]
        public void LightMissileLauncherBaseShotCommandShoudBeCorrect()
        {
            var missileLauncher = Factory.Create(1, "WRS5002");

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
