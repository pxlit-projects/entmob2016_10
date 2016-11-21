package be.pxl.rest.service;

import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateUserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.OptionalDouble;

/**
 * Created by Pieter on 28/10/2016.
 */
@Service
@Transactional
public class StrongPlateUserServiceImpl implements StrongPlateUserService {

    @Autowired
    private StrongPlateUserRepository strongPlateUserRepository;

    @Override
    public void setUser(User user) {
        strongPlateUserRepository.save(user);
    }

    @Override
    public Iterable<User> getStrongPlateUsers() {
        return strongPlateUserRepository.findAll();
    }

    @Override
    public void deleteAllUsers() {
        strongPlateUserRepository.deleteAll();
    }

    @Override
    public User getStrongPlateUserById(long userId) {
        return strongPlateUserRepository.getStalePlateUserById(userId);
    }

    @Override
    public void updateAverageSpeedUser(long userId, double average) {
        User userToUpdateSpeed = strongPlateUserRepository.getStalePlateUserById(userId);
        userToUpdateSpeed.setAverageSpeed(average);
        strongPlateUserRepository.save(userToUpdateSpeed);
    }

    @Override
    public void updateUser(User user) {
       strongPlateUserRepository.save(user);
    }
}
