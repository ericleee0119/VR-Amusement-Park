# VR-Amusement-Park

## Demo Video
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/8L9hfdfyGIg/0.jpg)](https://www.youtube.com/watch?v=8L9hfdfyGIg)  

## Technical skills and Keywords  
1. Unity3D  
2. C#  
3. AR/VR  
4. VR Roller Coaster  
5. Google Cardboard  
6. 3D Model  
...  

## Introduction
Most people enjoy visiting the amusement park. There
are several amusement parks in the world and each amusement
park has its own famous facilities. It is really hard
for people to visit all amusement parks all over the world.
Therefore, I decided to implement a VR project that can let
the user could have the experience to take rides with the
Google Cardboard. Each amusement park has many kinds
of facilities, and I choose to implement the most classical
facility into my project. I built two roller coasters for my
project. This VR amusement park can let the user select
which roller coasters they are going to play.

## Design and Implementation
The below image is the architecture of my project, We have two facilities, they share the sun, the cloud,
and the light in our Unity world. And each facility has their own
objects, such as cars, buildings, etc. The independent objects can
help us to design the different features at each facility  
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/4.jpg)  
  
    
    
    
The below image shows that we have two main code file. CameraPointer.
cs indicates the camera and the action it should do. And
the MoveCar.cs is the code indicates how the car moves. It also
provided the algorithm to adjust the Velocity
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/5.jpg)

There are some math and physics problems we may
need to take care of in this project. especially the Velocity.
Velocity includes acceleration and minimum Velocity and
Maximum Velocity. Acceleration tells us when the user sits
on the Roller Coaster, and how much velocity it accelerates
per second. And we also need to calculate the Maximum
velocity because it is impossible to let the acceleration keep
updating to infinite. The Roller Coaster may rise up and fall
down depending on the design of the tracks. And it is also possible that the tracks may lead the car to go up side down.
The velocity of each situation is different, therefore, this is
another thing we may need to think about. We set a default
acceleration value, and depending on the current rail angle,
we let this default value crossed by the sin(angle) to get
anew acceleration. With sin implementation, we could get
an acceleration that can be negative or positive. By this
way, we could control the speed well. Figure 3 mentioned
the possible situations we may meet and provided my
current solutions.  
  
# Demonstration  
The below image is the user experience flow. When the user
starts our project, this flow can indicate the all steps they may
meet.  
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/9.jpg)   

The below image is the scene of our amusement park. The
right side and the left side each contain a roller coaster. Users can
select the roller coaster they are going to play.  
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/7.jpg)  
  
The below image is the scene of the PC user while they play
on the roller coaster.  
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/8.jpg)  
  
The below image is the scene of the Google Cardboard user
while they play on the roller coaster.  
![image](https://github.com/ericleee0119/VR-Amusement-Park/blob/main/img/10.png)   
  

## Reference
Car 3D Model: (”pui pui molcar” (https://skfb.ly/6ZRCM) by klairbobos is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).  
Cloud 3D Model: (”Cartoon Cloud” (https://skfb.ly/6AuOS) by RunemarkStudio is licensed under Creative Commons Attribution (http://creativecommons.org/licenses/by/4.0/).  
