using System;
using System.Collections.Generic;
using System.Text;

namespace RazeTech
{
    struct AnalogHours
    {
        public byte Hours { get; private set; }
        public byte Minutes { get; private set; }

        public AnalogHours(byte hours, byte minutes)
        {
            bool hoursOutOfRange = hours > 12;
            bool minutesOutOfRange = minutes > 60;

            if (hoursOutOfRange && !minutesOutOfRange)
            {
                throw new ArgumentException("Hours cannot be greater than 12!");
            }

            if (!hoursOutOfRange && minutesOutOfRange)
            {
                throw new ArgumentException("Minutes cannot be greater than 60!");
            }

            if (hoursOutOfRange && minutesOutOfRange)
            {
                throw new ArgumentException("Hours cannot be greater than 12 and minutes greater than 60!");
            }

            this.Hours = hours;
            this.Minutes = minutes;
        }

        public static AnalogHours FromString(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }

            string[] parts = str.Split(":");

            if (parts.Length > 2)
            {
                throw new FormatException(
                    "Analog hour string must be of the following format: "
                    +   "<Hours>:<Minutes>\r\n"
                    +   "Whitespace is ignored"
                    );
            }

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i].Trim();
            }

            byte hours = byte.Parse(parts[0]);
            byte minutes = 0;

            if (parts.Length == 2)
            {
                minutes = byte.Parse(parts[1]);
            }

            return new AnalogHours(hours, minutes);
        }
    }
}
