﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] GameObject m_gameObject = null;
    [SerializeField] PhysicsWorld m_physicsWorld = null;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject go = Instantiate(m_gameObject, position, Quaternion.identity);
            PhysicsBody body = go.GetComponent<PhysicsBody>();
            //body.ApplyForce(Random.insideUnitCircle.normalized * 4.0f, PhysicsBody.eForceMode.VELOCITY);

            m_physicsWorld.bodies.Add(body);
        }

        if (Input.GetMouseButton(1))
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach (PhysicsBody body in m_physicsWorld.bodies)
            {
                Vector2 direction = body.position - position;
                if (direction.magnitude <= 4.0f)
                {
                    body.ApplyForce(direction.normalized * (4.0f - direction.magnitude), PhysicsBody.eForceMode.IMPULSE);
                }
            }

            Camera.main.backgroundColor = Color.HSVToRGB(Random.value, 1, 1);
        }
    }
}
