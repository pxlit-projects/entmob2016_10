package be.pxl.rest.integration;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateUserService;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.*;

import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.context.WebApplicationContext;


import javax.servlet.Filter;
import java.io.IOException;
import java.nio.charset.Charset;
import java.util.ArrayList;
import java.util.List;
import static org.junit.Assert.*;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.*;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.*;

import org.junit.Before;
import org.junit.Test;


/**
 * Created by Pieter on 28/10/2016.
 */
@RunWith(SpringRunner.class)
@SpringBootTest
@AutoConfigureMockMvc
public class StrongPlateApiTest {

    @Autowired
    private StrongPlateService strongPlateService;

    @Autowired
    private StrongPlateUserService strongPlateUserService;

    @Autowired
    private WebApplicationContext context;

    @Autowired
    private Filter springSecurityFilterChain;


    @Autowired
    private MockMvc mockMvc;

    private static User firstUser;
    private static User newOber;
    private static User firstOber;
    private static Plate plateEnti;
    private static ObjectMapper objectMapper;
    private static String userAsJson;
    private String replyUsers;
    private String replyPlates;
    private static List<User> users;
    private static List<Plate> plates;

    private static StrongPlateInput plate;

    private static boolean defaultUserAdded;


    @Before
    public void setUpData() throws Exception {

        if(!defaultUserAdded) {
            objectMapper= new ObjectMapper();
            firstUser = new User("Boss", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_BAAS", 10, 75, true);
            newOber = new User("Ober", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
            firstOber = new User("Ober", "The First", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);

            firstOber.setId(2);//Omdat deze anders nog niet gekend = kan geen plate op voorhand aanmaken
            System.out.println("EERSTE OBER: "+firstOber.getId());
            plate = new StrongPlateInput(20, 40, 67, 89, 12, 4, 8, 9, 4, true, 2);
            plateEnti = new Plate(20, 40, 67, 89, 12, 4, 8, 9, 4,true, firstOber);

            userAsJson = objectMapper.writeValueAsString(newOber);

            strongPlateService.deleteAllStrongPlateData();
            strongPlateUserService.deleteAllUsers();
            strongPlateUserService.setUser(firstUser);//krijgt id 1
            strongPlateUserService.setUser(firstOber);//krijgt id 2
            strongPlateService.setStrongPlateData(plateEnti);
            defaultUserAdded=true;
        }


    }
    /*@After
    public void cleanDB() throws Exception {
        /*strongPlateService.deleteAllStrongPlateData();
        strongPlateUserService.deleteAllUsers();*/
        //System.out.println("Have a nice day");
   // }

    @Test
    public void bosCanAskUsersTest() throws Exception{
        //Obers kunnen worden aangevraagd door de baas
        MvcResult mockMvcResult = mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();

        replyUsers = mockMvcResult.getResponse().getContentAsString();
        users = objectMapper.readValue(replyUsers, new TypeReference<List<User>>() {

        });

        assertFalse(mockMvcResult.getResponse().getContentAsString().isEmpty());
        assertFalse(users.isEmpty());

    }
    @Test
    public void bosCanAddUserTest() throws Exception{
        //Obers kunnen worden toegevoegd door de baas (user met id 1 = baas)
        this.mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("1", "secret")))
                .andExpect(status().isOk());

    }

    @Test
    public void getUsersPermissionTest() throws Exception {
        //Obers kunnen geen obers opvragen (User met id 2 = ober)
        this.mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("2", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isForbidden());

    }
    @Test
    public void addUserPermissionTest() throws Exception {
        //Obers kunnen geen obers toevoegen (User met id 2 = ober)
        this.mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("2", "secret")))
                .andExpect(status().isForbidden());

    }
    @Test
    public void addStrongPlateDataTest() throws Exception{
        //Toevoegen data sensor, userID van plate komt overeen met het userId meegegeven in de httpbasic
        MvcResult mockMvcResult = mockMvc.perform(post("/Plate/setData")
                .content(objectMapper.writeValueAsString(plate))
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("2", "secret")))
                .andExpect(status().isOk())
                .andReturn();

        assertEquals(mockMvcResult.getResponse().getContentAsString(), "Data toegevoegd aan database");


    }
    @Test
    public void addStrongPlateDataPermissionTest() throws Exception{
        //Toevoegen data sensor, userID van plate (2) komt NIET overeen met het userId(1) meegegeven in de httpbasic
        MvcResult mockMvcResult = mockMvc.perform(post("/Plate/setData")
                .content(objectMapper.writeValueAsString(plate))
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("1", "secret")))
                .andExpect(status().isOk())
                .andReturn();

        assertEquals(mockMvcResult.getResponse().getContentAsString(), "Kan geen data van iemand anders toevoegen!");

    }
    @Test
    public void getStrongPlateDataTest() throws Exception{
        MvcResult mockMvcResult = mockMvc.perform(get("/Plate/getData")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();

        replyPlates = mockMvcResult.getResponse().getContentAsString();

        assertFalse(mockMvcResult.getResponse().getContentAsString().isEmpty());


    }



}
