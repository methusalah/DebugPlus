# DebugPlus
You already like Debug.DrawLine and Log? You will love DebugPlus' DrawMesh, DrawSphere, LogOnScreen...

DebugPlus brings features that are missing in Unity Debug, allowing to draw gizmos and logs at run time, from anywhere in your code in a single line. Just specify a color, a duration and optionnaly a matrix.

This asset is in beta, you are welcome to report any issue in the github issue page.

## Gizmos
Gizmos are powerfull for debugging, but Unity Debug only offers Line and Ray. DebugPlus adds all built-in gizmos:
- DrawCube
- DrawSphere
- DrawMesh
- DrawIcon
- etc.

Examples:

    DebugPlus.DrawWireSphere(transform.position, 1, Color.blue);
    DebugPlus.DrawCube(transform.position, new Vector3(1, 2, 1), Color.red, duration: 10);



## Log on screen
Console logs are sweet, but sometimes it's more convienent to write things directly on the screen. Inspired by Unreal Engine 4, DebugPlus LogOnScreen let you write your logs with color and duration on the top left corner of your GUI.

Exapmles:

    DebugPlus.LogOnScreen("motion " + debugMotion, Color.green, 0);
    DebugPlus.LogOnScreen("An excpetion occured during played update : " + e.Message, Color.red, 10);
    
Note : on the first call to LogOnScreen, DebugPlus will create a special canvas that could mess with your existing GUI. Please report issues.
    
## Planned features
DrawArrow, DrawDisc, DrawText at a world position... I'm open to suggestions.
