using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SpawnGrenade : MonoBehaviour
{
    [SerializeField] private GameObject Grenade;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

    }

    private void SpawnAtMousePos()
    {
        if (Input.GetMouseButtonDown(0))
        {
            InputDevice mouse = Mouse.current;
            Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(Grenade, hit.point, Quaternion.identity);
            }
        }
    }

}
