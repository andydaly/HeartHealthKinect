## Update #1 ##

*20/10/2014*

Downloaded Unity Pro and tested the KinectForWindows_UnityPro_PublicPreview project, here are the results: 

[![Video](http://img.youtube.com/vi/MKLrpEePILk/0.jpg)](https://www.youtube.com/watch?v=MKLrpEePILk)

Kinect V2 is fully functional with Unity.

## Update #2 ##

*03/11/2014*

**Summary**

Home based rehabilitation system using the Xbox Kinect 2. 
Exercises suited for patients with Cardio-Vascular Diseases
User must perform exercises in front of the Kinect, Exercises are played out on the form of a game, different exercises are provided and patient’s heart rate is monitored. 
System is also connected online to the cloud for patient’s doctor to view, Doctor views how well exercises are performed and also keeps up to date with the patient without the need of continuous doctor visits.
Serious games can be thought of as any game based interfaces that have been designed for any purpose other than entertainment.
Rehabilitation in areas of Cardio-Vascular Diseases and Monitoring Heart-rate
Exercises may include: Squats, Jumping Jacks, Various Stretches and Basic Body Movements, etc.


**End Deliverables**

Patient’s System; Computer with Game/Rehabilitation Application and Kinect 2 attached.

Admin/Doctor’s System; Computer with Admin Application

Patient’s System; System will have the game and rehabilitation workout routines, Patient logs into their user-account (which is set up by Doctor) and application commences. Patient has ability to commence normal workouts, perform workouts in Gamified environment or view records from pervious workouts as well as comments from Doctor.

Admin/Doctor’s System; System will be a Doctor check-up system, Doctor logs into system, can view patients, create account for patient, can view specific patient records and send comment to patient on record to give progress, there may also be an ability to view exact patient workout.


**Rough Prototype**

System Overview:

![Alt text](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/systeimage.png?token=AGheTz7OsrTjHOGyJzBTXBxqq_Qmoj-oks5UgHVCwA%3D%3D)

Patient System:
Login Screen; 
Menu Screen; Select Options: Normal Workout, Gamified Workout, View Records
Normal Workout; Perform Normal workouts without gamified environment
Gamified Workout; Play Game, workouts performed along with game
View Records; View Records of Previous Workouts and view comments from Doctor

Doctor System:
Login Screen;
Patients Overview Screen; Displays all patients as well as option to create new patient
Specific Patient Overview Screen; View Details of Specific Patient Viewed, can also select specific workout performed, can comment or view progress

## Update #3 ##

*10/11/2014*

**Project Research**

Heart rate tracking

Looking into the heartrate tracking this week, I found this video:

[![Video](http://img.youtube.com/vi/LnX0qko-OOk/0.jpg)](https://www.youtube.com/watch?v=LnX0qko-OOk)

To get a better idea of the Kinect 2 use of the heart rate detecting ability, i decided to download the software provided by the video:
https://k4wv2heartrate.codeplex.com/

I downloaded the exe of HeartRateDetector.exe, sadly however I encountered errors concerning igd10iumd64.dll and igd10iumd64.pdb.

![Alt text](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/error1.png?token=AGheT6GiKIrcbiLA4S1E9LVc_UO8vweCks5UgHU5wA%3D%3D)

![Alt text](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/error2.png?token=AGheTyAx27l2iJdQPQln70LsOGHvwVADks5UgHU7wA%3D%3D)

![Alt text](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/error3.png?token=AGheT02YtJW-ixEauCLCvrkXoF9EJpVRks5UgHU9wA%3D%3D)

![Alt text](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/error4.png?token=AGheT6Ut5LLSD6b9evfxF_cNz7nyuR8Oks5UgHVAwA%3D%3D)

It appears that the reason the application is not working is because my current graphics card is too advanced to run the software.
In order to get the heart rate tracking working, I may have to work from scratch, the video gives good tips on how to implement it, by using C++, so I may create an external C++ program to get the heart rate tracking results and then import the results into my Unity Program.

## Update #4 ##

*12/11/2014*

**Project Plan**

Week Begins at Every Monday:

- **17/11/2014**

Research Heart Tracking Kinect 2 Capabilities 

Plan Project Requirements

Plan Use-case

- **24/11/2014**

Start Interim Report

Commence System Design

Draw Class Diagram

Commence Kinect 2 Skeletal Tracking

- **1/12/2014**

Complete Interim Report

- **8/12/2014**

Complete Skeleton Tracking

Start Workout Recognition

- **15/12/2014**

Complete Workout Recognition

Start Patient System Menus

Start Hand as mouse recognition

- **22/12/2014**

Commence Heart Rate Tracking (possibly in C++)

- **29/12/2014**

Commence Workout Game In Patients System

- **5/01/2015**

Commence Doctors Sytem

- **12/01/2015**

Commence Networking Capabilities

Create Online Database

Commence Patient System User Accounts Capabilites

- **19/01/2015**

Finish Featues

- **26/01/2015**

Finish Features

- **2/02/2015**

Polish System, Ensure Patient's System is Working Properly

- **9/02/2015**

Polish Sytem, Ensure Doctor's System is Working Properly

- **16/02/2015**

Polish System

Import Clean New 3D Models

- **23/02/2015**

Test And Fix

- **2/03/2015**

Test And Fix

- **9/03/2015**

Test And Fix

- **16/03/2015**

Test And Fix

- **23/03/2015**

Test And Fix

Complete Project

- **30/03/2015**

Complete Documentation

## Update #5 ##

*18/11/2014*

**Abstract**

The research presented in this abstract concern the utilization of Serious Games in terms of home-based patient rehabilitation. The main goal here is to attempt to provide motivation and enjoyment during the performance of exercises as well as monitor their condition and heartrate while using the Microsoft Kinect 2 integrated into a customized open sourced game engine.

Serious games can be thought of as any game based interfaces that has been designed for any purpose other than entertainment. Serious games have been researched in the areas of: military, health, government and education. The design of these serious games can offer valuable contributions to develop effective games in the area of rehabilitation. As any other computer game, they are fundamentally intended to capture and keep a person’s attention.

Patients that require rehabilitation for cardio-vascular diseases, balance re-training, rheumatoid arthritis rehabilitation, and rehabilitation following stroke, etc. must perform consistent exercises as a crucial element in their overall physical and mental rehabilitation. However patients at home tend to either only follow their programmes for a short period of time or do not follow them at all. The problem we are aiming to solve is that patients follow their exercise programmes regularly and to view it as a fun activity.

This system will make use of the Microsoft Kinect 2 sensor of motion capture capability to track user movements and using the infrared sensor to monitor their heartbeat, the data capture in terms of user movements as well as monitoring the user's heartbeat may become useful in terms of diagnosing and/or rehabilitation of a patient.
