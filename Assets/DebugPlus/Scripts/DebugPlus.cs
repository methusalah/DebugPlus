using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System;
using UnityEngine.UI;
using System.Text;
using DebugPlusNS;

public static class DebugPlus {
    private const string INDENTATION = "    ";
    private static Stack<BlocTimer> timers = new Stack<BlocTimer>();
    private static Dictionary<string, BlocTimer> blocTimers = new Dictionary<string, BlocTimer>();

    /// <summary>
    /// Draw a solid box with center and size.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="size"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawCube(Vector3 center, Vector3 size) {
        return Draw(new Drawing(() => Gizmos.DrawCube(center, size)));
    }

    /// <summary>
    /// Draw a camera frustum using the currently set Gizmos.matrix for it's location and rotation.
    /// </summary>
    /// <param name="center">The apex of the truncated pyramid.</param>
    /// <param name="fov">Vertical field of view (ie, the angle at the apex in degrees).</param>
    /// <param name="maxRange">Distance of the frustum's far plane.</param>
    /// <param name="minRange">Distance of the frustum's near plane.</param>
    /// <param name="aspect">Width/height ratio.</param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect) {
        return Draw(new Drawing(() => Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect)));
    }

    /// <summary>
    /// Draw a texture in the Scene.
    /// </summary>
    /// <param name="screenRect">The size and position of the texture on the "screen" defined by the XY plane.</param>
    /// <param name="texture">The texture to be displayed.</param>
    /// <param name="leftBorder">Inset from the rectangle's left edge.</param>
    /// <param name="rightBorder">Inset from the rectangle's right edge.</param>
    /// <param name="topBorder">Inset from the rectangle's top edge.</param>
    /// <param name="bottomBorder">Inset from the rectangle's bottom edge.</param>
    /// <param name="mat">An optional material to apply the texture.</param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawGUITexture(Rect screenRect, 
        Texture texture, 
        int leftBorder, 
        int rightBorder, 
        int topBorder, 
        int bottomBorder,
        Material mat) {
        return Draw(new Drawing(() => Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat)));
    }

    /// <summary>
    /// Draw an icon at a position in the Scene view.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="name"></param>
    /// <param name="allowScaling"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawIcon(Vector3 center, string name, bool allowScaling) {
        return Draw(new Drawing(() => Gizmos.DrawIcon(center, name, allowScaling)));
    }

    /// <summary>
    /// Draws a line starting at from towards to.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawLine(Vector3 start, Vector3 end) {
        return Draw(new Drawing(() => Gizmos.DrawLine(start, end)));
    }

    /// <summary>
    /// Draws a mesh.
    /// </summary>
    /// <param name="mesh">Mesh to draw as a gizmo.</param>
    /// <param name="submeshIndex">Submesh to draw (default is -1, which draws whole mesh).</param>
    /// <param name="position">Position (default is zero).</param>
    /// <param name="rotation">Rotation (default is no rotation).</param>
    /// <param name="scale">Scale (default is no scale).</param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale) {
        return Draw(new Drawing(() => Gizmos.DrawMesh(mesh, submeshIndex, position, rotation, scale)));
    }

    /// <summary>
    /// Draws a ray starting at from to from + direction.
    /// </summary>
    /// <param name="from"></param>
    /// <param name="direction"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawRay(Vector3 from, Vector3 direction) {
        return Draw(new Drawing(() => Gizmos.DrawRay(from, direction)));
    }

    /// <summary>
    /// Draws a ray starting at from to from + direction.
    /// </summary>
    /// <param name="ray"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawRay(Ray ray) {
        return Draw(new Drawing(() => Gizmos.DrawRay(ray)));
    }

    /// <summary>
    /// Draws a solid sphere with center and radius.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawSphere(Vector3 center, float radius) {
        return Draw(new Drawing(() => Gizmos.DrawSphere(center, radius)));
    }

    /// <summary>
    /// Draw a wireframe box with center and size.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="size"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawWireCube(Vector3 center, Vector3 size) {
        return Draw(new Drawing(() => Gizmos.DrawWireCube(center, size)));
    }

    /// <summary>
    /// Draws wireframe a mesh.
    /// </summary>
    /// <param name="mesh">Mesh to draw as a gizmo.</param>
    /// <param name="submeshIndex">Submesh to draw (default is -1, which draws whole mesh).</param>
    /// <param name="position">Position (default is zero).</param>
    /// <param name="rotation">Rotation (default is no rotation).</param>
    /// <param name="scale">Scale (default is no scale).</param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawWireMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale) {
        return Draw(new Drawing(() => Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation, scale)));
    }

    /// <summary>
    /// Draws a wireframe sphere with center and radius.
    /// </summary>
    /// <param name="center"></param>
    /// <param name="radius"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing DrawWireSphere(Vector3 center, float radius) {
        return Draw(new Drawing(() => Gizmos.DrawWireSphere(center, radius)));
    }

    /// <summary>
    /// Draws a custom drawing.
    /// </summary>
    /// <param name="drawing">A custom drawing to draw.</param>
    /// <returns>The fluent object to add parameters.</returns>
    public static Drawing Draw(Drawing drawing) {
#if UNITY_EDITOR
        GizmoDrawer.Draw(drawing);
#endif
        return drawing;
    }

    /// <summary>
    /// Draws text directly on the screen.
    /// Returns the <see cref="DebugPlusNS.LogEntry"/> to change drawing color and duration.
    /// </summary>
    /// <param name="text"></param>
    /// <returns>The fluent object to add parameters.</returns>
    public static LogEntry LogOnScreen(string text) {
        var res = new LogEntry(text);
#if UNITY_EDITOR
        LogDrawer.Log(res);
#endif
        return res;
    }

    /// <summary>
    /// Returns a multiline string presenting the time spent in each timed bloc of code.
    /// If a single bloc has been called from different code paths, times are dispatched between paths.
    /// </summary>
    /// <returns>The multiline report.</returns>
    public static string GetChronometerReport() {
        StringBuilder sb = new StringBuilder("Time spent in measured blocs: " + Environment.NewLine);
        foreach (var label in blocTimers.Keys) {
            BlocTimer timer = blocTimers[label];
            sb.Append(" " + timer.label + " : " + timer.Duration + " ms");
            if (timer.showAverage) {
                sb.Append(" (" + timer.DurationPerCall + " per call)");
            }
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Reset all timers and delete cumulated times.
    /// </summary>
    public static void ResetChronometer() {
        blocTimers = new Dictionary<string, BlocTimer>();
    }

    /// <summary>
    /// Starts the timer for this bloc of code.
    /// Each timer must be stopped with <see cref="StopCurrentBloc"/> method. Note that you can only stop the last started timer.
    /// </summary>
    /// <param name="showAverage">If true, the average time per call will be shown for this bloc of code in the report.</param>
    /// <param name="arg">An optionnal label to use in addition of the calling method name. Convenient if you need to time more than one bloc of code in a single method body.</param>
    public static void StartChronometer(string arg = "", bool showAverage = false, bool ignoreStackTrace = false) {
        string callTrace = "", indentation = "";
        foreach (var timer in timers) {
            indentation += INDENTATION;
            callTrace += timer.label;
        }
        string label = indentation;
        if (!ignoreStackTrace) {
            var callingMethod = new System.Diagnostics.StackFrame(1).GetMethod();

            string className = callingMethod != null ? callingMethod.ReflectedType.Name : "UnknowClass";
            string methodName = callingMethod != null ? callingMethod.Name : "UnknowMethod";
            label += className + "." + methodName;
        }
        if (!string.IsNullOrEmpty(arg)) {
            label += "." + arg;
        }
        if (!blocTimers.ContainsKey(callTrace + label)) {
            blocTimers[callTrace + label] = new BlocTimer(label, showAverage);
        }
        blocTimers[callTrace + label].Start();
        timers.Push(blocTimers[callTrace + label]);
    }

    /// <summary>
    /// Stops the last started timer.
    /// </summary>
    public static void StopCurrentChronometer() {
        timers.Pop().Stop();
    }

    private class BlocTimer
    {
        private DateTime cumulatedTime = DateTime.MinValue, startTime;
        private int startCount;

        public string label;
        public bool showAverage;

        public BlocTimer(string label, bool showAverage) {
            this.label = label;
            this.showAverage = showAverage;
        }

        public void Start() {
            startTime = DateTime.Now;
            startCount++;
        }

        public void Stop() {
            cumulatedTime += DateTime.Now - startTime;
        }

        public long Duration { get { return cumulatedTime.Ticks / TimeSpan.TicksPerMillisecond; } }
        public long DurationPerCall { get { return cumulatedTime.Ticks / startCount / TimeSpan.TicksPerMillisecond; } }

        public void Reset() {
            cumulatedTime = DateTime.MinValue;
            startTime = DateTime.MinValue;
        }
    }

}
