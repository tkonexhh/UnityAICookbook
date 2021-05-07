using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float maxSpeed = 5;//最大速度
    public float maxAccel = 1;//最大加速度
    public float orientation;//旋转角度
    public float rotation;//旋转速度
    public Vector3 velocity;//速度
    protected Steering steering;

    private void Start()
    {
        velocity = Vector3.zero;
        steering = new Steering();
    }

    public void SetSteering(Steering steering)
    {
        this.steering = steering;
    }

    public virtual void Update()
    {
        Vector3 displacement = velocity * Time.deltaTime;//当前的位移距离
        orientation += rotation * Time.deltaTime;//当前的旋转角度

        if (orientation < 0.0f)
        {
            orientation += 360.0f;
        }
        else if (orientation > 360.0f)
        {
            orientation -= 360.0f;
        }

        transform.Translate(displacement, Space.World);
        transform.rotation = Quaternion.identity;
        transform.Rotate(Vector3.up, orientation);
    }

    public virtual void LateUpdate()
    {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if (steering.angular == 0.0f)
        {
            rotation = 0.0f;
        }

        if (steering.linear.sqrMagnitude == 0.0f)
        {
            velocity = Vector3.zero;
        }

        steering = new Steering();
    }
}
