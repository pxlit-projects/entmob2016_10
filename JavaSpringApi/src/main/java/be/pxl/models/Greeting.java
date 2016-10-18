package be.pxl.models;

import javax.persistence.Entity;
import javax.persistence.Id;

/**
 * Created by Pieter on 17/10/2016.
 */
@Entity
public class Greeting {

    @Id
    private long id;
    private String content;

    public Greeting(long id, String content) {
        this.id = id;
        this.content = content;
    }

    public Greeting() {
    }

    public long getId() {
        return id;
    }

    public String getContent() {
        return content;
    }
}
