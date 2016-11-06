package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.controller.input.StrongPlateUserInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

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

        // strongPlateService.setStrongPlateData(new Plate(strongPlateInput.getUserId(), strongPlateInput.getTemperature()));
        strongPlateUserService.setUser(new User(
                strongPlateUserInput.getLastName(),
                strongPlateUserInput.getFirstName(),
                strongPlateUserInput.getPassword(),
                strongPlateUserInput.getRole(),
                strongPlateUserInput.getAverageSpeed(),
                strongPlateUserInput.getAverageSteadyness(),
                strongPlateUserInput.isEnabled(),
                null
        ));


        return "Data toegevoegd aan database";
    }
    @Secured({"ROLE_BAAS"})
    @RequestMapping("/getUsers")
    public ResponseEntity<Collection<User>> getUser(){

        return new ResponseEntity<>((Collection<User>)strongPlateUserService.getStrongPlateUsers(),HttpStatus.OK);
//        return new ResponseEntity<>((Collection<User>)strongPlateUserService.getStrongPlateUsers(), HttpStatus.OK);
//        return "getUser called";
    }



}
