using System;
using System.Collections.Generic;
using Universe.Geometry;
using Universe.Objects;
using Universe.Session;

namespace Engine
{
    public interface IGameSession: IGameSessionExporter
    {
        int Id { get; set; }

        int Turn { get; }

        bool IsPause { get; set; }

        string ScenarioName { get; set; }

        bool IsValid { get; set; }

        DateTime LastUpdate { get; set; }

        List<ICelestialObject> GetCelestialObjects();

        ICelestialObject GetCelestialObject(int id);

        void FinishTurn();

        void GenerateEmptySpaceMap();

        void GenerateBaseSpaceMap();

        void GenerateDebugSpaceMap();

        void AddCelestialObjects(List<ICelestialObject> celestialObjects);

        void AddCelestialObject(ICelestialObject celestialObject);

        void ReplaceCelestialObjects(List<ICelestialObject> celestialObjects);

        void Block();

        void UnBlock();

        bool IsBlocked();

        Point GetTurnLocation(int celestialObjectId, int step);
    }
}