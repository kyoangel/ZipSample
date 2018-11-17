﻿using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZipSample.test
{
    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void Union_integers()
        {
            var first = new List<int> { 1, 3, 5 };
            var second = new List<int> { 5, 3, 7, 9 };

            var expected = new List<int> { 1, 3, 5, 7, 9 };

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }


        [TestMethod]
        public void Union_girls()
        {
            var first = new List<Girl>
            {
				new Girl(){Name = "Amanda"},
				new Girl(){Name="Lucy"}
            } ;
            var second = new List<Girl>
            {
				new Girl(){Name = "Lucy"},
				new Girl(){Name="Xinyi"}
            } ;

            var expected = new List<Girl>
            {
				new Girl(){Name = "Amanda"},
	            new Girl(){Name = "Lucy"},
	            new Girl(){Name="Xinyi"}
            } ;

            var actual = MyUnion(first, second).ToList();
            expected.ToExpectedObject().ShouldEqual(actual);
        }

	    private IEnumerable<Girl> MyUnion(IEnumerable<Girl> first, IEnumerable<Girl> second)
	    {
		    throw new NotImplementedException();
	    }


	    private IEnumerable<int> MyUnion(IEnumerable<int> first, IEnumerable<int> second)
        {
            throw new NotImplementedException();
        }
    }
}