using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BettingSystem : MonoBehaviour
{
    public Slider[] betSliders; // 1, 2, 3번 슬라이더
    public Text betAmountText; // 배팅 금액을 표시할 UI Text

    private int selectedBetAmount = 0;
    private int selectedBetLine = 0;// 선택한 배팅 금액

    public void SetBetAmount(int sliderIndex)
    {
        // 각 슬라이더의 값에 따라 배팅 금액을 설정
        selectedBetAmount = (int)betSliders[sliderIndex].value;
        // 선택한 배팅 금액을 UI Text에 표시
        betAmountText.text = "Betting Amount: " + selectedBetAmount;
    }

    public void PlaceBet()
    {
        // 게임 로직: 승리한 말을 무작위로 선택하고 결과를 표시
        int winningHorse = Random.Range(1, 4); // 무작위로 승리한 말 선택 (1, 2, 3 중 하나)
        if (winningHorse == selectedBetLine)
        {
            // 선택한 라인과 승리한 말이 일치하면 승리
            Debug.Log("You won! Congratulations!");
            // 여기에 승리한 금액을 계산하고 표시하는 코드를 추가할 수 있습니다.
        }
        else
        {
            // 선택한 라인과 승리한 말이 일치하지 않으면 패배
            Debug.Log("You lost. Try again!");
        }
    }

}
