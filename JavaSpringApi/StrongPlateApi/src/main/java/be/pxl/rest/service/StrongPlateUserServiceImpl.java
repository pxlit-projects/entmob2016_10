package be.pxl.rest.service;

import be.pxl.rest.entity.User;
import be.pxl.rest.repository.StrongPlateRepository;
import be.pxl.rest.repository.StrongPlateUserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;

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
}
