using ElasticNest.Models;
using Nest;

namespace ElasticNest.Controller
{
    internal static class FieldsDefiner
    {
        public static PropertiesDescriptor<Person> AddAboutFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.About)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddNameFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Name)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddAgeFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Number(t => t
                    .Name(n => n.Age)
                    .Type(NumberType.Integer));
        }
        public static PropertiesDescriptor<Person> AddEyeColorFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.EyeColor)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddGenderFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Gender)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddCompanyFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Company)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddLocationFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .GeoPoint(t => t
                    .Name(n => n.Location)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
        public static PropertiesDescriptor<Person> AddEmailFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Email)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }

        public static PropertiesDescriptor<Person> AddPhoneFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Phone).Fields(f => f
                    .Text(ng => ng
                    .Name("ngram")
                    .Analyzer(Analyzers.NgramAnalyzer))));
        }

        public static PropertiesDescriptor<Person> AddAddressFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.About)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }

        public static PropertiesDescriptor<Person> AddDateFieldMapping(this PropertiesDescriptor<Person> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Date(t => t
                    .Name(n => n.RegistrationDate).Format("yyyy-MM-ddTHH:mm:ss"));
        }

    }
}