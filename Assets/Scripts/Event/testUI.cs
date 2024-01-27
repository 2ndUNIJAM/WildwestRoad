using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitiationUI test = new InitiationUI();
        test.OnAble(PlayerType.A, PlayerType.A);
    }

    
}
