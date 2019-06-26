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
    public static Drawing DrawCube(Vector3 center, Vector3 size) {
        return Draw(new Drawing(() => Gizmos.DrawCube(center, size)));
    }

    public static Drawing DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect) {
        return Draw(new Drawing(() => Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect)));
    }

    public static Drawing DrawGUITexture(Rect screenRect, 
        Texture texture, 
        int leftBorder, 
        int rightBorder, 
        int topBorder, 
        int bottomBorder,
        Material mat) {
        return Draw(new Drawing(() => Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat)));
    }

    public static Drawing DrawIcon(Vector3 center, string name, bool allowScaling) {
        return Draw(new Drawing(() => Gizmos.DrawIcon(center, name, allowScaling)));
    }

    public static Drawing DrawLine(Vector3 start, Vector3 end) {
        return Draw(new Drawing(() => Gizmos.DrawLine(start, end)));
    }

    public static Drawing DrawMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale) {
        return Draw(new Drawing(() => Gizmos.DrawMesh(mesh, submeshIndex, position, rotation, scale)));
    }

    public static Drawing DrawRay(Vector3 from, Vector3 direction) {
        return Draw(new Drawing(() => Gizmos.DrawRay(from, direction)));
    }

    public static Drawing DrawRay(Ray ray) {
        return Draw(new Drawing(() => Gizmos.DrawRay(ray)));
    }

    public static Drawing DrawSphere(Vector3 center, float radius) {
        return Draw(new Drawing(() => Gizmos.DrawSphere(center, radius)));
    }

    public static Drawing DrawWireCube(Vector3 center, Vector3 size) {
        return Draw(new Drawing(() => Gizmos.DrawWireCube(center, size)));
    }

    public static Drawing DrawWireMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale) {
        return Draw(new Drawing(() => Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation, scale)));
    }

    public static Drawing DrawWireSphere(Vector3 center, float radius) {
        return Draw(new Drawing(() => Gizmos.DrawWireSphere(center, radius)));
    }

    public static Drawing Draw(Drawing drawing) {
        GizmoDrawer.Draw(drawing);
        return drawing;
    }

    public static LogEntry LogOnScreen(string text) {
        var res = new LogEntry(text);
        LogDrawer.Log(res);
        return res;
    }
}
