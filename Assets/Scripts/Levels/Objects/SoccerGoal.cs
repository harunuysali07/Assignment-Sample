using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoccerGoal : MonoBehaviour
{
    public GoalType goalType;

    private List<ParticleSystem> confettiParticles;

    private void Awake()
    {
        confettiParticles = GetComponentsInChildren<ParticleSystem>().ToList();
    }

    public void OnGoal()
    {
        confettiParticles.ForEach(p => p.Play());
    }
}

public enum GoalType
{
    Player,
    Enemy
}
