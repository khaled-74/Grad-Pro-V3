using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respwan : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respwanPoint;
      private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Player"))
        {
            player.transform.position = respwanPoint.transform.position;
Physics.SyncTransforms();
        }
    }
}
