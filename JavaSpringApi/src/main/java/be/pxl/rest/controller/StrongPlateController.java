package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.service.StrongPlateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;

/**
 * Created by Pieter on 19/10/2016.
 */
@RestController

public class StrongPlateController {

    @Autowired
    private StrongPlateService strongPlateService;

    @PostMapping("/setData")
    public String setStrongPlateData(@RequestBody StrongPlateInput strongPlateInput) {

        strongPlateService.setStrongPlateData(new Plate(strongPlateInput.getUserId(), strongPlateInput.getTemperature()));
        return "Data toegevoegd aan database";
    }
    @RequestMapping(value = "/getData", method = RequestMethod.GET)
    public ResponseEntity<Collection<Plate>> getStrongPlateData() {
        System.out.println("Get all data from all users");
        return new ResponseEntity<>((Collection<Plate>)strongPlateService.getStrongPlateData(), HttpStatus.OK);
    }
    @RequestMapping(value = "/getByUserId/{userId}", method = RequestMethod.GET)
    public @ResponseBody ResponseEntity<Collection<Plate>> getStrongPlateDataByUserId(@PathVariable long userId) {
        System.out.println("Get user with userId: "+userId);
        return new ResponseEntity<>(strongPlateService.getStrongPlateDataByUserId(userId), HttpStatus.OK);
    }

}
