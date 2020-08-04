package app;

import java.io.File;
import java.util.HashMap;
import java.util.HashSet;


public class Tokenizer {
    private HashMap<String, HashSet<Integer>> invertedIndex = new HashMap<>();
    private String folderPath;

    public HashMap<String, HashSet<Integer>> getInvertedIndex() {
        return invertedIndex;
    }
    /**
     * 
     * @param folderPath address of folder that we store documents in it
     */
    public Tokenizer(String folderPath) {
        this.folderPath = folderPath;
        initFilePaths(); // init and start tokenize
    }

    public void initFilePaths() {
        File folder = new File(folderPath);
        File[] listOfFiles = folder.listFiles();//get files in folder path
        for (File file: listOfFiles)
            if (file.isFile())
                tokenize(file); // tokenize all files and set them to invertedIndex
    }

    public void tokenize(File file) {
        HashSet<String> tokens;
        FileReader sc = new FileReader(file);
        tokens = sc.scan();
        addDocIdToTokens(tokens, Integer.valueOf(file.getName()));
    }

    public void addDocIdToTokens(HashSet<String> tokens, int docId) {
        for (String token : tokens) {
            this.invertedIndex.putIfAbsent(token, new HashSet<Integer>());
            this.invertedIndex.get(token).add(docId);
        }
    }
}