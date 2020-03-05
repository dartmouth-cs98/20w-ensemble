# Ensemble

* Ensemble is a VR experience that places the user in a realistic concert environment with an audience and ensemble. The user practices a musical piece that includes accompaniment and the ensemble plays along with the user, adapting to his or her tempo and practice habits such as repeating passages.

## Architecture

* The frontend and all visual aspects are implemented using Unity3D and compatible C# scripts. Autodesk Maya is used for modeling.
* The backend will be coded in Python in a separate companion app. This will allow the visual aspect of the project to run at full capacity without worry of computational exhaustion as a result of numerous probability calculations.

## Setup

* Install Unity3D version 2019.2.19f1 if needed.
     * Import Oculus Integration from the asset store
     * Follow the doc (https://docs.google.com/document/d/1qQUxRkFI3ZYzungtmWm_m737iezlGOvsgwCqs6ibgjQ/edit) to ensure that settings are correct


## Deployment

* Clone this repository into any folder. Then, open the project in Unity! An Oculus Quest is required to run the application, so plug in an Oculus Quest into your computer via USB cable. Enable USB debugging on the Oculus Quest. Open the companion Python app as well.
* Go to Build Settings, and ensure that it is building to Android. Go to player settings and ensure that Quest is set as the build target. Then, click Build and Run, save the .apk into any folder you would like, and enjoy!

## Authors

* James Lee
* Bryan Shin
* Marshall Peng
* Soohwan Park
* Myles Holt
* Ryan Hyun

## Acknowledgments
