package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.service.StrongPlateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by Pieter on 19/10/2016.
 */
@RestController
public class StrongPlateController {

    @Autowired
    private StrongPlateService strongPlateService;

    @PostMapping("/data")
    public String getStalePlateData(@RequestBody StrongPlateInput strongPlateInput){
        strongPlateService.stalePlateCall(new Plate(strongPlateInput.getUserId(),strongPlateInput.getTemperature()));

        return "Data toegevoegd aan database";
    }

}
