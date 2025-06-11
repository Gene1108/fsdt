using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFirstPerson : MonoBehaviour
{
    [SerializeField] 
    float speed = 10f;

    [SerializeField] 
    float rotationSpeed = 10f;

    [SerializeField] 
    RandomSoundManager footsteps;

    private float lastFootstepPlayed = 0;

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(hAxis, y: 0, vAxis) * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotationSpeed * Time.deltaTime); 
        } else if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime);
        }

        lastFootstepPlayed += Time.deltaTime; 
        
        if (hAxis != 0 || vAxis != 0)
        {
           if(lastFootstepPlayed > 3f / speed)
            {
               footsteps.PlayRandomSound();
               lastFootstepPlayed = 0;
            }
            
        }
        
    }
}
