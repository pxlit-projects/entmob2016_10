#-----Installatie ActiveMq-----
Nodig voor JMS
1) Downloaden apache active mq (http://activemq.apache.org/)
2) Zip uitpakken op een bestandslocatie naar keuze
3) Commandline naar de activemq folder navigeren
4) Commando: bin\activemq start
5) Webbrowsers naar http://127.0.0.1:8161/admin/ gaan (Username:admin, password:admin)
6) Als stap 5 lukt werkt het

#-----Installatie Server-----
De jar gebruikt localhost:3306/staleplatedb 
Het project vanuit IntelIj gebruikt localhost:3306/staleplatedb en localhost:3306/staleplatetestdb (laatste voor testing)
Dus de server moet 2 databases hebben : "staleplatedb" en "staleplatetestdb". 
De database moet een gebruiker "root" hebben met een paswoord "Pxl" met alle privileges. 
(enkel voor jar, in intelIj kan je eventueel de gebruiker aanpassen in de applications.properties)

#-----Project Runnen-----
Jar bestand : java -jar StrongPlateApi.jar
1e keer moet je een gebruiker via sql in phpmyadmin zelf toevoegen
sql statement: INSERT INTO `user`(`average_speed`, `average_steadyness`, `enabled`, `first_name`, `last_name`, `password`, `role`) VALUES (5, 98, true, "The", "Boss", "2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b", "ROLE_BAAS");
Gebruiker met Id: 1 en paswoord "secret" is dan aangemaakt.

#-----Javadoc openen-----
apidocs > index.html

#-----Post/Get met Postman-----
urls:   
        -----Plate-----
        (get)   http://localhost:8090/Plate/getData
        (post)  http://localhost:8090/Plate/setData
        (get)   http://localhost:8090/Plate/getDataByUserId/{userid}
        
        -----User-----
        (get)   http://localhost:8090/User/getUsers
        (post)  http://localhost:8090/User/addUser
        (put)   http://localhost:8090/User/editUser/{userId} 
        (get)   http://localhost:8090/User/getUserById/{userId}


Authentication op "Basic Auth" zetten en aanmelden met userId en wachtwoord

Meegeven data postrequest: 
    body op raw zetten en JSON(application/Json)
        setData: 
                {
	                "xG":12.5,
                        "yG":4.5,
   	                "zG":70,
                        "xS":60,
                        "yS":20.0002,
                        "zS":450,
                        "xUt":9980,
                        "yUt":145,
                        "zUt":245,
                        "magnetic":false,
  	                "userId":1
                }

        addUser: 
        {
            "lastName":"Fons", 
            "firstName":"Peeters", 
            "age":20,
            "gender":true,
            "password":"sha265 en niet gewoon het password", 
            "role":"ROLE_OBER", 
            "averageSpeed":5, 
            "averageSteadyness":99,
            "enabled":true
        }
        (password moet gehashed met sha265 meegegeven worden, http://www.xorbin.com/tools/sha256-hash-calculator)
        password: secret = 2bb80d537b1da3e38bd30361aa855686bde0eacd7162fef6a25fe97bf527a25b
        (roles zijn er maar 2 van : ROLE_BAAS en ROLE_OBER)


#-----Veel plezier-----
        
        
    