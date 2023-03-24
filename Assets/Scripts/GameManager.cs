using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int attackRange;
    [SerializeField] private Text gold;
    [SerializeField] private GameObject neonCircle;
    [SerializeField] private EnemyAi enemy;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private int enemiesPerWave;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float waveInetrval;
   
    public static int Gold;

    private Transform _transform;
    private int _enemyCount;   
    private int _attackSpeed;
    private int _bulletDamage;
    private int _counter;

    public int EnemyCount
    {
        get => _enemyCount;
        set => _enemyCount = value;
    }

    private void Start()
    {
        attackRange = 3;
        _attackSpeed = 3;
        _bulletDamage = 25;

        _transform = GetComponent<Transform>();

        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        gold.text = "Gold: " + Gold.ToString();
    }

    private void OnEnable()
    {
        EnemyAi.EnemyDied += AddScore;
    }

    private void OnDisable()
    {
        EnemyAi.EnemyDied -= AddScore;
    }

    private void AddScore()
    {
        Gold += 10;
        if (gold == null) return;
        gold.text = "Gold: " + Gold.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
           // if (EnemyCount <= 0)
            {
                float randDirection;
                float randDistance;
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    randDirection = Random.Range(0, 360);
                    randDistance = Random.Range(10, 25);

                    float posX = _transform.position.x + (Mathf.Cos(randDirection * Mathf.Deg2Rad) * randDistance);
                    float posY = _transform.position.y + (Mathf.Sin(randDirection * Mathf.Deg2Rad) * randDistance);
                    var spawnedEnemy = Instantiate(enemy, new Vector3(posX, posY, 0), Quaternion.identity);
                    spawnedEnemy.Initialize(playerTransform, this);
                    EnemyCount++;
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            yield return new WaitForSeconds(waveInetrval);
        }
    }

    public void BuyBulletDamage()
    {
        if (GameManager.Gold >= 100)
        {
            _bulletDamage += 25;
            PlayerPrefs.SetInt("BulletDamage", _bulletDamage);
            GameManager.Gold -= 100;
        }
    }

    public void BuyAttackSpeed()
    {
        if (GameManager.Gold >= 100)
        {
            if (_attackSpeed > 0)
            {
                _attackSpeed -= 1;
                PlayerPrefs.SetInt("AttackSpeed", _attackSpeed);
                GameManager.Gold -= 100;
            }
        }
    }

    public void BuyAttackRange()
    {
        if (GameManager.Gold >= 100)
        {         
            GameManager.Gold -= 100;

            switch (_counter)
            {
                case 1:
                    attackRange = 2;
                    break;

                case 2:
                    attackRange = 3;
                    break;

                case 3:
                    attackRange = 4;
                    break;
            }

            PlayerPrefs.SetInt("AttackRange", attackRange);
        }
    }

    public void NeonCircle()
    {
        _counter++;
      
       switch(_counter)
        {
            case 1:
                neonCircle.transform.localScale = new Vector3(7, 7, 7);
            break;

            case 2:
                neonCircle.transform.localScale = new Vector3(8, 8, 8);
                break;

            case 3:
                neonCircle.transform.localScale = new Vector3(10, 10, 10);
                break;
        }
    }
}