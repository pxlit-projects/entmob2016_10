package be.pxl.rest.unit;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.repository.StrongPlateRepository;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateServiceImpl;
import org.mockito.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.dao.RecoverableDataAccessException;

import java.util.ArrayList;
import java.util.List;

import static org.mockito.Matchers.any;
import static org.mockito.Matchers.anyObject;
import static org.mockito.Mockito.doThrow;
import static org.mockito.Mockito.when;

/**
 * Created by Pieter on 24/10/2016.
 */
@Configuration
public class StrongPlateServiceTestConfig {

    @Bean
    public StrongPlateService testPlateService() {
        StrongPlateService sService = Mockito.mock(StrongPlateServiceImpl.class);
        List<Plate> plates = new ArrayList<>();
        Plate plateData1 = new Plate(1, 20.6);

        plates.add(plateData1);

        when(sService.getStrongPlateData()).thenReturn(plates);
        when(sService.getStrongPlateDataByUserId(1)).thenReturn(plates);
        doThrow(new RecoverableDataAccessException("Tothier")).when(sService).setStrongPlateData(anyObject());

        return sService;

    }


}
