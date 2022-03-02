using System;


namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This app will ask the user to enter a distance measured in one unit,
    /// and it will calculate and display the equivalent distance in another.
    /// </summary>
    /// <author>
    /// Amir Hamza version 0.1
    /// </author>
    public class DistanceConverter
    {
    // constants for distance coversion
        public const int FEET_IN_MILES = 5280;
        public const double METRES_IN_MILES = 1609.34;
        public const double FEET_IN_METRES = 3.28084;

     //initialised instance variables
        public double FromDistance { get; set; }
        public double ToDistance { get; set; }
        public DistanceUnits FromUnit { get; set; }
        public DistanceUnits ToUnit { get; set; }

     /// <summary>
     /// Constructor of the DistanceConverter Class
     /// </summary>
        public DistanceConverter()
        {
            FromUnit = DistanceUnits.Miles;
            ToUnit = DistanceUnits.Feet;
        }
        /// <summary>
        /// Call other methods 
        /// Prompts the user to input which unit the distance which will be converted from
        /// and which unit it will be converted to. 
        /// </summary>
        public void ConvertDistance()
        {
            ConsoleHelper.OutputHeading("Distance Converter");

            FromUnit = SelectUnit("Please select the from distance unit > ");
            ToUnit = SelectUnit("Please select the to distance unit > ");

            Console.WriteLine($"Converting {FromUnit} to {ToUnit}\n");

            FromDistance = ConsoleHelper.InputNumber($"Please enter the number of {FromUnit} > ");
            CalculateDistance();
            OutputDistance();
        }
        /// <summary>
        /// Calculate the distance based on the user choice
        /// Used enum for the units
        /// </summary>
        public void CalculateDistance()
        {
            if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / FEET_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Miles && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance * METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Miles)
            {
                ToDistance = FromDistance / METRES_IN_MILES;
            }
            else if (FromUnit == DistanceUnits.Feet && ToUnit == DistanceUnits.Metres)
            {
                ToDistance = FromDistance / FEET_IN_METRES;
            }
            else if (FromUnit == DistanceUnits.Metres && ToUnit == DistanceUnits.Feet)
            {
                ToDistance = FromDistance * FEET_IN_METRES;
            }
        }
        /// <summary>
        /// Prompt the user to select their chosen (choices)unit
        /// </summary>
        /// <param name="prompt"> the user choice</param>
        /// <returns>the unit of the user choice</returns>
        private DistanceUnits SelectUnit(string prompt)
        {
            string[] choices =
            {
                DistanceUnits.Feet.ToString(),
                DistanceUnits.Metres.ToString(),
                DistanceUnits.Miles.ToString()
            };
            Console.WriteLine(prompt);
            int choiceNo = ConsoleHelper.SelectChoice(choices);
            return ExecuteUnit(choiceNo);
        }

        /// <summary>
        /// Execute the choice based on the user input
        /// </summary>
        /// <param name="choice"> the user choice(input)</param>
        /// <returns>The unit based on the user choice </returns>
        private static DistanceUnits ExecuteUnit(int choiceNo)
        {
            switch (choiceNo)
            {
                case 1:
                    return DistanceUnits.Feet;
                case 2:
                    return DistanceUnits.Metres;
                case 3:
                    return DistanceUnits.Miles;
                default:
                    return DistanceUnits.NoUnit;
            }
        }

        /// <summary>
        /// Display the result of the calculation
        /// </summary>
        private void OutputDistance()
        {
            Console.WriteLine($"\n{FromDistance} {FromUnit} is {ToDistance} {ToUnit}.\n");
        }
    }
}
    


