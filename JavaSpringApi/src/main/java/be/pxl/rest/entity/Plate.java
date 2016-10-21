package be.pxl.rest.entity;

import org.hibernate.annotations.NamedQuery;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import java.io.Serializable;
import java.time.LocalDateTime;
import java.util.UUID;

/**
 * Created by Pieter on 19/10/2016.
 */
@Entity

public class Plate implements Serializable {

    @Id
    @GeneratedValue
    private long id;

    @Column
    private LocalDateTime createdOn;

    @Column
    private long userId;

    @Column
    private double temperature;

    public Plate(){

    }

    public Plate(long userId, double temperature){
        this.createdOn = LocalDateTime.now();
        this.userId = userId;
        this.temperature = temperature;
    }

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public LocalDateTime getCreatedOn() {
        return createdOn;
    }

    public void setCreatedOn(LocalDateTime createdOn) {
        this.createdOn = createdOn;
    }

    public long getUserId() {
        return userId;
    }

    public void setUserId(Long userId) {
        this.userId = userId;
    }

    public double getTemperature() {
        return temperature;
    }

    public void setTemperature(double temperature) {
        this.temperature = temperature;
    }
}
