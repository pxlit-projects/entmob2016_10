package be.pxl.rest.entity;

import com.fasterxml.jackson.annotation.JsonIgnore;
import javax.persistence.*;
import java.io.Serializable;
import java.time.LocalDateTime;

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
    private double xG;

    @Column
    private double yG;

    @Column
    private double zG;

    @Column
    private double xS;

    @Column
    private double yS;

    @Column
    private double zS;

    @Column
    private double xUt;

    @Column
    private double yUt;

    @Column
    private double zUt;

    @Column
    private boolean magnetic;

    @JsonIgnore
    @ManyToOne
    private User user;

    public Plate(double xG, double yG, double zG, double xS, double yS, double zS, double xUt, double yUt, double zUt, boolean magnetic, User user) {
        this.createdOn = LocalDateTime.now();
        this.xG = xG;
        this.yG = yG;
        this.zG = zG;
        this.xS = xS;
        this.yS = yS;
        this.zS = zS;
        this.xUt = xUt;
        this.yUt = yUt;
        this.zUt = zUt;
        this.magnetic = magnetic;
        this.user = user;
    }

    public Plate() {

    }

    public long getId() {
        return id;
    }

    public LocalDateTime getCreatedOn() {
        return createdOn;
    }

    public double getxG() {
        return xG;
    }

    public double getyG() {
        return yG;
    }

    public double getzG() {
        return zG;
    }

    public double getxS() {
        return xS;
    }

    public double getyS() {
        return yS;
    }

    public double getzS() {
        return zS;
    }

    public double getxUt() {
        return xUt;
    }

    public double getyUt() {
        return yUt;
    }

    public double getzUt() {
        return zUt;
    }

    public boolean isMagnetic() {
        return magnetic;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }
}
