using System.Collections.Generic;
using InvertedSearch.Controller;
using Xunit;

namespace GoogleSearch.Test.ConrollerTests
{
    public class TokenizerTest
    {

        private Tokenizer tokenizer;

        private const string content = "Slm. KhObi?  +  - email:Dr.mh.@gmail chEtory!!?";
        
        public TokenizerTest(){
            tokenizer = new Tokenizer(content);
        }

        [Fact]
        public void TokenizeTest(){
            var excepted = new HashSet<string>(){"slm" , "khobi" , "chetory","email","dr","mh","gmail"};
            var actual = tokenizer.Tokenize();
            Assert.Equal(excepted , actual);
        }
    }
}