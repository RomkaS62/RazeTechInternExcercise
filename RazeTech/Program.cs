using System;

namespace RazeTech
{
    internal static class AnalogHoursExt
    {
        private const double DEGREES_PER_HOUR = 360.0 / 12.0;
        private const double DEGREES_PER_MINUTE = 360.0 / 60.0;

        public static double MinuteAngle(this AnalogHours hours)
        {
            return hours.Minutes * DEGREES_PER_MINUTE;
        }

        public static double HoursAngle(this AnalogHours hours)
        {
            return hours.Hours * DEGREES_PER_HOUR;
        }
    }

    class Program
    {
        private static double MinimumAngleDifference(double angle1, double angle2)
        {
            angle1 %= 360.0;
            angle2 %= 360.0;

            double absDiff = Math.Abs(angle1 - angle2);

            if (absDiff > 180.0)
            {
                return 360.0 - absDiff;
            }
            else
            {
                return absDiff;
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    AnalogHours hours = AnalogHours.FromString(args[i]);

                    double hourAngle = hours.HoursAngle();
                    double minuteAngle = hours.MinuteAngle();
                    double diff = MinimumAngleDifference(hourAngle, minuteAngle);

                    Console.WriteLine(args[i] + "\t" + diff);
                }
                catch (FormatException ex)
                {
                    Console.Error.WriteLine("Invalid analog hour format: " + args[i]);
                }
                catch (ArgumentException ex)
                {
                    Console.Error.WriteLine("Analog hours out of range: " + args[i]);
                }
            }
        }
    }
}
