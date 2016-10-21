package be.pxl.rest.service;

import be.pxl.rest.entity.Plate;
import org.springframework.data.repository.query.Param;

import java.util.List;

/**
 * Created by Pieter on 19/10/2016.
 */
public interface StrongPlateService {

    void stalePlateCall(Plate plate);

    Iterable<Plate> getStalePlateData();

    public List<Plate> getStalePlateDataByUserId(long userId);

}
