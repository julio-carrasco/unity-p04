using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    int point_score = 0;
    void OnTriggerEnter(Collider collision)
    {
      if (collision.gameObject.CompareTag("Alone"))
        {
          point_score += 5;
          collision.gameObject.SetActive(false);
          Debug.Log("Score: " + point_score);
        } 
        else if (collision.gameObject.CompareTag("Grouped"))
        {
          point_score += 10;
          collision.gameObject.SetActive(false);
          Debug.Log("Score: " + point_score);
        }
    }
}
