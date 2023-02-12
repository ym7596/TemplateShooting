using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Transform _spawnPosition;

    [SerializeField]
    private GameObject _startCam;
    // Start is called before the first frame update
    void Start()
    {
        if (InGameUI.instance)
        {
            InGameUI.instance._startPanel.gameObject.SetActive(true);
        }
    }

   
    public void SpawnPlayer()
    {
        _startCam.SetActive(false);
        var player = Instantiate(_playerPrefab, _spawnPosition);

        HPStats.instance.playerInfo = player.GetComponent<PlayerInfo>();
        HPStats.instance.SetInitHP();
    }
}
