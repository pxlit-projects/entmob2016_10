package be.pxl.rest.mq;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.stereotype.Service;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.TextMessage;

/**
 * Created by pieterswennen on 10/11/2016.
 */
@Service
public class Receiver {
    @JmsListener(destination = "StalePlateQueue")
    public void onMessage(Message msg) {
        try {
            if (msg instanceof TextMessage) {
                String text = ((TextMessage) msg).getText();
                System.out.println(text);
            }
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
