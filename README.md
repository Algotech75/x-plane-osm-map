# x-plane-rt-map
**X-Plane real time OSM map**

This project is a C# application embedding a map renderer (Leaflet with OpenStreetMap).
It receives position data from X-Plane output.

![](/doc/screenshot1.png)


# How to setup

* First, in X-Plane, go in setup to the data output tab.
* Check the UDP checkbox, line 20 (Latitude/Longitude data).
* Set the UDP packet rate (2 packets/second is enough).
* Check the checkbox "Send data on the network".
* Set the IP of the target machine (the one with the map application). If you have only 1 machine, set "127.0.0.1".
* Set the port (49003 by default). Do not use the range [49000-49002].

![](/doc/screenshot3.png)


* In X-Plane-rt-map, go in menu file -> setup.
* You can see the IP of the machine running the map.
* Set the same UDP port as the one in X-Plane (49003 by default).

![](/doc/screenshot2.png)

# Options

If you have only 1 machine, and if you select the menu file -> "Stay on top", you can see the map while X-Plane is running.
You can modify the transparency and hide the title bar too (but you must display the title bar to move the map !).

![](/doc/screenshot4.png)


# TODO

* Display plane orientation
* Speed
* Altitude
* Etc...


# About

If you are satisfied with this application, and you would like to make a donation, please do so to someone in need :)
