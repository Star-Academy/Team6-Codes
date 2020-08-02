package app;

import java.util.HashMap;
import java.util.HashSet;

import java.util.ArrayList;

public class Query {
    private String query;
    private HashMap<String, HashSet<Integer>> invertedIndex;
    private HashSet<Integer> res;

    public Query(String query, HashMap<String, HashSet<Integer>> invertedIndex) {
        this.query = query;
        this.invertedIndex = invertedIndex;
    }

    public HashSet<Integer> process() {
        res = new HashSet<>();
        QueryType queryType = new QueryType(query);
        typeAnd(queryType.andType);
        typeOr(queryType.orType);
        typeDel(queryType.delType);
        return res;
    }

    private void typeAnd(ArrayList<String> queries) {
        if (queries.size() == 0)
            return;
        res.addAll(invertedIndex.get(queries.get(0)));
        for (int i = 1; i < queries.size(); i++) 
            res.retainAll(invertedIndex.get(queries.get(i)));
    }

    private void typeOr(ArrayList<String> queries) {
        for (String query : queries)
            res.addAll(invertedIndex.get(query));
    }

    private void typeDel(ArrayList<String> queries) {
        for (String queryWord : queries)
            res.removeAll(invertedIndex.get(queryWord));
    }

}