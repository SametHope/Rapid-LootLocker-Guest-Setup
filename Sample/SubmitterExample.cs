using TMPro;
using UnityEngine;
using UnityEngine.UI;

using SametHope.RLLGS;

// An example script to simulate data submitting process.
public class SubmitterExample : MonoBehaviour
{
    [SerializeField] private Button _submitButton;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private LeaderboardUpdater _updater;

    // Called when button is clicked.
    // Set players name, then submit score, then update UI via fetching them again.
    public void Btn_Submit()
    {
        int scoreToSubmit = GameExample.Score;
        string nameToSet = _nameField.text;

        _submitButton.interactable = false;
        _nameField.interactable = false;

        Debug.Log($"Setting name: '{nameToSet}'.");
        RLLManager.Instance.SetName(nameToSet, () =>
        {
            Debug.Log($"Submitting score: '{scoreToSubmit}'.");
            RLLManager.Instance.SubmitScore(RLLManager.PlayerID, scoreToSubmit, _updater.UpdateBehaviour.LeaderBoardID, () =>
            {
                Debug.Log($"Fetching leaderboard.");
                _updater.FetchHighscores();

                _submitButton.interactable = true;
                _nameField.interactable = true;
            });
        });
    }


    // Called when text in the inputfield has changed.
    // Sets submit button not interactable if given name is not invalid.
    public void InFi_SetBtnState()
    {
        _submitButton.interactable = _nameField.text != "" && !string.IsNullOrWhiteSpace(_nameField.text);
    }
}

