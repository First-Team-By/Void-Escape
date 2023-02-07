using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventResolver : MonoBehaviour
{
    public void OnEventResolver(RoomContent content)
    {
        SceneManager.LoadScene("BattleScene");
    }
}
