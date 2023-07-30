using Assignment3;
using System.Runtime.Intrinsics.X86;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private ILinkedListADT users;

        [SetUp]
        public void Setup()
        {
            this.users = new SLL();

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.users.Clear();
        }

        /// <summary>
        /// Tests the SSL if it is empety.
        /// </summary>
        [Test]
        public void IsEmpetyTest()
        {
            users.Clear();
            Assert.AreEqual(0, users.Count());
        }

        /// <summary>
        /// Tests the SSL AddFirst method.
        /// </summary>
        [Test]
        public void AddFirstTest()
        {
            users.AddFirst(new User(5, "Larry Smith", "lsmith@gmail.com", "12345678"));
            Assert.AreEqual("Larry Smith", users.GetValue(0).Name);
        }

        /// <summary>
        /// Tests the SSL AddLast method.
        /// </summary>
        [Test]
        public void AddLastTest()
        {
            users.AddLast(new User(5, "Larry Smith", "lsmith@gmail.com", "12345678"));
            Assert.AreEqual("Larry Smith", users.GetValue(4).Name);
        }

        /// <summary>
        /// Tests the SSL Add method.
        /// </summary>
        [Test]
        public void AddTest()
        {
            users.Add(new User(5, "Larry Smith", "lsmith@gmail.com", "12345678"), 2);
            Assert.AreEqual("Larry Smith", users.GetValue(2).Name);
        }

        /// <summary>
        /// Tests the SSL Replace method.
        /// </summary>
        [Test]
        public void ReplaceTest()
        {
            users.Replace(new User(5, "Larry Smith", "lsmith@gmail.com", "12345678"), 2);
            Assert.AreEqual("Larry Smith", users.GetValue(2).Name);
        }

        /// <summary>
        /// Tests the SSL RemoveFirst method.
        /// </summary>
        [Test]
        public void RemoveFirstTest()
        {
            users.RemoveFirst();
            Assert.AreEqual("Joe Schmoe", users.GetValue(0).Name);
        }

        /// <summary>
        /// Tests the SSL RemoveLast method.
        /// </summary>
        [Test]
        public void RemoveLastTest()
        {
            users.RemoveLast();
            Assert.Throws<IndexOutOfRangeException>(() => users.GetValue(3));
        }

        /// <summary>
        /// Tests the SSL Remove method.
        /// </summary>
        [Test]
        public void RemoveTest()
        {
            users.Remove(1);
            Assert.AreEqual("Colonel Sanders", users.GetValue(1).Name);
        }

        /// <summary>
        /// Tests the SSL Contains method.
        /// </summary>
        [Test]
        public void ContainsTest1()
        {
            Assert.AreEqual(true, users.Contains(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555")));
        }

        /// <summary>
        /// Tests the SSL Contains method.
        /// </summary>
        [Test]
        public void ContainsTest2()
        {
            Assert.AreEqual(2, users.IndexOf(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555")));
        }

        /// <summary>
        /// Tests the SSL Invert method.
        /// </summary>
        [Test]
        public void InvertTest()
        {
            users.Invert();
            Assert.AreEqual("Ronald McDonald", users.GetValue(0).Name);
        }

        /// <summary>
        /// Tests the SSL Sort method.
        /// </summary>
        [Test]
        public void SortTest()
        {
            users.Sort();
            Assert.AreEqual("Colonel Sanders", users.GetValue(0).Name);
        }

        /// <summary>
        /// Tests the SSL ToArray method.
        /// </summary>
        [Test]
        public void ToArrayTest()
        {
            User[]userArray = users.ToArray();
            Assert.AreEqual("Joe Schmoe", userArray[1].Name);
        }

        /// <summary>
        /// Tests the SSL Join method.
        /// </summary>
        [Test]
        public void JoinTest()
        {
            this.users = new SLL();
            SLL list1 = new SLL();
            SLL list2 = new SLL();

            list1.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            list1.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            list2.AddLast(new User(1, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            list2.AddLast(new User(2, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.Join(list1, list2);
            Assert.AreEqual("Colonel Sanders", users.GetValue(2).Name);
        }

        /// <summary>
        /// Tests the SSL Seperate method.
        /// </summary>
        [Test]
        public void SeperateTest()
        {
            var seperateLists = users.Seperate(2);
            Assert.AreEqual("Joe Schmoe", seperateLists.Item1.GetValue(1).Name);
            Assert.AreEqual("Ronald McDonald", seperateLists.Item2.GetValue(1).Name);

        }
    }
}