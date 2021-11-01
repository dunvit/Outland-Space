using Newtonsoft.Json.Linq;
using System;

namespace Engine
{
    [Serializable]
    public class Command
    {
        public int Id { get; set; }
        public CommandTypes Type { get; set; }
        public int ModuleId { get; set; }
        public long CelestialObjectId { get; set; }
        public long TargetCelestialObjectId { get; set; }
        public string Body { get; set; }

        public Command(string commandBody)
        {
            try
            {
                CelestialObjectId = (long)JObject.Parse(commandBody)["OwnerId"];
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }

            try
            {
                Type = (CommandTypes)(int)JObject.Parse(commandBody)["TypeId"];
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }            

            if (Enum.IsDefined(typeof(CommandTypes), Type) == false)
            {
                throw new ArgumentException();
            }
            
            try
            {
                TargetCelestialObjectId = (long)JObject.Parse(commandBody)["TargetId"];
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }
            
            try
            {
                ModuleId = (int)JObject.Parse(commandBody)["ModuleId"];
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }

            Body = commandBody;
        }
    }
}
