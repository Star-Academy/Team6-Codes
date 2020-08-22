using GoogleApp.Models;
using System.Collections.Generic;
using GoogleApp.Controller.ElasticController;
using GoogleApp.Controller.Repository;
namespace GoogleApp.Controller
{
    public class Manager
    {
        private string index = "google-docs";
        private string folderPath { get; set; }
        public void manage()
        {
            var postDocument = new PostDoc<Document>(index);
            var client = ElasticClientFactory.GetElasticClient();
            var customIndex = new CustomIndex();
            customIndex.CreateIndex(index);
            var bulk = postDocument.Post(CreateDoc());
            client.Bulk(bulk);
        }
        public List<Document> CreateDoc()
        {
            FolderReader folderReader = new FolderReader(folderPath);
            List<Document> documents = folderReader.DocumentsOfFolder();
            foreach (Document doc in documents)
            {
                var reader = new FileReader(doc);
                doc.Content = reader.GetContent();
            }
            return documents;
        }
    }
}