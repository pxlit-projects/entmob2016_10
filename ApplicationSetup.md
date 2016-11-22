#StrongPlate app setup
##Nodige programma's 
###Xampp
https://www.apachefriends.org/index.html
###ActiveMq
http://activemq.apache.org/activemq-5141-release.html
###Vysor 
Optioneel enkel als je telefoonscherm wilt tonen op de pc.
https://chrome.google.com/webstore/detail/vysor/gidgenkbbabolejbgbpnhbimgjbffefm

-
##1) Mobilehotspot
Op android toestel: settings > more > mobile network sharing/tethering&portable hotspot
Met pc verbinden, en het IP adres veranderen op de pc naar 192.168.1.5 (als dit bereikbaar is via hotspot, anders moet ge een ander pakken, pas ip dan wel aan in xamarin app)

##2) ActiveMq
Commandline naar de map apache-activemq-5.14.1 > commando: "bin\activemq start"

##3) Xampp Control panel
apache en mySql opstarten
(Kan zijn dat die niet opstart omdat vmware Authorization nog aan staat opl: windowsKey+r > services.msc > VMware Authorization Service > Rechtemuis > stop)

##4) SpringApi
###Manier 1 (commandline)
Commandline naar de locatie waar de jar staat : java -jar StrongPlateApi.jar 
###Manier 2 (via InteliJ)
Gewoon project runnen, letop dat als ge wachtwoord hebt voor uw database ge dit even aanpast in de application.properties folder
###Manier 3 (Dubbelklik op de jar)
Niet aangeraden, het gaat dan in de background runnen, kunt dan gaan zoeken met Task manager wilt ge het stoppen + ziet logberichten niet.

##5) Vysor (optioneel)
1) Verbind de telefoon met de computer via usb 
2) Open Vysor (op pc)
3) Klik op "view" bij de devices die ge wilt zien (op pc)
4) Kunt telefoon nu bedienen via de computer. 
*Eerste keer duurt iets langer omdat die nog een apk moet installeren op het toestel zelf
**Soms slechte beeld kwaliteit ma is meestal na 2 seconden weg
***Om de 30 minuten reclame, ma zolang zit ge hopelijk niet binnen 

##UWP app
Deze kan gewoon gerunt worden aangezien het op de zelfde pc draait als de api

##Sensortag
Aanzetten en verbinden via bluetooth met de telefoon

##Xamarin app
Deze zou ge op voorhand 1 keer moeten deployen op het toestel
droid project > rechtemuis > deploy > dan staat er normaal bij het play teken voor het project te runnen uw device tussen
klikken en bidden

##Happyend 








