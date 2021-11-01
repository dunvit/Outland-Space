using Engine;
using NUnit.Framework;
using System;

namespace OutlandSpaceEngine.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void BaseCommandThrowExceptionIfOwnerIdIsNullOrEmpty()
        {
            var json = "{ \"OwnerId\":  \"\", \"TypeId\":  \"" + CommandTypes.Fire.ToInt() + "\", \"TargetId\":  \"2000\", \"ModuleId\":  \"3000\"}";

            // Assert

            Assert.Throws<ArgumentException>(() => new Command(json));
        }

        [Test]
        public void BaseCommandThrowExceptionIfCommandTypeIsNullOrEmpty()
        {
            var json = "{ \"OwnerId\":  \"200\", \"TypeId\":  \"\", \"TargetId\":  \"2000\", \"ModuleId\":  \"3000\"}";

            // Assert

            Assert.Throws<ArgumentException>(() => new Command(json));
        }

        [Test]
        public void BaseCommandThrowExceptionIfTargetIdIsNullOrEmpty()
        {
            var json = "{ \"OwnerId\":  \"1000\", \"TypeId\":  \"" + CommandTypes.Fire.ToInt() + "\", \"TargetId\":  \"\", \"ModuleId\":  \"3000\"}";

            // Assert

            Assert.Throws<ArgumentException>(() => new Command(json));
        }

        [Test]
        public void BaseCommandThrowExceptionIfModuleIdIsNullOrEmpty()
        {
            var json = "{ \"OwnerId\":  \"1000\", \"TypeId\":  \"" + CommandTypes.Fire.ToInt() + "\", \"TargetId\":  \"2000\", \"ModuleId\":  \"\"}";

            // Assert

            Assert.Throws<ArgumentException>(() => new Command(json));
        }

        [Test]
        public void BaseCommandThrowExceptionIfCommandTypeWrong()
        {
            var json = "{ \"OwnerId\":  \"100\", \"TypeId\":  \"-10\", \"TargetId\":  \"2000\", \"ModuleId\":  \"3000\"}";

            // Assert

            Assert.Throws<ArgumentException>(() => new Command(json));
        }

        [Test]
        public void BaseCommandHasIdAfterCreationFromJson()
        {
            var json ="{ \"OwnerId\":  \"1000\", \"TypeId\":  \"" + CommandTypes.Fire.ToInt() + "\", \"TargetId\":  \"2000\", \"ModuleId\":  \"3000\"}";
            
            // Act
            
            var command = new Command(json);

            // Assert

            Assert.That(command.Type, Is.EqualTo(CommandTypes.Fire));
            Assert.That(command.CelestialObjectId, Is.EqualTo(1000));
            Assert.That(command.TargetCelestialObjectId, Is.EqualTo(2000));
            Assert.That(command.ModuleId, Is.EqualTo(3000));
        }
    }
}
