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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricProbe : MonoBehaviour
{

    [System.Serializable]
    public struct Island
    {
        public Vector3[] vertices;
    }

    [SerializeField]
    private Island[] islands;
    public Island[] Islands
    {
        get
        {
            return islands;
        }
        set
        {
            if (islands == value)
                return;

            islands = value;
            UpdateMesh();
        }
    }

    [SerializeField, Header("Options")]
    private Light lightSource;
    public Light LightSource
    {
        get
        {
            return lightSource;
        }
        set
        {
            if (lightSource == value)
                return;

            lightSource = value;
            UpdateMesh();
        }
    }

    [SerializeField, Tooltip("Volumetric probe will be calculated only once and on validation")]
    private bool isStatic;
    public bool IsStatic
    {
        get
        {
            return isStatic;
        }
        set
        {
            if (isStatic == value)
                return;

            isStatic = value;
            UpdateMesh();
        }
    }

    [SerializeField, Header("Physics"), Tooltip("Use Raycast to calculate volume")]
    private bool usePhysics;
    public bool UsePhysics
    {
        get
        {
            return usePhysics;
        }
        set
        {
            if (usePhysics == value)
                return;

            usePhysics = value;
            UpdateMesh();
        }
    }

    [SerializeField]
    private float rayDist;
    public float RayDist
    {
        get
        {
            return rayDist;
        }
        set
        {
            if (rayDist == value)
                return;

            rayDist = value;
            UpdateMesh();
        }
    }

    [SerializeField]
    private LayerMask layerMask;
    public LayerMask LayerMask
    {
        get
        {
            return layerMask;
        }
        set
        {
            if (layerMask == value)
                return;

            layerMask = value;
            UpdateMesh();
        }
    }

    [SerializeField, Header("Appearence")]
    private Material material;
    [SerializeField]
    private Color colorMultiplier = Color.white;
    public Color ColorMultiplier
    {
        get
        {
            return colorMultiplier;
        }
        set
        {
            if (colorMultiplier == value)
                return;

            colorMultiplier = value;
            UpdateMesh();
        }
    }

    [SerializeField]
    private ParticleSystem particles;

    private bool initialized;
    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Vector3 oldLightPos;
    private Vector3 oldLightRot;
    private Vector3 oldPos;
    private Vector3 oldRot;

    private void Awake()
    {
        //Creating new MeshFilter and MeshRenderer to the object
        mesh = new Mesh();
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;

        //Calculate mesh
        UpdateMesh();

        //if particles is assigned throw meshrenderer to it
        if (particles)
        {
            ParticleSystem.ShapeModule pShape = particles.shape;
            pShape.shapeType = ParticleSystemShapeType.MeshRenderer;
            pShape.meshRenderer = meshRenderer;
            particles.Clear();
            particles.Simulate(particles.main.duration);
            particles.Play();
        }

        initialized = true;
    }

    private void OnValidate()
    {
        //recalculate mesh when component values is changed
        if (!initialized)
            return;

        UpdateMesh();
    }

    private void Update()
    {
        //dont check for changes if isStatic
        if (isStatic)
            return;

        //if the position/rotation of the object or light has changed then recalculate mesh
        if (oldLightPos != lightSource.transform.position || oldLightRot != lightSource.transform.eulerAngles || oldPos != transform.position || oldRot != transform.eulerAngles)
            UpdateMesh();
    }

    /// <summary>
    /// Update volumetric probe mesh
    /// </summary>
    public void UpdateMesh()
    {
        //stop if lightsource is not assigned
        if (!lightSource)
            throw new System.Exception("Light source is not assigned");

        //update position/rotation
        oldLightPos = lightSource.transform.position;
        oldLightRot = lightSource.transform.eulerAngles;
        oldPos = transform.position;
        oldRot = transform.eulerAngles;

        //create lists for verices, tris, vertices colors and clear mesh
        List<Vector3> verts = new List<Vector3>();
        List<int> tris = new List<int>();
        List<Color> vertColor = new List<Color>();
        mesh.Clear();

        //main calculation algorithm
        int addIndex = 0;
        for (int s = 0; s < islands.Length; s++)
        {
            verts.AddRange(islands[s].vertices);
            for (int i = 0; i < islands[s].vertices.Length; i++)
            {
                vertColor.Add(lightSource.color * colorMultiplier);
            }

            if (s > 0)
                addIndex += islands[s - 1].vertices.Length * 2;
            for (int i = 0; i < islands[s].vertices.Length; i++)
            {
                if (i == 0)
                {
                    tris.Add(i + addIndex);
                    tris.Add(islands[s].vertices.Length + 1 + addIndex);
                    tris.Add(islands[s].vertices.Length + addIndex);

                    tris.Add(i + addIndex);
                    tris.Add(i + 1 + addIndex);
                    tris.Add(islands[s].vertices.Length + 1 + addIndex);
                }
                else if (i == islands[s].vertices.Length - 1)
                {
                    tris.Add(i + addIndex);
                    tris.Add(islands[s].vertices.Length + addIndex);
                    tris.Add(islands[s].vertices.Length + i + addIndex);

                    tris.Add(i + addIndex);
                    tris.Add(0 + addIndex);
                    tris.Add(islands[s].vertices.Length + addIndex);
                }
                else
                {
                    tris.Add(i + addIndex);
                    tris.Add(islands[s].vertices.Length + i + 1 + addIndex);
                    tris.Add(islands[s].vertices.Length + i + addIndex);

                    tris.Add(i + addIndex);
                    tris.Add(i + 1 + addIndex);
                    tris.Add(islands[s].vertices.Length + i + 1 + addIndex);
                }

                Vector3 worldPos = transform.TransformPoint(islands[s].vertices[i]);
                Color color = lightSource.color;
                color.a = 0;
                RaycastHit hit;
                Vector3 dir;
                switch (lightSource.type)
                {
                    case LightType.Directional:
                        if (usePhysics && Physics.Raycast(new Ray(worldPos, lightSource.transform.forward), out hit, rayDist, layerMask))
                        {
                            verts.Add(transform.InverseTransformPoint(hit.point));
                            color.a = 1f - hit.distance / rayDist;
                        }
                        else
                        {
                            verts.Add(islands[s].vertices[i] + lightSource.transform.forward * rayDist);
                        }
                        break;

                    case LightType.Spot:
                        float offset = lightSource.spotAngle * lightSource.range / 90f;
                        Vector3 origin = worldPos;
                        Vector3 pointDir = (origin - lightSource.transform.position).normalized;
                        Vector3 target = lightSource.transform.position + (lightSource.transform.forward) * lightSource.range + pointDir * offset;
                        dir = (target - origin).normalized;
                        if (usePhysics && Physics.Raycast(new Ray(worldPos, dir), out hit, rayDist, layerMask))
                        {
                            verts.Add(transform.InverseTransformPoint(hit.point));
                            color.a = 1f - hit.distance / rayDist;
                        }
                        else
                        {
                            verts.Add(islands[s].vertices[i] + dir * rayDist);
                        }
                        break;

                    default:
                        dir = (worldPos - lightSource.transform.position).normalized;
                        if (usePhysics && Physics.Raycast(new Ray(worldPos, dir), out hit, rayDist, layerMask))
                        {
                            verts.Add(transform.InverseTransformPoint(hit.point));
                            color.a = 1f - hit.distance / rayDist;
                        }
                        else
                        {
                            verts.Add(transform.InverseTransformPoint(worldPos + dir * rayDist));
                        }
                        break;
                }
                vertColor.Add(color * colorMultiplier);
            }
        }

        //update mesh
        mesh.SetVertices(verts);
        mesh.SetTriangles(tris, 0);
        mesh.RecalculateNormals();

        mesh.SetColors(vertColor);
    }

}
