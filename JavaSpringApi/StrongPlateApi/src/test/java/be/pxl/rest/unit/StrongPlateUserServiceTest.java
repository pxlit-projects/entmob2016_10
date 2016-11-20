package be.pxl.rest.unit;

import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateUserRepository;
import be.pxl.rest.service.StrongPlateUserService;
import be.pxl.rest.service.StrongPlateUserServiceImpl;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;

import static org.mockito.Matchers.any;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import javax.validation.constraints.AssertTrue;
import java.util.ArrayList;
import java.util.List;


/**
 * Created by pieterswennen on 08/11/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@DirtiesContext

public class StrongPlateUserServiceTest {

    @InjectMocks
    private StrongPlateUserServiceImpl testPlateUserService;

    @Mock
    private StrongPlateUserRepository strongPlateUserRepository;

    private User user;
    private List<User> userList;

    @Before
    public void setUpData() throws Exception {
        user = new User("Peeters", "Jaak", "secret", "ROLE_OBER", 20, 30, true);
        user.setId(1);
        userList = new ArrayList<>();
        userList.add(user);
    }

    @Test
    public void setUserTest() {
        testPlateUserService.setUser(user);
        verify(strongPlateUserRepository).save(any(User.class));
    }
    @Test
    public void updateUserTest() {
        when(strongPlateUserRepository.getStalePlateUserById(1)).thenReturn(user);


        user.setEnabled(false);
        testPlateUserService.updateUser(user);
        User userFromDb = testPlateUserService.getStrongPlateUserById(1);

        verify(strongPlateUserRepository).save(any(User.class));
        Assert.assertTrue(userFromDb.isEnabled()==user.isEnabled());
    }

    @Test
    public void getStrongPlateUsersTest() {
        when(strongPlateUserRepository.findAll()).thenReturn(userList);
        List<User> users = (List<User>) testPlateUserService.getStrongPlateUsers();
        Assert.assertFalse(users.isEmpty());
    }

    @Test
    public void getStrongPlateUserByIdTest() {
        when(strongPlateUserRepository.getStalePlateUserById(user.getId())).thenReturn(user);
        User incomingUser = testPlateUserService.getStrongPlateUserById(user.getId());
        Assert.assertEquals(incomingUser.getId(), 1);
    }

    @Test
    public void updateAverageSpeedUserTest() {
        when(strongPlateUserRepository.getStalePlateUserById(user.getId())).thenReturn(user);
        testPlateUserService.updateAverageSpeedUser(user.getId(), 12.5);
        verify(strongPlateUserRepository).save(user);

    }
}
