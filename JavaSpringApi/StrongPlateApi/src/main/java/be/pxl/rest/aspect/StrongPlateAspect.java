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
        getLoggedInUser();

        sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " aanvraag gegevens");
        Object returnValue = pjp.proceed();
        sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " aanvraag gegevens OK");

        return returnValue;

    }
    @AfterThrowing(value = "execution(* be.pxl.rest.controller.StrongPlateController.getStrongPlateData(..))", throwing = "ex")
    public void afterExceptionGetStrongPlateData(Exception ex){
        sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " [EXCEPTION] "+ex.getMessage());
    }

    @Before("execution(* be.pxl.rest.controller.StrongPlateController.setStrongPlateData(..))")
    public void beforeAddingData(){
        getLoggedInUser();
        sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " toevoegen data ");
    }

    @AfterReturning(value = "execution(* be.pxl.rest.controller.StrongPlateController.setStrongPlateData(..))", returning = "returnValue")
    public void afterAddingData(String returnValue){
        if(returnValue.equals("Data toegevoegd aan database"))
            sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " toevoegen data OK ");
        else
            sender.sendMessage(LocalDateTime.now().toLocalDate() + " " + LocalDateTime.now().toLocalTime() + " User: " + userSpring.getUsername() + " toevoegen data NIET OK ");


    }



    private void getLoggedInUser() {
        userSpring = (User) SecurityContextHolder.getContext().getAuthentication().getPrincipal();
    }


}
