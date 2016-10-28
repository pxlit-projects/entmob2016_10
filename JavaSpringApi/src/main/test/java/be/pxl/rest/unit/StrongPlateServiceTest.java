package be.pxl.rest.unit;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.service.StrongPlateService;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.dao.RecoverableDataAccessException;

import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

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

    @Test
    public void getStalePlateDataTest() {
        List<Plate> plateList = (List<Plate>) testPlateService.getStrongPlateData();

        Assert.assertFalse(plateList.isEmpty());

    }

    @Test
    public void getStalePlateByUserIdTest() {
        List<Plate> plateList = testPlateService.getStrongPlateDataByUserId(1);
        Plate plateData1 = new Plate(1, 20.6);

        Assert.assertEquals("Komt niet overeen", plateList.get(0).getUserId(), plateData1.getUserId());

    }
    @Test(expected = RecoverableDataAccessException.class)
    public void setStrongPlateDataTest(){
        Plate p2 = new Plate(3, 18.4);
        testPlateService.setStrongPlateData(p2);
    }


}
