using System;

namespace RefactoringInCSharpAndASP.Chapter7
{
    struct Point
    {
        public double X;
        public double Y;
    }
    
    class CircleCircumferenceLength
    {
        static void Main(string[] args)
        {
            Point center;
            Point pointOnCircumference;
            //read center coordinates
            Console.WriteLine("Enter X coordinate " + 
                "of circle center");
            center.X = Double.Parse(Console.In.ReadLine());
            Console.WriteLine("Enter Y coordinate " + 
                "of circle center");
            center.Y = Double.Parse(Console.In.ReadLine());
            //read some point on circumference coordinates
            Console.WriteLine("Enter X coordinate " + 
                "of some point on circumference");
            pointOnCircumference.X = 
                Double.Parse(Console.In.ReadLine());
            Console.WriteLine("Enter Y coordinate " + 
                "of some point on circumference");
            pointOnCircumference.Y = 
                Double.Parse(Console.In.ReadLine());
            //calculate and display the length of circumference
            Console.WriteLine("The length of circle " 
                + "circumference is:");
            //calculate the length of circumference
            double radius;
            radius = Math.Sqrt(Math.Pow(pointOnCircumference.X - center.X,
                                      2) + 
                                Math.Pow(pointOnCircumference.Y - center.Y, 
                                        2)
                                );
            double lengthOfCircumference;
            lengthOfCircumference = 2 * 3.1415 * radius;
            Console.WriteLine(lengthOfCircumference);
            Console.Read();
        }

    }
}
