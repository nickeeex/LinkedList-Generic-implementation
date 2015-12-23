using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GenericLinkedList;

namespace GenericLinkedList
{
    public class LinkedListAreEqual : IEqualityComparer<LinkedList<int>>
    {
        public bool Equals(LinkedList<int> x, LinkedList<int> y)
        {
            if (object.ReferenceEquals(x, y)) return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null)) return false;

            return x.PrintAll() == y.PrintAll();
        }

        public int GetHashCode(LinkedList<int> obj)
        {
            if (object.ReferenceEquals(obj, null)) return 0;

            int hashCodeHeadData = obj.GetHeadData().GetHashCode();
            int hasCodeLastData = obj.GetLastData().GetHashCode();

            return hashCodeHeadData ^ hasCodeLastData;
        }
    }

    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void ReverseTest()
        {
            LinkedList<int> original = new LinkedList<int>(new List<int> { 1, 2, 3 });
            original.Reverse();
            LinkedList<int> target = new LinkedList<int>(new List<int> { 3, 2, 1 });
            LinkedListAreEqual comparer = new LinkedListAreEqual();
            Assert.IsTrue(comparer.Equals(original, target));
        }

        [TestMethod()]
        public void GetLastDataTest()
        {
            GetLastDataLinkedListTestHelper<int>(5, new List<int> { 1, 2, 3, 4, 5 });
            GetLastDataLinkedListTestHelper<char>('c', new List<char> { 'a','b','c' });
        }

        public void GetLastDataLinkedListTestHelper<T>(T TestData,IEnumerable<T> startarray)
        {
            LinkedList<T> target = new LinkedList<T>(startarray); 
            T actual = target.GetLastData();
            Assert.AreEqual(TestData, actual); 
        }
    }
}

