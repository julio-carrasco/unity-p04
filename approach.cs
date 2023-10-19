using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Approach : MonoBehaviour
{
    GameObject cube;
    GameObject cylinder;
    public float jumpForce = 10.0f;
    public float jumpInterval = 1.0f;

    private bool isCubeNearCylinder = false;
    private float lastJumpTime = 0;

    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube");
        cylinder = GameObject.FindGameObjectWithTag("Cylinder");
    }

    void Update()
    {
        
        float distance = Vector3.Distance(cube.transform.position, cylinder.transform.position);
        float jumpThreshold = 2.0f;
        if (distance < jumpThreshold)
        {
            isCubeNearCylinder = true;
        }
        else
        {
            isCubeNearCylinder = false;
        }
        if (isCubeNearCylinder && Time.time - lastJumpTime >= jumpInterval)
        {
            JumpAloneSpheres();
            lastJumpTime = Time.time;
        }
    }

    void JumpAloneSpheres()
    {
        GameObject[] aloneSpheres = GameObject.FindGameObjectsWithTag("Alone");

        foreach (GameObject sphere in aloneSpheres)
        {
            Rigidbody sphereRigidbody = sphere.GetComponent<Rigidbody>();

            if (sphereRigidbody != null)
            {
                sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
