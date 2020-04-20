using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tas1_DoublyLinkedList;

namespace Task1_Tests
{
    [TestClass]
    public class DoublyLinkedListShould
    {
        DoublyLinkedList<Song> songs;

        [TestInitialize]
        public void SetUp()
        {
            songs = new DoublyLinkedList<Song>();
        }

        [DataTestMethod]
        [DataRow(3)]
        public void DoublyLinkedList_Add_ReturnTrue(int count)
        {
            for (int i = 0; i < count; i++)
            {
                songs.Add(new Song());
            }

            Assert.AreEqual(songs.Count, count);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void DoublyLinkedList_GetCurrent_ReturnTrue(int count)
        {
            Song uno = new Song("Uno", "Little Big", new DateTime(2020, 03, 13));
            string title;

            if(count == 0)
            {
                songs.Add(new Song());
                title = "Untitled";
            }
            else
            {
                songs.Add(new Song());
                songs.Add(uno);
                songs.MoveNext();
                title = uno.Title;
            }

            Assert.AreEqual(title, songs.GetCurrent().Title);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void DoublyLinkedList_GetNext_ReturnTrue(int count)
        {
            Song uno = new Song("Uno", "Little Big", new DateTime(2020, 03, 13));
            Song expected;

            if (count == 0)
            {
                songs.Add(new Song());
                expected = default(Song);
            }
            else
            {
                songs.Add(new Song());
                songs.Add(uno);
                expected = uno;
            }

            Assert.AreEqual(expected, songs.GetNext());
        }
        
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(1)]
        public void DoublyLinkedList_GetPrevious_ReturnTrue(int count)
        {
            Song uno = new Song("Uno", "Little Big", new DateTime(2020, 03, 13));
            Song expected;

            if (count == 0)
            {
                songs.Add(new Song());
                expected = default(Song);
            }
            else
            {
                songs.Add(uno);
                songs.Add(new Song());
                songs.MoveNext();
                expected = uno;
            }

            Assert.AreEqual(expected, songs.GetPrevious());
        }
    }
}
