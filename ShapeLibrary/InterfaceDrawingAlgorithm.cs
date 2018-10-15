using System.Collections.Generic;

namespace ShapeLibrary
{
    interface InterfaceDrawingAlgorithm
    {
        List<Point> getListPointsUsingDDA();
        List<Point> getListPointsUsingBresenham();
        List<Point> getListPointsUsingMidPoint();
    }
}
