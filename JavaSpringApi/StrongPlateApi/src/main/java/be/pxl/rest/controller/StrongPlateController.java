package be.pxl.rest.controller;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.service.StrongPlateService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.userdetails.User;
import org.springframework.web.bind.annotation.*;
import java.util.Collection;

/**
 * Created by Pieter on 19/10/2016.
 */
@RestController
@RequestMapping("/Plate")
public class StrongPlateController {

    @Autowired
    private StrongPlateService strongPlateService;

    private be.pxl.rest.entity.User userInput;

    /**
     * Gaat de strongPlateInput gebruiken voor de gegevens die binnenkomen.
     */
    @Secured({"ROLE_OBER", "ROLE_BAAS"})
    @PostMapping("/setData")
    public String setStrongPlateData(@RequestBody StrongPlateInput strongPlateInput,
                                     @AuthenticationPrincipal User userSpring) {

        userInput = new be.pxl.rest.entity.User();

        if((userSpring.getUsername().equals(strongPlateInput.getUserId()+""))){
            userInput.setId(strongPlateInput.getUserId());
            strongPlateService.setStrongPlateData(new Plate(
                    strongPlateInput.getxG(),
                    strongPlateInput.getyG(),
                    strongPlateInput.getzG(),
                    strongPlateInput.getxS(),
                    strongPlateInput.getyS(),
                    strongPlateInput.getzS(),
                    strongPlateInput.getxUt(),
                    strongPlateInput.getyUt(),
                    strongPlateInput.getzUt(),
                    strongPlateInput.isMagnetic(),
                    userInput
            ));
            return "Data toegevoegd aan database";
        }else{
            return "Kan geen data van iemand anders toevoegen!";
        }



    }

    @Secured({"ROLE_OBER", "ROLE_BAAS"})
    @RequestMapping(value = "/getData", method = RequestMethod.GET)
    public ResponseEntity<Collection<Plate>> getStrongPlateData(@AuthenticationPrincipal User userSpring) {
        return new ResponseEntity<>((Collection<Plate>) strongPlateService.getStrongPlateData(), HttpStatus.OK);
    }

    @Secured({"ROLE_OBER", "ROLE_BAAS"})
    @RequestMapping(value = "/getDataByUserId/{userId}", method = RequestMethod.GET)
    public
    @ResponseBody
    ResponseEntity<Collection<Plate>> getStrongPlateDataByUserId(@PathVariable int userId) {
        return new ResponseEntity<>(strongPlateService.getStrongPlateDataByUserId(userId), HttpStatus.OK);
    }

}
