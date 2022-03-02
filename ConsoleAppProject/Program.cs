using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start Apps 01 to 05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Amir Hamza 02/03/2022
    /// </summary>
    public static class Program
    {

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            ConsoleHelper.OutputHeading("BNU CO453 Applications Programming 2020-2021!");

            string[] choices = { "Distance Converter", "BMI Calculator", "Student Marks", "Social Network" };
            int choiceNo = ConsoleHelper.SelectChoice(choices);

            switch (choiceNo)
            {
                case 1:
                    DistanceConverter converter = new DistanceConverter();
                    converter.ConvertDistance();
                    break;
                case 2:
                    BMI bmiindex = new BMI();
                    bmiindex.ConvertBmi();
                    break;
            }
        }
    }
}
                
            
        
    


