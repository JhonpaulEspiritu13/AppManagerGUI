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

namespace AppManagerUnitTest;

using AppManagerGUI;

public class ManagerUnitTest
{
    [Fact]
    public void AppManagerTestBadPath()
    {
        // ARRANGE
        AppManager appManager = new AppManager("null");

        // ASSERT
        Assert.Throws<AppManagerInvalidPathException>(() => appManager.SaveManager());
    }

    [Fact]
    public void AppManagerTestNullPath()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);

        // ASSERT
        Assert.Throws<AppManagerInvalidPathException>(() => appManager.LoadManager());
    }

    [Fact]
    public void AppManagerTestSerialization()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        string serialize = appManager.SerializeManager();

        // ASSERT
        Assert.Equal(typeof(AppManager), appManager.DeserializeManager(serialize).GetType());
    }

    [Fact]
    public void AppManagerTestPriorityPush()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        int expectedSize = 5;

        // ACT
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 25);
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 10);
        appManager.PushDocument(new Document("null", "null"), 15);

        // ASSERT
        Assert.Equal(expectedSize, appManager.IncompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerTestPriorityPop()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        int expectedSize = 2;

        // ACT
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 25);
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 10);
        appManager.PushDocument(new Document("null", "null"), 15);
        appManager.PopDocument();
        appManager.PopDocument();
        appManager.PopDocument();

        // ASSERT
        Assert.Equal(expectedSize, appManager.IncompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerTestPriorityPopAll()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        int expectedSize = 5; // For Linked List

        // ACT
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 25);
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 10);
        appManager.PushDocument(new Document("null", "null"), 15);
        appManager.PopAllDocuments();

        // ASSERT
        Assert.Equal(expectedSize, appManager.CompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerTestPriorityClear()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        int expectedSize = 0; 

        // ACT
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 25);
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 10);
        appManager.PushDocument(new Document("null", "null"), 15);
        appManager.QueueClear(); // For Linked List

        // ASSERT
        Assert.Equal(expectedSize, appManager.CompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerGetDocument()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        Document expectedDocument = new Document("1", "1");
        int expectedIndex = 5; // End of list with 0 priority

        // ACT
        appManager.PushDocument(new Document("2", "2"), 5);
        appManager.PushDocument(new Document("3", "3"), 25);
        appManager.PushDocument(new Document("4", "4"), 5);
        appManager.PushDocument(expectedDocument, 0);
        appManager.PushDocument(new Document("5", "5"), 10);
        appManager.PushDocument(new Document("6", "6"), 15);

        // ASSERT
        Assert.Equal(expectedDocument, appManager.PriorityGetDocument(expectedIndex));
    }

    [Fact]
    public void AppManagerTestLinkedRemove()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        int expectedSize = 2;

        // ACT
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 25);
        appManager.PushDocument(new Document("null", "null"), 5);
        appManager.PushDocument(new Document("null", "null"), 10);
        appManager.PushDocument(new Document("null", "null"), 15);
        appManager.PopAllDocuments();
        appManager.Remove();
        appManager.Remove();
        appManager.Remove();
        // 5 Pushes - 3 Removes.

        // ASSERT
        Assert.Equal(expectedSize, appManager.CompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerTestLinkedRemoveDocument()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        Document document = new Document("1", "1");
        int expectedSize = 4;

        // ACT
        appManager.PushDocument(new Document("2", "2"), 5);
        appManager.PushDocument(document, 25);
        appManager.PushDocument(new Document("3", "3"), 5);
        appManager.PushDocument(new Document("4", "4"), 10);
        appManager.PushDocument(new Document("5", "5"), 15);
        appManager.PopAllDocuments();
        appManager.Remove(document);
        // 5 pushes - 1 Remove

        // ASSERT
        Assert.Equal(expectedSize, appManager.CompletedDocuments.Size());
    }

    [Fact]
    public void AppManagerTestLinkedGetDocument()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        Document expectedDocument = new Document("1", "1");
        int expectedIndex = 0;

        // ACT
        appManager.PushDocument(new Document("2", "2"), 5);
        appManager.PushDocument(expectedDocument, 25);
        appManager.PushDocument(new Document("3", "3"), 5);
        appManager.PushDocument(new Document("4", "4"), 10);
        appManager.PushDocument(new Document("5", "5"), 15);
        appManager.PopAllDocuments();
        appManager.Remove();
        appManager.Remove();

        // ASSERT
        Assert.Equal(expectedDocument, appManager.LinkedGetDocument(expectedIndex));
    }

    [Fact]
    public void AppManagerTestLinkedMergeSort()
    {
        // ARRANGE
        AppManager appManager = new AppManager(null!);
        Document expectedDocument = new Document("5", "5");
        int expectedIndex = 0;

        // ACT
        appManager.PushDocument(expectedDocument, 1); // Priority one will be at top after merge
        appManager.PushDocument(new Document("1", "1"), 25);
        appManager.PushDocument(new Document("2", "2"), 5);
        appManager.PushDocument(new Document("3", "3"), 10);
        appManager.PushDocument(new Document("4", "4"), 15);
        appManager.PopAllDocuments();
        appManager.MergeSort();

        // ASSERT
        Assert.Equal(expectedDocument, appManager.LinkedGetDocument(expectedIndex));
    }
}