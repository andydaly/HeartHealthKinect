#Interim Report
---

##1. Introduction 


##1.2 Project Aim

Home based rehabilitation system using the Xbox Kinect 2. Exercises suited for patients with Cardio-Vascular Diseases. User must perform exercises in front of the Kinect, Exercises are played out on the form of a game, different exercises are provided and patient’s heart rate is monitored. System is also connected online to the cloud for patient’s doctor to view, Doctor views how well exercises are performed and also keeps up to date with the patient without the need of continuous doctor visits.

Serious games can be thought of as any game based interfaces that have been designed for any purpose other than entertainment.

Rehabilitation in areas of Cardio-Vascular Diseases and Monitoring Heart-rate
Exercises may include: Squats, Jumping Jacks, Various Stretches and Basic Body Movements, etc.

#1.3 Project Objectives

Research and Deliver Home-based Rebailiation system for patients in rehabilitation of cardio-vascular diseases with a user-friendly interface and also a doctor-patient interaction system for doctors to diagnose and examine patients without face-to-face interaction.

**Project Objectives**

1. Research if project feasible.
2. Research similar technologies to determine user requirements for this project.
3. Research technologies to determine the most appropriate implementation of this project. 
4. Implement exercise tracking in patient system.
5. Implement serious game in patient system.
6. Implement doctor system.
7. Implement Heart-rate tracking in patient system.


#1.4 Walkthrough of the Report

Chapter 2: Technologies Research

Similar Solutions to HeartHealth will be covered in this chapter as well as that a comparison of all the available technologies will be discussed and compared to find the best for the proposed system.

Chapter 3: Project Ananlysis

This chapter will outline the strategies used to acquire functional requirements for this system. It will provide the results and conclusions obtained from interviews with retail owners, a SAS expert and surveys completed by the public. The chapter will illustrate how the results obtained were used as useful guidelines to structure the functional requirements of this system.

Chapter 4: Approach and Methodology

Technologies that can be used to facilitate certain functional requirements will be discussed in this chapter. Technologies that were researched but not used will also be outlined. A detailed description and justifications as to why some technologies were used instead of others will also be discussed in this chapter.

Chapter 5: Design

This chapter will outline the overall design of the system. It will discuss the methodologies researched and give an evaluation as to why one methodology was chosen over others. It will provide detailed diagrams on the overall system, database structure and on the GUI for the Android device and web site.

Chapter 6: Prototyping and Development

This chapter will provide an overview of how the system was implemented. It will provide a breakdown of each of the modules that were required for this system to meet the outlined requirements .It will also provide code snippets of how some functionality was implemented.

Chapter 7: Testing

This chapter will discuss the approach taken to testing the overall system. The results of unit testing, system testing and regression testing will be provided. This chapter will also discuss some of the user testing results obtained after the application was released into a real world environment.

Chapter 8: Issues and risks

This chapter will critically analyse all of the work completed in previous chapters. It will provide an objective evaluation on the entire system. This chapter will also outline any weaknesses within the system and how they may be overcome in future work.


Chapter 9: Plan And Future Work


Chapter 10:	Conclusions





#1.5 Timeline

![Gantt Chart](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/gantt2.png)

Proposed Project Timeline represented as a Gantt chart.

Meetings with Supervisor (Bryan Duggan) takes place every Wednesday which was agreed upon at the first meeting. Both College Semester's are divided with Research and Design taking place mainly in the first semester and implementation taking place moreso in the second semester.




#1.6 Conclusion 




##2. Research

#2.1 Introduction

((((Whats Covered in this chapter))))



#2.2 Background Research

**Serious Games**

Serious games can be thought of as any game based interfaces that has been designed for any purpose other than entertainment. Serious games have been researched in the areas of: military, health, government and education.[1] In this case, Serious Games can be used in the area of health. The Serious games aspect of the may be a solution to motivate patients to continue exercises in an engaging way. Patients are immersed in the game simulation and play the games regularly and as suchattribute to their rehabilitation.

Lots of research has been conducted in using serious games in terms of rehabilitation. Effective rehabilitation must be early, intensive and repetitive [2]. Serious games provide a means to maintain motivation for people undergoing therapy [3] by means of exercises. Games of virtual reality and imaging of webcam-based games [4] are usually the solution to provide an engaging and motivating tool for physical rehabilitation. 

