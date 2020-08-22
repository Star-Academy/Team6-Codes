using System.Collections.Generic;
using GoogleApp.Models;

namespace GoogleApp.View
{
    public interface IOutputWriter
    {
        void ShowOutput(IEnumerable<Document> docs);
    }
}