using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private UnityAction<int> unityAction;
    private Action cSharpAction;
    [SerializeField] private Button button;

    [SerializeField] private LayerMask layerMask;

    private void Start()
    {

    }
}