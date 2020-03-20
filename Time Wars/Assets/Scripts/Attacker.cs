using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float currentSpeed = 0.6f;
    
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }
    public void MoveToLeft(float walkSpeed)
    {
        currentSpeed = walkSpeed;
    }
}
