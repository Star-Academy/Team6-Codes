package test;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import org.junit.Before;
import org.junit.Test;

import app.QueryType;

public class QueryTypeTest {

    private String query;
    QueryType queryType;

    List<String> querySplit;

    @Before
    public void initQueryTypeClassTest() {
        query = "+or1 +or2 +or3 -delete1 -delete2 -delete3 and1 and2 and3";
        queryType = new QueryType(query);
        query = query.replaceAll("[\\-\\+]", "");
        querySplit = Arrays.asList(query.split(" "));
    }

    @Test
    public void queryAndTest() {
        ArrayList<String> checkAnd = new ArrayList<>();
        checkAnd.addAll(querySplit.subList(6, 9));
        assertEquals(checkAnd, queryType.andType);
    }

    @Test
    public void queryOrTest() {
        ArrayList<String> checkOr = new ArrayList<>();
        checkOr.addAll(querySplit.subList(0, 3));
        assertEquals(checkOr, queryType.orType);
    }

    @Test
    public void queryDeleteTest() {
        ArrayList<String> checkDelete = new ArrayList<>();
        checkDelete.addAll(querySplit.subList(3, 6));
        assertEquals(checkDelete, queryType.delType);
    }

}