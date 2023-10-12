using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingButton : MonoBehaviour
{
    public BettingSystem bettingSystem; // BettingSystem 스크립트를 참조하기 위한 변수

    private void Start()
    {
        // BettingSystem 스크립트를 찾아서 참조합니다. 이 스크립트를 클릭 이벤트에서 사용합니다.
        bettingSystem = GameObject.FindObjectOfType<BettingSystem>();
    }

    public void OnClick()
    {
        // 버튼이 클릭될 때 호출되는 함수
        // 이 함수에서 배팅을 처리하도록 BettingSystem 스크립트의 PlaceBet() 함수를 호출할 수 있습니다.
        bettingSystem.PlaceBet();
    }
}

