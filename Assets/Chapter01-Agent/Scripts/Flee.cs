using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 逃跑
/// </summary>
public class Flee : AgentBehaviour
{
    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        steering.linear = transform.position - target.transform.position;
        steering.linear.Normalize();
        steering.linear = steering.linear * agent.maxAccel;
        return steering;
    }
}
