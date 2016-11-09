package be.pxl.rest.repository;

import be.pxl.rest.entity.Plate;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

/**
 * Created by Pieter on 19/10/2016.
 */

@Repository
public interface StrongPlateRepository extends CrudRepository<Plate, UUID> {
    public List<Plate> getStalePlateDataByUserId(long userId);
}
