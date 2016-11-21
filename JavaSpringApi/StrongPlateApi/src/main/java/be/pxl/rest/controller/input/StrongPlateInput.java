package be.pxl.rest.controller.input;

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

    public StrongPlateInput(double xG, double yG, double zG, double xS, double yS, double zS, double xUt, double yUt, double zUt, boolean magnetic, long userId) {
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
        this.userId = userId;
    }
    public StrongPlateInput(){
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

    public long getUserId() { return userId;  }



}

