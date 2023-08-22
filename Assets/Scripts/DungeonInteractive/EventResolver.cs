using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventResolver : MonoBehaviour
{
    public void OnEventResolve()
    {
        if (Global.GetCurrentRoomInfo().Inhabitable)
        {
            SceneManager.LoadScene(4); // BattleScene
        }
    }
}
