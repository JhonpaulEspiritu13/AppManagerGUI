/***************************************************************
* Name : Application Manager
* Author: Jhon Paul Espiritu
* Created : 11/6/2023
* Course: CIS 152 - Data Structure
* Version: 1.0
* OS: Windows 10
* IDE: Visual Studio 22
* Copyright : This is my own original work 
* based onspecifications issued by our instructor
* Description : Final Project.
*            Input: The amount of files that user needs to use.
*            Ouput: Priority of files.
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or
* unmodified. I have not given other fellow student(s) access
* to my program.
***************************************************************/

// Had to copy and paste code from project on PC since I was doing it from another source.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppManagerGUI
{
    [Serializable]
    class Document
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        private string fileName;
        private string filePath;

        /**************************************************************
        * Constructor
        ***************************************************************/

        /// <summary>
        /// Creates a new document object with a file name and file path.
        /// </summary>
        /// <param name="fileName">File name to use.</param>
        /// <param name="filePath">File path used as base for document.</param>
        [JsonConstructor]
        public Document(string fileName, string filePath)
        {
            this.fileName = fileName;
            this.filePath = filePath;
        }

        /**************************************************************
        * Accessors
        ***************************************************************/

        /// <summary>
        /// Actual file name to use for the document.
        /// </summary>
        [JsonPropertyName("File Name")]
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// File Path to use as base for the Document.
        /// </summary>
        [JsonPropertyName("File Path")]
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        /**************************************************************
        * Class Functions - Document
        ***************************************************************/

        /// <summary>
        /// Checks to ensure that the file is a valid object.
        /// </summary>
        /// <returns>True or false dependant on whether or not the current document has a valid file path.</returns>
        public bool IsValid()
        {
            if (!Path.Exists(filePath))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Launches the document's file path.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void OpenDocument()
        {
            if (!IsValid())
            {
                throw new Exception("File could not be opened.");
            }
            Process.Start(filePath);
        }
    }
}
