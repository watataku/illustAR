using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARManager : MonoBehaviour
{
    // イラストをチェックした回数のカウント
    [SerializeField]
    private Text seeCounter;
    private int seeCount;

    private void Start()
    {
        seeCount = -1;
    }

    private void Update()
    {
        // カウンタを更新する
        seeCounter.text = "Count: " + seeCount.ToString();
    }

    // HandTrackingが解除されたらカウントする
    public void SeeCounter()
    {
        seeCount++;
    }
}
