using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetDrawer : MonoBehaviour
{
    public float radius = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
