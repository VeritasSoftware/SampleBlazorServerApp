# Blazor Server Demo Application

[**Blazor Web Assembly Demo Application**](https://github.com/VeritasSoftware/SampleBlazorWebAssemblyApp)

## Robot Pipetter

A robot for pipetting can be operated by the below commands:

* PLACE - Positions the pipetter at the start.
* DROP - Places a drop in the current well. The pipette marks the well with a drop.
* MOVE - Moves the pipetter one position North, South, East, West.

### Sample

```
PLACE 2,2
DROP
MOVE N
DROP
MOVE E
```

These commands will move the robot pipetter as shown below:

![Screenshot](https://github.com/VeritasSoftware/SampleBlazorServerApp/blob/master/Screenshot.JPG)

[Try it out!](https://robotpipetting-sample-blazorserver-app.azurewebsites.net/)