**Cardiovascular Diseases**

The main area of rehabilitation focused on for this project is rehabilitation of people with cardiovascular diseases. Cardiovascular Disease (or Heart disease) is a class of diseases that involve the heart, the blood vessels (arteries, capillaries, and veins) or both.

Patients that require rehabilitation for cardio-vascular diseases must perform consistent exercises as a crucial element in their overall physical and mental rehabilitation. These exercises help the patient in many ways: [5] 

- Strengthens your heart
- May improve congestive heart failure symptoms
- Lowers your blood pressure
- Makes you stronger
- Helps you reach (and stay at) a healthy weight
- Helps manage stress
- Boosts your mood and self-esteem
- Improves sleep

However patients at home tend to either only follow their programmes for a short period of time or do not follow them at all. By using Serious Games with this project, patients may follow their exercise programmes regularly and to view it as a fun activity.


**Doctor-Patient Interaction**

Communication between doctor and patient is a key success factor in medical treatment. [6] And as such the doctor–patient relationship is central to the practice of healthcare and is essential for the delivery of high-quality health care in the diagnosis and treatment of disease or rehabilitation. Doctors must maintain a professional rapport with patients, uphold patients’ dignity, and respect their privacy.

In terms of online medical systems between doctors and patients, there has been an emergence of websites set up for booking appointments, order repeat prescriptions and view your medical record with certain Doctors/General Practitioners depending on if they choose to use the website.

The planned system will be in some ways similar to these online medical systems between doctors and patients except that results taken from patient's exercises will be sent straight to the doctor without the need for direct communication. 


#2.3 Alternative Solutions

Research of existing Doctor-Patient Home-based Rehabilitation systems which implemented motion capture and heart-rate tracking showed little or no results. The alternative solutions found are solutions which closely relate more to the two parts of the system, the Patients system and the Doctors system.


**Xbox Fitness**

![Xbox Fitness](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/xboxfitness.jpg?token=AGheT3Z_qfW1TFZvzcmu4Tff0rX4v2Q8ks5UkYcKwA%3D%3D)

The biggest to similiarity to a system which tracked heart rate as exercises were performed was Xbox Fitness. Xbox Fitness is a game/service exclusion to Xbox One which use's the Kinect V2 sensor for motion capture as well tracking the player's heart rate and estimating their calorie amount burned based on their workout. [7] The workouts are given by professional fitness trainers and given as a workout training video where the user works out along with the video. Based on reviews of Xbox Fitness, it has gained much success, with accurate tracking of the Kinect and excellent workouts and basing results of workouts by tracking heart rate. 


**Lloyds Online Doctor**

![Lloyds Online Doctor](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/onlinedoctor.jpg)

In relation to the Doctor's system the biggest similarity to an online Doctor-Patient system was Lloyds Online Doctor. In the system patients can choose their own doctor to diagnose them based on their condition. User's also have the ability to fill out a medical questionaire and from there doctor's on the site evaluate the questionaire and post out prescriptions to the patients if medically appropriate. [10]



#2.4 Technologies

#Game Engines

The Patient application which includes the Serious Game aspect of the system was decided to be built using a game engine as game engines contain all the tool available for building game-based systems without the need of coding them which would take a large amount of time.

Deciding on the proper game engines is important as different game engines may or not be able to implement some aspects of the proposed system. Some game engines are not able to support the motion capture device of the Xbox Kinect which may be a big deciding factor on whether it will be used in implementation of the system.


**Unity3D**

![Unity3d](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/unity3d.png)

Unity3D (or just Unity) is a cross-platform game creation system with it's own game engine and a built-in Integrated Development Environment (IDE) developed by Unity Technologies. Games built using Unity can be made for PC platforms like Windows and Mac, ot consoles like the Xbox 360 and Playstation 3, and even mobile devices like Android and Iphone.

Developers can program in scripts like C#, JavaScript or Boo (Python inspired syntax). MonoDevelop is the IDE built into Unity. Scripts do not need yo be written with the built-in MonoDevelop, however MonoDevelop necessary to debug them.

Unity3D has many plugins to implement many different types of motion capture. In terms of Microsofts Kinect, Microsoft have released their own plugins for Unity to implement Kinect Version 1 and Version 2 projects. [9]

**Unreal Engine**

![Unreal Engine](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/unreal.png)

