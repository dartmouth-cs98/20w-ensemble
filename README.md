# Ensemble

* Ensemble is a VR experience that places the user in a realistic concert environment with an audience and ensemble. The musician is able to practice performing a piece in front of a simulated audience, to help combat stage fright.

## Architecture

* The frontend and all visual aspects are implemented using Unity3D and compatible C# scripts. Autodesk Maya is used for modeling and animations.
* The backend will be coded in Python in a separate companion app. This will allow the visual aspect of the project to run at full capacity without worry of computational exhaustion as a result of numerous probability calculations. The backend repository can be found at: https://github.com/dartmouth-cs98/20w-ensemble-vr-score-following

## Setup

* Install Unity3D version 2019.2.19f1 if needed.
     * Import Oculus Integration from the asset store
     * Follow the doc (https://docs.google.com/document/d/1qQUxRkFI3ZYzungtmWm_m737iezlGOvsgwCqs6ibgjQ/edit) to ensure that settings are correct.
* In your Oculus headset, click on Settings, then See All, and then Experimental Features. Scroll down and enable Hand Tracking as well as Auto Enable Hands or Controllers.


## Deployment via Unity3D

* Clone this repository into any folder. Then, open the project in Unity! An Oculus Quest is required to run the application, so plug in an Oculus Quest into your computer via USB Type-C cable. Enable USB debugging on the Oculus Quest.
* Go to Build Settings, and ensure that it is building to Android. Go to player settings and ensure that Quest is set as the build target. Then, click Build and Run, save the .apk into any folder you would like, and enjoy!

## Deploying the .apk
* Download Android File Transfer: https://www.android.com/filetransfer/
* Go into your Oculus Settings and in Experimental Settings, toggle on Hands.
* Download the .apk from: https://drive.google.com/file/d/1BoVSxiobD31sZLNn6Qb-DimpiuhovuNM/view?usp=sharing
* Connect the oculus to your compute and use Android File Transfer to move the .apk into your oculus.
* Run the .apk on your oculus!

## How to Navigate the Game
* Once the game is started, point the ray shooting out of your right hand at the "Play" button and pinch your index fingerand thumb together.
* There is a also a tutorial you can use to practice the interactive hands.
* Once you begin, you will be taken to the backstage room. There, flip through the music book pages until you find a piece you want. Currently, there are only 3 pieces to choose from (Pachelbels Canon, Let It Go, and Beethoven's Symphony No. 9).
* Once you are flipped to the right piece, turn right and pinch on the door to go to the main stage.
* Pinch on the green play button on the podium to start the music.
* Practice to your heart's content!

## Authors

* James Lee
* Bryan Shin
* Marshall Peng
* Soohwan Park
* Myles Holt
* Ryan Hyun

## Acknowledgments
