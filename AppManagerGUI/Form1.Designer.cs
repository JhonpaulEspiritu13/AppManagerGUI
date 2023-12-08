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
    partial class AppManagerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PriorityQueueDelete = new Button();
            PriorityQueueInsert = new Button();
            LinkedListView = new ListView();
            LinkedListDelete = new Button();
            LinkedListSort = new Button();
            HorizontalRule = new Label();
            OpenFileDialog = new OpenFileDialog();
            PriorityQueueView = new ListView();
            PriorityQueuePriorityView = new ListView();
            PriorityQueueViewLabel = new Label();
            PriorityQueuePriorityLabel = new Label();
            PriorityViewWarningLabel = new Label();
            PriorityQueueBoundingLabel = new Label();
            PriorityQueueBoundingBox = new TextBox();
            SaveManagerButton = new Button();
            LinkedListViewLabel = new Label();
            SuspendLayout();
            // 
            // PriorityQueueDelete
            // 
            PriorityQueueDelete.BackColor = Color.IndianRed;
            PriorityQueueDelete.FlatAppearance.BorderColor = Color.Black;
            PriorityQueueDelete.FlatAppearance.BorderSize = 5;
            PriorityQueueDelete.FlatStyle = FlatStyle.Popup;
            PriorityQueueDelete.Font = new Font("Segoe UI", 15F);
            PriorityQueueDelete.Location = new Point(12, 398);
            PriorityQueueDelete.Name = "PriorityQueueDelete";
            PriorityQueueDelete.Size = new Size(118, 39);
            PriorityQueueDelete.TabIndex = 1;
            PriorityQueueDelete.Text = "Pop";
            PriorityQueueDelete.UseVisualStyleBackColor = false;
            PriorityQueueDelete.Click += PriorityQueueDelete_Click;
            // 
            // PriorityQueueInsert
            // 
            PriorityQueueInsert.BackColor = SystemColors.ActiveCaption;
            PriorityQueueInsert.FlatAppearance.BorderColor = Color.Black;
            PriorityQueueInsert.FlatAppearance.BorderSize = 5;
            PriorityQueueInsert.FlatStyle = FlatStyle.Popup;
            PriorityQueueInsert.Font = new Font("Segoe UI", 15F);
            PriorityQueueInsert.Location = new Point(165, 398);
            PriorityQueueInsert.Name = "PriorityQueueInsert";
            PriorityQueueInsert.Size = new Size(118, 39);
            PriorityQueueInsert.TabIndex = 2;
            PriorityQueueInsert.Text = "Push";
            PriorityQueueInsert.UseVisualStyleBackColor = false;
            PriorityQueueInsert.Click += PriorityQueueInsert_Click;
            // 
            // LinkedListView
            // 
            LinkedListView.AutoArrange = false;
            LinkedListView.FullRowSelect = true;
            LinkedListView.GridLines = true;
            LinkedListView.LabelWrap = false;
            LinkedListView.MultiSelect = false;
            LinkedListView.Location = new Point(369, 37);
            LinkedListView.Name = "LinkedListView";
            LinkedListView.Size = new Size(271, 341);
            LinkedListView.TabIndex = 3;
            LinkedListView.View = View.Details;
            LinkedListView.UseCompatibleStateImageBehavior = false;
            LinkedListView.DoubleClick += LinkedListView_DoubleClick;
            // 
            // LinkedListDelete
            // 
            LinkedListDelete.BackColor = Color.IndianRed;
            LinkedListDelete.FlatAppearance.BorderColor = Color.Black;
            LinkedListDelete.FlatAppearance.BorderSize = 5;
            LinkedListDelete.FlatStyle = FlatStyle.Popup;
            LinkedListDelete.Font = new Font("Segoe UI", 15F);
            LinkedListDelete.Location = new Point(369, 398);
            LinkedListDelete.Name = "LinkedListDelete";
            LinkedListDelete.Size = new Size(118, 39);
            LinkedListDelete.TabIndex = 4;
            LinkedListDelete.Text = "Delete";
            LinkedListDelete.UseVisualStyleBackColor = false;
            LinkedListDelete.Click += LinkedListDelete_Click;
            // 
            // LinkedListSort
            // 
            LinkedListSort.BackColor = Color.PeachPuff;
            LinkedListSort.FlatAppearance.BorderColor = Color.Black;
            LinkedListSort.FlatAppearance.BorderSize = 5;
            LinkedListSort.FlatStyle = FlatStyle.Popup;
            LinkedListSort.Font = new Font("Segoe UI", 15F);
            LinkedListSort.Location = new Point(522, 398);
            LinkedListSort.Name = "LinkedListSort";
            LinkedListSort.Size = new Size(118, 39);
            LinkedListSort.TabIndex = 5;
            LinkedListSort.Text = "Sort";
            LinkedListSort.UseVisualStyleBackColor = false;
            LinkedListSort.Click += LinkedListSort_Click;
            // 
            // HorizontalRule
            // 
            HorizontalRule.BorderStyle = BorderStyle.Fixed3D;
            HorizontalRule.Location = new Point(325, 12);
            HorizontalRule.Name = "HorizontalRule";
            HorizontalRule.RightToLeft = RightToLeft.Yes;
            HorizontalRule.Size = new Size(1, 350);
            HorizontalRule.TabIndex = 6;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // PriorityQueueView
            // 
            PriorityQueueView.Alignment = ListViewAlignment.Left;
            PriorityQueueView.AutoArrange = false;
            PriorityQueueView.FullRowSelect = true;
            PriorityQueueView.GridLines = true;
            PriorityQueueView.LabelWrap = false;
            PriorityQueueView.Location = new Point(12, 37);
            PriorityQueueView.MultiSelect = false;
            PriorityQueueView.Name = "PriorityQueueView";
            PriorityQueueView.Size = new Size(223, 341);
            PriorityQueueView.TabIndex = 7;
            PriorityQueueView.UseCompatibleStateImageBehavior = false;
            PriorityQueueView.View = View.Details;
            PriorityQueueView.DoubleClick += PriorityQueueView_DoubleClick;
            // 
            // PriorityQueuePriorityView
            // 
            PriorityQueuePriorityView.AutoArrange = false;
            PriorityQueuePriorityView.FullRowSelect = true;
            PriorityQueuePriorityView.GridLines = true;
            PriorityQueuePriorityView.LabelWrap = false;
            PriorityQueuePriorityView.Location = new Point(241, 37);
            PriorityQueuePriorityView.MultiSelect = false;
            PriorityQueuePriorityView.Name = "PriorityQueuePriorityView";
            PriorityQueuePriorityView.Size = new Size(42, 341);
            PriorityQueuePriorityView.TabIndex = 7;
            PriorityQueuePriorityView.UseCompatibleStateImageBehavior = false;
            PriorityQueuePriorityView.View = View.Details;
            // 
            // PriorityQueueViewLabel
            // 
            PriorityQueueViewLabel.AutoSize = true;
            PriorityQueueViewLabel.Font = new Font("Segoe UI", 15F);
            PriorityQueueViewLabel.Location = new Point(18, 2);
            PriorityQueueViewLabel.Name = "PriorityQueueViewLabel";
            PriorityQueueViewLabel.Size = new Size(214, 28);
            PriorityQueueViewLabel.TabIndex = 9;
            PriorityQueueViewLabel.Text = "Incomplete Documents";
            // 
            // PriorityQueuePriorityLabel
            // 
            PriorityQueuePriorityLabel.AutoSize = true;
            PriorityQueuePriorityLabel.Location = new Point(238, 19);
            PriorityQueuePriorityLabel.Name = "PriorityQueuePriorityLabel";
            PriorityQueuePriorityLabel.Size = new Size(45, 15);
            PriorityQueuePriorityLabel.TabIndex = 10;
            PriorityQueuePriorityLabel.Text = "Priority";
            // 
            // PriorityViewWarningLabel
            // 
            PriorityViewWarningLabel.AutoSize = true;
            PriorityViewWarningLabel.Location = new Point(208, 440);
            PriorityViewWarningLabel.Name = "PriorityViewWarningLabel";
            PriorityViewWarningLabel.Size = new Size(39, 15);
            PriorityViewWarningLabel.TabIndex = 11;
            PriorityViewWarningLabel.Text = "with...";
            // 
            // PriorityQueueBoundingLabel
            // 
            PriorityQueueBoundingLabel.AutoSize = true;
            PriorityQueueBoundingLabel.Location = new Point(83, 464);
            PriorityQueueBoundingLabel.Name = "PriorityQueueBoundingLabel";
            PriorityQueueBoundingLabel.Size = new Size(76, 15);
            PriorityQueueBoundingLabel.TabIndex = 12;
            PriorityQueueBoundingLabel.Text = "A priority of: ";
            // 
            // PriorityQueueBoundingBox
            // 
            PriorityQueueBoundingBox.Location = new Point(165, 461);
            PriorityQueueBoundingBox.Name = "PriorityQueueBoundingBox";
            PriorityQueueBoundingBox.Size = new Size(118, 23);
            PriorityQueueBoundingBox.TabIndex = 13;
            // 
            // SaveManagerButton
            // 
            SaveManagerButton.BackColor = Color.MediumSeaGreen;
            SaveManagerButton.FlatAppearance.BorderColor = Color.Black;
            SaveManagerButton.FlatAppearance.BorderSize = 5;
            SaveManagerButton.FlatStyle = FlatStyle.Popup;
            SaveManagerButton.Font = new Font("Segoe UI", 15F);
            SaveManagerButton.Location = new Point(449, 445);
            SaveManagerButton.Name = "SaveManagerButton";
            SaveManagerButton.Size = new Size(118, 39);
            SaveManagerButton.TabIndex = 14;
            SaveManagerButton.Text = "Save";
            SaveManagerButton.UseVisualStyleBackColor = false;
            SaveManagerButton.Click += SaveManagerButton_Click;
            // 
            // LinkedListViewLabel
            // 
            LinkedListViewLabel.AutoSize = true;
            LinkedListViewLabel.Font = new Font("Segoe UI", 15F);
            LinkedListViewLabel.Location = new Point(394, 2);
            LinkedListViewLabel.Name = "LinkedListViewLabel";
            LinkedListViewLabel.Size = new Size(213, 28);
            LinkedListViewLabel.TabIndex = 15;
            LinkedListViewLabel.Text = "Completed Documents";
            // 
            // AppManagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 498);
            Controls.Add(LinkedListViewLabel);
            Controls.Add(SaveManagerButton);
            Controls.Add(PriorityQueueBoundingBox);
            Controls.Add(PriorityQueueBoundingLabel);
            Controls.Add(PriorityViewWarningLabel);
            Controls.Add(PriorityQueuePriorityLabel);
            Controls.Add(PriorityQueueViewLabel);
            Controls.Add(PriorityQueuePriorityView);
            Controls.Add(PriorityQueueView);
            Controls.Add(HorizontalRule);
            Controls.Add(LinkedListSort);
            Controls.Add(LinkedListDelete);
            Controls.Add(LinkedListView);
            Controls.Add(PriorityQueueInsert);
            Controls.Add(PriorityQueueDelete);
            Name = "AppManagerForm";
            Text = "App Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button PriorityQueueDelete;
        private Button PriorityQueueInsert;
        private ListView LinkedListView;
        private Button LinkedListDelete;
        private Button LinkedListSort;
        private Label HorizontalRule;
        private OpenFileDialog OpenFileDialog;
        private ListView PriorityQueueView;
        private ListView PriorityQueuePriorityView;
        private Label PriorityQueueViewLabel;
        private Label PriorityQueuePriorityLabel;
        private Label PriorityViewWarningLabel;
        private Label PriorityQueueBoundingLabel;
        private TextBox PriorityQueueBoundingBox;
        private Button SaveManagerButton;
        private Label LinkedListViewLabel;
    }
}
