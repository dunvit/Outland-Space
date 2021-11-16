namespace Universe.Geometry
{
    public static class GeometryExtensions
    {
        public static float To360Degrees(this float angle)
        {
            if (angle > 360) angle = angle - 360;
            if (angle < 0) angle = 360 + angle;

            return angle;
        }
    }
}
