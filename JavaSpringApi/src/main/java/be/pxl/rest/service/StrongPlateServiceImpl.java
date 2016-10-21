package be.pxl.rest.service;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.repository.StrongPlateRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 19/10/2016.
 */
@Service
@Transactional
public class StrongPlateServiceImpl implements StrongPlateService {

    @Autowired
    private StrongPlateRepository strongPlateRepository;

    @Override
    public void stalePlateCall(Plate plate) {
        strongPlateRepository.save(plate);
    }

    @Override
    public Iterable<Plate> getStalePlateData() {
        return strongPlateRepository.findAll();
    }

    @Override
    public List<Plate> getStalePlateDataByUserId(long userId) {
        return strongPlateRepository.getStalePlateDataByUserId(userId);
    }
}
