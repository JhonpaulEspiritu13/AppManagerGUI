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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// Used different namespaces for the Data Structures for easier customization.
using LinkedLister = AppManagerGUI.LinkedList;
using AppManagerGUI.PriorityQueue;

namespace AppManagerGUI
{
    class AppManager
    {
        /**************************************************************
        * Class Variables
        ***************************************************************/

        private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        private string appManagerPath;
        PriorityQueue<Document> documentsInQueue = new PriorityQueue<Document>();
        LinkedLister.LinkedList<Document> documentsInList = new LinkedLister.LinkedList<Document>();

        /**************************************************************
        * Constructor
        ***************************************************************/

        /// <summary>
        /// Creates an AppManager object with a corresponding path.
        /// </summary>
        /// <param name="managerPath">Manager Path to write json to.</param>
        public AppManager(string managerPath)
        {
            appManagerPath = managerPath;
        }

        /// <summary>
        /// Creates an AppManager object with a corresponding path, priority queue, and linked list.
        /// Also the default Json Constructor when a json has been read.
        /// </summary>
        /// <param name="managerPath"></param>
        /// <param name="incompletedDocuments"></param>
        /// <param name="completedDocuments"></param>
        [JsonConstructor]
        public AppManager(string managerPath, PriorityQueue<Document> incompletedDocuments, LinkedLister.LinkedList<Document> completedDocuments) =>
            (appManagerPath, documentsInQueue, documentsInList) = (managerPath, incompletedDocuments, completedDocuments);

        /**************************************************************
        * Accessors
        ***************************************************************/

        /// <summary>
        /// Path of manager app json (stores all data of app).
        /// </summary>
        public string ManagerPath
        {
            get { return appManagerPath; }
        }

        /// <summary>
        /// All documents stored in a priority queue (incompleted documents).
        /// </summary>
        public PriorityQueue<Document> IncompletedDocuments
        {
            get { return documentsInQueue; }
        }

        /// <summary>
        /// All documents stored in the linked list (completed documents).
        /// </summary>
        public LinkedLister.LinkedList<Document> CompletedDocuments
        {
            get { return documentsInList; }
        }

        /**************************************************************
        * Class Functions - Manager Functions
        ***************************************************************/

        /// <summary>
        /// Serializes the manager into a json.
        /// </summary>
        /// <returns>Sring json serialization.</returns>
        public string SerializeManager()
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Saves manager to a specified location.
        /// </summary>
        public void SaveManager()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(appManagerPath, "appManager.json")))
            {
                sw.WriteLine(SerializeManager());
            }
        }

        /// <summary>
        /// Deserializes a string object into an AppManager object.
        /// </summary>
        /// <param name="deserializeObject">String object to deserialize.</param>
        /// <returns>New App Manager object created from string.</returns>
        public AppManager DeserializeManager(string deserializeObject)
        {
            return JsonSerializer.Deserialize<AppManager>(deserializeObject);
        }

        /// <summary>
        /// Gets manager json file from a specified location, then returns it.
        /// </summary>
        /// <returns></returns>
        public AppManager LoadManager()
        {
            string jsonObject;
            using (StreamReader sr = new StreamReader(Path.Combine(appManagerPath, "appManager.json")))
            {
                jsonObject = sr.ReadToEnd();
            }

            return DeserializeManager(jsonObject);
        }

        /**************************************************************
        * Class Functions - Priority Queue
        ***************************************************************/

        /// <summary>
        /// Pushes a new document object into the priority queue.
        /// </summary>
        /// <param name="item">Document to be pushed onto the Queue.</param>
        /// <param name="priority">Priority of the document.</param>
        public void PushDocument(Document item, int priority)
        {
            documentsInQueue.Enqueue(item, priority);
        }

        /// <summary>
        /// Pops a document out of the priority queue and puts it in a list.
        /// </summary>
        /// <returns>Document object popped out from the queue.</returns>
        public Document PopDocument()
        {
            PriorityQueueItem<Document> popDocument = documentsInQueue.Dequeue();
            documentsInList.AddLast(popDocument.Value, popDocument.Priority);

            return popDocument.Value;
        }

        /// <summary>
        /// Pops all documents from the queue into the list.
        /// </summary>
        public void PopAllDocuments()
        {
            for (int i = 0; i < documentsInQueue.Size(); i++)
            {
                PopDocument();
            }
        }

        /// <summary>
        /// Clears all items from the queue without popping them into the list.
        /// </summary>
        public void QueueClear()
        {
            documentsInQueue.Clear();
        }

        /**************************************************************
        * Class Functions - Linked List
        ***************************************************************/

        /// <summary>
        /// Removes a specified document item from the list.
        /// </summary>
        /// <param name="item">Item to be removed from the list of completed documents.</param>
        public void Remove(Document item)
        {
            documentsInList.Remove(item);
        }

        /// <summary>
        /// Clears all documents from the linked list.
        /// </summary>
        public void Clear()
        {
            documentsInList.Clear();
        }
    }
}