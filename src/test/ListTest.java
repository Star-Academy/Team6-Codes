package test;

import java.util.ArrayList;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class ListTest {
    private ArrayList<Integer> ar = new ArrayList<>();

    @Before
    public void setup() {
        ar.add(0);
        ar.add(1);
        ar.add(2);
    }

    @Test
    public void test() {
        Assert.assertEquals(3, ar.size());
    }
}