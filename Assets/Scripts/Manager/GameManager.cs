using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameConfig config { get; private set; }



    private void Awake()
    {
        Instance = this;
        config = Resources.Load<GameConfig>("GameConfig");
    }

    private void Start()
    {
        SoundManager.instance.PlayMusic("Insidebgm");
    }
}
