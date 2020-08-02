package app;

import java.util.HashSet;
import java.util.Scanner;

public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String folderPath = scanner.nextLine();
        Tokenizer tokenizer = new Tokenizer(folderPath);
        tokenizer.tokenize();
        String queString = scanner.nextLine();
        Query query = new Query(queString.toLowerCase(), tokenizer.getInvertedIndex());
        HashSet<Integer> docIndex = query.process();
        for (Integer integer : docIndex)
            System.out.println(integer);
        scanner.close();
    }
}