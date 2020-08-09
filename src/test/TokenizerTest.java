package test;

import org.junit.Before;
import org.junit.Test;

import app.Tokenizer;

public class TokenizerTest {
    private Tokenizer tokenizer;
    private String folderPath = "/home/mahdi/Documents/code-star/Team-6/src/app.test/app.test-data/1";

    @Before
    public void init() {
        tokenizer = new Tokenizer(folderPath);
    }

    @Test
    public void addDocIdToTokensTest() {

    }

}