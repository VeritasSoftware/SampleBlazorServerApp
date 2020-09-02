# Blazor Server Demo Application

## Robot Pipetter

A robot for pipetting can be operated by the below commands:

* PLACE - Positions the pippeter at the start.
* DROP - Places a drop in the current well. Marked as **X**.
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