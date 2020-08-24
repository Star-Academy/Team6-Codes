using Nest;
using System;
using GoogleApp.Models;
namespace GoogleApp.Controller.ElasticController
{
    public static class FieldDefiner
    {
        public static PropertiesDescriptor<Document> AddContentFieldMapping(this PropertiesDescriptor<Document> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Content)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Document> AddIdFieldMapping(this PropertiesDescriptor<Document> prpertiesDescriptor)
        {
            // prpertiesDescriptor.
            return prpertiesDescriptor.Text(t => t
                    .Name(n => n.ID)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
    }
}