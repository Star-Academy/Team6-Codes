package app;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;

public class CustomScanner {
    private File file;

    public CustomScanner(File file) {
        this.file = file;
    }

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