using System;
using System.Linq;
using Universe.Geometry;
using Universe.Session;

namespace OutlandSpaceClient.Tools
{
    public class OuterSpace
    {
        public event Action<int> OnChangeActiveObject;
        public event Action<int> OnChangeSelectedObject;

        private int _activeObjectId;
        private int _selectedObjectId;

        public Point MouseCoordinates { get; private set; }

        public void Refresh(IGameSessionData gameSession, Point coordinates, MouseArguments type)
        {
            MouseCoordinates = coordinates;

            var objectsInRange = gameSession.GetCelestialObjectsByDistance(coordinates, 20).Where(celestialObject =>
                celestialObject.Id != gameSession.GetPlayerSpaceShip().Id).ToList();

            if (objectsInRange.Count == 0) return;

            var id = objectsInRange.First().Id;

            switch (type)
            {
                case MouseArguments.LeftClick:
                    //if (_selectedObjectId == id) return;
                    _selectedObjectId = id;
                    OnChangeSelectedObject?.Invoke(id);
                    break;

                case MouseArguments.Move:
                    if (_activeObjectId == id) return;
                    _activeObjectId = id;
                    OnChangeActiveObject?.Invoke(id);
                    break;
            }
        }

        public void ClearActiveObject()
        {
            _activeObjectId = 0;
        }
    }
}
