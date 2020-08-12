using InvertedSearch.Controller.Repository;

namespace InvertedSearch.Controller
{
    public class Manager
    {

        public FolderReader folderReader;

        public Manager(string folderPath)
        {
            this.folderReader = new FolderReader(folderPath);
        }

        public void run()
        {

        }

    }
}