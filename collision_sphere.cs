using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSphere : MonoBehaviour
{
    private GameObject[] aloneSpheres;
    private GameObject cylinder;
    private bool isAloneColliding = false;
    private bool isGroupColliding = false;

    void Start()
    {
        aloneSpheres = GameObject.FindGameObjectsWithTag("Alone");
        cylinder = GameObject.FindGameObjectWithTag("Cylinder");
    }

    void Update()
    {
        if (isAloneColliding)
        {
            // Move objects in another group.
            MoveObjects();
        }
        if(isGroupColliding) 
        {
            GrowObjects();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Alone"))
        {
            isAloneColliding = true;
        } 
        else 
        {
            isGroupColliding = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (!collision.gameObject.CompareTag("Alone"))
        {
            isAloneColliding = false;
        } 
        else 
        {
            isGroupColliding = false;
        }
    }

    void GrowObjects()
    {
        float growthRate = 0.001f;
        float maxSize = 5.0f;
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Grouped");
        foreach (GameObject obj in taggedObjects)
        {
            Vector3 currentScale = obj.transform.localScale;
            currentScale += new Vector3(growthRate, growthRate, growthRate);
            currentScale = Vector3.Min(currentScale, new Vector3(maxSize, maxSize, maxSize));
            obj.transform.localScale = currentScale;
        }
    }

    void MoveObjects()
    {
        if (aloneSpheres != null && cylinder != null)
        {
            foreach (GameObject child in aloneSpheres)
            {
                // Calculate the direction from the sphere to the cylinder.
                Vector3 direction = (cylinder.transform.position - child.transform.position).normalized;

                // Set the speed at which the spheres move towards the cylinder.
                float moveSpeed = 2.0f;

                // Move the spheres towards the cylinder.
                child.transform.position = Vector3.MoveTowards(child.transform.position, cylinder.transform.position, moveSpeed * Time.deltaTime);
            }
        }
    }
}
