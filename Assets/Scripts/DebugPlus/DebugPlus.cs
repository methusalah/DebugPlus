using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using System;
using UnityEngine.UI;
using System.Text;
using DebugPlusAsset;

public static class DebugPlus {
    public static void DrawCube(Vector3 center, Vector3 size, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawCube(center, size), color, duration, matrix);
    }

    public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawFrustum(center, fov, maxRange, minRange, aspect), color, duration, matrix);
    }

    public static void DrawGUITexture(Rect screenRect, 
        Texture texture, 
        int leftBorder, 
        int rightBorder, 
        int topBorder, 
        int bottomBorder,
        Material mat,
        Color color, 
        float duration = 0, 
        Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawGUITexture(screenRect, texture, leftBorder, rightBorder, topBorder, bottomBorder, mat), color, duration, matrix);
    }

    public static void DrawIcon(Vector3 center, string name, bool allowScaling, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawIcon(center, name, allowScaling), color, duration, matrix);
    }

    public static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawLine(start, end), color, duration, matrix);
    }

    public static void DrawMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale,
        Color color,
        float duration = 0,
        Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawMesh(mesh, submeshIndex, position, rotation, scale), color, duration, matrix);
    }

    public static void DrawRay(Vector3 from, Vector3 direction, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawRay(from, direction), color, duration, matrix);
    }

    public static void DrawRay(Ray ray, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawRay(ray), color, duration, matrix);
    }

    public static void DrawSphere(Vector3 center, float radius, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawSphere(center, radius), color, duration, matrix);
    }

    public static void DrawWireCube(Vector3 center, Vector3 size, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawWireCube(center, size), color, duration, matrix);
    }

    public static void DrawWireMesh(Mesh mesh,
        int submeshIndex,
        Vector3 position,
        Quaternion rotation,
        Vector3 scale,
        Color color,
        float duration = 0,
        Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawWireMesh(mesh, submeshIndex, position, rotation, scale), color, duration, matrix);
    }

    public static void DrawWireSphere(Vector3 center, float radius, Color color, float duration = 0, Matrix4x4 matrix = default) {
        Draw(() => Gizmos.DrawWireSphere(center, radius), color, duration, matrix);
    }

    private static void Draw(Action action, Color color, float duration = 0, Matrix4x4 matrix = default) {
        GizmoDrawer.Draw(new Drawing(action, color, duration, matrix));
    }

    public static void LogOnScreen(string text, Color color, float duration) {
        LogDrawer.Log(new LogEntry(text, color, duration));
    }
}
