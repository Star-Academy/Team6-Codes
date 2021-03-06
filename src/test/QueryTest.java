package test;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import app.Query;

public class QueryTest {
    private Query query;
    private HashMap<String, HashSet<Integer>> invertedIndex = new HashMap<>();
    private String folderPath = "src/test/test-data";

    @Before
    public void setInvertedIndex() {
        invertedIndex.put("slm", new HashSet<>(Arrays.asList(1, 2, 3)));
        invertedIndex.put("mahdi", new HashSet<>(Arrays.asList(1, 2)));
        invertedIndex.put("mohamadhosein", new HashSet<>(Arrays.asList(2, 3)));
        invertedIndex.put("haj", new HashSet<>(Arrays.asList(1)));

    }

    @Test
    public void testQuery1() {
        String queryStr = "+slm -mahdi mohamadhosein";
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