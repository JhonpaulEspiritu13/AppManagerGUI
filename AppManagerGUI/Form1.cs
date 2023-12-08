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

namespace AppManagerGUI
{
    public partial class AppManagerForm : Form
    {
        private AppManager appManager = new AppManager(AppDomain.CurrentDomain.BaseDirectory);

        public AppManagerForm()
        {
            InitializeComponent();
            // Add a new column to the Views.
            PriorityQueueView.Columns.Add("File Name", -2);
            PriorityQueueView.Columns.Add("File Path", -2);
            PriorityQueuePriorityView.Columns.Add("ID", -2);
            LinkedListView.Columns.Add("File Name", -2);
            LinkedListView.Columns.Add("File Path", -2);

            // Initializes a new App Manager object.
            try
            {
                appManager = appManager.LoadManager();
            }
            // If App Manager was not detected, save a new AppManager at the programs' bin.
            catch (Exception)
            {
                MessageBox.Show("An App Manager Json was not detected. Creating a new App Manager in the program's exe.", "App Manager Not Located");
                appManager.SaveManager();
            }

            // Reload the views in order to display the lists.
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
            // Clears both Priority Queue Views.
            PriorityQueueView.Items.Clear();
            PriorityQueuePriorityView.Items.Clear();

            // Then adds all Priority Queue items to the views.
            foreach (PriorityQueueItem<Document> d in appManager.IncompletedDocuments.Items)
            {
                ListViewItem newListItem = new ListViewItem(new[] { d.Value.FileName, d.Value.FilePath });
                PriorityQueueView.Items.Add(newListItem);
                PriorityQueuePriorityView.Items.Add(d.Priority.ToString());
            }
        }

        /// <summary>
        /// Reloads the Linked List View in order to update it with the items selected.
        /// </summary>
        private void LinkedListViewReload()
        {
            // Clears LinkedList view.
            LinkedListView.Items.Clear();
            
            // Increments through the linked list.
            LinkedListNode<Document> index = appManager.CompletedDocuments.Head;
            for (int i = 0; i < appManager.CompletedDocuments.Size(); i++)
            {
                ListViewItem newListItem = new ListViewItem(new[] { index.Value.FileName, index.Value.FilePath });
                LinkedListView.Items.Add(newListItem);
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
                MessageBox.Show(appManager.CompletedDocuments.Size().ToString());
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
            if (int.TryParse(PriorityQueueBoundingBox.Text, out priorityFromBox))
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

        /// <summary>
        /// Double clicking an item will call a specified document's OpenDocument() function.
        /// </summary>
        private void PriorityQueueView_DoubleClick(object sender, EventArgs e)
        {
            // Gets index of selected item, then finds it in Priority Queue.
            int selectedIndex = PriorityQueueView.SelectedItems[0].Index;
            Document document = appManager.PriorityGetDocument(selectedIndex);
            document.OpenDocument();
        }

        /// <summary>
        /// Double clicking an item will call a specified document's OpenDocument() function.
        /// </summary>
        private void LinkedListView_DoubleClick(object sender, EventArgs e)
        {
            int selectedIndex = LinkedListView.SelectedItems[0].Index;
            Document document = appManager.LinkedGetDocument(selectedIndex);
            document.OpenDocument();
        }

        private void LinkedListDelete_Click(object sender, EventArgs e)
        {

        }

        private void LinkedListSort_Click(object sender, EventArgs e)
        {
            appManager.MergeSort();
            MessageBox.Show(appManager.CompletedDocuments.Size().ToString());
            LinkedListViewReload();
        }

        private void PriorityQueueViewLabel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Calls the App Manager's Save Function in order to save to a json.
        /// </summary>
        private void SaveManagerButton_Click(object sender, EventArgs e)
        {
            appManager.SaveManager();
        }
    }
}