The Unreal Engine is a game engine developed by Epic Games. The Unreal Engine also comes with the Unreal Development Kit, a game creation system for developing Unreal Engine games. The current release is Unreal Engine 4. Unreal Engine 4 uses C++ for scripting.


#Motion Capture

Deciding on the right motion capture device and software is very important in this project. The Xbox Kinect being the main open-source (depending on if you own a Kinect) motion capture device is primarily chosen. However depending on which version of the kinect certain aspects are required for the project such as the whichever version of the kinect has the ability of heart rate monitoring, a neccessary component of this project.

**Kinect**

![Kinect 1](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/kinect1.png)

The Kinect (Kinect version 1) is a motion sensing input device developed by Microsoft and PrimeSense for the Xbox 360 console and Windows PCs. Based on a webcam style peripheral device, it acts as an alternative type of input and allows user's to interact with interact with their console/computer without the need of a game controller.

**Kinect 2**

![Kinect 2](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/Kinect2.jpg?token=AGheT66cnyZokNimTenNdaY4WxHbdU5Zks5UjIJFwA%3D%3D)

The Kinect V2 is a motion sensing input developed by Microsoft as the predecessor to the Kinect. It is developed for the Xbox One console and Windows PCs. It holds most of the same functions as it's predecessor except many new features as well as upgraded features. It has the ability of heart-rate tracking by using it's infrared sensor.


#Cloud Services

Cloud Services for the system need to be decided upon in terms of web-hosting of the Doctor's System as well as database storage of Patient-Doctor account credentials as well as patient exercise results.

Choosing the correct cloud service depends on which programming languages it supports to facilate the application we have to deploy. In cloud computing terms this is known as Platform-as-a-Service, which means that an application is created using tool and/or libraries from the provider. The provider provides the network, servers, storage and other services that are required to host an application.



**Windows Azure**

![Windows Azure](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/windowsazure.png)

Windows Azure is Microsoft’s cloud-computing platform. Consumers of Windows Azure can build, deploy and manage applications through a global network of Microsoft-managed datacenters. It also provides web-hosting and the ability to create and deploy Virtual Machines. Users can develop applications in Java, PHP, Python, ASP.NET and Node.js. [13] Windows Azure has the ability to allow any language or framework, to be deployed onto the cloud however middleware must be used for some to work, and client libraries are available on GitHub.




**Amazon Web Services**

![Amazon Web Services](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/amazon.png)

Amazon's solution to cloud computing is Amazon Elastic Compute Cloud (EC2) which is part of Amazon's Web Services.
Amazon Web Services holds many tools especially for developers such as load balancers, relational databases add-ons, caching systems, notification systems and content delivery networks. These are constantly being optimize by Amazon and more services and online tools are constantly being added. [14] It also provides support for every major programming language. 




#Server-Side Languages

Communication between the client and server is an essential part of the Doctor's System. The Doctor's System must perform many specific functions such as creating patient accounts, viewing patient accounts and view patient workout results and heart rate condition. Server side languages perform the programming functions of the system on the server. Once the task has been completed here, the result is returned to the client through the front end.

**PHP**

![PHP](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/php.jpg)

PHP is scripting language also used as a programming language. PHP is probably one of the most popular languages in terms of creating server side web applications. PHP's syntax is very similar to that of languages like Java and C++, making PHP familiar and easy to learn. It can be considered as an option as I am very familiar with it, however it is considered outdated by many because of the more recent web frameworks available which allow for less code and faster completion.


**Python (Django)**

![Python](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/python.png)

![Django](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/django.png)

Python is a high-level programming language which has a unique code syntax which expresses concepts in fewer lines of code than other high-level programming langauges. Python can be written for applications and web-based applications.
Django is a free and open source web application framework, written in Python. Django’s motivation lies in the “intensive deadlines of a newsroom and the stringent requirements of the experienced Web developers who wrote it”. [12] Which means that it is a fast and easy to manage framework, it is also readable for people not exactly familiar with the framework, which is of benefit to myself as I am neither familiar with Python or Django. It follows the Model, View, Controller class technique where every class involved in the framework must be organised into specific roles of Models (Storing Functions and Information), Views (Output of information) and Controllers (Managing information and connecting the view and model classes).


**ASP (ASP.Net)**

![ASP.NET](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/aspnet.png)

