package test;

import java.io.File;
import java.util.HashMap;
import java.util.HashSet;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import app.Query;
import app.Tokenizer;

public class QueryTest {
    private Query query;
    private HashMap<String, HashSet<Integer>> invertedIndex;
    private String folderPath = "/home/mahdi/Documents/code-star/Team-6/src/test/test-data";

    @Before
    public void setInvertedIndex() {
        System.out.println(new File(folderPath).getAbsolutePath());
        Tokenizer tokenizer = new Tokenizer(folderPath);
        invertedIndex = tokenizer.getInvertedIndex();
    }

    @Test
    public void testQuery1() {
        String queryStr = "+slm -mahdi mohamadhosein halet khobe";
        query = new Query(queryStr, invertedIndex);
        HashSet<Integer> result = query.process();
        HashSet<Integer> expectedResult = new HashSet<>();
        expectedResult.add(3);
        Assert.assertEquals(expectedResult, result);
    }

    @Test
    public void testQuery() {
        String queryStr = "+slm -mahdi";
        query = new Query(queryStr, invertedIndex);
        HashSet<Integer> result = query.process();
        HashSet<Integer> expectedResult = new HashSet<>();
        expectedResult.add(3);
        Assert.assertEquals(expectedResult, result);
    }

}