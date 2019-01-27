using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructs
{
    public class TimePeriodStruc
    {
        private readonly TimePeriod timePeriod;
        public TimePeriod TimePeriod => timePeriod;
    }
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        /// <summary>
        /// Klasa dziedziczona z interface'u IComparable porównuje ze sobą właściowości
        /// </summary>
        public int CompareTo(TimePeriod other)
        {
            if (this.Hours == other.Hours)
                if (this.Mins == other.Mins)
                    return this.Secs.CompareTo(other.Secs);
                else
                    return this.Mins.CompareTo(other.Mins);

            return other.Hours.CompareTo(this.Hours);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable sprawdza poprawność równości do objektu typu Time
        /// </summary>
        public override bool Equals(object obj)
        {
            var x = (TimePeriod)obj;
            return this.Equals(x);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable sprawdza poprawność 
        /// równości do objektu typu Time razem z właściowściami: godz, min, sek
        /// </summary>
        public bool Equals(TimePeriod t)
        {
            if (object.ReferenceEquals(t, null)) { return false; }

            if (Object.ReferenceEquals(this, t)) { return true; }

            if (this.GetType() != t.GetType()) { return false; }

            return (Hours == t.Hours) && (Mins == t.Mins) && (Secs == t.Secs);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable oblicza Hash'a
        /// </summary>
        public override int GetHashCode()
        {
            return Hours * 0x00010000 + Hours;
        }
        private readonly long numberSecs;

        public byte Hours
        {
            get { return (byte)(numberSecs / 3600); }
            private set
            {
                if (Hours >= 0 && Hours <= 23)
                    Hours = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        public byte Mins
        {
            get { return (byte)((numberSecs / 60) % 60); }
            private set
            {
                if (Mins >= 0 && Mins <= 59)
                    Mins = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        public byte Secs
        {
            get { return (byte)(numberSecs - Hours * 60 * 60 - Mins * 60); }
            private set
            {
                if (Secs >= 0 && Secs <= 59)
                    Secs = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        /// <summary>
        /// Obliczanie różnicy między gozinami
        /// </summary>
        /// <param name="hours"></param>
        public TimePeriod(byte hours) {
            numberSecs = hours * 3600;
        }

        /// <summary>
        /// Obliczanie różnicy między gozinami oraz minutami
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        public TimePeriod(byte hours, byte minutes) {
            numberSecs = hours * 3600 + minutes * 60;
        }

        /// <summary>
        /// Obliczanie różnicy między godzinami, między minutami oraz sekundami
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public TimePeriod(byte hours, byte minutes, byte seconds) {
            numberSecs = hours * 3600 + minutes * 60 + seconds;
        }

        public override string ToString()
        {
            return Hours + "h " + Mins + "m " + Secs + "s";
        }

        public static TimePeriod Plus(Time time, TimePeriod timeP)
        {
            var seconds = time.Seconds + timeP.Secs;

            var minutes = time.Minutes +  timeP.Mins;

            var hours = time.Hours +  timeP.Hours;

            TimePeriod result = new TimePeriod(Convert.ToByte(hours),
                                                Convert.ToByte(minutes),
                                                Convert.ToByte(seconds));

            return result;
        }


        public static TimePeriod Minus(Time time, TimePeriod timePeriod)
        {

            var timeInSec = time.Hours * 3600 + time.Minutes * 60 + time.Seconds;
            var timePeriodInSec = timePeriod.Hours * 3600 + timePeriod.Mins * 60 + timePeriod.Secs;

            timePeriodInSec %= (24 * 3600);

            var resultInSec = timeInSec - timePeriodInSec;

            var hours = resultInSec / 3600;
            var minutes = (resultInSec - (hours * 3600)) / 60;
            var seconds = (resultInSec - (hours * 3600) - (minutes * 60));

            TimePeriod result = new TimePeriod(Convert.ToByte(hours),
                                               Convert.ToByte(minutes),
                                               Convert.ToByte(seconds));

            return result;
        }
    }
}