ASP.NET is an open source Web application framework designed for Web development to produce dynamic Web pages. It was developed by Microsoft to allow programmers to build dynamic web sites, web applications and web services. [13]
Any .Net language can be used along with ASP.NET. The main being actual ASP (Active Server Page). ASP is most commonly used along with VBScript for client-side scripting.


#Client-Side Languages

Client-side languages became of use because of the static nature of HTML only documents and as such client side scripting languages were designed to introduce some level of interactivity in these web pages. [20] Client side languages and frameworks are used in conjunction with Server-side languages to construct and deliver the front end of the system and display the data from the server databases to the user. When a user wishes to view the site, client scripts are sent to the user's browser and run there. The client side scripts are what is responsible for displaying the system and data to the user. The most common client-side languages are JavaScript with the JQuery framework and VBScript. 


**JavaScript (JQuery)**

JavaScript is a dynamic computer programming language most commonly used when programming websites for the client side interface. Javascript is usually used along with HTML, to present efficient and well-presented user interfaces. A note as well; Unity can used JavaScript type scripts.  
JQuery is a Javascript library which is used to simplify the client-side scipting of HTML and allows for the creation of powerful and dynamic web pages and applications. JQuery is a free and open source software. It's syntax makes it easier to a document and allow for easier implementation of more difficult features to display on a webpage. JQuery also allows for developers to create plug-ins on top of the Javascript library.

**VBScript**


VBScript (Visual Basic Scripting Edition) is the language most commonly used when programming with ASP (Active Server Pages). VBScript is closely modeled on Microsoft's Visual Basic. VBScript uses Windows Script to communicate with host applications.




#Database Management System

Deciding on the right database management is crucial to how the whole system operates. The system requires a Database management system to keep track of doctor accounts, patient accounts and patient records. One of the main deciding factors on picking the right Database management system is that will it be compatible with each component in the system. For example, does the Cloud service support it? Can the patient application connect to it? Can the doctor system connect to it? Is it the best Database management system to organise and store the data in?

Of the two examples compared, a compasion is done of whether to use a NoSQL Database and a Relational Database, which is also a point to be consider in choosing the correct database.

**MongoDB (JSON)**

![MongoDB](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/mongodb.png)

MongoDB is the most popular open source document-oriented datbase. Classified as a NoSQL database, [15] MongoDB performs differently to the normal table-based relational database structure of most popular databases and stores data in JSON (JavaScript Object Notation) documents (known as BSON with MongoDB). Being a different type of database management system to the traditional relational database system MongoDB does contain some limitations such it cannot join different data types across the database, a functions which is commonly used in most relational databases, however it does allow for data querying.

**MySQL**

![MySQL](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/mysql.png)

MySQL is an open-source relational database management system. MySQl is one of the most popular database management systems in the world with being open source a big part of the reason. Large organisations such as Facebook, Google and Youtube still make use of MySQL databases. A thing to note is that SQL Developer can also be used as a front end solution to interface with the MySQL backend.



#2.5 Technology Analysis

**Game Engines**

On comparison both Unity and Unreal Engine (UE4) are both supurb game engines, however Unity wins outright for many reasons above Unreal in terms of my own preference and reasons to do with the project based on the following factors from my own experience working with them 
To note, I was already familiar with Unity, having worked on many projects before with it which aided my decision, however I gave Unreal a chance and looked into what it had to offer. 

- Programming/Scripting Languages

Unity - C#, JavaScript, Boo

Unreal - C++


- Kinect V2 Compatible

Unity - Microsoft Officially released Kinect V2 Plugin

Unreal - User-made plugins still in development for UE4


- Hardware requirement

Unity - Unity can run on low spec system and still make good games

Unreal - Unreal requires high spec system for good games


- Cross Platform

Unity - Windows, Mac, Wii, iPhone, iPad, Android, PS3, Xbox, Xbox 360, Web Applications

Unreal - Windows, Mac, iPhone, PS3, PS4, Xbox360, Xbox One, PS Vita, Wii, Android


- License

Unity - All tools to create game are free, except for pro which only has Glass refactoring and shadows

Unreal - Free, but limits to many tools unless paid

- Stability

Unity - Rarely Crashes

Unreal - Crashes Often

- Learning Curve

Unity - Very User friendly and easy to understand

