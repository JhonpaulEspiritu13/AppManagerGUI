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
    public class LinkedListNode<T> 
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        /// <summary>
        /// The generic object value of the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next node in a Linked List.
        /// </summary>
        [JsonPropertyName("Child Node")]
        public LinkedListNode<T>? Next { get; set; }

        /// <summary>
        /// The 'priority' value of the linked list node.
        /// </summary>
        public int ReferenceValue { get; set; }

        /**************************************************************
        * Constructor
        ***************************************************************/

        /// <summary>
        /// Creates a new LinkedListNode object with a value (no next pointer).
        /// </summary>
        /// <param name="value">Value to be inserted into the node.</param>
        /// <param name="referenceValue">Ref. Value to be added onto the node.</param>
        public LinkedListNode(T value, int referenceValue)
        {
            Value = value;
            Next = null;
            ReferenceValue = referenceValue;
        }

        /// <summary>
        /// Creates a new LinkedListNode object with a value.
        /// </summary>
        /// <param name="value">Value to be inserted into the node.</param>
        /// <param name="next">Next node linked to this node.</param>
        /// <param name="referenceValue">Ref. Value to be added onto the node.</param>
        [JsonConstructor]
        public LinkedListNode(T value, LinkedListNode<T> next, int referenceValue)
        {
            Value = value;
            Next = next;
            ReferenceValue = referenceValue;
        }
    }
}
