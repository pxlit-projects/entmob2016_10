package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.controller.input.StrongPlateUserInput;
import be.pxl.rest.entity.User;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by Pieter on 28/10/2016.
 */
@RestController
@RequestMapping("/User")
public class StrongPlateUserController {

    @Autowired
    private StrongPlateUserService strongPlateUserService;

    @PostMapping("/addUser")
    public String setStrongPlateData(@RequestBody StrongPlateUserInput strongPlateUserInput) {

        // strongPlateService.setStrongPlateData(new Plate(strongPlateInput.getUserId(), strongPlateInput.getTemperature()));
        strongPlateUserService.setUser(new User(strongPlateUserInput.getLastName(),
                strongPlateUserInput.getFirstName(),
                strongPlateUserInput.getPassword(),
                strongPlateUserInput.getRole(),
                strongPlateUserInput.getAverageSpeed(),
                strongPlateUserInput.getAverageSteadyness(),
                strongPlateUserInput.isEnabled(),
                null));


        return "Data toegevoegd aan database";
    }



}
