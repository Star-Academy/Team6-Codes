package app;

import java.util.HashSet;
import java.util.Scanner;

public class App {

    private static Tokenizer tokenizer;
    private static Scanner scanner;

    public static void main(String[] args) {
        start();
    }

    public static void start(){
        scanner = new Scanner(System.in);
        String folderPath = scanner.nextLine();
        initDocs(folderPath);
        String queString = scanner.nextLine();
        search(queString);
        scanner.close();
    }

    // get folder path to begin process
    public static void initDocs(String folderPath){
        tokenizer = new Tokenizer(folderPath);
    }

    // make queries and print their response
    public static void search(String queString){
        Query query = new Query(queString.toLowerCase(), tokenizer.getInvertedIndex());
        HashSet<Integer> docIndex = query.process();
        for (Integer integer : docIndex)
            System.out.println(integer);
    }
}