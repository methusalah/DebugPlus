![please report broken links](https://i.postimg.cc/PqxsTgRG/demo.jpg)

**<a href="https://twitter.com/dumas181" target="_blank">Follow me on twitter !</a>**

# DebugPlus
You already like Debug.DrawLine and Log? You will love DebugPlus' DrawMesh, DrawSphere, LogOnScreen...

DebugPlus brings features that are missing in Unity Debug, allowing to draw gizmos and logs at run time, from anywhere in your code with a single line. Specify optional color, duration and matrix in a fluent way.

This free and open-source asset is in beta, you are welcome to report any issue in the github issue page. It will be released on the asset store when beta testing is done.

## Gizmos
Gizmos are powerfull for debugging, but Unity Debug only offers Line and Ray. DebugPlus adds all built-in gizmos:
- DrawCube
- DrawSphere
- DrawMesh
- DrawIcon
- etc.

Examples:

    DebugPlus.DrawWireSphere(transform.position, 1).Color(Color.blue);
    DebugPlus.DrawCube(transform.position, new Vector3(1, 2, 1)).Color(Color.red).Duration(10).Matrix(m);



## Log on screen
Console logs are sweet, but sometimes it's more convienent to write things directly on the screen. Inspired by Unreal Engine 4, DebugPlus LogOnScreen let you write your logs with color and duration on the top left corner of your GUI.

Examples:

    DebugPlus.LogOnScreen("motion " + debugMotion).Color(Color.green);
    DebugPlus.LogOnScreen("An excpetion occured during played update : " + e.Message).Color(Color.red).Duration(10);
    
Note : on the first call to LogOnScreen, DebugPlus will create a special canvas that could mess with your existing GUI. Please report issues.
    
## Planned features
DrawArrow, DrawDisc, DrawText at a world position... I'm open to suggestions !
