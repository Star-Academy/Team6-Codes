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
    private ByteArrayInputStream inputContent;
    private StringBuilder inputData = new StringBuilder();
    private final PrintStream originalOut = System.out;
    private final PrintStream originalErr = System.err;

    @Before
    public void init() {
        System.setOut(new PrintStream(outContent));
        System.setErr(new PrintStream(errContent));
    }

    @After
    public void after() {
        System.setOut(originalOut);
        System.setErr(originalErr);
    }

    @Test
    public void mainTest() throws IOException {

        App.initDocs("src/test/test-data");
        App.search("+slm +haj");

        String newLine = System.getProperty("line.separator");
        assertEquals("1" + newLine +
                "2" + newLine +
                "3" + newLine, outContent.toString());

    }

    @Test
    public void testStart() {
        inputData.append("src/test/test-data").append(System.getProperty("line.separator")).append("+slm +haj");
        inputContent = new ByteArrayInputStream(inputData.toString().getBytes());
        System.setIn(inputContent);
        App.main(new String[2]);
        String newLine = System.getProperty("line.separator");
        assertEquals("1" + newLine +
                "2" + newLine +
                "3" + newLine, outContent.toString());

    }
}
