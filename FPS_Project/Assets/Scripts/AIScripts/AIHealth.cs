using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHealth : MonoBehaviour
{
   [SerializeField] private float _maxHealth;
   [SerializeField] private float _currentHealth;

    public Ragdoll Ragdoll;
    public Animator animator;
    public AIAgent agent;


    private int _deathPoints = 100;

    private bool _isDead = false;
    public void Start()
    {
        agent = GetComponent<AIAgent>();
        Ragdoll = GetComponent<Ragdoll>();
        _currentHealth = _maxHealth;

        
    }

    public void TakeDamage(float damage)
    {
        if (!_isDead)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
        }

        private void Die()
    {
        PlayerPrefs.SetInt("RedScore", PlayerPrefs.GetInt("RedScore") + _deathPoints);
        _isDead = true;
        agent.StateMachine.ChangeState(AIStateID.Death);
    }
}
