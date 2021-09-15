using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Target;
    private Vector3 offset;
    private Vector3 move;
    private float transition = 0.0f;
    private float animationTime = 3.0f;
    public Vector3 animationOffset = new Vector3(0, 5, 5);

    
    // Start is called before the first frame update
    void Start()
    {
       Target =  GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        move = Target.position + offset;
        move.x = 0; //x axis
        move.y = Mathf.Clamp(move.y, 3, 5);//y axis

        if (transition > 2)
        {
            transform.position = move;
        }
        else
        {
            transform.position = Vector3.Lerp(move + animationOffset, move, transition);
            transition += Time.deltaTime * 1 / animationTime;
            transform.LookAt(Target.position + Vector3.up);
        }
    }
}
