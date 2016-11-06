package be.pxl.rest.controller.input;

import be.pxl.rest.entity.User;

import java.time.LocalDateTime;

/**
 * Created by Pieter on 19/10/2016.
 */
public class StrongPlateInput {

    private double xG;//gkracht?
    private double yG;
    private double zG;
    private double xS;//graden
    private double yS;
    private double zS;
    private double xUt;//uT
    private double yUt;
    private double zUt;
    private boolean magnetic;
    private long userId;


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

    public long getUserId() { return userId;  }


}

