using System;
using Engine.Generation;
using Universe.Objects.Points;

namespace Engine
{
    public class SessionFactory
    {
        public static IGameSession ProduceSession(int sessionId = -1)
        {
            if (sessionId == -1)
                return EmptySession();

            throw new NotImplementedException();
        }

        private static IGameSession EmptySession()
        {
            var result = new GameSession
            {
                Id = OutlandSpaceCommon.RandomGenerator.GetId(),
                Turn = 1,
                IsPause = true,
                ScenarioName = "Empty session scenario"
            };

            const double centerMap = 1000;
            const int radiusMap = 500;

            var smallAsteroids = RandomFactory.GenerateSmallAsteroids(120, new SpacePoint(centerMap, centerMap), radiusMap);
            var stations = RandomFactory.GenerateStations(4, new SpacePoint(centerMap, centerMap), radiusMap);

            result.SpaceMap.Add(smallAsteroids);
            result.SpaceMap.Add(stations);


            return result;
        }
    }
}