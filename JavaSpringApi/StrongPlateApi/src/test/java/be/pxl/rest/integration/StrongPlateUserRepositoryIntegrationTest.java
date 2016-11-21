package be.pxl.rest.integration;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateUserRepository;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
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
public class StrongPlateUserRepositoryIntegrationTest {

    @Autowired
    private StrongPlateUserRepository strongPlateUserRepository;

    private User newOber;



    @Before
    public void setUp() throws Exception {
        newOber = new User("Ober", "The", 20,true, "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        strongPlateUserRepository.save(newOber);
    }

    @Test
    public void canAddUser()throws Exception{
        User newOber2 = new User("Ober", "The", 20,true, "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        strongPlateUserRepository.save(newOber2);
        List<User> userList = (List<User>) strongPlateUserRepository.findAll();
        Assert.assertTrue(userList.get(1).getId()==2);

    }
    @Test
    public void canGetStalePlateUserByUserId()throws Exception{
        User user = strongPlateUserRepository.getStalePlateUserById(1);
        Assert.assertTrue(user.getId()==1);

    }
}
