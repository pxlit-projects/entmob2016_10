package be.pxl.rest;

import be.pxl.rest.mq.Sender;
import javafx.application.Application;
import org.apache.tomcat.jdbc.pool.DataSource;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;
import org.springframework.security.authentication.encoding.ShaPasswordEncoder;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;


/**
 * Created by Pieter on 19/10/2016.
 */
@SpringBootApplication
@EnableGlobalMethodSecurity(securedEnabled = true)
public class StrongPlateApplication {
    public static void main(String[] args) {
        ConfigurableApplicationContext ctx = SpringApplication.run(StrongPlateApplication.class, args);
        Sender sender = ctx.getBean(Sender.class);
        sender.sendMessage("Hello plates!");

    }

    @Autowired
    public void configureSecurity(AuthenticationManagerBuilder auth, DataSource ds) throws Exception {
        auth.jdbcAuthentication().passwordEncoder(new ShaPasswordEncoder(256))
                .dataSource(ds)
                .usersByUsernameQuery(
                        "select id, password, enabled from user where id = ? ")
                .authoritiesByUsernameQuery(
                        "select id, role from user where id = ?"
                );

    }

}