Unreal - Difficult to understand User interface, however much documentation available


Unreal had a bigger learning curve and different User Interface to Unity which would of taken time to get a hang of. Unity is also free unless you want the Unity Pro paid edition which only include small nitpicking features such as glass refactoring and shadows whereas Unreal Engine is not free. One last important which greatly influenced my decision was that there is no official plugin or support for the Unreal Engine to use the Kinect or Kinect 2. I had found that some people created plugins for the engine however Microsoft released their own plugins especially for Unity for the Kinect v2 and on testing them they worked fine. Also to note C# will be the scripting language used in Unity3D as I have more experience using it.


**Motion Capture**

On comparison of both the Kinect and the Kinect 2, the Kinect 2 is the outright winner for the obvious reason of it's ability to measure heart rate, however it is also good to note the positive things of the original Kinect.

- Color Camera [17]

Kinect - 640 x 480 @30 FPS

Kinect 2 - 1920 x 1080 @30 FPS


- Depth Camera [17]

Kinect - 320 x 480 

Kinect 2 - 512 x 424

- Skelton Joints [17]

Kinect - 20 joints

Kinect 2 - 26 joints


- Number of Skeletons Tacked

Kinect - 2

Kinect 2 - 6


- Bone Orientations [16]

Kinect - No

Kinect 2 - Yes


- Measuring Heart Rate

Kinect - No

Kinect 2 - Yes



- Muscle Simulation [16]

Kinect - No

Kinect 2 - Yes


- Face Tracking

Kinect - Yes

Kinect 2 - Yes


- Recogniziong Expressions [16]

Kinect - No (You must Write Algorithm to do so)

Kinect 2 - Yes



- Hardware requirement

Kinect - Either USB 2.0 or USB 3.0

Kinect 2 - PC must have USB 3.0


- Cost

Kinect - €30+ (Retail Price)

Kinect 2 - €95+ (Retail Price)



- SDKs Available

Kinect - Kinect for Windows SDK v1.8, OpenNI v2.2

Kinect 2 - Kinect for Windows SDK v2.0


- Unity Plugins

Kinect - Kinect with MS-SDK (Unity Asset Store), Many more available

Kinect 2 - KinectForWindows_UnityPro_PublicPreview, Available from Microsoft

Based on the results, in comparison the Kinect V2 with it's new and upgraded features as opposed to it's predessor wins outright, but it is important to note that it's 2 flaws which can influence a decision in a different scenario is its Hardware Requirement and its Cost. A lot of computers, some custom-built or old models, do not have a USB 3.0 port and as such the Kinect V2 will not work without one. Cost may be a big part of influencing decision as well and these factors must be taken into account in the implementation of this project. The Project is stated for home-based rehabilitation and if the patient does not have the money for an expensive Kinect V2 or their PC does not have a USB 3.0 then the Patient's system will be of no use.


**Cloud Services**

The main things to be considered on picking the right cloud service is the Programming Languages it supports, and the Database Management sytem it already supports.

- Programming Languages Supported

Windows Azure - Java, PHP, Python, ASP.NET and Node.js

Amazon - Supports every main programming langauage except Node.js


- Database Management Systems

Windows Azure - MySQL, Oracle, SQL Azure,  DocumentDB, Storage Blobs, Storage Tables, MongoDB (MongoLab)

Amazon - MySQL, Oracle, SQL Server, PostgreSQL, Aurora

- Ease of use

Windows Azure - Beginner freindly (Alot of Documentation) [13]

Amazon - Said to be extensive and diverse and difficult to newcomers [14]


Windows Azure seeems to win out in terms of Cloud Services not so much for the Programming Languages it supports or its Database Management Systems but it's Ease of use and friendly User interface which makes it easy to abjust for newcomers to cloud software like myself.

**Server-Side Languages**

For the Doctor system choosing the correct langauge depends on perference more than anything, however some languages would be more suitable than other for some reasons.


- Ease of Use

PHP - Average Ease of Use

Python (Django) - Known for simplicity

ASP.NET - Very much frowned upon by alot of people


- Web-Based

PHP - Yes

Python (Django) - Yes

ASP.NET - Yes


- Windows Azure Compatible

PHP - Yes

Python (Django) - Yes

ASP.NET - Yes



