using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SceneSingleton<GameManager>
{


    public void GameOver_OnPlayerDead()
    {
        Debug.Log("�÷��̾�����");
    }

    public void StageClear()
    {
        Debug.Log("��������Ŭ����");
    }
}
