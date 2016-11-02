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

    public Plate(LocalDateTime createdOn, double xG, double yG, double zG, double xS, double yS, double zS, double xUt, double yUt, double zUt, boolean magnetic, User user) {
        this.createdOn = createdOn;
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

    public double getxG() {
        return xG;
    }

    public void setxG(double xG) {
        this.xG = xG;
    }

    public double getyG() {
        return yG;
    }

    public void setyG(double yG) {
        this.yG = yG;
    }

    public double getzG() {
        return zG;
    }

    public void setzG(double zG) {
        this.zG = zG;
    }

    public double getxS() {
        return xS;
    }

    public void setxS(double xS) {
        this.xS = xS;
    }

    public double getyS() {
        return yS;
    }

    public void setyS(double yS) {
        this.yS = yS;
    }

    public double getzS() {
        return zS;
    }

    public void setzS(double zS) {
        this.zS = zS;
    }

    public double getxUt() {
        return xUt;
    }

    public void setxUt(double xUt) {
        this.xUt = xUt;
    }

    public double getyUt() {
        return yUt;
    }

    public void setyUt(double yUt) {
        this.yUt = yUt;
    }

    public double getzUt() {
        return zUt;
    }

    public void setzUt(double zUt) {
        this.zUt = zUt;
    }

    public boolean isMagnetic() {
        return magnetic;
    }

    public void setMagnetic(boolean magnetic) {
        this.magnetic = magnetic;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }
}
