using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EnnemiSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _baseEnnemis;
    [SerializeField] private GameObject _eliteEnnemis;
    [SerializeField] private TextMeshProUGUI _timerText;

    [SerializeField] private Transform[] _spawnPoints;

    public List<Wave> _waves = new();
    private float _time;

    [System.Serializable]
    public struct Wave
    {
        public void Spawn(Transform _parent)
        {
            foreach (var item in content)
            {
                for (int i = 0; i < item._numbers; i++)
                {
                    GameObject _ennemie = Instantiate(item._prefab, _parent);
                    _ennemie.transform.position = SP[Random.Range(0,SP.Count)].position;
                }
            }
        }
        public List<WaveContent> content;
        [HideInInspector]
        public List<Transform> SP;
    }

    [System.Serializable]
    public struct WaveContent
    {
        public GameObject _prefab;
        public int _numbers;
    }



    void Start()
    {
        for (int i = 0; i < _waves.Count; i++)
        {
            foreach (var item in _spawnPoints)
            {
                _waves[i].SP.Add(item);
            }
        }

        InvokeRepeating("SpawnWave", 5f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        _timerText.text = Mathf.Floor(_time / 60).ToString("F0") + " : " + (_time % 60).ToString("F0") + " min";
    }

    public void SpawnWave()
    {
        float _percentage;
        if (_time < 120)
        {
            _waves[0].Spawn(transform);
        }
        else if(_time > 120 && _time < 300)
        {
            _percentage = Random.Range(0f, 100f);
            if( _percentage <= 25)
            {
                _waves[0].Spawn(transform);
            }
            else
            {
                _waves[1].Spawn(transform);
            }
        }
        else if(_time > 300)
        {
            _percentage = Random.Range(0f, 100f);
            if(_percentage <= 50)
            {
                _waves[1].Spawn(transform);
            }
            else
            {
                _waves[2].Spawn(transform);
            }
        }

    }
}

