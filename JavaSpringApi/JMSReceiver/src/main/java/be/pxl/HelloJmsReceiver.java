package be.pxl;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Service;

import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.TextMessage;

/**
 * Created by Pieter on 07/11/2016.
 */
@Service
public class HelloJmsReceiver {
    @JmsListener(destination = "StalePlateQueue")
    public void onMessage(Message msg){
        try{
            if(msg instanceof TextMessage){
                String text = ((TextMessage)msg).getText();
                System.out.println(text);
            }
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
