package app;

import java.util.ArrayList;

public class QueryType {
    public ArrayList<String> andType;
    public ArrayList<String> orType;
    public ArrayList<String> delType;

    public QueryType(String query){
        andType = new ArrayList<>();
        orType = new ArrayList<>();
        delType = new ArrayList<>();
        split(query);
    }

    private void split(String query) {
        for (String queryWord : query.split(" ")) {
            switch (queryWord.charAt(0)) {
            case '+':
                orType.add(queryWord.substring(1));
                break;
            case '-':
                delType.add(queryWord.substring(1));
                break;
            default:
                andType.add(queryWord);
            }
        }
    }
    
}