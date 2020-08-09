package test;

import static org.junit.Assert.assertArrayEquals;

import java.io.File;
import java.util.HashSet;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import app.FileReader;

public class FileReaderTest {

    private String folderPath = "/home/mahdi/Documents/code-star/Team-6/src/app/test/test-data/1";
    private FileReader fileReader;

    private FileReader fileReaderForInvalidAddress;

    @Before
    public void initFileReaderClass() {
        File file = new File(folderPath);
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