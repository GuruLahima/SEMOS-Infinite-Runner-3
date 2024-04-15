using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    [Tooltip("How far to the left or right will cat move?")]
    [SerializeField] private float horizontalMovementDelta;


    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        // initialize start position
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 targetPos = startPos - (Vector3.right * horizontalMovementDelta);
            // teleportation code
            // transform.position = targetPos;
            // animation code
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        }

    }
}
