import be.pxl.rest.controller.StrongPlateController;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.service.StrongPlateService;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.ResponseEntity;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.List;

/**
 * Created by Pieter on 21/10/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringBootTest
public class StrongPlateServiceTest {

    @Autowired
    private StrongPlateController strongPlateController;

    @Test
    public void exampleTest() {
      // ResponseEntity<Plate> plates = strongPlateController.getStrongPlateData();
    }





}
