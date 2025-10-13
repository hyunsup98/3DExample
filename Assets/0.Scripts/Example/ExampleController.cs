using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            player?.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(player != null)
            {
                Destroy(player);
            }
        }
    }
}
