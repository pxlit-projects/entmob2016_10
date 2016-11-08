package be.pxl.rest.aspect;

import be.pxl.rest.mq.Sender;
import org.aopalliance.intercept.Joinpoint;
import org.aspectj.lang.JoinPoint;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.User;
import org.springframework.stereotype.Component;

import java.time.LocalDateTime;

/**
 * Created by Pieter on 07/11/2016.
 */
@Component
@Aspect
public class StrongPlateAspect {

    @Autowired
    private Sender sender;

    private User userSpring;

    @Around("execution(* be.pxl.rest.controller.StrongPlateController.getStrongPlateData(..))")
    public Object aroundGetStrongPlateData(ProceedingJoinPoint pjp) throws Throwable {

        sender.sendMessage(logBuilder("Aanvraag gegevens", "info"));
        Object returnValue = pjp.proceed();
        sender.sendMessage(logBuilder("Aanvraag gegevens OK", "info"));
        return returnValue;

    }

    @AfterThrowing(value = "execution(* be.pxl.rest.controller.StrongPlateController.getStrongPlateData(..))", throwing = "ex")
    public void afterExceptionGetStrongPlateData(Exception ex) {
        sender.sendMessage(logBuilder(ex.getMessage(), "exception"));
    }

    @Before("execution(* be.pxl.rest.controller.StrongPlateController.setStrongPlateData(..))")
    public void beforeAddingData() {
        sender.sendMessage(logBuilder("Toevoegen data", "info"));
    }

    @AfterReturning(value = "execution(* be.pxl.rest.controller.StrongPlateController.setStrongPlateData(..))", returning = "returnValue")
    public void afterAddingData(String returnValue) {
        if (returnValue.equals("Data toegevoegd aan database"))
            sender.sendMessage(logBuilder("toevoegen data OK ", "info"));
        else
            sender.sendMessage(logBuilder("toevoegen data niet OK ", "error"));

    }

    private String logBuilder(String message, String type) {

        getLoggedInUser();
        String logMessage = String.format("%s %s [%s] User: %s %s", LocalDateTime.now().toLocalDate(), LocalDateTime.now().toLocalTime(), type.toUpperCase(), userSpring.getUsername(), message);
        return logMessage;

    }


    private void getLoggedInUser() {
        userSpring = (User) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
    }


}
