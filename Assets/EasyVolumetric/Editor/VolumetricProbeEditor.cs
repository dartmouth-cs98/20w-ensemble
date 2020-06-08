/*Easy Volumetric
Copyright(C) 2020 NorthLab

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.If not, see<https://www.gnu.org/licenses/>.*/

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(VolumetricProbe))]
public class VolumetricProbeEditor : Editor
{

    private static Color[] islandColors = {Color.green, Color.yellow, Color.red, Color.blue, Color.magenta, Color.cyan, Color.white};

    private SerializedProperty islands;

    private SerializedProperty lightSource;
    private SerializedProperty isStatic;

    private SerializedProperty usePhysics;
    private SerializedProperty rayDist;
    private SerializedProperty layerMask;

    private SerializedProperty material;
    private SerializedProperty colorMultiplier;
    private SerializedProperty particles;

    private VolumetricProbe script;
    private bool editMode;
    private bool islandsFoldOut;
    private List<bool> islandFoldOut;

    private void OnEnable()
    {
        islands = serializedObject.FindProperty("islands");
        lightSource = serializedObject.FindProperty("lightSource");
        isStatic = serializedObject.FindProperty("isStatic");
        usePhysics = serializedObject.FindProperty("usePhysics");
        rayDist = serializedObject.FindProperty("rayDist");
        layerMask = serializedObject.FindProperty("layerMask");
        material = serializedObject.FindProperty("material");
        colorMultiplier = serializedObject.FindProperty("colorMultiplier");
        particles = serializedObject.FindProperty("particles");

        islandFoldOut = new List<bool>();
        for (int i = 0; i < islands.arraySize; i++)
            islandFoldOut.Add(true);

        script = (VolumetricProbe)target;
    }

    private void OnDisable()
    {
        Tools.hidden = false;
    }

    private Color GetIslandColor(int index)
    {
        while (index >= islandColors.Length)
        {
            index -= islandColors.Length;
        }

        return islandColors[index];
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //foldoutstyle
        GUIStyle foldoutStyle = new GUIStyle(EditorStyles.foldout);
        foldoutStyle.fontStyle = FontStyle.Bold;

        EditorGUILayout.BeginVertical(EditorStyles.helpBox);
        EditorGUI.indentLevel++;
        islandsFoldOut = EditorGUILayout.Foldout(islandsFoldOut, "Islands", foldoutStyle);
        EditorGUI.indentLevel--;

        if (islandsFoldOut)
        {
            for (int i = 0; i < islands.arraySize; i++)
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                EditorGUILayout.BeginHorizontal();
                EditorGUI.indentLevel++;
                islandFoldOut[i] = EditorGUILayout.Foldout(islandFoldOut[i], "Island " + i, foldoutStyle);
                EditorGUI.DrawRect(EditorGUILayout.GetControlRect(GUILayout.MaxWidth(18)), GetIslandColor(i));
                if (GUILayout.Button("Delete"))
                {
                    islands.DeleteArrayElementAtIndex(i);
                    break;
                }
                EditorGUI.indentLevel--;
                EditorGUILayout.EndHorizontal();

                float oldWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 80;
                if (islandFoldOut[i])
                {
                    EditorGUILayout.Space();
                    EditorGUI.indentLevel++;
                    for (int j = 0; j < islands.GetArrayElementAtIndex(i).FindPropertyRelative("vertices").arraySize; j++)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PropertyField(islands.GetArrayElementAtIndex(i).FindPropertyRelative("vertices").GetArrayElementAtIndex(j), new GUIContent("Vertex " + j));
                        if (GUILayout.Button("Delete"))
                        {
                            islands.GetArrayElementAtIndex(i).FindPropertyRelative("vertices").DeleteArrayElementAtIndex(j);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    if (GUILayout.Button("Add vertex"))
                    {
                        islands.GetArrayElementAtIndex(i).FindPropertyRelative("vertices").InsertArrayElementAtIndex(islands.GetArrayElementAtIndex(i).FindPropertyRelative("vertices").arraySize);
                    }
                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.EndVertical();
                EditorGUIUtility.labelWidth = oldWidth;
            }

            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add island"))
            {
                islands.InsertArrayElementAtIndex(islands.arraySize);
                islandFoldOut.Add(true);
            }
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();

        editMode = EditorGUILayout.Toggle("Edit mode", editMode);
        if (!islandsFoldOut && editMode)
            EditorGUILayout.HelpBox("Expand Islands to edit vertices", MessageType.Warning);
        if (editMode)
            EditorGUILayout.HelpBox("Hold shift to move islands", MessageType.Info);

        EditorGUILayout.PropertyField(lightSource);
        EditorGUILayout.PropertyField(isStatic);

        EditorGUILayout.PropertyField(usePhysics);
        EditorGUILayout.PropertyField(rayDist);
        EditorGUILayout.PropertyField(layerMask);

        EditorGUILayout.PropertyField(material);
        EditorGUILayout.PropertyField(colorMultiplier);
        EditorGUILayout.PropertyField(particles);

        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        Tools.hidden = editMode;

        if (Application.isPlaying)
            return;

        if (!islandsFoldOut)
            return;

        SceneView.RepaintAll();

        for (int i = 0; i < script.Islands.Length; i++)
        {
            if (!islandFoldOut[i])
                continue;

            VolumetricProbe.Island island = script.Islands[i];
            Handles.color = GetIslandColor(i);
            for (int j = 0; j < island.vertices.Length; j++)
            {
                Vector3 worldPos = script.transform.TransformPoint(island.vertices[j]);
                float size = HandleUtility.GetHandleSize(worldPos) * 0.05f;
                Handles.DrawWireDisc(worldPos, Vector3.up, size);
                Handles.DrawWireDisc(worldPos, Vector3.right, size);
                Handles.DrawWireDisc(worldPos, Vector3.forward, size);

                if (j < island.vertices.Length - 1)
                    Handles.DrawLine(worldPos, script.transform.TransformPoint(island.vertices[j + 1]));
                else Handles.DrawLine(worldPos, script.transform.TransformPoint(island.vertices[0]));
            }
        }

        if (!editMode)
            return;

        EditorGUI.BeginChangeCheck();

        List<Vector3> vertPos = new List<Vector3>();

        if (Event.current.shift)
        {
            for (int i = 0; i < script.Islands.Length; i++)
            {
                if (!islandFoldOut[i])
                    continue;

                VolumetricProbe.Island island = script.Islands[i];
                Vector3 delta = island.vertices[0] - script.transform.InverseTransformPoint(Handles.PositionHandle(script.transform.TransformPoint(island.vertices[0]), Quaternion.identity));
                for (int j = 0; j < island.vertices.Length; j++)
                {
                    vertPos.Add(island.vertices[j] - delta);
                }
            }
        }
        else
        {
            for (int i = 0; i < script.Islands.Length; i++)
            {
                if (!islandFoldOut[i])
                    continue;

                VolumetricProbe.Island island = script.Islands[i];
                for (int j = 0; j < island.vertices.Length; j++)
                {
                    vertPos.Add(script.transform.InverseTransformPoint(Handles.PositionHandle(script.transform.TransformPoint(island.vertices[j]), Quaternion.identity)));
                }
            }
        }

        if (EditorGUI.EndChangeCheck())
        {
            int v = 0;
            for (int i = 0; i < script.Islands.Length; i++)
            {
                VolumetricProbe.Island island = script.Islands[i];
                for (int j = 0; j < island.vertices.Length; j++)
                {
                    Undo.RecordObject(script, "Changed vertex pos");
                    island.vertices[j] = vertPos[v];
                    v++;
                }
            }
        }
    }

}