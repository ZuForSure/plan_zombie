using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLineParticle : MonoBehaviour
{
    public ParticleSystem ps;
    public float radius = 1f;
    public float speed = 1f;

    ParticleSystem.Particle[] particles;
    float angle = 0f;

    void Start()
    {
        particles = new ParticleSystem.Particle[1];

        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = Vector3.right * radius; 
        emitParams.startLifetime = Mathf.Infinity;
        emitParams.velocity = Vector3.zero;
        emitParams.startSize = 0.1f;

        ps.Emit(emitParams, 1);
    }

    void Update()
    {
        angle += Time.deltaTime * speed;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        ps.GetParticles(particles);
        particles[0].position = new Vector3(x, y, 0);
        ps.SetParticles(particles, 1);
    }
}
