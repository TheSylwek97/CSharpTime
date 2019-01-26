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
            if (this.hours == other.hours)
                if (this.mins == other.mins)
                    return this.secs.CompareTo(other.secs);
                else
                    return this.mins.CompareTo(other.mins);

            return other.hours.CompareTo(this.hours);
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

            return (hours == t.hours) && (mins == t.mins) && (secs == t.secs);
        }

        /// <summary>
        /// Klasa dziedziczona z interface'u IEquatable oblicza Hash'a
        /// </summary>
        public override int GetHashCode()
        {
            return hours * 0x00010000 + hours;
        }
        private readonly long numberSecs;

        byte hours
        {
            get { return (byte)(numberSecs / 3600); }
            set
            {
                if (hours >= 0 && hours <= 23)
                    hours = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        byte mins
        {
            get { return (byte)((numberSecs / 60) % 60); }
            set
            {
                if (mins >= 0 && mins <= 59)
                    mins = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }

        byte secs
        {
            get { return (byte)(numberSecs - hours * 60 * 60 - mins * 60); }
            set
            {
                if (secs >= 0 && secs <= 59)
                    secs = value;
                else
                    throw new ArgumentException("Niepoprawna liczba");
            }
        }
        /// <summary>
        /// Obliczanie różnicy między sekundami
        /// </summary>
        /// <param name="intervalH"></param>
        /// <param name="hours"></param>
        public TimePeriod(long intervalS, byte sec)
        {
            if (sec > 59)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberSecs = (long)sec - intervalS;
        }
        /// <summary>
        /// Obliczanie różnicy między minutami oraz między sekundami
        /// </summary>
        /// <param name="intervalH"></param>
        /// <param name="hours"></param>
        /// <param name="intervalM"></param>
        /// <param name="m"></param>
        public TimePeriod(long intervalM, byte min, long intervalS, byte s)
        {
            if (min > 59 || s > 59)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberSecs = (long)s - intervalS + (((long)min - intervalM)) ;
        }
        /// <summary>
        /// Obliczanie różnicy między godzinami, między minutami oraz sekundami
        /// </summary>
        /// <param name="intervalH"></param>
        /// <param name="hours"></param>
        /// <param name="intervalM"></param>
        /// <param name="m"></param>
        /// <param name="intervalS"></param>
        /// <param name="s"></param>
        public TimePeriod(long intervalH, byte hours, long intervalM, byte m, long intervalS, byte s)
        {
            if (hours > 23 || m > 59 || s > 59)
                throw new ArgumentOutOfRangeException("Podany czas nie jest prawidłowy");
            else
                numberSecs = (3600 * ((long)hours - intervalH)) +( 60 * ((long)m - intervalM))  + (long)s - intervalS;
        }
        public override string ToString()
        {
            return hours + "h " + mins + "m " + secs + "s";
        }
    }
}
