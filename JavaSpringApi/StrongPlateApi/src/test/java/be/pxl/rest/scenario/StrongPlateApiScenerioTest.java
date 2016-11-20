package be.pxl.rest.scenario;

import be.pxl.rest.controller.input.StrongPlateInput;
import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import be.pxl.rest.service.StrongPlateService;
import be.pxl.rest.service.StrongPlateUserService;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.web.context.WebApplicationContext;

import javax.servlet.Filter;
import java.util.List;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.springframework.security.test.web.servlet.request.SecurityMockMvcRequestPostProcessors.httpBasic;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.put;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

/**
 * Created by Pieter on 20/11/2016.
 */
@RunWith(SpringRunner.class)
@SpringBootTest
@AutoConfigureMockMvc
public class StrongPlateApiScenerioTest {
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
    private static User newOber, newUpdateOber;
    private static User firstOber;
    private static Plate plateEnti;
    private static ObjectMapper objectMapper;
    private static String userAsJson, updatedUserAsJson;
    private String replyUsers;
    private String replyPlatesUsersId;
    private String replyPlates;
    private static List<User> users;
    private static List<Plate> plates;
    private static StrongPlateInput plate;
    private static boolean defaultUserAdded;

    @Before
    public void setUpData() throws Exception {
        objectMapper = new ObjectMapper();
        firstUser = new User("Boss", "Theeeee", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_BAAS", 10, 75, true);
        newOber = new User("Ober", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        newUpdateOber = new User("Ober2.0", "The", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);
        firstOber = new User("Ober", "The First", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_OBER", 10, 96, true);

        firstOber.setId(2);//Omdat deze anders nog niet gekend = kan geen plate op voorhand aanmaken
        plate = new StrongPlateInput(20, 40, 67, 89, 12, 4, 8, 9, 4, true, 2);
        plateEnti = new Plate(20, 40, 67, 89, 12, 4, 8, 9, 4, true, firstOber);

        userAsJson = objectMapper.writeValueAsString(newOber);
        updatedUserAsJson = objectMapper.writeValueAsString(newUpdateOber);

        strongPlateService.deleteAllStrongPlateData();
        strongPlateUserService.deleteAllUsers();
        strongPlateUserService.setUser(firstUser);//krijgt id 1
        strongPlateUserService.setUser(firstOber);//krijgt id 2
        strongPlateService.setStrongPlateData(plateEnti);
        defaultUserAdded = true;
    }

    @Test
    public void scenarioTest() throws Exception{
        //Obers kunnen worden aangevraagd door de baas
        MvcResult mockMvcResult1 = mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();
        replyUsers = mockMvcResult1.getResponse().getContentAsString();
        users = objectMapper.readValue(replyUsers, new TypeReference<List<User>>() {
        });
        assertFalse(mockMvcResult1.getResponse().getContentAsString().isEmpty());
        assertFalse(users.isEmpty());

        //Baas kan users bewerken
        MvcResult mockMvcResult2 = mockMvc.perform(put("/User/editUser/2")
                .content(updatedUserAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();

        User userFromDb = strongPlateUserService.getStrongPlateUserById(2);
        assertEquals(userFromDb.getLastName(), "Ober2.0");
        assertEquals(mockMvcResult2.getResponse().getContentAsString(), "User bewerkt");

        //GetUserById
        MvcResult mockMvcResult3 = mockMvc.perform(get("/User/getUserById/1")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();
        User incomingUser = objectMapper.readValue(mockMvcResult3.getResponse().getContentAsString(), User.class);
        assertEquals(firstUser.getId(), incomingUser.getId());

        //Obers kunnen worden toegevoegd door de baas (user met id 1 = baas)
        MvcResult mockMvcResult4 = mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("1", "secret")))
                .andExpect(status().isOk())
                .andReturn();
        assertEquals(mockMvcResult4.getResponse().getContentAsString(), "User toegevoegd aan database");

        //Obers kunnen geen obers opvragen (User met id 2 = ober)
        this.mockMvc.perform(get("/User/getUsers")
                .with(httpBasic("2", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isForbidden());

        //Obers kunnen geen obers toevoegen (User met id 2 = ober)
        this.mockMvc.perform(post("/User/addUser")
                .content(userAsJson)
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("2", "secret")))
                .andExpect(status().isForbidden());

        //Toevoegen data sensor, userID van plate komt overeen met het userId meegegeven in de httpbasic
        MvcResult mockMvcResult5 = mockMvc.perform(post("/Plate/setData")
                .content(objectMapper.writeValueAsString(plate))
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("2", "secret")))
                .andExpect(status().isOk())
                .andReturn();
        assertEquals(mockMvcResult5.getResponse().getContentAsString(), "Data toegevoegd aan database");

        //Toevoegen data sensor, userID van plate (2) komt NIET overeen met het userId(1) meegegeven in de httpbasic
        MvcResult mockMvcResult6 = mockMvc.perform(post("/Plate/setData")
                .content(objectMapper.writeValueAsString(plate))
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8"))
                .with(httpBasic("1", "secret")))
                .andExpect(status().isOk())
                .andReturn();
        assertEquals(mockMvcResult6.getResponse().getContentAsString(), "Kan geen data van iemand anders toevoegen!");

        //getstrongplatedata
        MvcResult mockMvcResult7 = mockMvc.perform(get("/Plate/getData")
                .with(httpBasic("1", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();
        replyPlates = mockMvcResult7.getResponse().getContentAsString();
        System.out.println(replyPlates);
        assertFalse(replyPlates.length() < 2);

        //getstrongplatedatebyuserId
        MvcResult mockMvcResult8 = mockMvc.perform(get("/Plate/getDataByUserId/2")
                .with(httpBasic("2", "secret"))
                .accept(MediaType.parseMediaType("application/json;charset=UTF-8")))
                .andExpect(status().isOk())/*.andDo(print())*/.andReturn();
        replyPlatesUsersId = mockMvcResult8.getResponse().getContentAsString();
        assertFalse(replyPlatesUsersId.length() < 2);
    }

}
