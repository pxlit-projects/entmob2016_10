package be.pxl.rest.service;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import org.springframework.stereotype.Component;

import java.util.List;

/**
 * Created by Pieter on 28/10/2016.
 */
public interface StrongPlateUserService {
    void setUser(User user);

    Iterable<User> getStrongPlateUsers();

   // public List<User> getStrongPlateDataByUserId(long userId);
}
