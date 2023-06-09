 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
    


public class Menu : MonoBehaviour
{
    public struct ScoreEntry
    {
        public DateTime data;
        public int score;
    }    
    public Text table;
    List<ScoreEntry> scores;

    public void LoadGame() => SceneManager.LoadScene(0);
    public void Exit() => Application.Quit();

    private List<ScoreEntry> GetAllScores()
    {
        scores = new List<ScoreEntry>();
        // Цикл по всіх ключах PlayerPrefs
        foreach (var key in PlayerPrefs)
        {
            DateTime dateTime;
            if (DateTime.TryParse(key, out dateTime))
            {
                int scoreValue = PlayerPrefs.GetInt(key);
                scores.Add(new ScoreEntry(data:dateTime, score:scoreValue));
            }
        }

        scores.Sort((x, y) => x.score.CompareTo(y.score));
        return scores;    
    }
    public void PrintScores()
    {
        for (int i = 0, i<= 10, i++) 
            table.text +=  scores[i].data.ToString() + "   -   " + scores[i].score.ToString() + "\n";
    }
    
    

}
