package be.pxl.rest.repository;

import be.pxl.rest.entity.Plate;
import java.time.LocalDateTime;
import java.time.temporal.ChronoUnit;
import java.util.*;

/**
 * Created by Pieter on 20/11/2016.
 */
public class AverageSpeedCalculator {
    private static LocalDateTime tempValue = null;
    private static NavigableSet<String> datesWorked = new TreeSet<>();
    private static List<Long> results = new ArrayList<>();

    public static double CalculateAverageSpeed(List<Plate> plateList){
        plateList.forEach(e->datesWorked.add(formatDate(e.getCreatedOn())));
        for(String day : datesWorked){
            plateList.stream().filter((s)->s.isMagnetic()&&day.equals(formatDate(s.getCreatedOn()))).forEach(e->results.add(doCalculation(e.getCreatedOn())));
            //Gaat per dag kijken hoeveel tijd erzit tussen 2 true values van ismagnetic en deze tijd opslaan in results
            //Per dag word de tempvalue op null gezet omdat er anders verder gerekend word op de vorige dag
            tempValue = null;
        }
        results = deleteZeros(results);
        OptionalDouble avarage = results.stream().mapToLong(x -> x).average();
        if (avarage.isPresent()) {
            return avarage.getAsDouble();
        }else{
           return 0.0;
        }
    }
    private static List<Long> deleteZeros(List<Long> list){
        List<Long> dummy = new ArrayList<>();
        list.stream().filter(s->s>0).forEach(d->dummy.add(d));
        return dummy;
    }
    private static long doCalculation(LocalDateTime time){
        long substraction = 0;
        if(tempValue != null){
            substraction = tempValue.until(time, ChronoUnit.SECONDS);
        }
        tempValue = time;
        return substraction;
    }
    private static String formatDate(LocalDateTime created){
        int year = created.getYear();
        int month = created.getMonthValue();
        int day = created.getDayOfMonth();
        return String.format("%d/%d/%d", day, month, year);
    }

}
