package be.pxl.rest.unit;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateRepository;
import be.pxl.rest.service.StrongPlateServiceImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import java.util.ArrayList;
import java.util.List;
import static org.mockito.Matchers.any;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

/**
 * Created by Pieter on 21/10/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@DirtiesContext
public class StrongPlateServiceTest {

    @InjectMocks
    private StrongPlateServiceImpl testPlateService;

    @Mock
    private StrongPlateRepository strongPlateRepository;

    private List<Plate> plateList;
    private User user;
    private Plate plate;

    @Before
    public void setUpData() throws Exception {
        user = new User();
        plateList = new ArrayList<>();
        plate = new Plate(20, 30, 21, 100, 89, 23, 20, 48, 10, true, user);
        user.setId(1);
        plateList.add(plate);
    }

    @Test
    public void getStronPlateDataTest() {
        when(strongPlateRepository.findAll()).thenReturn(plateList);
        List<Plate> plates = (List<Plate>) testPlateService.getStrongPlateData();
        Assert.assertFalse(plates.isEmpty());
    }

    @Test
    public void setStrongPlataDataTest() {
        testPlateService.setStrongPlateData(plate);
        verify(strongPlateRepository).save(any(Plate.class));
    }

    @Test
    public void getStrongPlateDataByUserIdTest(){
        when(strongPlateRepository.getStalePlateDataByUserId(user.getId())).thenReturn(plateList);
        List<Plate> plates = (List<Plate>) testPlateService.getStrongPlateDataByUserId(user.getId());
        Assert.assertEquals(plateList, plates);
    }


}
