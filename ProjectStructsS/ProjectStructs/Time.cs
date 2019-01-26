using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructs
{
    public class TimeStruc
    {
        private readonly Time time;
        public Time Time => time;
    }

    public struct Time : IEquatable<Time> , IComparable<Time>
    {
        /// <summary>
        /// Klasa dziedziczona z interface'u IComparable porównuje ze sobą właściowości
        /// </summary>
        public int CompareTo(Time other)
        {
            if (this.Hours == other.Hours)
                if(this.Minutes == other.Minutes)
                    return this.Seconds.CompareTo(other.Seconds);
                else
                    return this.Minutes.CompareTo(other.Minutes);

            return other.Hours.CompareTo(this.Hours);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable sprawdza poprawność równości do objektu typu Time
        /// </summary>
        public override bool Equals(object obj)
        {
            var x = (Time)obj;
            return this.Equals(x);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable sprawdza poprawność 
        /// równości do objektu typu Time razem z właściowściami: godz, min, sek
        /// </summary>
        public bool Equals(Time t)
        {
            if (object.ReferenceEquals(t, null))  {  return false;  }
            
            if (Object.ReferenceEquals(this, t)) {  return true; }

            if (this.GetType() != t.GetType()) { return false; } 
            
            return (Hours == t.Hours) && (Minutes == t.Minutes) && (Seconds == t.Seconds);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable oblicza Hash'a
        /// </summary>
        public override int GetHashCode()
        {
            return Hours * 0x00010000 + Minutes;
        }

        private readonly int numberOfSecs;

        byte Hours
        {
            get { return (byte)(numberOfSecs / 3600);}
            set
            {
                if (Hours >= 0 && Hours <= 23)
                    Hours = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        byte Minutes
        {
            get{ return (byte)((numberOfSecs / 60) % 60);}
            set
            {
                if (Minutes >= 0 && Minutes <= 59)
                    Minutes = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        byte Seconds
        {
            get{ return (byte)(numberOfSecs - Hours * 60 * 60 - Minutes * 60);}
            set
            {
                if (Seconds >= 0 && Seconds <= 59)
                    Seconds = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }
        /// <summary>
        /// Konstrukotr z trzema parametrami
        /// </summary>
        public Time(byte hours, byte minutes, byte seconds)
        {
            if (hours > 23 || minutes > 59 || seconds > 59)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberOfSecs = seconds + 60 * minutes + 3600 * hours;
        }

        /// <summary>
        /// Konstrukotr z dwoma parametrami tylko godziny i minuty
        /// </summary>
        public Time(byte hours, byte minutes)
        {
            if (hours > 23 || minutes > 59)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberOfSecs = 60 * minutes + 3600 * hours;
        }

        /// <summary>
        /// Konstrukotr z jednyn parametrami tylko godziny
        /// </summary>
        public Time(byte hours)
        {
            if (hours > 23)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberOfSecs = 3600 * hours;
        }

        /// <summary>
        /// Metoda standardowa reprezentacji tekstowej czasu
        /// </summary>
        public override string ToString()
        {
            return Hours + "h " + Minutes + "m " + Seconds + "s";
            //return $"{ Hours.ToString("hh") + Minutes.ToString("mm") + Seconds.ToString("ss")} ";
        }
        
        public static Time Plus(Time time, TimePeriod timeP)
        {
            var seconds = (time.Seconds + timeP.Secs) % 60;
            var additionalMinute = ((byte)time.Seconds + timeP.Secs) / 60;

            var minutes = (time.Minutes + additionalMinute + timeP.Mins) % 60;
            var additionalHours = (byte)(time.Minutes + additionalMinute + timeP.Mins) / 60;

            var hours = (time.Hours + additionalHours+ timeP.Hours) % 24;

            Time result = new Time(Convert.ToByte(hours), 
                                    Convert.ToByte(minutes), 
                                    Convert.ToByte(seconds));

            return result;
        }


        public static Time Minus(Time time, TimePeriod timePeriod) {

            var timeInSec = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
            var timePeriodInSec = timePeriod.Hours * 3600 + timePeriod.Mins * 60 + timePeriod.Secs;

            if (timeInSec < timePeriodInSec)
                timeInSec += 24 * 3600;

            var resultInSec = timeInSec - timePeriodInSec;

            var hours = resultInSec / 3600;
            var minutes = (resultInSec - (hours * 3600)) / 60;
            var seconds = (resultInSec - (hours * 3600) - (minutes * 60));

            Time result = new Time(Convert.ToByte(hours),
                                    Convert.ToByte(minutes),
                                    Convert.ToByte(seconds));

            return result;
        }

    }
}
