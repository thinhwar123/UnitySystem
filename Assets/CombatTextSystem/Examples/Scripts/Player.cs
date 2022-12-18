using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CombatTextSystem;
public class Player : MonoBehaviour
{
    private Transform m_Transform;
    public Transform Transform { get => m_Transform ??= transform; }

    [SerializeField] private int m_Health;
    [SerializeField] private float m_Speed;
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += new Vector3(horizontal, 0, vertical) * m_Speed * Time.deltaTime;
    }
    public void TakeDamage(int damage, bool isCritHit)
    {
        m_Health -= damage;
        CombatTextManager.Instance.CreateText(Transform.position, $"-{damage}", Color.red, isCritHit);
    }
    public void Heal(int value)
    {
        m_Health += value;
        CombatTextManager.Instance.CreateText(Transform.position, $"+{value}", Color.green, false);
    }
}
