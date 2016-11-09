package be.pxl.rest.unit;

import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateUserRepository;
import be.pxl.rest.service.StrongPlateUserService;
import be.pxl.rest.service.StrongPlateUserServiceImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;

import static org.mockito.Matchers.any;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.List;


/**
 * Created by pieterswennen on 08/11/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@DirtiesContext
@Ignore
public class StrongPlateUserServiceTest {

    @InjectMocks
    private StrongPlateUserService testPlateUserService = new StrongPlateUserServiceImpl();

    @Mock
    private StrongPlateUserRepository strongPlateUserRepository;

    private User user;
    private List<User> userList;

    @Before
    public void setUpData(){
        user = new User("Peeters", "Jaak", "secret", "ROLE_OBER", 20, 30, true);
        userList = new ArrayList<>();
        userList.add(user);

    }

    @Test
    public void setUserTest(){

        testPlateUserService.setUser(user);
        verify(strongPlateUserRepository).save(any(User.class));
    }

    @Test
    public void getStrongPlateUsersTest(){
        when(strongPlateUserRepository.findAll()).thenReturn(userList);
        List<User> users = (List<User>)testPlateUserService.getStrongPlateUsers();
        Assert.assertFalse(users.isEmpty());
    }


}
