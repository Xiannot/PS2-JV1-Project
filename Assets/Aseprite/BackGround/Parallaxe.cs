using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public static Parallax instance;
    public Camera cam;
    public Transform Subject;

    Vector2 startPosition;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float DistanceFromSubject => transform.position.z - Subject.position.z;

    float ClippingPlane => (cam.transform.position.z + (DistanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float ParallaxFactor => Mathf.Abs(DistanceFromSubject) / ClippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = startPosition + travel * ParallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);

    }






}