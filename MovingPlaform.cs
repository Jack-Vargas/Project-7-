using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    private Transform Goal;
    public float Speed;


    private void Start()
    {
        Goal = PointA;
    }

    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, Goal.transform.position, Speed * Time.deltaTime);

        if (transform.position == PointA.position)
        {
            Goal = PointB;
        }

        if (transform.position == PointB.position)
        {
                Goal = PointA;
        }
    }

    private void OnDrawGizmos()
    {
        if(gameObject != null && PointA != null && PointB != null)
        {
            Gizmos.DrawLine(gameObject.transform.position, PointA.position);
            Gizmos.DrawLine(gameObject.transform.position, PointB.position);
        }
    }
}
