package be.pxl.rest.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;
import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 28/10/2016.
 */
@Entity
public class User {

    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Id
    private long id;

    @Column
    private String lastName;

    @Column
    private String firstName;

    @Column
    private String password;

    @Column
    private String role;

    @Column
    private double averageSpeed;

    @Column
    private double averageSteadyness;

    @Column
    private boolean enabled;

    @JsonIgnore
    @OneToMany(mappedBy = "user")
    private List<Plate> platesData = new ArrayList<>();

    public User(String lastName, String firstName, String password, String role, double averageSpeed, double averageSteadyness, boolean enabled) {
        this.lastName = lastName;
        this.firstName = firstName;
        this.password = password;
        this.role = role;
        this.averageSpeed = averageSpeed;
        this.averageSteadyness = averageSteadyness;
        this.enabled = enabled;
        this.platesData = platesData;
    }

    public User() {
    }

    public void setId(long id) {
        this.id = id;
    }

    public long getId() {
        return id;
    }

    public String getLastName() {
        return lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getPassword() {
        return password;
    }

    public String getRole() {
        return role;
    }

    public double getAverageSpeed() {
        return averageSpeed;
    }

    public double getAverageSteadyness() {
        return averageSteadyness;
    }

    public boolean isEnabled() {
        return enabled;
    }

    public List<Plate> getPlatesData() {
        return platesData;
    }

}
