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

using AppManagerGUI.PriorityQueue;

namespace AppManagerGUI
{
    public partial class AppManagerForm : Form
    {
        private AppManager appManager = new AppManager(AppDomain.CurrentDomain.BaseDirectory);

        public AppManagerForm()
        {
            InitializeComponent();
            // Initializes a new App Manager object.

            try
            {
                appManager = appManager.LoadManager();
            }
            catch (Exception)
            {
                MessageBox.Show("An App Manager Json was not detected. Creating a new App Manager in the program's exe.", "App Manager Not Located");
                appManager.SaveManager();
            }

            PriorityQueueViewReload();
            LinkedListViewReload();
        }

        private void AppManagerForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Reloads the Priority Queue View in order to update it with the items selected.
        /// </summary>
        private void PriorityQueueViewReload()
        {
            PriorityQueueView.Items.Clear();
            PriorityQueuePriorityView.Items.Clear();
            foreach (PriorityQueueItem<Document> d in appManager.IncompletedDocuments.Items)
            {
                PriorityQueueView.Items.Add(d.Value.FileName);
                PriorityQueuePriorityView.Items.Add(d.Priority.ToString());
            }
        }

        /// <summary>
        /// Reloads the Linked List View in order to update it with the items selected.
        /// </summary>
        private void LinkedListViewReload()
        {
            LinkedListView.Items.Clear();
            AppManagerGUI.LinkedList.LinkedListNode<Document> index = appManager.CompletedDocuments.Head;
            for (int i = 0; i < appManager.CompletedDocuments.Size(); i++)
            {
                LinkedListView.Items.Add(index.Value.FileName);
                index = index.Next;
            }
        }

        /// <summary>
        /// When the Delete Button is clicked, Pop the document into the Linked List.
        /// </summary>
        private void PriorityQueueDelete_Click(object sender, EventArgs e)
        {
            // First try to Pop the document and reload the views.
            try
            {
                appManager.PopDocument();
                PriorityQueueViewReload();
                LinkedListViewReload();
            }
            // If an exception pops up, display a message box.
            catch (Exception)
            {
                MessageBox.Show("There are no items currently in the Priority Queue.", "No Items",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// When the Insert Button is clicked, Push the document into the Priority Queue.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriorityQueueInsert_Click(object sender, EventArgs e)
        {
            int priorityFromBox;
            // Checks to make sure there's a value in the priority textbox.
            if (PriorityQueueBoundingBox.Text.Length == 0)
            {
                MessageBox.Show("There must be a value in the Priority Box to specify a Push from file.", "Invalid Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parses priority into int. If valid, ensure that priority is not negative and below 9999.
            if(int.TryParse(PriorityQueueBoundingBox.Text, out priorityFromBox))
            {
                if (priorityFromBox < 0)
                {
                    MessageBox.Show("The value entered in the Priority Box is too low. Please ensure that you have an integer value ranging from 0 to 9999.", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (priorityFromBox > 9999)
                {
                    MessageBox.Show("The value entered in the Priority Box is too high. Please ensure that you have an integer value ranging from 0 to 9999.", "Invalid Value",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Document newDocument = new Document(Path.GetFileName(OpenFileDialog.FileName), OpenFileDialog.FileName);
                    appManager.PushDocument(newDocument, priorityFromBox);
                    PriorityQueueViewReload();
                }
            }
            // If try parse returns false, warn the user.
            else
            {
                MessageBox.Show("The value entered in the Priority Box is invalid. Please ensure that you have an integer value ranging from 0 to 9999.", "Invalid Value",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PriorityQueueView_DoubleClick(object sender, EventArgs e)
        {

            MessageBox.Show(PriorityQueueView.SelectedItems[0].SubItems[0].Text);
        }

        private void LinkedListDelete_Click(object sender, EventArgs e)
        {

        }

        private void LinkedListSort_Click(object sender, EventArgs e)
        {
            appManager.CompletedDocuments.MergeSort(appManager.CompletedDocuments.Head);
        }

        private void PriorityQueueViewLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
