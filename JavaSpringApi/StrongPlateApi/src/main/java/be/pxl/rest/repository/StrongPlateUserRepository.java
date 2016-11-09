package be.pxl.rest.repository;

import be.pxl.rest.entity.Plate;
import be.pxl.rest.entity.User;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.UUID;

/**
 * Created by Pieter on 28/10/2016.
 */
@Repository
public interface StrongPlateUserRepository extends CrudRepository<User, UUID> {
    public List<Plate> getStalePlateUserById(long userId);

}
