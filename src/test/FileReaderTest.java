package test;

import static org.junit.Assert.assertArrayEquals;
import static org.junit.Assert.assertEquals;

import java.io.File;
import java.net.URL;
import java.util.HashSet;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import app.FileReader;

public class FileReaderTest {

    private FileReader fileReader;

    private FileReader fileReaderForInvalidAddress;

    @Before
    public void initFileReaderClass() {
        File file = new File("/home/mahdi/Documents/code-star/Team-6/src/test/test-data/1");
        fileReader = new FileReader(file);

        File fileInvalidAddress = new File("address alaki");
        fileReaderForInvalidAddress = new FileReader(fileInvalidAddress);
    }

    @Test
    public void scanTest() {
        HashSet<String> testHash = new HashSet<>();
        testHash.add("slm");
        testHash.add("haj");
        testHash.add("mohammad");
        testHash.add("mahdi");
        assertArrayEquals(testHash.toArray(), fileReader.scan().toArray());
    }

    @Test
    public void scanInvalidAddress() {
        Assert.assertEquals(0, fileReaderForInvalidAddress.scan().size());

    }

}