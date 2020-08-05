package app;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;

public class FileReader {
    private File file;

    public FileReader(File file) {
        this.file = file;
    }

    // scan the file and add return tokens in hashset
    public HashSet<String> scan() {
        HashSet<String> result = new HashSet<String>();
        try {
            Scanner sc = new Scanner(file);
            while (sc.hasNext()){
                String currentToken = sc.next();
                result.add(currentToken.toLowerCase());
            }
            sc.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        return result;
    }
    
}