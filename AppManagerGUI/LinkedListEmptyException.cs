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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppManagerGUI
{
    public class LinkedListEmptyException : Exception
    {
        public override string Message
        {
            get
            {
                return "Linked List is empty.";
            }
        }
    }
}
