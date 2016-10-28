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

    //@InjectMocks
    //@Autowired
    private StrongPlateService sService = new StrongPlateServiceImpl();



    @Bean
    public StrongPlateService testPlateService(){
        //StrongPlateService sService = Mockito.mock(strongplateServiceImpl.class);
        List<Plate> plates = new ArrayList<>();
        Plate plateData1 = new Plate(1,20.6);

        plates.add(plateData1);
       //return new StrongPlateServiceImpl();
        //when(sService.setStrongPlateData(any(Plate.class))).thenReturn(false).thenReturn(plat);
                //then(plates.add(plate)).thenReturn(false);
        when(sService.getStrongPlateData()).thenReturn(plates);
        when(sService.getStrongPlateDataByUserId(1)).thenReturn(plates);
        return sService;
      // return null;


    }
    @Bean
    public StrongPlateRepository strongPlateRepository(){
       List<Plate> plates = new ArrayList<>();
        plates.add(new Plate(2, 7.0));
        StrongPlateRepository sRepository = Mockito.mock(StrongPlateRepository.class);
        doThrow(new RecoverableDataAccessException("oeps")).when(sRepository).save((Plate)anyObject());
        when(sRepository.findAll()).thenReturn(plates);
        return sRepository;

    }

}
