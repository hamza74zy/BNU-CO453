using System;
using System.Text;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will use the body weight and height to calculate BMI Index
    /// then classify the health risk.
    /// User can input Imperial or Metric Unit.
    /// </summary>
    /// <author>
    /// Amir Hamza version 0.3
    /// </author>
    public class BMI
    { //Bmi Index result
        public double BmiIndex { get; set; }

        //Weight and Height Units
        public int Stone { get; set; }
        public int Pound { get; set; }
        public int Feet { get; set; }
        public int Inch { get; set; }
        public double Centimetres { get; set; }
        public double Kilograms { get; set; }

        public double Metres;

        //For conversion
        public const int POUNDS_IN_STONES = 14;
        public const int INCH_IN_FEET = 12;

        //WHO Weight Status	
        public const double Underweight = 18.5;
        public const double Normal = 24.9;
        public const double Overweight = 29.9;
        public const double ObeseClassI = 34.9;
        public const double ObeseClassII = 39.9;
        public const double ObeseClassIII = 40.0;

        /// <summary>
        /// Ouput Heading and Display menu choices
        /// User can select their preferred unit between Imperial and Mertic
        /// Then ouput the bmi category and bame message
        /// </summary>
        public void ConvertBmi()
        {
            ConsoleHelper.OutputHeading("Body Mass Index Calculator");
            Console.WriteLine("\nYour BMI, or Body Mass Index, is a measure of your weight compared to your height. \n" +
                "This app will use the body weight and height to calculate BMI Index\n" +
                "then classify the health risk based on the WHO weight status\n");
            SelectUnit("Please enter your choice > ");
            Console.WriteLine(OutputBmiCategory());
            Console.WriteLine(OutputBame());
        }

        /// <summary>
        /// Allows user to select their prefered unit 
        /// Imperial or Metric Unit
        /// </summary>
        private BMIUnit SelectUnit(string prompt)
        {
            string[] choices =
            {
                BMIUnit.Metric.ToString(),
                BMIUnit.Imperial.ToString()
            };
            int choiceNo = ConsoleHelper.SelectChoice(choices);
            return ExecuteChoice(choiceNo);
        }
        /// <summary>2
        /// 
        /// Execute other method 
        /// based on user's chosen unit
        /// returns the metric unit
        /// </summary>
        private BMIUnit ExecuteChoice(int choiceNo)
        {
            switch (choiceNo)
            {
                case 1:
                    InputMetricValue();
                    CalculateMetric();
                    return (BMIUnit)BMIUnit.Metric;
                case 2:
                    InputImperialValue();
                    CalculateImperial();
                    return (BMIUnit)BMIUnit.Imperial;
                default:
                    return BMIUnit.NoUnit;
            }
        }

        /// <summary>
        /// Prints the Bame message 
        /// explaining the extra risk
        /// </summary>
        public string OutputBame()
        {
            StringBuilder message = new StringBuilder("\n");
            message.Append("\n\tIf you are Black, Asian or other minority");
            message.Append("ethnic groups, you have a higher risk!");
            message.Append("\n\tAdults 23.0 or more are at increased risk;");
            message.Append("Adults 27.5 or more are at high risk.");
            return message.ToString();
        }

        /// <summary>
        /// Ouputs the WHO weight status 
        /// based on user calculated BMI index
        /// </summary>
        /// <returns></returns>
        public string OutputBmiCategory()
        {
            StringBuilder message = new StringBuilder("\n");

            if (BmiIndex < Underweight)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Underweight.");
            }
            else if (BmiIndex >= Underweight && BmiIndex <= Normal)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Normal");
            }
            else if (BmiIndex >= Normal && BmiIndex <= Overweight)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Overweight");
            }
            else if (BmiIndex >= Overweight && BmiIndex <= ObeseClassI)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Obese Class I");
            }
            else if (BmiIndex >= ObeseClassI && BmiIndex <= ObeseClassII)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Obese Class II");
            }
            else if (BmiIndex >= ObeseClassIII)
            {
                message.Append($"Your BMI is {BmiIndex:0.00}, " + $"You are classified as Obese Class III");
            }
            return message.ToString();
        }
        /// <summary>
        /// Inputs the height and weight of user
        /// using imperial units
        /// </summary>
        private void InputImperialValue()
        {
            Console.WriteLine("\nEnter your Height:");
            Feet = (int)ConsoleHelper.InputNumber("--in Feet > ");
            Inch = (int)ConsoleHelper.InputNumber("--in Inches > ");
            Console.WriteLine("\nEnter your Weight:");
            Stone = (int)ConsoleHelper.InputNumber("--in Stones > ");
            Pound = (int)ConsoleHelper.InputNumber("--in Pounds > ");
        }

        /// <summary>
        /// Inputs the height and weight of user
        /// using metric units
        /// </summary>
        private void InputMetricValue()
        {
            Kilograms = ConsoleHelper.InputNumber("\nEnter your weight to the nearest Kg > ");
            Centimetres = (int)ConsoleHelper.InputNumber("\nEnter your height to the nearest centimeters > ");
        }

        /// <summary>
        /// Calculates the BMI index of user
        /// using imperial units
        /// </summary>
        public void CalculateImperial()
        {
            Pound += Stone * POUNDS_IN_STONES;
            Inch += Feet * INCH_IN_FEET;
            BmiIndex = (double)Pound * 703 / (Inch * Inch);
        }

        /// <summary>
        /// Inputs the BMI index of user
        /// using imperial units
        /// </summary>
        public void CalculateMetric()
        {
            Metres = (double)Centimetres / 100;
            BmiIndex = Kilograms / (Metres * Metres);
        }

       
       
    }
}

 