using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;
    [SerializeField] private TextMeshProUGUI successText;

    GameObject parentGameObject;
    ScoreBoard scoreBoard;
    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidBody();
    }

    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }
    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;
    }
    void KillEnemy()
    {
        if (gameObject.tag == "Mare Bere" && successText != null)
        {
            successText.gameObject.SetActive(true);
        }
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}
