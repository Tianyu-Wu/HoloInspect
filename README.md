# HoloInspect - Mixed Reality for BIM Software

## Introduction
This is a course project for GIS and Geoinformatics Lab in 2020 Fall at ETH Zurich. 
With Microsoft HoloLens, our application, HoloInspect, provides additional mixed reality support for traditional BIM software in three construction stages:
presentation, management and on-site inspection, with partial multi-user capabilities. 

## Dependencies
HoloLens 1 <br/>
Unity 2019.4.12f1 <br/>
Visual Studio 2019 Version 16.5.0 <br/>
MRTK v2.5.1 <br/>
Microsoft Azure Spatial Anchor SDK version 2.7.0 <br/>
[MRTK.HoloLens2.Unity.Tutorials.Assets.GettingStarted.2.4.0.unitypackage](https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/tutorials/mr-learning-asa-02#importing-the-tutorial-assets) <br/>
[MRTK.HoloLens2.Unity.Tutorials.Assets.AzureSpatialAnchors.2.4.0.unitypackage](https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/tutorials/mr-learning-asa-02#importing-the-tutorial-assets)
> some HoloLens 2 packages are adopted for multi-user support

## Main functionalities

Presentation
+ Tap to place: place virtual house model on real object
+ Show environment: show nearby street block of house
+ Toggle layer: switch on/off inner/outer structures

Management
+ Time management: show current progress of each building element
+ Budget management: highlight overspend elements

Inspection
+ 1:1 on scale model: show 1:1 scale model
+ Georeference: locate model on site
+ Elevator: use virtual elevator to check different floors of house

## Demo 

[![Demo Video](http://img.youtube.com/vi/EXrDo03un5o/0.jpg)](https://www.youtube.com/watch?app=desktop&v=EXrDo03un5o&feature=youtu.be&ab_channel=HaydenSun)

## Useful links
[MRTK Github](https://github.com/microsoft/MixedRealityToolkit-Unity) <br/>
[Tutorial for spatial anchor related packages](https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/tutorials/mr-learning-asa-02#importing-the-tutorial-assets)

