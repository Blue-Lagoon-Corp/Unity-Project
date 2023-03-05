using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreEntity
{
    private string game;
    private string player;
    private int score;

    public ScoreEntity(string game,
        string player, int score)
    {
        this.game = game;
        this.player = player;
        this.score = score;
    }
}
