using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CliModline.Utils;

namespace CliModline.Test
{
    [TestClass]
    public class ModLineTest
    {
        private readonly string expectCrLf = "abc\r\ndef\r\n123";
        private readonly string expectLf = "abc\ndef\n123";
        private readonly string expectCr = "abc\rdef\r123";

        [TestMethod]
        public void NonConstract()
        {
            var source = "abcdef123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.None;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(source, target.GetCrLf());
        }

        [TestMethod]
        public void CrLfConstract()
        {
            var source = "abc\r\ndef\r\n123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.CRLF;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }

        [TestMethod]
        public void LfConstract()
        {
            var source = "abc\ndef\n123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.LF;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }

        [TestMethod]
        public void CrConstract()
        {
            var source = "abc\rdef\r123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.CR;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }

        [TestMethod]
        public void MixedCrLf_CrConstract()
        {
            var source = "abc\r\ndef\r123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.Mixed;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }

        [TestMethod]
        public void MixedCrLf_LfConstract()
        {
            var source = "abc\r\ndef\n123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.Mixed;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }

        [TestMethod]
        public void MixedCr_LfConstract()
        {
            var source = "abc\rdef\n123";
            var target = new ModLine(source);
            var expect1 = NewLineKind.Mixed;

            Assert.AreEqual(expect1, target.OriginalKind);
            Assert.AreEqual(expectCrLf, target.GetCrLf());
            Assert.AreEqual(expectLf, target.GetLf());
            Assert.AreEqual(expectCr, target.GetCr());
        }
    }
}
