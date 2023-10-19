using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCylinder : MonoBehaviour
{
    public Color colorChangeMaterial = Color.blue; // Assign the material for color change in the Inspector.
    private GameObject[] aloneSpheres;
    private GameObject cylinder;
    private bool isColliding = false;

    void Start()
    {
        aloneSpheres = GameObject.FindGameObjectsWithTag("Alone");
        cylinder = GameObject.FindGameObjectWithTag("Cylinder");
    }

    void Update()
    {
        if (isColliding)
        {
            // Change the color of objects in one group.
            ChangeColor();
            // Move objects in another group.
            MoveObjects();
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cylinder"))
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Cylinder"))
        {
            isColliding = false;
        }
    }

    void ChangeColor()
    {
        Renderer[] renderers = GameObject.FindObjectsOfType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            if (renderer.CompareTag("Grouped"))
            {
                renderer.material.color = colorChangeMaterial;
            }
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
