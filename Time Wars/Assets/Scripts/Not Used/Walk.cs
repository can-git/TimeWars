using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] float currentSpeed = 0.6f;

    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }
    public void MoveTo(float walkSpeed)
    {
        currentSpeed = walkSpeed;
    }
}
