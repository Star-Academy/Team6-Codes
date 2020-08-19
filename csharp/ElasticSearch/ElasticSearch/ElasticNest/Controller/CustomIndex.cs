using ElasticNest.Models;
using Nest;

namespace ElasticNest.Controller
{
    public class CustomIndex
    {

        private ElasticClient client;
        public CustomIndex(ElasticClient client)
        {
            this.client = client;
        }
        public void CreateIndex(string index)
        {
            var response = client.Indices.Create(index, setting =>
            setting.Settings(CreateSettings)
            .Map<Person>(CreateMapping));
        }


        private ITypeMapping CreateMapping(TypeMappingDescriptor<Person> mappingDescriptor)
        {
            return mappingDescriptor
                .Properties(pr => pr
                    .AddNameFieldMapping().AddAboutFieldMapping().AddAgeFieldMapping()
                        .AddEyeColorFieldMapping().AddGenderFieldMapping().AddLocationFieldMapping()
                            .AddPhoneFieldMapping().AddAddressFieldMapping().AddCompanyFieldMapping()
                                .AddDateFieldMapping()
                                      );
        }
        private IPromise<IIndexSettings> CreateSettings(IndexSettingsDescriptor settingsDescriptor)
        {
            return settingsDescriptor
                .Setting("max_ngram_diff", 7)
                .Analysis(CreateAnalysis);
        }

        private IAnalysis CreateAnalysis(AnalysisDescriptor analysisDescriptor)
        {
            return analysisDescriptor
                .TokenFilters(CreateTokenFilters)
                .Analyzers(CreateAnalyzers);
        }

        private static IPromise<IAnalyzers> CreateAnalyzers(AnalyzersDescriptor analyzersDescriptor)
        {
            return analyzersDescriptor
                .Custom(Analyzers.NgramAnalyzer, custom => custom
                    .Tokenizer("standard")
                    .Filters("lowercase", TokenFilters.NgramFilter));
        }

        private static IPromise<ITokenFilters> CreateTokenFilters(TokenFiltersDescriptor tokenFiltersDescriptor)
        {
            return tokenFiltersDescriptor
                .NGram(TokenFilters.NgramFilter, ng => ng
                    .MinGram(3)
                    .MaxGram(10));
        }
    }

}