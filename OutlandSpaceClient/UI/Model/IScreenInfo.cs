using System.Drawing;

namespace OutlandSpaceClient.UI.Model
{
    public interface IScreenInfo
    {
        PointF Center { get; }
        float Width { get; }
        float Height { get; }
        int DrawInterval { get; set; }
        PointF CenterScreenOnMap { get; set; }

        IMapDrawSettings Settings { get; set; }
    }
}