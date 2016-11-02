package be.pxl.rest.mq;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

/**
 * Created by Pieter on 02/11/2016.
 */
@Component
public class Sender {
    @Autowired
    private JmsTemplate jmsTemplate;

    public void sendMessage(final String text){
        jmsTemplate.send("log", s->s.createTextMessage(text));

    }
}
