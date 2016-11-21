package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateUserInput;
import be.pxl.rest.entity.User;
import be.pxl.rest.service.StrongPlateUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;
import java.util.Collection;

/**
 * Created by Pieter on 28/10/2016.
 */
@RestController
@RequestMapping("/User")
public class StrongPlateUserController {

    @Autowired
    private StrongPlateUserService strongPlateUserService;

    @Secured({"ROLE_BAAS"})
    @PostMapping("/addUser")
    public String setStrongPlateUser(@RequestBody StrongPlateUserInput strongPlateUserInput) {
        strongPlateUserService.setUser(new User(
                strongPlateUserInput.getLastName(),
                strongPlateUserInput.getFirstName(),
                strongPlateUserInput.getPassword(),
                strongPlateUserInput.getRole(),
                strongPlateUserInput.getAverageSpeed(),
                strongPlateUserInput.getAverageSteadyness(),
                strongPlateUserInput.isEnabled()
        ));
        return "User toegevoegd aan database";
    }

    @Secured({"ROLE_BAAS"})
    @RequestMapping(value ="/getUsers", method = RequestMethod.GET)
    public ResponseEntity<Collection<User>> getUser(){
        return new ResponseEntity<>((Collection<User>)strongPlateUserService.getStrongPlateUsers(),HttpStatus.OK);
    }

    @Secured({"ROLE_OBER", "ROLE_BAAS"})
    @RequestMapping(value ="/getUserById/{userId}", method = RequestMethod.GET)
    public ResponseEntity<User> getUserById(@PathVariable long userId){
        return new ResponseEntity<>(strongPlateUserService.getStrongPlateUserById(userId),HttpStatus.OK);
    }

    @Secured({"ROLE_BAAS"})
    @PutMapping(value = "/editUser/{userId}")
    public String updateUserValues(@RequestBody StrongPlateUserInput strongPlateUserInput, @PathVariable long userId){
        User user = new User(
                strongPlateUserInput.getLastName(),
                strongPlateUserInput.getFirstName(),
                strongPlateUserInput.getPassword(),
                strongPlateUserInput.getRole(),
                strongPlateUserInput.getAverageSpeed(),
                strongPlateUserInput.getAverageSteadyness(),
                strongPlateUserInput.isEnabled());
        user.setId(userId);
        strongPlateUserService.updateUser(user);
        return "User bewerkt";

    }




}
