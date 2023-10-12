using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public InputField betAmountInput;
    public Button penguinButton;

    private int selectedPenguinNumber;
    private int betAmount;

    // 이벤트 핸들러: 팽귄 선택 버튼 클릭
    public void OnPenguin1ButtonClicked()
    {
        selectedPenguinNumber = 1;
    }

    public void OnPenguin2ButtonClicked()
    {
        selectedPenguinNumber = 2;
    }

    public void OnPenguin3ButtonClicked()
    {
        selectedPenguinNumber = 3;
    }


    // 이벤트 핸들러: 게임 시작 버튼 클릭
    public void OnStartGameButtonClicked()
    {
        betAmount = int.Parse(betAmountInput.text);

        // 선택한 팽귄 번호와 베팅 금액을 GameManager.Instance.PlaceBet()를 통해 전달
        PenguinController penguinController = GetPenguinController(selectedPenguinNumber);
        GameManager.Instance.PlaceBet(betAmount, penguinController);

        // 게임 시작
        GameManager.Instance.StartGame();
    }
    private int GetSelectedPenguinNumber()
    {
        return selectedPenguinNumber;
    }

    // 선택한 팽귄 번호에 해당하는 PenguinController 스크립트를 반환하는 함수
    private PenguinController GetPenguinController(int penguinNumber)
    {
        // penguins 배열에서 penguinNumber에 해당하는 팽귄의 PenguinController 스크립트를 반환
        return GameManager.Instance.penguins[penguinNumber];
    }
}
