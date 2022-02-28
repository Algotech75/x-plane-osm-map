# x-plane-osm-map
**X-Plane real time OSM map**

This project is a C# application embedding a map renderer (Leaflet with OpenStreetMap).
It receives position/orientation/orientation data from X-Plane output.
It works well, but the code is ugly (the base has been coded in 3-4h).

![](/doc/screenshot1.png)


# How to setup

* First, In X-Plane-OSM-Map, go in menu "File" -> "Setup".
* You can see the IP of the machine running the map. Use this IP to setup X-Plane.
* Set the UDP port. It must be the same in X-Plane (49003 by default).

![](/doc/screenshot2.png)



* Then, in X-Plane, go in setup to the data output tab.
* Check the UDP checkbox, line 20 (Latitude/Longitude/Altitude).
* Check the UDP checkbox, line 17 (Pitch, Roll, Headings).
* Set the UDP packet rate (4 packets/second is enough).
* Check the checkbox "Send data on the network".
* Set the IP of the target machine (the one with the map application). Use the IP displayed in the Setup.
* Set the port (49003 by default). Do not use the range [49000-49002].

![](/doc/screenshot3.png)


# Options

If you have only 1 machine, and if you select the menu "File" -> "Stay on top", you can see the map while X-Plane is running.
You can modify the transparency and hide the title bar too (but you must display the title bar to move the map !).

![](/doc/screenshot4.png)


# Miscellaneous

You can export your route as a GPX file.


# TODO

* Speed
* Altitude
* Etc...


# About

If you are satisfied with this application, and you would like to make a donation, please do so to someone in need :)
