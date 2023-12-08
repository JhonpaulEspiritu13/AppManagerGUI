/***************************************************************
* Name : Priority Queue Implementation
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppManagerGUI
{
    public class PriorityQueueItem<T>
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        [JsonPropertyName("Priority Queue Value")]
        /// <summary>
        /// Item in a Priority Queue, actual value used to return data.
        /// </summary>
        public T Value { get; set; }

        [JsonPropertyName("Priority Queue ID")]
        /// <summary>
        /// Integer priority value of an item, used to sort values.
        /// </summary>
        public int Priority { get; set; }

        /**************************************************************
        * Constructor
        ***************************************************************/

        /// <summary>
        /// Creates a Priority Queue Item object with both a value and priority.
        /// </summary>
        /// <param name="value">Value to be inserted into the Priority Queue Item.</param>
        /// <param name="priority">Priority of the item.</param>
        [JsonConstructor]
        public PriorityQueueItem(T value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }
}
