package app;

import java.util.Scanner;

public class App {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String folderPath = scanner.next();
        Tokenizer tokenizer = new Tokenizer(folderPath);
        tokenizer.tokenize();
    }
}