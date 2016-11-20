package be.pxl.rest.unit;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.repository.AverageSpeedCalculator;
import org.junit.Ignore;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.time.LocalDateTime;
import java.time.Month;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 20/11/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
public class AverageSpeedCalculatorTest {
    private List<Plate> plateListAv;
    private LocalDateTime[] creationTime;
    private Plate d;
    private AverageSpeedCalculator averageSpeedCalculator;

    @Before
    public void setUp() throws Exception {
        plateListAv = new ArrayList<>();
        creationTime = new LocalDateTime[7];
        averageSpeedCalculator = new AverageSpeedCalculator();
        creationTime[0] = LocalDateTime.of(2016, Month.APRIL, 5, 10, 10, 30);
        creationTime[1] = LocalDateTime.of(2016, Month.APRIL, 5, 10, 10, 50);
        creationTime[2] = LocalDateTime.of(2016, Month.APRIL, 5, 10, 11, 15);
        creationTime[3] = LocalDateTime.of(2016, Month.APRIL, 6, 10, 10, 5);
        creationTime[4] = LocalDateTime.of(2016, Month.APRIL, 6, 10, 10, 25);
        creationTime[5] = LocalDateTime.of(2016, Month.APRIL, 6, 10, 10, 50);
        creationTime[6] = LocalDateTime.of(2016, Month.APRIL, 6, 10, 10, 45);
        for (int i = 0; i < 7; i++) {
            d = new Plate(20, 30, 21, 100, 89, 23, 20, 48, 10, true, null);
            d.setCreatedOn(creationTime[i]);
            plateListAv.add(d);
        }
        plateListAv.get(6).setMagnetic(false);
    }

    @Test
    public void calculateAverageTest() {
        double average = averageSpeedCalculator.CalculateAverageSpeed(plateListAv);


        Assert.assertEquals(22.5, average, 0.1);
    }


}
