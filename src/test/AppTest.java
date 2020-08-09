package test;

import app.App;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.io.*;

import static org.junit.Assert.assertEquals;


public class AppTest {

    private final ByteArrayOutputStream outContent = new ByteArrayOutputStream();
    private final ByteArrayOutputStream errContent = new ByteArrayOutputStream();

    private final PrintStream originalOut = System.out;
    private final PrintStream originalErr = System.err;

    @Before
    public void init(){
        System.setOut(new PrintStream(outContent));
        System.setErr(new PrintStream(errContent));
    }
    @After
    public void after(){
        System.setOut(originalOut);
        System.setErr(originalErr);
    }
    @Test
    public void mainTest() throws IOException {

        App.initDocs("C:\\Users\\Mohammad hossein\\Desktop\\codecovrage\\src\\test\\data");
        App.search("+slm +haj");



        String newLine = System.getProperty("line.separator");
        assertEquals("1" +newLine+
                "2" + newLine+
                "3"+newLine, outContent.toString());

    }
}
