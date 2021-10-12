﻿using System.Collections.Generic;
using Universe.Geometry;
using Universe.Objects;
using Universe.Session;

namespace Engine
{
    public interface IGameSession: IGameSessionData, IGameSessionExporter
    {
        //CelestialMap SpaceMap { get; set; }

        List<ICelestialObject> GetCelestialObjects();

        ICelestialObject GetCelestialObject(int id);

        void FinishTurn();

        void GenerateEmptySpaceMap();

        void GenerateBaseSpaceMap();

        void AddCelestialObjects(List<ICelestialObject> celestialObjects);

        void AddCelestialObject(ICelestialObject celestialObject);

        void ReplaceCelestialObjects(List<ICelestialObject> celestialObjects);

        void Block();

        void UnBlock();

        bool IsBlocked();

        Point GetTurnLocation(int celestialObjectId, int step);
    }
}