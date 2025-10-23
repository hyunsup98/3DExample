using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_Player : MonoBehaviour
{
    [field: SerializeField] public UnityEvent onPetCalled { get; private set; } = new UnityEvent();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            CallPet();
        }
    }

    private void CallPet()
    {
        onPetCalled?.Invoke();
    }
}
