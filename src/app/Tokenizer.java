package app;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class Tokenizer {
    private HashMap<String, ArrayList<Integer>> invertedIndex;
    private ArrayList<File> files;
    private String folderPath;
    


    public Tokenizer(String folderPath) {
        this.folderPath = folderPath;
        initFilePaths(folderPath);
    }

    public void initFilePaths(String folderPath){

        File folder = new File(folderPath);

        File[] listOfFiles = folder.listFiles();

        for (int i = 0; i < listOfFiles.length; i++) {
            if (listOfFiles[i].isFile()) 
                files.add(listOfFiles[i]);
            else if (listOfFiles[i].isDirectory())
                initFilePaths(listOfFiles[i]);
        }
    }

    public void tokenize(){
        HashSet<String> tokens;
        for (int i = 0; i < filePaths.size(); i++) {
            CustomScanner sc = new CustomScanner(filePaths.get(i));
            tokens = sc.scan();
            init(tokens , );
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