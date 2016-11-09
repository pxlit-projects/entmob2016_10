package be.pxl.rest.controller.input;

import be.pxl.rest.entity.Plate;
import org.json.JSONObject;


import javax.persistence.Column;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Pieter on 28/10/2016.
 */
public class StrongPlateUserInput
{


    private String lastName;
    private String firstName;
    private String password;
    private String role;
    private double averageSpeed;
    private double averageSteadyness;
    private boolean enabled;





    public String getLastName() {
        return lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getPassword() {
        return password;
    }

    public String getRole() {
        return role;
    }

    public double getAverageSpeed() {
        return averageSpeed;
    }

    public double getAverageSteadyness() {
        return averageSteadyness;
    }

    public boolean isEnabled() {
        return enabled;
    }

}

