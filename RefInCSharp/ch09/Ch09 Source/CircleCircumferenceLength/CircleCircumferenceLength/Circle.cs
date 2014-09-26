using System;

namespace RefactoringInCSharpAndASP.Chapter9
{
    public class Circle
    {
        private Point center;
        private Point pointOnCircumference;

        public Point Center
        {
            get { return center; }
            set { center = value; }
        }
        public Point PointOnCircumference
        {
            get { return pointOnCircumference; }
            set { pointOnCircumference = value; }
        }

        public double CalculateCircumferenceLength()
        {
            return 2 * 3.1415 * CalculateRadius();
        }

        private double CalculateRadius()
        {
            return Math.Sqrt(Math.Pow(this.PointOnCircumference.X
                                            - this.Center.X,
                                       2) +
                                 Math.Pow(this.PointOnCircumference.Y
                                            - this.Center.Y,
                                         2)
                             );
        }
    }
}
