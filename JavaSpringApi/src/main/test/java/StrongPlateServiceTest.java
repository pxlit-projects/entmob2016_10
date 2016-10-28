import be.pxl.rest.controller.StrongPlateController;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.repository.StrongPlateRepository;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateServiceImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.ResponseEntity;

import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import javax.validation.constraints.AssertFalse;
import javax.validation.constraints.AssertTrue;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 21/10/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = StrongPlateServiceTestConfig.class)
@DirtiesContext
public class StrongPlateServiceTest {

    @Autowired
    private StrongPlateService testPlateService;

   /* @Test
    public void getStalePlateDataTest(){

        List<Plate> plateList = (List<Plate>) testPlateService.getStrongPlateData();
        Assert.assertFalse(plateList.isEmpty());

    }*/
    @Test
    public void getStalePlateByUserIdTest(){
        List<Plate> plateList =  testPlateService.getStrongPlateDataByUserId(1);
        Plate plateData1 = new Plate(1,20.6);

        Assert.assertEquals(plateList.get(0), plateData1.getId());

    }










}
