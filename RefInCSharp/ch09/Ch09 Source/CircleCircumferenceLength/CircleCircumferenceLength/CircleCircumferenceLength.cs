using System;

namespace RefactoringInCSharpAndASP.Chapter9
{
    public struct Point
    {
        public double X;
        public double Y;
    }

    class CircleCircumferenceLength
    {
        static void Main(string[] args)
        {            
            Circle circle = new Circle();
            circle.Center = InputPoint("circle center");
            circle.PointOnCircumference = InputPoint("point on circumference");
            //calculate and display the length of circumference
            Console.WriteLine("The length of circle "
                + "circumference is:");
            double lengthOfCircumference = circle.CalculateCircumferenceLength();
            Console.WriteLine(lengthOfCircumference);
            WaitForUserToClose();
        }

        private static Point InputPoint(String pointName)
        {
            Point point = new Point();
            Console.WriteLine("Enter X coordinate " +
                "of " + pointName + " point");
            point.X = Double.Parse(Console.In.ReadLine());
            Console.WriteLine("Enter Y coordinate " +
                "of " + pointName + " point");
            point.Y = Double.Parse(Console.In.ReadLine());
            return point;
        }

        private static void WaitForUserToClose()
        {
            Console.Read();
        }
    }
}
