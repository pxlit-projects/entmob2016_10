package be.pxl.rest.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;
import org.springframework.context.annotation.Primary;

import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 28/10/2016.
 */
@Entity
public class User {


    @GeneratedValue()
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

    public User(String lastName, String firstName, String password, String role, double averageSpeed, double averageSteadyness, boolean enabled, List<Plate> platesData) {
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

    public void setId(int id) {
        this.id = id;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public double getAverageSpeed() {
        return averageSpeed;
    }

    public void setAverageSpeed(double averageSpeed) {
        this.averageSpeed = averageSpeed;
    }

    public double getAverageSteadyness() {
        return averageSteadyness;
    }

    public void setAverageSteadyness(double averageSteadyness) {
        this.averageSteadyness = averageSteadyness;
    }

    public boolean isEnabled() {
        return enabled;
    }

    public void setEnabled(boolean enabled) {
        this.enabled = enabled;
    }

    public List<Plate> getPlatesData() {
        return platesData;
    }

    public void setPlatesData(List<Plate> platesData) {
        this.platesData = platesData;
    }

   }
