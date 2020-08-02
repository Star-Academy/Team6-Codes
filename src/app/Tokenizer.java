package app;

import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

public class Tokenizer {
    private HashMap<String, HashSet<Integer>> invertedIndex = new HashMap<>();
    private ArrayList<File> files = new ArrayList<>();
    private String folderPath;

    public HashMap<String, HashSet<Integer>> getInvertedIndex() {
        return invertedIndex;
    }

    public Tokenizer(String folderPath) {
        this.folderPath = folderPath;
        initFilePaths();
    }

    public void initFilePaths() {
        File folder = new File(folderPath);
        File[] listOfFiles = folder.listFiles();
        for (int i = 0; i < listOfFiles.length; i++)
            if (listOfFiles[i].isFile())
                files.add(listOfFiles[i]);
    }

    public void tokenize() {
        HashSet<String> tokens;
        for (File file : files) {
            CustomScanner sc = new CustomScanner(file);
            tokens = sc.scan();
            init(tokens, Integer.valueOf(file.getName()));
        }
    }

    public void init(HashSet<String> tokens, int docId) {
        for (String token : tokens) {
            this.invertedIndex.putIfAbsent(token, new HashSet<Integer>());
            this.invertedIndex.get(token).add(docId);
        }
    }
}