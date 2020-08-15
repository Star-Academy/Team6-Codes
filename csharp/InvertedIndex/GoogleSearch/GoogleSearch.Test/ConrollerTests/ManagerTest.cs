using System.Collections.Generic;
using InvertedSearch.Controller;
using InvertedSearch.Models;
using InvertedSearch.View;
using Moq;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests
{
    public class ManagerTest
    {
        private Manager manager;

        private IInputReader inputReader;

        private string path = "../../../Data";
        private string query = "-slm +khobi mamnoon";
        List<Document> docs;
        private int documentCount = 3;

        public ManagerTest()
        {
            var inputReaderMock = new Mock<IInputReader>();

            inputReaderMock.Setup(reader => reader.GetPath()).Returns(path);
            inputReaderMock.Setup(reader => reader.GetQuery()).Returns(query);
            inputReader = inputReaderMock.Object;

            var outputWriterMock = new Mock<IOutputWriter>();

            outputWriterMock.Setup(writer => writer.ShowOutput(new HashSet<Document>()));


            manager = new Manager(inputReader, outputWriterMock.Object);


        }

        [Fact]
        public void RunTest()
        {
            docs = new List<Document>();
            for (int i = 0; i < documentCount; i++)
            {
                docs.Add(new Document(path + "/" + (i + 1).ToString()));
            }
            manager.Run();
            Assert.Equal(new HashSet<Document>(){docs[2], docs[1]}, manager.result);
        }
    }
}