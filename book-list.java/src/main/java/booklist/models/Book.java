package booklist.models;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class Book {
    private String name;
    private int page;
    private String author;
    private int release;

    public Book(String name, int page, String author, int release) {
        this.name = name;
        this.page = page;
        this.author = author;
        this.release = release;
    }

    @Override
    public String toString() {
        return String.format("%s|%s|%s|%s", this.name, this.page, this.author, this.release);
    }
}
