using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStructs;

namespace UnitTestProjectStructsTime
{
    [TestClass]
    public class UnitTest0Time
    {
        [TestMethod]
        public void ConstrDefault() { }
    }

    [TestClass]
    public class UnitTest1Time
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(4)]

        [TestMethod]
        public void Constr1(Int32 a)
        {
            byte hour = (byte)a;
            Time t = new Time(hour);
            Assert.IsTrue(hour < 24);
            //Assert.AreEqual(daneTestowe, t);
        }
    }
    
    [TestClass]
    public class UnitTest2Time
    {
        [DataTestMethod]
        [DataRow(2, 5)]
        public void Constr2(Int32 a, Int32 b)
        {
            byte h = (byte)a;
            byte min = (byte)b;
            Time t = new Time(h, min);
            Assert.IsTrue(h < 24);
            Assert.IsTrue(min <= 59);
        }
    }

    [TestClass]
    public class UnitTest3Time
    {
        [DataTestMethod]
        [DataRow(2, 48, 53)]
        public void Constr3(Int32 a, Int32 b, Int32 c)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            byte sek = (byte)c;
            Time t = new Time(godz, min, sek);
            Assert.IsTrue(godz < 24);
            Assert.IsTrue(min <= 59);
            Assert.IsTrue(sek <= 59);
        }
    }

    [TestClass]
    public class UnitTest6Time
    {
        [DataTestMethod]
        [DataRow(11, 57, 59, 27, 15, 03, 15, 13, 02)]
        public void TimePlus(Int32 timeHours, Int32 timeMinutes, Int32 timeSeconds,
                              Int32 timeHoursP, Int32 timeMinutesP, Int32 timeSecondsP,
                              Int32 resultHours, Int32 resultMinutes, Int32 resultSeconds)
        {
            Time time =                     new Time(Convert.ToByte(timeHours),  Convert.ToByte(timeMinutes), Convert.ToByte(timeSeconds));
            TimePeriod timePeriod =   new TimePeriod(Convert.ToByte(timeHoursP), Convert.ToByte(timeMinutesP), Convert.ToByte(timeSecondsP));
                
            Time sum = Time.Plus(time, timePeriod);
            Assert.AreEqual(sum, new Time(Convert.ToByte(resultHours), Convert.ToByte(resultMinutes), Convert.ToByte(resultSeconds)));

        }
    }

    [TestClass]
    public class UnitTest7Time
    {
        [DataTestMethod]
        [DataRow(11, 57, 59, 27, 15, 03, 08, 42, 56)]
        public void TimeMinus(Int32 timeHours, Int32 timeMinutes, Int32 timeSeconds,
                       Int32 timeHoursP, Int32 timeMinutesP, Int32 timeSecondsP,
                       Int32 resultHours, Int32 resultMinutes, Int32 resultSeconds)
        {
            Time time = new Time(Convert.ToByte(timeHours), Convert.ToByte(timeMinutes), Convert.ToByte(timeSeconds));
            TimePeriod timePeriod = new TimePeriod(Convert.ToByte(timeHoursP), Convert.ToByte(timeMinutesP), Convert.ToByte(timeSecondsP));

            Time substraction = Time.Minus(time, timePeriod);
            Assert.AreEqual(substraction, new Time(Convert.ToByte(resultHours), Convert.ToByte(resultMinutes), Convert.ToByte(resultSeconds)));

        }
    }
    [TestClass]
    public class UnitTest4Time
    {
        [TestMethod]
        public bool IEquatable_Test()
        {
            Time t = new Time();

            if (Object.ReferenceEquals(this, t))
                return true;
            /*else if (object.ReferenceEquals(i, null) && this.GetType() != i.GetType())
                return false;*/
            else
                return false;
        }
    }

    [TestClass]
    public class UnitTest5Time
    {
        [TestMethod]
        public int IComparable_Test(Int32 a, Int32 b, Int32 c)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            byte sek = (byte)c;
            Time t = new Time(godz, min, sek);

            if (godz == a)
                if (min == b)
                    return sek.CompareTo(c);
                else
                    return min.CompareTo(b);

            return a.CompareTo(godz);
        }
    }
}

namespace UnitTestProjectStructsTimePeriod
{
    [TestClass]
    public class UnitTest1TimePeriod
    {
        [DataTestMethod]
        [DataRow(8)]
        [DataRow(12)]
        public void Konstruktor1arg(Int32 a)
        {
            byte godz = (byte)a;
            Time t = new Time(godz );
            Assert.IsTrue(godz < 24);
        }
    }

    [TestClass]
    public class UnitTest2TimePeriod
    {
        [DataTestMethod]
        [DataRow(5, 13)]
        public void Konstruktor2arg(Int32 a, Int32 b)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            Time t = new Time(godz, min);
            Assert.IsTrue(godz < 24);
            Assert.IsTrue(min <= 59);
        }
    }
    
    [TestClass]
    public class UnitTest3TimePeriod
    {
        [DataTestMethod]
        [DataRow(2, 48, 53)]
        public void Konstruktor3arg(Int32 a, Int32 b, Int32 c)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            byte sek = (byte)c;
            Time t = new Time(godz, min, sek);
            Assert.IsTrue(godz < 24);
            Assert.IsTrue(min <= 59);
            Assert.IsTrue(sek <= 59);
        }
    }

    [TestClass]
    public class UnitTest4TimePeriod
    {
        [TestMethod]
        public bool IEquatable_TimePeriod_Test()
        {
            Time t = new Time();

            if (Object.ReferenceEquals(this, t))
                return true;
            else
                return false;
        }
    }

    [TestClass]
    public class UnitTest5TimePeriod
    {
        [TestMethod]
        public int IComparable_TimePeriod_Test(Int32 a, Int32 b, Int32 c)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            byte sek = (byte)c;
            Time t = new Time(godz, min, sek);

            if (godz == a)
                if (min == b)
                    return sek.CompareTo(c);
                else
                    return min.CompareTo(b);

            return a.CompareTo(godz);
        }
    }
}