Python with Django has been chosen mainly becuase of my own personal preference to work with it, it's Ease of Use is also a factor however I would like the chance to work with Python and Django to get a broader experience on different types of programming languages.


**Client-Side Languages**

The decision of the client-side languages has a lot to do with the previous choice of which Server-side language was chosen. Some Server-side languages perform better with specific Client-side Languages and vice-versa.


- Server-side Best Compatibility

JavaScript - PHP, Python (Django)

VBScript - ASP.NET

- Browser Compatibility

JavaScript - Default scripting language for browsers

VBScript - Not as common on a lot of browsers (Firefox and Opera)

JavaScript with JQuery was chosen because of my previous decision on server-side languages of Python with Django, JavaScript with JQuery works best with Python with Django as opposed to Python working with VBScript. JavaScript is also more compatible on most web browsers as opposed to VBScript.


**Database Management**

The two Database Management Systems to be compared are totally different types of management systems, one being the new NoSQL database and the being the well known relational tabular database management system. This comparison is really to compare which is the best way to store data, by using the well-known SQL or the new NoSQL method of JSON.


- Data Storage

MongoDB - Collection (Document-Oriented Storage with BSON) 

MySQL - Tabular-Storage (SQL)


- Data Querying

MongoDB - Yes

MySQL - Yes

- Winows Azure Compatible

MongoDB - May require some work to set up

MySQL - Already set up, just allocate that it is needed.


- Format

MongoDB - BSON

![BSON](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/bson.jpg?token=AGheT2vCQUoWuP5I4t5r_Z3nfxaky4Yjks5UjbZxwA%3D%3D)


MySQL - SQL

![SQL](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/sqlstorage.png?token=AGheTyDBDaDVewsf1kVSPJ5Tj5WE8bDiks5UjbZzwA%3D%3D)


MongoDb has be chosen as my Database Management System because of my own personal preference, I would like to gain a bit of insight into NoSQL and to find out exactly why MongoDB is so popular.



#2.6 Additional Research

Interview with Zachery Tan
(zacherytan@hotmail.com)

Interview 

*1. What do you do? (occupation)

I'm Orthopedic surgeon at Bon Secours hospital in Glasnevin.

*2. Do you work with much patients with cardio-vascular disease(s)?

Yes!

*3. What are the main exercises patients with cardio-vascular disease(s) most perform?

There are no particular set exercises for people who suffer with cardio-vascular diseases. Depending on the type of stage patients are in terms of heart disease, patients must perform a lot of cardio exercises in a gym before surgury of a heart bypass and after surgey they must perform light exercises such as walking or swimming. Check out DCU's weight loss programme for more information on the specific type of exercises for these people.

*4. What is the average timeline of improvement for people going through this rehabilitation?

Depending on the severity of heart problems, it can take very long, however exercise is definately crucial in recovery, if patients do minimum exercises then there is little or no recovery, however if patients actually do exercises there is a big improvement, improved health and patient quality of life.

*5. Would you say people adhere to their exercise programmes?

No, most patients do not and because of this their quality of life doesnt change, patients who became ill due to smoking habits or lack of exercise just get worse by not performing any exercise even though they know they must. They also continue with bad smoking habits even though they should not.

*6. What other diseases are there where exercises must be performed as part of rehabilitation?

Everything! Diabetes, endocrinology diseases, Orthopedic conditions, etc.

*7. What exercises must be performed in relation to said disease(s)?

There are no particular set exercises for any of them, basically the part of the body which is damaged or diseases needs to be exercised. For example, if there is damage to a patients knee, they must perform knee physio exercises which improves muscle build on the knee and increases a lot in the joint.

*8. Do you think this system will work for people in rehabilitation?

Link the system for Physio terapists and not doctors as people who are in rehabiliation and must perform exercises are in more contact with physio-terapists than doctors. The Elderly must be taken into account as they are the majority of people with cardio-vascular diseases.


*9. Your opinion of the system, any additional input for the system?
 
System sounds good, however need a bit more medical experience, have check counters for maximum heart rate of different types of patients, also different levels of exercises need to be implemented for different types of people depending on their fitness, for example obese patients exercises versus patients who are in good physical condition and used to run marathons. Make sure to test the system on normal people as well as people with heart conditions.


**Things noted**
Doctors will not be the main users of Doctor-Patient system, Physio-terapists will most be in charge of patient checkups, however for this project, Doctor's will be used to refer to the group of Physio-terapists, Doctors, General-Practicetioners and whoever else may make use of the system.

