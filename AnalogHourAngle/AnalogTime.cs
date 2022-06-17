using System;
using System.Collections.Generic;
using System.Text;

namespace AnalogHourAngle
{
    struct AnalogTime
    {
        public byte Hours { get; private set; }
        public byte Minutes { get; private set; }

        public AnalogTime(byte hours, byte minutes)
        {
            bool hoursOutOfRange = hours >= 12;
            bool minutesOutOfRange = minutes >= 60;

            if (hoursOutOfRange && !minutesOutOfRange)
            {
                throw new ArgumentException("Hours cannot be greater than 11!");
            }

            if (!hoursOutOfRange && minutesOutOfRange)
            {
                throw new ArgumentException("Minutes cannot be greater than 59!");
            }

            if (hoursOutOfRange && minutesOutOfRange)
            {
                throw new ArgumentException(
                    "Hours cannot be greater than 11 and minutes greater than 59!"
                    );
            }

            this.Hours = hours;
            this.Minutes = minutes;
        }

        public override string ToString()
        {
            return String.Format("{0:D2}:{1:D2}", Hours, Minutes);
        }

        public static AnalogTime FromString(string str)
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

            return new AnalogTime(hours, minutes);
        }
    }
}
