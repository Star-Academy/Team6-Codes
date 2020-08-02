package app;

import java.util.HashMap;
import java.util.HashSet;

import java.util.ArrayList;
import java.util.Arrays;

public class Query {
    private String query;
    private HashMap<String, HashSet<Integer>> invertedIndex;

    public Query(String query, HashMap<String, HashSet<Integer>> invertedIndex) {
        this.query = query;
        this.invertedIndex = invertedIndex;
    }

    public ArrayList<String>[] split() {
        ArrayList<String>[] queryTypes = new ArrayList[3];
        for (int i = 0; i < queryTypes.length; i++) {
            queryTypes[i] = new ArrayList<>();
        }

        for (String queryWord : query.split(" ")) {
            switch (queryWord.charAt(0)) {
            case '+':
                queryTypes[1].add(queryWord.substring(1));
                break;
            case '-':
                queryTypes[2].add(queryWord.substring(1));
                break;
            default:
                queryTypes[0].add(queryWord);
            }
        }
        return queryTypes;
    }

    public HashSet<Integer> process() {
        ArrayList<String>[] queryTypes = split();
        HashSet<Integer> res = typeAnd(queryTypes[0]);
        typeOr(queryTypes[1], res);
        typeDel(queryTypes[2], res);
        return res;
    }

    private HashSet<Integer> typeAnd(ArrayList<String> queries) {
        if (queries.size() == 0)
            return new HashSet<>(); 

        HashSet<Integer> res = new HashSet<>(invertedIndex.get(queries.get(0)));

        for (int i = 1; i < queries.size(); i++) {
            res.retainAll(invertedIndex.get(queries.get(i)));
        }
        return res;
    }

    private void typeOr(ArrayList<String> queries, HashSet<Integer> res) {
        for (String query : queries)
            res.addAll(invertedIndex.get(query));
    }

    private void typeDel(ArrayList<String> queries, HashSet<Integer> res) {
        for (String queryWord : queries)
            res.removeAll(invertedIndex.get(queryWord));
    }

}