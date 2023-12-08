/***************************************************************
* Name : Linked List Application -- Used for Final Project
* Author: Jhon Paul Espiritu
* Created : 9/24/2023
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 22
* Copyright : This is my own original work 
* based onspecifications issued by our instructor
* Description : Model showcasing the implementation of a LinkedList class.
*            Input: Unit Tests over Linked List.
*            Ouput: Linked List outputs.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/


// I used my linked list from my Assignment because it has a function I want to use.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppManagerGUI
{
    public class LinkedList<T>
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        private int _size;    // Size of the current Linked List.
        private LinkedListNode<T>? _head;    // Head of the Linked List.
        private LinkedListNode<T>? _current;

        /**************************************************************
        * Constructors
        ***************************************************************/

        /// <summary>
        /// Initializes a new LinkedList object, making the head of Linked List null.
        /// </summary>
        public LinkedList()
        {
            _size = 0;
            _head = null;
            _current = null;
        }

        /// <summary>
        /// Initializes a new LinkedList object, setting the head with Can.
        /// </summary>
        /// <param name="head">Head of the LinkedList.</param>
        [JsonConstructor]
        public LinkedList(LinkedListNode<T> head)
        {
            _size = 0;
            // If head is null, don't do anything but assign a size of zero.
            if (head == null)
                return;

            // Insert the head node, and iterate through its children. Increment the size for each child.
            Insert(head);
            LinkedListNode<T> index = head;
            while (index.Next != null)
            {
                index = index.Next;
                _size++;
            }

            // Make the current Node the index.
            _current = index;
        }

        /**************************************************************
        * Accessors
        ***************************************************************/

        /// <summary>
        /// Head of the LinkedList. Possibly null.
        /// </summary>
        public LinkedListNode<T>? Head
        {
            get { return _head; }
        }

        /***************************************************************
        * Class Functions
        ***************************************************************/

        /// <summary>
        /// Checks if current size is equal to zero.
        /// </summary>
        /// <returns>Returns true if current size is zero, false if not.</returns>
        public bool Empty()
        {
            return _head == null;
        }

        /// <summary>
        /// Creates a new LinkedList node object and appends it to the end of the list.
        /// </summary>
        /// <param name="item">Object to be stored in the linked list.</param>
        /// <param name="referenceValue">Reference value of the new object.</param>
        public void AddLast(T item, int referenceValue)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, referenceValue);
            Insert(newNode);
        }

        /// <summary>
        /// Inserts an item into the array, adding onto Linked List.
        /// </summary>
        /// <param name="item">Item to add into the next of the list.</param>
        public void Insert(LinkedListNode<T> item)
        {
            if (!Empty())
            {
                // Creates an index, looping through the list.
                // If index is the same as the item inserted, throw exception.
                // Head is *not* null due to check.
                LinkedListNode<T> index = _head!;
                for (int i = 1; i < _size; i++)
                {
                    if (index == item)
                        throw new Exception("Item is already in the list.");
                    index = index.Next!;
                }

                // Makes inserted object the tail and makes its next null.
                // Current is *not* null due to check.
                _current!.Next = item;
                _current = item;

                // If there are any nodes connected to the added node, append those nodes to the Linked List as well.
                index = _current;
                while (index.Next != null)
                {
                    index = index.Next;
                    _size++;
                }
            }
            // If there are no items in Linked List, make item the head.
            else
            {
                _head = item;
                _current = _head;
            }

            // Increase size after either if statements.
            _size++;
        }

        /// <summary>
        /// Removes an item from the top of the Linked List, nulling the reference of the previous Node.
        /// </summary>
        public void Remove()
        {
            // If List is empty, throw an exception.
            if (Empty())
                throw new LinkedListEmptyException();
            // If removed item is head, null it.
            if (_current == _head)
            {
                _head = null;
                _size--;
                return;
            }

            // Creates an index, looping through the list.
            // If the Node object two spots ahead is null, make index the current object
            // and null its Next pointer to remove references.
            LinkedListNode<T> index = _head!;
            for (int i = 1; i < _size; i++)
            {
                index = index.Next!;
            }
            _current = index;
            _current.Next = null;
            _size--;
        }

        /// <summary>
        /// Removes a specific item from the linked list.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <exception cref="Exception">Item was not found in linked list.</exception>
        public void Remove(T item)
        {
            if (Empty())
                throw new LinkedListEmptyException();
            // For this program's purposes, the value cannot be null. Nor can the head due to check.
            if (_head!.Value!.Equals(item))
            {
                _head = null;
                _size--;
                return;
            }

            // Loops through the linked list to find specific element.
            LinkedListNode<T> index = _head;
            LinkedListNode<T> previous = index;

            while (!(index.Value!.Equals(item)))
            {
                // If the next node is null, return an error because the end of the list has been reached.
                if (index.Next == null)
                {
                    throw new LinkedListEndOfListException();
                }
                previous = index;
                index = index.Next;
            }
            // If element was found, simply make the previous element the index's next.
            previous.Next = index.Next;
            _size--;
        }

        /// <summary>
        /// Clears all objects in the list.
        /// </summary>
        public void Clear()
        {
            _head = null;
            _size = 0;
        }

        /// <summary>
        /// Finds the generic object at a certain index in the Linked List.
        /// </summary>
        /// <param name="indexToFind">Index to search for.</param>
        /// <returns>Generic object.</returns>
        public T FindAtIndex(int indexToFind)
        {
            LinkedListNode<T> index;
            if (Empty())
            {
                throw new LinkedListEmptyException();
            }
            index = _head!;

            // Iterates through list to find desired index.
            for (int i = 1; i < indexToFind; i++)
            {
                if (index.Next == null)
                {
                    throw new LinkedListEndOfListException();
                }
                index = index.Next;
            }

            return index.Value;
        }

        /// <summary>
        /// The current size of the LinkedList.
        /// </summary>
        /// <returns>Returns size.</returns>
        public int Size()
        {
            return _size;
        }

        /// <summary>
        /// Prints the list of items in the LinkedList's array.
        /// </summary>
        /// <returns>Returns a string of items.</returns>
        public string Print()
        {
            // Tests if List is empty.
            if (Empty())
            {
                throw new LinkedListEmptyException();
            }

            // Initializes return string by calling Can's ToString().
            string returnString = string.Empty;
            LinkedListNode<T> index = _head!;
            for (int i = 0; i < _size; i++)
            {
                // Indexes should not be null as they are iterating through the size of the list.
                returnString += index!.Value!.ToString() + "\n";
                index = index.Next!;
            }
            return returnString;
        }

        /***************************************************************
        * Class Functions - Merge Sort Referenced From: https://www.geeksforgeeks.org/merge-sort-for-linked-list/#
        ***************************************************************/

        LinkedListNode<T> SortedMerge(LinkedListNode<T> left, LinkedListNode<T> right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }

            LinkedListNode<T> result;
            if (left.ReferenceValue <= right.ReferenceValue)
            {
                result = left;
                left.Next = SortedMerge(left.Next!, right.Next!);
            }
            else
            {
                result = right;
                right.Next = SortedMerge(left, right.Next!);
            }

            return result;
        }

        LinkedListNode<T>? GetMiddle(LinkedListNode<T> node)
        {
            if (node == null)
                return node;
            LinkedListNode<T>? fastptr = node.Next;
            LinkedListNode<T>? slowptr = node;

            // Move fastptr by two and slow ptr by one
            // Finally slowptr will point to middle node
            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }

        /// <summary>
        /// Preforms a Merge Sort made for a Linked List by preforming a O(n*log n) operation.
        /// Code referenced and modified from: https://www.geeksforgeeks.org/merge-sort-for-linked-list/#
        /// </summary>
        /// <param name="node">Head node, or the next node to be merge sorted.</param>
        /// <returns>A linked list node value with the sorted list.</returns>
        public LinkedListNode<T>? MergeSort(LinkedListNode<T> node)
        {
            // Checks if the head node is either null, or alone.
            if (node == null || node.Next == null)
            {
                return node;
            }

            // Splits the list into two halves by getting the middle first..
            LinkedListNode<T> middle = GetMiddle(node)!;
            LinkedListNode<T> middleNext = middle.Next!;
            middle.Next = null;

            // Calls a MergeSort to check the two halves of the List.
            LinkedListNode<T> left = MergeSort(node)!;
            LinkedListNode<T> right = MergeSort(middleNext)!;

            // Start the Sorted Merge
            LinkedListNode<T> sortedList = SortedMerge(left, right);
            return sortedList;
        }
    }
}
