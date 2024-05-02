using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 endPosition = new Vector3(0, 0, 0);
    public float duration = 4f;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float movePercent = elapsedTime / duration;

        transform.position = Vector3.Lerp(startPosition, endPosition, movePercent);
    }
}
