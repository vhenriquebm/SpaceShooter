using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;

    private float spriteHeight;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * parallaxSpeed * Time.deltaTime);

        if (transform.position.y < startPosition.y - spriteHeight)
        {
            transform.position = startPosition;
        }
    }
}
