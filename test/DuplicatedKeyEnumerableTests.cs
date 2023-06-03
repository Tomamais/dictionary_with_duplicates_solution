using System;
using Xunit;

namespace dictionary_with_duplicates
{
    public class DuplicatedKeyEnumerableTests
    {
        [Fact]
        public void Add_AddsValuesWithDuplicateKeys()
        {
            var myEnumerable = new DuplicatedKeyEnumerable<string, int>();
            myEnumerable.Add("Key1", 1);
            myEnumerable.Add("Key2", 2);
            myEnumerable.Add("Key1", 3);

            Assert.Equal(2, myEnumerable.Keys.Count());
            Assert.True(myEnumerable.ContainsKey("Key1"));
            Assert.True(myEnumerable.ContainsKey("Key2"));
        }

        [Fact]
        public void Indexer_ReturnsValuesForGivenKey()
        {
            var myEnumerable = new DuplicatedKeyEnumerable<string, int>();

            myEnumerable.Add("Key1", 1);
            myEnumerable.Add("Key2", 2);
            myEnumerable.Add("Key1", 3);

            var valuesForKey1 = myEnumerable["Key1"].ToList();
            var valuesForKey2 = myEnumerable["Key2"].ToList();

            Assert.Equal(2, valuesForKey1.Count);
            Assert.Equal(1, valuesForKey1[0]);
            Assert.Equal(3, valuesForKey1[1]);
            Assert.Single(valuesForKey2);
            Assert.Equal(2, valuesForKey2[0]);
        }

        [Fact]
        public void Values_ReturnsAllValues()
        {
            var myEnumerable = new DuplicatedKeyEnumerable<string, int>();

            myEnumerable.Add("Key1", 1);
            myEnumerable.Add("Key2", 2);
            myEnumerable.Add("Key1", 3);

            var allValues = myEnumerable.Values.ToList();

            Assert.Equal(3, allValues.Count);
            Assert.Contains(1, allValues);
            Assert.Contains(2, allValues);
            Assert.Contains(3, allValues);
        }

        [Fact]
        public void GetEnumerator_ReturnsAllValuesInOrder()
        {
            var myEnumerable = new DuplicatedKeyEnumerable<string, int>();

            myEnumerable.Add("Key1", 1);
            myEnumerable.Add("Key2", 2);
            myEnumerable.Add("Key1", 3);

            var enumeratedValues = myEnumerable.ToList();

            Assert.Equal(3, enumeratedValues.Count);
            Assert.Equal(1, enumeratedValues[0]);
            Assert.Equal(2, enumeratedValues[1]);
            Assert.Equal(3, enumeratedValues[2]);
        }
    }
}
