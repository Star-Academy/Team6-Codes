package app;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Scanner;

public class CustomScanner {
    private String filePath;

    public CustomScanner(String filePath) {
        this.filePath = filePath;
    }

    public HashSet<String> scan() {
        HashSet<String> result = new HashSet();
        File file = new File(filePath);
        Scanner sc = null;

        try {
            sc = new Scanner(file);
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        while (sc.hasNext()){
            String currentToken = sc.next();
            result.add(currentToken);
        }
        return result;
    }
    
}