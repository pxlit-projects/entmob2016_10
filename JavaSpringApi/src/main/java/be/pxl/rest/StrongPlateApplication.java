package be.pxl.rest;

import javafx.application.Application;
import org.apache.tomcat.jdbc.pool.DataSource;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;


/**
 * Created by Pieter on 19/10/2016.
 */
@SpringBootApplication

public class StrongPlateApplication {
    public static void main(String[] args) {
        SpringApplication.run(StrongPlateApplication.class, args);

    }

   /* @Autowired
    public void configureSecurity(AuthenticationManagerBuilder auth, DataSource ds)throws Exception{
        auth.jdbcAuthentication().passwordEncoder(new ShaPasswordEncoder(256))
                .dataSource(ds)
                .usersByUsernameQuery(
                        "select id, password, enabled from Users where name = ? ")
                .authoritiesByUsernameQuery(
                        "select id, role from Users where name = ?"
                );

    }*/

}
