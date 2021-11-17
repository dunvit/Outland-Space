using System;
using System.Collections.Generic;
using System.Text;
using OutlandSpaceClient.Tools;
using Universe.Geometry;
using Updater;

namespace OutlandSpaceClient
{
    public interface IGameManager: IGameEvents
    {
        void RefreshOuterSpace(Point coordinates, MouseArguments type);

        GameState State { get; set; }
    }
}
