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
                if (this.mins == other.mins)
                    return this.secs.CompareTo(other.secs);
                else
                    return this.mins.CompareTo(other.mins);

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

            return (Hours == t.Hours) && (mins == t.mins) && (secs == t.secs);
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

        public byte mins
        {
            get { return (byte)((numberSecs / 60) % 60); }
            private set
            {
                if (mins >= 0 && mins <= 59)
                    mins = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        public byte secs
        {
            get { return (byte)(numberSecs - Hours * 60 * 60 - mins * 60); }
            private set
            {
                if (secs >= 0 && secs <= 59)
                    secs = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        /// <summary>
        /// Obliczanie różnicy między gozinami
        /// </summary>
        /// <param name="hours"></param>
        TimePeriod(byte hours) {
            numberSecs = hours * 3600;
        }

        /// <summary>
        /// Obliczanie różnicy między gozinami oraz minutami
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        TimePeriod(byte hours, byte minutes) {
            numberSecs = hours * 3600 + minutes * 60;
        }

        /// <summary>
        /// Obliczanie różnicy między godzinami, między minutami oraz sekundami
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        TimePeriod(byte hours, byte minutes, byte seconds) {
            numberSecs = hours * 3600 + minutes * 60 + seconds;
        }

        public override string ToString()
        {
            return Hours + "h " + mins + "m " + secs + "s";
        }
    }
}