There may be different levels of exercises depending on the patient to be implemented in both exercise and serious game of patient's system, on patient account creation doctor (Physio) will specify correct level.  



#2.7 Additional Software

- Github

GitHub is a web-based software project repository hosting service. Github uses Git which is a distributed revision control system with an emphasis on speed, data integrity, and support for distributed, non-linear workflows. [18] GitHub provides a web-based graphical interface for Git based projects. Users can make either private or public repositories if they want to share their code or not.

GitHub will be used for the version control of the whole system and a private repository will be used until project completion.

- 3DS Max

3DS Max is a 3D modeling software which can be useful for modelling a variety of architectural, character models and even be used to create 3D animations. The main reason 3DS Max will be used is for the creation and/or editing of models/assets/areas in the Patients System. Most character models are in FBX format which 3DS Max does indeed support. Another influence to my decision is my past experience to 3DS Max as opposed to other 3D modeling software.

#2.8 Conclusion

The Softwares which will be involved in the implementation of the whole system:

- Unity3D
- Kinect 2 (Kinect for Windows SDK v2.0)
- Python (Django)
- MongoDB
- GitHub
- 3DS Max 




##3. Project Analysis

#3.1 Introduction


#3.2 Project Overview

![System Overview](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/systeimage.png?token=AGheT6VF_-DwvR08K1GbQMdGfjySQnmzks5UjbvOwA%3D%3D)

Patient’s System; Computer with Game/Rehabilitation Application and Kinect 2 attached.
Admin/Doctor’s System; Computer with Admin Application

Patient’s System; System will have the game and rehabilitation workout routines, Patient logs into their user-account (which is set up by Doctor) and application commences. Patient has ability to commence normal workouts, perform workouts in Gamified environment or view records from pervious workouts as well as comments from Doctor.

Admin/Doctor’s System; System will be a Doctor check-up system, Doctor logs into system, can view patients, create account for patient, can view specific patient records and send comment to patient on record to give progress, there may also be an ability to view exact patient workout.

#3.3 User Requirements

**Functional Requirements**

Use Cases

Patient
- Log in
- Perform Basic Exercise
- Play Game
- View Records (Workout)

Doctor
- Log in
- Create Patient Account
- Select Patient
- Edit Patient Details
- Send Message
- View Records (Workouts)
- Comment on Workout

**Non Functional Requirements**


#3.4 Conclusion





##4. Approach and Methodology

#4.1 Introduction
Choosing the correct Software Development Methodology is an important factor in the design, implementation and devlopment of the system. It makes the life of a developer working on a project a whole lot simpler by layout out a set of predefined steps to follow from the beginning to the end of the project. 

For the HeartHealth project, I am considering one of three software development methodologies of Agile Software Development's Scrum method, Iterative and Incremental method and Rapid Application Development. Each methodology will be analazed and compared to one another to determine which is the most suitable for use in developing this project.



#4.2 Methodologies

**Scrum (Agile Methodology)**


 
![Scrum](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/scrum.png)



Scrum is an Agile Software Development Framework, with Scrum roles for team members must be assigned to properly implement the methodology such as the Product Owner, the Development Team and the Scrum Master.

Scrum Agile Methodology Software Development approach will be adopted in development of the game.
The reason as to why Scrum was chosen was because it was the best software development methodology in terms of game development, Scrum was recommended as the best as most game development companies use it in development of their games.
Scrum also displayed logical methods in terms of development of a game with its many iterations of the developed product and continuously improved iterations of the product over time, as well daily meetings on what could be improved in the developed product.





**Rapid Application Development**

![RAD](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/rapidapp.png)


**Iterative and Incremental method**

![Iterative](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/iterative.jpg)


#4.3 Methodology Analysis


#4.4 Conclusion



##5. Design


#5.1 Introduction

#5.2 Use-case Diagram

![Use-Case Diagram](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/usecase.png)

#5.3 System Architecture diagram




#5.4 ERWIN Diagram

![ERWIN Diagram](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/erwinimage.png)


#5.5 Flowchart

![Flowchart](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/flowchart.png?token=AGheT88qS6jMhm34DWnaTOc3e3ljS0p_ks5UjbedwA%3D%3D)


