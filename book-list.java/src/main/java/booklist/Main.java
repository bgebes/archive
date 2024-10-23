package booklist;

import booklist.models.Book;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {
    public static void main(String[] args) {
        List<Book> bookList = new ArrayList<>();

        bookList.add(new Book("The House of Mirth", 100, "Edith Wharton", 1905));
        bookList.add(new Book("East of Eden", 120, "John Steinbeck", 1952));
        bookList.add(new Book("Brave New World", 130, "Aldous Huxley", 1910));
        bookList.add(new Book("Pale Fire", 145, "Vladımır Nabokov", 1980));
        bookList.add(new Book("In Cold Blood", 300, "Truman Capote", 1990));
        bookList.add(new Book("Pride and Prejudice", 180, "Jane Austen", 1813));
        bookList.add(new Book("The Alchemist", 160, "Paulo Coelho", 1988));
        bookList.add(new Book("The Lord of the Rings", 250, "J.R.R. Tolkien", 1954));
        bookList.add(new Book("To the Lighthouse", 120, "Virginia Woolf", 1927));
        bookList.add(new Book("Siddhartha", 140, "Hermann Hesse", 1922));

        System.out.println("Book List: " + bookList);

        Map<String, String> booksByAuthor = new HashMap<>();
        bookList.forEach(book -> booksByAuthor.put(book.getName(), book.getAuthor()));

        System.out.println("Book List by Author: " + booksByAuthor);

        List<Book> filterByPage = bookList.stream().filter(book -> book.getPage() > 100).toList();
        System.out.println("Filtered Book List by Page Length > 100: " + filterByPage);
    }
}