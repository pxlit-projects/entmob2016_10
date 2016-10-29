package be.pxl.rest.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;
import org.hibernate.annotations.NamedQuery;

import javax.persistence.*;
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
    private double xG;//gkracht?

    @Column
    private double yG;

    @Column
    private double zG;

    @Column
    private double xS;//graden

    @Column
    private double yS;

    @Column
    private double zS;

    @Column
    private double xUt;//uT

    @Column
    private double yUt;

    @Column
    private double zUt;

    @Column
    private boolean magnetic;


    @JsonIgnore
    @ManyToOne
    private User user;


    public Plate(){

    }

   /* public Plate(long userId, double temperature){
        this.createdOn = LocalDateTime.now();
        this.userId = userId;
        this.temperature = temperature;
    }*/


}
