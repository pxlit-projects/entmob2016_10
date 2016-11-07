package be.pxl;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.jms.annotation.EnableJms;

/**
 * Created by Pieter on 07/11/2016.
 */
@SpringBootApplication
@EnableJms
public class Main {
    public static void main(String[] args) {
        SpringApplication.run(Main.class, args);
    }

}
