package be.pxl.rest.repository;

import be.pxl.rest.entity.Plate;
import org.springframework.data.repository.CrudRepository;

import java.util.UUID;

/**
 * Created by Pieter on 19/10/2016.
 */



public interface StrongPlateRepository extends CrudRepository<Plate,UUID> {
}
