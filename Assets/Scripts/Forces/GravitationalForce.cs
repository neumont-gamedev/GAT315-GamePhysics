﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GravitationalForce
{
	public static void ApplyForce(ref List<PhysicsBody> bodies, float G)
	{
		for (int i = 0; i < bodies.Count - 1; i++)
		{
			for (int j = i + 1; j < bodies.Count; j++)
			{
				PhysicsBody bodyA = bodies[i];
				PhysicsBody bodyB = bodies[j];

				Vector2 direction = bodyA.position - bodyB.position;
				float distanceSqr = Mathf.Max(direction.sqrMagnitude, 0.01f);
				float force = G * ((bodyA.mass * bodyB.mass) / distanceSqr);
				bodyA.ApplyForce(-direction.normalized * force, PhysicsBody.eForceMode.FORCE);
				bodyB.ApplyForce( direction.normalized * force, PhysicsBody.eForceMode.FORCE);
			}
		}
	}
}
