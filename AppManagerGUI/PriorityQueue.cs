/***************************************************************
* Name : Priority Queue Implementation - Used for Final Project
* Author: Jhon Paul Espiritu
* Created : 10/6/2023
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 22
* Copyright : This is my own original work 
* based onspecifications issued by our instructor
* Description : Model showcasing the implementation of a Priority Queue (using LinkedList).
*            Input: None
*            Ouput: Priority Queue Test Outputs in Main.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

// I used my priority queue from my Assignment because it has a function I want to use.

using System;
// Had to specify name due to me wanting to preserve the LinkedList structure my original assignment used.
using Generic = System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;

namespace AppManagerGUI
{
    public class PriorityQueue<T>
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        private Generic.LinkedList<PriorityQueueItem<T>> _items;

        /**************************************************************
        * Constructor
        ***************************************************************/

        /// <summary>
        /// Creates a new PriorityQueue item with a specified type.
        /// </summary>
        public PriorityQueue()
        {
            _items = new Generic.LinkedList<PriorityQueueItem<T>>();
        }

        /// <summary>
        /// Creates a new PriorityQueue object with a specified type, and initalization of those items.
        /// Also the default for json reading.
        /// </summary>
        /// <param name="items">Linked List of PriorityQueueItems.</param>
        [JsonConstructor]
        public PriorityQueue(Generic.LinkedList<PriorityQueueItem<T>> items)
        {
            _items = items;
        }

        /**************************************************************
        * Accessors
        ***************************************************************/

        /// <summary>
        /// PriorityQueueItems currently in the Priority Queue.
        /// </summary>
        public Generic.LinkedList<PriorityQueueItem<T>> Items
        {
            get { return _items; }
        }

        /**************************************************************
        * Class Functions
        ***************************************************************/

        /// <summary>
        /// Checks if the PriorityQueue is currently empty.
        /// </summary>
        /// <returns>True or False, dependant on Count.</returns>
        public bool Empty()
        {
            return _items.Count == 0;
        }

        /// <summary>
        /// Checks the amount of items in PriorityQueue.
        /// </summary>
        /// <returns>Integer Count in List.</returns>
        public int Size()
        {
            return _items.Count;
        }

        /// <summary>
        /// Inserts an item into the PriorityQueue, sorting the List based on priority of object 
        /// (Highest Value being top priority).
        /// </summary>
        /// <param name="value">Value to be enqueued onto Priority Queue.</param>
        /// <param name="priority">Priority of item to ensure sort of queue.</param>
        public void Enqueue(T value, int priority)
        {
            // Initializes the PriorityQueueItem for inserted value.
            PriorityQueueItem<T> item = new PriorityQueueItem<T>(value, priority);

            // If Queue is empty, make the item the highest priority and the first item.
            if (Empty())
            {
                _items.AddFirst(item);
                return;
            }
            // Else, it goes through different checkpoints to sort throughout the list.
            else
            {
                // Initializes the first ListNode to compare values. Cannot be null due to checking first item.
                Generic.LinkedListNode<PriorityQueueItem<T>> listNode = _items.First!;

                // If item's priority is higher than the first list priority, insert it first.
                if (item.Priority > listNode.Value.Priority)
                {
                    _items.AddFirst(item);
                }
                // Else, it iterates through the list of PriorityQueueItems until something has been inserted.
                else
                {
                    // Checks to ensure the loop is not at the end of the list
                    // and makes sure the item's priority is lesser than or equal to the
                    // node's priority.
                    while (listNode.Next != null && item.Priority <= listNode.Next.Value.Priority)
                    {
                        listNode = listNode.Next;
                        // Iterates through list *until* item priority is no longer the same as the node's.
                        while (listNode.Next != null && listNode.Next.Value.Priority == item.Priority)
                        {
                            listNode = listNode.Next;
                        }
                    }

                    // Once the list is done being iterated through, add the node after the appropriate item.
                    _items.AddAfter(listNode, item);
                }
            }
        }

        /// <summary>
        /// Peeks at Priority Queue without deleting any data.
        /// </summary>
        /// <returns>Object Queue is initialized in.</returns>
        /// <exception cref="Exception">Queue is empty.</exception>
        public T Peek()
        {
            if (Empty())
            {
                throw new PriorityQueueEmptyException();
            }
            // Cannot be null due to checking first item.
            PriorityQueueItem<T> item = _items.First!.Value;
            return item.Value;
        }

        /// <summary>
        /// Returns Priority Queue object at the start of its queue (the highest priority object).
        /// </summary>
        /// <returns>Object Queue is initialized in.</returns>
        /// <exception cref="Exception">Queue is empty.</exception>
        public PriorityQueueItem<T> Dequeue()
        {
            if (Empty())
            {
                throw new PriorityQueueEmptyException();
            }
            // // Cannot be null due to checking first item.
            PriorityQueueItem<T> item = _items.First!.Value;
            _items.RemoveFirst();
            return item;
        }

        /// <summary>
        /// Enqueues an item onto the Priority Queue before dequeueing the first item afterwards.
        /// </summary>
        /// <param name="value">Value to be enqueued onto Priority Queue.</param>
        /// <param name="priority">Priority of item to insert into the priority queue.</param>
        /// <returns></returns>
        public T EnqueueDequeue(T value, int priority)
        {
            Enqueue(value, priority);
            T returnElement = Dequeue().Value;
            return returnElement;
        }

        /// <summary>
        /// Enqueues a range of items with a specified priority.
        /// </summary>
        /// <param name="items">Values to be enqueued onto Priority Queue.</param>
        /// <param name="priority">Priority of items to insert into the priority queue./param>
        public void EnqueueRange(IEnumerable<T> items, int priority)
        {
            foreach (T item in items)
            {
                Enqueue(item, priority);
            }
        }

        /// <summary>
        /// Enqueues a range of items using ValueTuple (looked at arguments from PriorityQueue documentation).
        /// </summary>
        /// <param name="items">Values to be enqueued onto Priority Queue.</param>
        public void EnqueueRange(IEnumerable<ValueTuple<T, int>> items)
        {
            foreach (var item in items)
            {
                Enqueue(item.Item1, item.Item2);
            }
        }

        /// <summary>
        /// Clears all items in Priority Queue.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Combines all items in Priority Queue and returns their values.
        /// </summary>
        /// <returns>Single string containing all item values.</returns>
        public override string ToString()
        {
            if (Empty())
            {
                return string.Empty;
            }

            string returnString = "";
            foreach (var item in _items)
            {
                // For this program's intents, the Document object won't be null.
                returnString += item.Value!.ToString() + "\n";
            }
            return returnString;
        }

        /// <summary>
        /// Uses Peek() to apply the object value to another variable, does nothing if function fails.
        /// </summary>
        /// <param name="value">Value to add onto after Peek is done.</param>
        /// <returns>True or False, depending on if Peek was successful.</returns>
        public bool TryPeek(out T value)
        {
            try
            {
                value = Peek();
                return true;
            }
            catch (Exception)
            {
                // Default value of 'Document' object will not be null.
                value = default(T)!;
                return false;
            }
        }

        /// <summary>
        /// Uses Peek() to apply the object value to another variable, does nothing if function fails.
        /// </summary>
        /// <param name="value">Value to add onto after Peek is done.</param>
        /// <returns>True or False, depending on if Peek was successful.</returns>
        public bool TryDequeue(out T value)
        {
            try
            {
                value = Dequeue().Value;
                return true;
            }
            catch (Exception)
            {
                // Default value of 'Document' object will not be null.
                value = default(T)!;
                return false;
            }
        }
    }
}

