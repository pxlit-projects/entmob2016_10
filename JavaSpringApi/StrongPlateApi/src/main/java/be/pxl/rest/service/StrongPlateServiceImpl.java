package be.pxl.rest.service;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.repository.AverageSpeedCalculator;
import be.pxl.rest.repository.StrongPlateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import javax.transaction.Transactional;
import java.util.List;
import java.util.OptionalDouble;

/**
 * Created by Pieter on 19/10/2016.
 */
@Service
@Transactional
public class StrongPlateServiceImpl implements StrongPlateService {

    @Autowired
    private StrongPlateRepository strongPlateRepository;

    @Override
    public void setStrongPlateData(Plate plate) {strongPlateRepository.save(plate);}

    @Override
    public Iterable<Plate> getStrongPlateData() {
        return strongPlateRepository.findAll();
    }

    @Override
    public List<Plate> getStrongPlateDataByUserId(long userId) {
        return strongPlateRepository.getStalePlateDataByUserId(userId);
    }

    @Override
    public void deleteAllStrongPlateData() {
        strongPlateRepository.deleteAll();
    }

    @Override
    public double calculateAverageSpeed(List<Plate> plateList) {
        return AverageSpeedCalculator.CalculateAverageSpeed(plateList);
    }
}
