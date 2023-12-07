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

namespace AppManagerGUI.LinkedList
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
            if (head == null)
                return;

            Insert(head);
            LinkedListNode<T> index = head;
            while (index.Next != null)
            {
                index = index.Next;
                _size++;
            }
            _current = index;
        }

        /**************************************************************
        * Accessors
        ***************************************************************/

        /// <summary>
        /// Head of the LinkedList.
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
            return _size == 0;
        }

        /// <summary>
        /// Creates a new LinkedList node object and appends it to the end of the list.
        /// </summary>
        /// <param name="item">Object to be stored in the linked list.</param>
        /// <param name="referenceValue">Reference value of the new object.</param>
        public void AddLast(T item, int referenceValue)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(item, null, referenceValue);
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
                LinkedListNode<T>? index = _head;
                for (int i = 1; i < _size; i++)
                {
                    if (index == item)
                        throw new Exception("Item is already in the list.");
                    index = index.Next;
                }

                // Makes inserted object the tail.
                _current.Next = item;
                _current = item;
                _current.Next = null;
            }
            // If there are no items in Linked List, make item the head.
            else
            {
                _head = item;
                _current = _head;
            }
            _size++;
        }

        /// <summary>
        /// Removes an item from the Linked List, nulling the reference of the previous Node.
        /// </summary>
        public void Remove()
        {
            // If List is empty, throw an exception.
            if (Empty())
                throw new Exception("Linked List is empty.");
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
            LinkedListNode<T> index = _head;
            while (!(index.Next.Next == null))
            {
                index = index.Next;
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
                throw new Exception("Linked List is empty.");
            if (_head.Value.Equals(item))
            {
                _head = null;
                _size--;
                return;
            }

            // Loops through the linked list to find specific element.
            LinkedListNode<T> index = _head;
            LinkedListNode<T> previous = null;
            while (!(index.Value.Equals(item)))
            {
                // If the next node is null, return an error because the end of the list has been reached.
                if (index.Next == null)
                {
                    throw new Exception("Linked List item is invalid.");
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

        /* -- Assuming that this does not need to be added since there are no Unit Test Requirements for it.
        /// <summary>
        /// Replaces item in specificed position in the LinkedList array.
        /// </summary>
        /// <param name="position">Position to replace item in array (Minus one in index conversion)</param>
        /// <param name="item">Item to replace with.</param>
        /// <exception cref="LinkedListInvalidPosition">Position specified is invalid.</exception>
        public void Replace(int position, string item)
        {
            // Checks if position is above zero or below current size.
            if ((position < 1) || (position > _currentSize))
            {
                throw new LinkedListInvalidPosition();
            }

            // Position minus one is where item will be replaced.
            _listArray[position - 1] = item;
        }
        */

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
            if (_head == null)
            {
                throw new Exception("Linked list is empty.");
            }

            // Initializes return string by calling Can's ToString().
            string returnString = string.Empty;
            LinkedListNode<T> index = _head;
            for (int i = 0; i < _size; i++)
            {
                returnString += index.ToString() + "\n";
                index = index.Next;
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
                left.Next = SortedMerge(left.Next, right.Next);
            }
            else
            {
                result = right;
                right.Next = SortedMerge(left, right.Next);
            }

            return result;
        }

        LinkedListNode<T> GetMiddle(LinkedListNode<T> node)
        {
            if (node == null)
                return node;
            LinkedListNode<T> fastptr = node.Next;
            LinkedListNode<T> slowptr = node;

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
        /// <param name="node"></param>
        /// <returns></returns>
        public LinkedListNode<T> MergeSort(LinkedListNode<T> node)
        {
            if (Empty() || node.Next == null)
            {
                return node;
            }

            LinkedListNode<T> middle = GetMiddle(node);
            LinkedListNode<T> middleNext = middle.Next;

            middle.Next = null;

            LinkedListNode<T> left = MergeSort(node);
            LinkedListNode<T> right = MergeSort(middleNext);

            LinkedListNode<T> sortedList = SortedMerge(left, right);
            return sortedList;
        }
    }
}
