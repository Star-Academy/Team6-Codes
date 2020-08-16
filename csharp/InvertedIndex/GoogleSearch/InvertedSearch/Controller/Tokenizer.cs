using System.Collections.Generic;

namespace InvertedSearch.Controller
{
    public class Tokenizer
    {
        private readonly string text;

        private readonly string pattern = @"[\s\+-?!@;.:]+";

        private readonly char[] invalidChars = {' ','+','-','?','!','@',';','.',':'};
        
        public Tokenizer(string text){
            this.text = text.Trim(invalidChars).ToLower();
        }

        public  HashSet<string> Tokenize(){
            string[] elements = System.Text.RegularExpressions.Regex.Split(text, pattern);
            return new HashSet<string>(elements);
        }
    }
}