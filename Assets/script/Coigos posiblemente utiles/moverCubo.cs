using System;
using UnityEngine;
using static OVRInput;
public class moverCubo : MonoBehaviour
{
    [SerializeField] private float speed = 1.04f;
    [SerializeField] private  Controller controller;
    [SerializeField] private Renderer cubeRenderer;
    
    void Update()
    {
        Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        transform.Translate(new Vector3(axis.x, 0, axis.y) * speed * Time.deltaTime);
        if(OVRInput.Get(OVRInput.Button.One)) transform.Translate(Vector3.up * speed * Time.deltaTime); //en lugar de touch se puede usar button
        if (OVRInput.Get(OVRInput.Button.Two)) transform.Translate(Vector3.down * speed * Time.deltaTime);
        float triggerPress = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        cubeRenderer.material.color = Color.Lerp(Color.red, Color.green, triggerPress);

        Debug.Log(triggerPress);
        Debug.Log($"Eje x: {axis.x}, Eje y: {axis.y}");

        
    }
}