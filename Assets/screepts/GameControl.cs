using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameControl : MonoBehaviour
{
    /// public static event Action Run = delegate { };
    private Text score;
    private Text credits;
    private GameObject rall_0; /// с массивом не так
    private GameObject rall_1;
    private GameObject rall_2;

    void Update() /// мало блокувати кнопку все на час. коли крутяться слоти
    {
       
    }
   
    private IEnumerator Spin_an()
    {
        for (int i = 0; i < 5; i++) 
        {
            Button.transform.rotation = Quaternion.Euler(0f, 0f, 3 * i);
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < 5; i++)
        {
            Button.transform.rotation = Quaternion.Euler(0f, 0f, -3 * i);
            yield return new WaitForSeconds(0.3f);
        }
        if (credits.text != "0")
        {
            credits.text = (Convert.ToInt32(credits.text) - 1).ToString();
            Save();
        }
        else SceneManager.LoadScene(1);
    }
    private void CountResult() //пошук виграшних комбінацій
    {
        float slot1, slot2, slot3;
        slot1 = rall_0.transform.position.y;
        slot2 = rall_1.transform.position.y;
        slot3 = rall_2.transform.position.y;
        if (slot1 == slot2 && slot2 == slot3)
            credits.text = (Convert.ToInt32(score.text) + Convert.ToInt32(credits.text)).ToString();
        else if (slot1 == slot2 || slot1 == slot3 || slot3 == slot2)
            credits.text = (Convert.ToInt32(credits.text) - 1).ToString();
        score.text = (Convert.ToInt32(score.text) + 1).ToString();
    }
    private void Save()// збереження рахунку
    {
        string dataKey = DateTime.Now.ToString();
        PlayerPrefs.SetInt(dataKey, Convert.ToInt32(score.text));
    }

}
