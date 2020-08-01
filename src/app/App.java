package app;

import java.util.ArrayList;
import java.util.Scanner;

public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String folderPath = scanner.next();
        Tokenizer tokenizer = new Tokenizer(folderPath);
        tokenizer.tokenize();
        String word = scanner.next();
        ArrayList<Integer> docIndex = tokenizer.query(word);
        for (Integer integer : docIndex) {
            System.out.println(integer);
        }
        scanner.close();
    }
}