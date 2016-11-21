package be.pxl.rest.integration;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateRepository;
import be.pxl.rest.repository.StrongPlateUserRepository;
import org.hibernate.exception.ConstraintViolationException;
import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.junit4.SpringRunner;
import java.util.List;

/**
 * Created by Pieter on 20/11/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringBootTest
public class StrongPlateRepositoryIntegrationTest {

    @Autowired
    private StrongPlateRepository strongPlateRepository;

    @Autowired
    private StrongPlateUserRepository strongPlateUserRepository;//nodig om innitiele gebruiker in database te zetten

    private User newOber;

    @Before
    public void setUp() throws Exception {
        try{
        newOber = new User("Ober", "The", 20,true, "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        newOber.setId(1);

            strongPlateUserRepository.save(newOber);
            Plate plate = new Plate(20, 40, 67, 89, 12, 4, 8, 9, 4, true, newOber);
            strongPlateRepository.save(plate);
        }catch (ConstraintViolationException conEx){
            System.out.println(conEx);
        }


    }

    @Test
    public void canAddPlateData() throws Exception {
        Plate plate = new Plate(20, 40, 67, 89, 12, 4, 8, 9, 4, true, newOber);
        strongPlateRepository.save(plate);
        List<Plate> plateList = (List<Plate>) strongPlateRepository.findAll();
        Assert.assertTrue(plateList.get(1).getId()==2);
    }

    @Test
    public void canGetStalePlateDataByUserId()throws Exception{
        List<Plate> plates =  strongPlateRepository.getStalePlateDataByUserId(1);
        Assert.assertTrue(plates.get(0).getUser().getId()==1);

    }



}
