using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Engine.Generation;
using OutlandSpaceCommon;
using Universe.Geometry;
using Universe.Objects;
using Universe.Session;

namespace Engine
{
    [Serializable]
    public class GameSession: IGameSession
    {
        public int Id { get; set; }
        public int Turn { get; private set; }
        public bool IsPause { get; set; }
        public DateTime LastUpdate { get; set; }
        public string ScenarioName { get; set; }
        public bool IsValid { get; set; } = true;
        private bool _isBlocked = false;
        private CelestialMap SpaceMap { get; set; } = new CelestialMap(new List<ICelestialObject>());

        public GameSession()
        {
            Turn = 1;
        }

        public void GenerateEmptySpaceMap()
        {
            SpaceMap = GlobalSpaceMap.GenerateEmpty();
        }

        public void GenerateBaseSpaceMap()
        {
            SpaceMap = GlobalSpaceMap.GenerateBase();
        }

        public void GenerateDebugSpaceMap()
        {
            SpaceMap = GlobalSpaceMap.GenerateDebug();
        }


        public ICelestialObject GetCelestialObject(int id)
        {
            return SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.Id == id);
        }

        public void FinishTurn()
        {
            Turn++;
        }

        

        public List<ICelestialObject> GetCelestialObjects()
        {
            return SpaceMap.GetCelestialObjects().DeepClone();
        }

        public IGameSessionData Export()
        {
            return new SessionDataDto
            {
                Id = Id,
                Turn = Turn,
                IsPause = IsPause,
                ScenarioName = ScenarioName,
                IsValid = IsValid
            };
        }

        public void AddCelestialObjects(List<ICelestialObject> celestialObjects)
        {
            foreach (var celestialObject in celestialObjects)
            {
                SpaceMap.Add(celestialObject);
            }
        }

        public void AddCelestialObject(ICelestialObject celestialObject)
        {
            SpaceMap.Add(celestialObject);
        }

        public void ReplaceCelestialObjects(List<ICelestialObject> celestialObjects)
        {
            SpaceMap.Clear();

            AddCelestialObjects(celestialObjects);
        }

        public void Block()
        {
            _isBlocked = true;
        }

        public void UnBlock()
        {
            _isBlocked = false;
        }

        public bool IsBlocked()
        {
            return _isBlocked;
        }

        public Point GetTurnLocation(int celestialObjectId, int step)
        {
            var celestialObject = SpaceMap.GetCelestialObjects().FirstOrDefault(x => x.Id == celestialObjectId);

            if (celestialObject is null)
            {
                throw new Exception($"Atomic results for turn location object '{celestialObjectId}' not found.");
            }

            var atomicLocation = celestialObject.AtomicLocation.FirstOrDefault(x => x.Item1 == step);

            if (atomicLocation is null)
            {
                throw new Exception($"Atomic results for turn location object '{celestialObjectId}' and step {step} not found.");
            }

            return atomicLocation.Item2;
        }
    }
}