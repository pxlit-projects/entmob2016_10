package be.pxl.rest.service;

import be.pxl.rest.entity.User;

/**
 * Created by Pieter on 28/10/2016.
 */

public interface StrongPlateUserService {
    void setUser(User user);

    Iterable<User> getStrongPlateUsers();

    void deleteAllUsers();


}
