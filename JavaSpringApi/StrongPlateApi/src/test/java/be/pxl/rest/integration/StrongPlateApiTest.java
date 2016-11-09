package be.pxl.rest.integration;

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

    private RestTemplate template = new RestTemplate();
    private User firstUser;
    private User newUser;
    private ObjectMapper objectMapper;
    private String userAsJson;
    private String reply;
    private List<User> users;


    @Before
    public void setUpData() throws Exception {
        objectMapper= new ObjectMapper();
        firstUser = new User("Boss", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_BAAS", 10, 75, true);
        newUser = new User("Oober", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        userAsJson = objectMapper.writeValueAsString(newUser);

    }

    @Test
    public void fullUserTest() throws Exception {

        strongPlateService.deleteAllStrongPlateData();
        strongPlateUserService.deleteAllUsers();

        strongPlateUserService.setUser(firstUser);

        //Obers kunnen worden aangevraagd door de baas
        MvcResult mockMvcResult = mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();

        //Obers kunnen worden toegevoegd door de baas
        this.mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("1", "secret")))
                .andExpect(status().isOk());

        //Obers kunnen geen obers toevoegen
        this.mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("2", "secret")))
                .andExpect(status().isForbidden());

        //Obers kunnen geen obers opvragen
        this.mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("2", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isForbidden());


        reply = mockMvcResult.getResponse().getContentAsString();
        users = objectMapper.readValue(reply, new TypeReference<List<User>>() {

        });

        assertFalse(mockMvcResult.getResponse().getContentAsString().isEmpty());
        assertFalse(users.isEmpty());



    }
    @Test
    public void fullPlateTest() throws Exception {

    }

    @After
    public void cleanDB() throws Exception {
        strongPlateService.deleteAllStrongPlateData();
        strongPlateUserService.deleteAllUsers();
        System.out.println("Have a nice day");
    }


}