#5.6 User Interface Design

![User Interface Design 1](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/proto1.jpg)

![User Interface Design 2](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/proto2.jpg)


#5.6 Class Diagram












ERD
Doctor Login table
-DoctorUsername
-Password


Doctor Details
-DoctorUserName
-Name
-Practise
-PhoneNumber
-Position
-Bio


Patient Login table
-PatientUserName
-Password

Patient Details
-PatientUserName
-Name
-Address
-DateOfBirth
-WorkoutLevel

Patient Report
-DoctorUserName
-PatientUserName
-Diagnosis
-DiagnoisDate
-DisgnoisNumber


Patient Workout
-PatientUserName
-Date
-HeartRate
-WorkoutType
-ActionsPerformedNUM
-WorkoutNumber
-DoctorComment
-WorkoutLength






Doctor-Patient Messages
-DoctorUserName
-PatientUserName
-MessageNumber
-MessageDate
-Message


Doctor-Patient Allocations
-DoctorUserName
-PatientUserName
-PatientNumber
-DateCreated








##6. Prototyping and Development

#6.1 Introduction

Prototype was made with Unity 3D and using the original Kinect

![Prototype 1](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/PrototypeImage2.png?token=AGheT6qUQJ-jWkXme6jP9XiiOA6wTa_vks5UjcLlwA%3D%3D)

![Prototype 2](https://raw.githubusercontent.com/andydaly/HeartHealth/master/Pics/PrototypeImage.png?token=AGheTwIVl6ep38-O0JMwBvlsB5YVI3fWks5UjcLfwA%3D%3D)


##7. Testing

#7.1 Introduction

#7.2

#7.3




##8. Issues and risks

#8.1 Introduction

#8.2

#8.3



 
##9. Plan and future work

#9.1 Introduction

#9.2

#9.3


##10. Conclusions

#10.1 Introduction

#10.2 Research Summary

#10.3 Research Analysis

#10.4 Conclusion

   

## References
[1] Clark C. Abt, Serious Games
http://books.google.ie/books?hl=en&lr=&id=axUs9HA-hF8C&oi=fnd&pg=PR13&dq=serious+games&ots=dZR3aey9sV&sig=-MbsQ0J-JNZnmSCrodAvZoEJrTc&redir_esc=y#v=onepage&q=serious%20games&f=false

[2] REGO, P., MOREIRA, P.M. and REIS, L.P., 2010. Serious games for rehabilitation: A survey and a classification towards a taxonomy, Information Systems and Technologies (CISTI), 2010 5th Iberian Conference on 2010, IEEE, pp. 1-6.

[3] Burke, J.W, Serious Games for Upper Limb Rehabilitation Following Stroke, In Games and Virtual Worlds for Serious Applications, 2009. VS-GAMES '09., IEEE, pages 103 - 110, Coventry, 23-24 March 2009

[4] Burke, J.W, Augmented Reality Games for Upper-Limb Stroke Rehabilitation, In Games and Virtual Worlds for Serious Applications (VS-GAMES), 2010 Second International Conference, IEEE, pages 75 – 78,
Braga, 25-26 March 2010

[5] http://www.webmd.com/heart-disease/guide/exercise-healthy-heart


[6] http://www.noldus.com/human-behavior-research/application-areas/doctor-patient-interaction

[7] http://www.xbox.com/en-IE/xbox-one/games/xbox-fitness


[9] http://blogs.msdn.com/b/uk_faculty_connection/archive/2014/07/17/kinect-v2-preview-sdk-now-available-includes-unity3d-plugin.aspx

[10] https://www.lloydsonlinedoctor.ie/



[12] https://bernardopires.com/2014/03/rails-vs-django-an-in-depth-technical-comparison/

[13] http://www.asp.net/

[13] http://cloud-hosting-review.toptenreviews.com/windows-azure-review.html

[14] http://cloud-hosting-review.toptenreviews.com/amazon-elastic-beanstalk-review.html


[15] http://www.mongodb.com/what-is-mongodb

[16] http://www.quora.com/What-is-the-difference-between-Kinect-and-Kinect-2

[17] http://zugara.com/how-does-the-kinect-2-compare-to-the-kinect-1

[18] http://git-scm.com/book/en/v2/Getting-Started-Git-Basics

[20] http://uopteamc.tripod.com/javavb.html
