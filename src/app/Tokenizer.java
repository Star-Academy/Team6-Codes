package app;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class Tokenizer {
    private HashMap<String, ArrayList<Integer>> invertedIndex = new HashMap<>();
    private ArrayList<File> files = new ArrayList<>();
    private String folderPath;
    


    public Tokenizer(String folderPath) {
        this.folderPath = folderPath;
        initFilePaths();
    }

    public void initFilePaths(){
        File folder = new File(folderPath);
        File[] listOfFiles = folder.listFiles();
        for (int i = 0; i < listOfFiles.length; i++) 
            if (listOfFiles[i].isFile()) 
                files.add(listOfFiles[i]);
    }

    public void tokenize(){
        HashSet<String> tokens;
        for (File file : files) {
            CustomScanner sc = new CustomScanner(file);
            tokens = sc.scan();
            init(tokens , Integer.valueOf(file.getName()));
        }
    }

    public void init (HashSet<String> tokens , int docId){
        for (String token : tokens){
            this.invertedIndex.putIfAbsent(token, new ArrayList<Integer>());
            this.invertedIndex.get(token).add(docId);
        }
    }

    public ArrayList<Integer> query(String word){
        return invertedIndex.get(word);
    }

}