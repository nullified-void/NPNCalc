using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using NPNcalc;

namespace PrefixCalc
{
    class Program
    {
        
        static void Main(string[] args)
        {
            NPNCalc calc = new NPNCalc();
            while (true)
            {
                Console.WriteLine(calc.Resolve(Console.ReadLine()));
            }
        }

        [TestFixture]
        public class test
        {
            NPNCalc calc = new NPNCalc();
            [Test]
            public void BasicTests()
            {
                Assert.AreEqual(7.0d, calc.Resolve("+ 4 3"));
                Assert.AreEqual(2.0d, calc.Resolve("/ 10 5"));
                Assert.AreEqual(12.0d, calc.Resolve("* 6 2"));
                Assert.AreEqual(32.0d, calc.Resolve("- 40 8"));
            }
        }
    }

}
