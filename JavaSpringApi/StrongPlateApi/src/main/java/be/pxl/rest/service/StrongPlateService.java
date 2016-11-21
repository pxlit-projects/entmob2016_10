package be.pxl.rest.service;

import be.pxl.rest.entity.Plate;
import java.util.List;
import java.util.OptionalDouble;

/**
 * Created by Pieter on 19/10/2016.
 */
public interface StrongPlateService {

    void setStrongPlateData(Plate plate);

    Iterable<Plate> getStrongPlateData();

    List<Plate> getStrongPlateDataByUserId(long userId);

    void deleteAllStrongPlateData();

    double calculateAverageSpeed(List<Plate> plateList);


}
