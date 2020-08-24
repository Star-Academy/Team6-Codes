using System.Collections.Generic;
using GoogleApp.Controller.ElasticController;
using GoogleApp.Controller.Repository;
using GoogleApp.Models;
using Nest;

namespace GoogleApp.Controller
{
    public class Importer
    {
        private readonly string index;

        public Importer(string index)
        {
            this.index = index;
        }

        private readonly ElasticClient client = ElasticClientFactory.GetElasticClient();
        public List<Document> CreateDoc(string folderPath)
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

        public bool CreateIndex()
        {
            var existsIndicesResponse = client.Indices.Exists(index);
            new ResponseValidator<ExistsResponse>(existsIndicesResponse).Validate();
            if (existsIndicesResponse.Exists)
            {
                return true;
            }
            var customIndex = new CustomIndex();
            customIndex.CreateIndex(index);
            return false;
        }
        public void PostDocument(string folderPath, bool IndexExistence, bool IsExistenceImportant)
        {
            // if we want to post initial docs we pass isExistanceImportant as true !
            // if we add new documents we pass false

            if (IsExistenceImportant && IndexExistence)
                return;
            List<Document> docs = CreateDoc(folderPath);
            var postDocument = new PostDoc<Document>(index);
            var bulk = postDocument.Post(docs);
            var bulkResponse = client.Bulk(bulk);
            new ResponseValidator<BulkResponse>(bulkResponse).Validate();
        }
    }
}