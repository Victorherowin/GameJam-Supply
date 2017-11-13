using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawn : MonoBehaviour {
    public static ElementSpawn Instance;
    public GameObject[] ElementSpawnPoints;
    public Element[] Elements;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            throw new UnityException("ElementSpawn.Instance!=null");
    }

    public void SpawnElement(GameObject element_prefab)
    {
        GameObject spawn_point= ElementSpawnPoints[UnityEngine.Random.Range(0, ElementSpawnPoints.Length)];
        var obj_transform=Instantiate(element_prefab, spawn_point.transform).transform;
        obj_transform.localPosition = Vector3.zero;
        obj_transform.localRotation = Quaternion.identity;
    }

    public void SpawnElementFromType(Type element_type)
    {
        foreach(var ele in Elements)
            if(ele.GetComponent<Element>().GetType()==element_type)
                SpawnElement(ele.gameObject);
    }

    float time = 0.0f;
    private void FixedUpdate()
    {
        if (time > 1.0f)
        {
            time = 0.0f;
            SpawnElement(Elements[UnityEngine.Random.Range(0, Elements.Length)].gameObject);
        }
        time += Time.deltaTime;
    }
}
