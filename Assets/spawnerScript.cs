using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [SerializeField] private Vector3 center = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private float radius = 3;
    private float pi = Mathf.PI;

    private List<GameObject> listGO;

    void Start()
    {
        listGO = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateNewCube();
        CreateNewSphere();
        CreateNewCylinder();
    }

    private void CreateNewCube()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject newCube = Instantiate(Resources.Load("Cube"), Vector3.zero, Quaternion.identity) as GameObject;
            listGO.Add(newCube);
            cerclePlacement(listGO);
        }
    }
    
    private void CreateNewSphere()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject newSphere = Instantiate(Resources.Load("Sphere"), Vector3.zero, Quaternion.identity) as GameObject;
            listGO.Add(newSphere);
            cerclePlacement(listGO);
        }
    }
    
    private void CreateNewCylinder()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject newCylinder = Instantiate(Resources.Load("Cylinder"), Vector3.zero, Quaternion.identity) as GameObject;
            listGO.Add(newCylinder);
            cerclePlacement(listGO);
        }
    }

    private void cerclePlacement(List<GameObject> list)
    {
        int sizeList = list.Count;
        foreach (var element in list)
        {
            float a = center.x + (Mathf.Cos(2 * (pi) / sizeList * list.IndexOf(element)) * radius);
            float b = center.y + (Mathf.Sin(2 * (pi) / sizeList * list.IndexOf(element)) * radius);
            float c = center.z;

            element.transform.position = new Vector3(a, b, c);
        }
    }
}
