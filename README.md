# README #

### What is this repository for? ###

This is a .net core 3.1 console app to calculate the development site metrics based on configurations 

### Project structure ###

1- SiteCalculator Console App

2- SiteCalculator.Services Business logic 

3- SiteCalculator.Services.UnitTests unit tests mainly for the business logic


### How to build and run ###

You will have to install .net core 3.1 runtime which can be downloaded from 

    https://dotnet.microsoft.com/download/dotnet-core/3.1 to run the project.


## To build run and test the project you need to to the following: ##


1- clone the repo to your local environment and cd to repository directory

## Build: ##
2- dotnet build SiteCalculator.sln

## Run unit tests: ###
3 - dotnet test

## Run Project ##
4- dotnet run --project SiteCalculator/SiteCalculator.csproj


You can also run the SiteCalculator and pass a json file including an array of site configuration json object 

Alternatively, open SiteCalculator.Api.sln using visual studio 2019 or Intelij Rider then Build and run it.


5- dotnet run --project SiteCalculator/SiteCalculator.csproj <JsonFullPathFileName>




