using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectStructs;

namespace UnitTestProjectStructsTime
{
    [TestClass]
    public class UnitTest0Time
    {
        [TestMethod]
        public void KonstruktorDomyslny_NieUstalonyCzas() { }
    }

    [TestClass]
    public class UnitTest1Time
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(4)]

        [TestMethod]
        public void KonstruktorJednoargumentowy_Godzina(Int32 a)
        {
            byte daneTestowe = (byte)a;
            Time t = new Time(daneTestowe);
            Assert.IsTrue(daneTestowe < 24);
            //Assert.AreEqual(daneTestowe, Time);
        }
    }
    
    [TestClass]
    public class UnitTest2Time
    {
        [DataTestMethod]
        [DataRow(2, 5)]
        public void KonstruktorDwuargumentowy_GodzinaIMinuta(Int32 a, Int32 b)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            Time t = new Time(godz, min);
            Assert.IsTrue(godz < 24);
            Assert.IsTrue(min <= 59);
        }
    }

    [TestClass]
    public class UnitTest3Time
    {
        [DataTestMethod]
        [DataRow(2, 48, 53)]
        public void KonstruktorTrojargumentowy_GodzinaIMinutaISekunda(Int32 a, Int32 b, Int32 c)
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
        [DataRow(0, 12)]
        [DataRow(4, 22)]

        [TestMethod]
        public void KonstruktorJednoargumentowy_Sek(Int32 Is, Int32 s)
        {
            byte sek = (byte)s;
            long interSek = (long)Is;
            TimePeriod t = new TimePeriod(interSek, sek);
            Assert.IsTrue(sek <= 59);
            Assert.AreNotSame(interSek, sek);
        }
    }

    [TestClass]
    public class UnitTest2TimePeriod
    {
        [DataTestMethod]
        [DataRow(2, 5, 4, 3)]
        public void KonstruktorCzworoarg_SekundaIMinuta( Int32 b, Int32 c,  Int32 Ib, Int32 Ic)
        {
            byte min = (byte)b;
            byte sek = (byte)c;
            long interMin = (long)Ib;
            long interSek = (long)Ic;
            TimePeriod t = new TimePeriod(interMin, min, interSek, sek);
            Assert.IsTrue(min <= 59);
            Assert.AreNotSame(interMin, min);
        }
    }
    
    [TestClass]
    public class UnitTest3TimePeriod
    {
        [DataTestMethod]
        [DataRow(2, 48, 53,24,56,11)]
        public void KonstruktorSzescioarg_GodzinaIMinutaISekunda(Int32 a, Int32 b, Int32 c, Int32 Ia, Int32 Ib, Int32 Ic)
        {
            byte godz = (byte)a;
            byte min = (byte)b;
            byte sek = (byte)c;
            long interGodz = (long)Ia;
            long interMin = (long)Ib;
            long interSek = (long)Ic;
            TimePeriod t = new TimePeriod( interGodz, godz,  interMin, min, interSek, sek);
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