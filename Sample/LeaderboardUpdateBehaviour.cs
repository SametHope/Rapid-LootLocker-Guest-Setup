using LootLocker.Requests;
using TMPro;
using UnityEngine;

namespace SametHope.RLLGS.Sample
{
    public class LeaderboardUpdateBehaviour : MonoBehaviour, ILeaderboardUpdateBehaviour
    {
        [SerializeField] private GameObject _boardContent;

        [SerializeField] private TextMeshProUGUI _infoTMP;
        [SerializeField] private TextMeshProUGUI _playerNamesTMP;
        [SerializeField] private TextMeshProUGUI _playerScoresTMP;

        public int LeaderBoardID => _leaderBoardID;
        [SerializeField] private int _leaderBoardID = 0;

        public int FetchAmount => _fetchAmount;
        [SerializeField] private int _fetchAmount = 10;


        private string _infoLoadingText = "Loading...";
        private string _infoFailureText = "Something went wrong.";
        private string _infoSuccessText = "";


        public void OnFetchCalled()
        {
            _infoTMP.text = _infoLoadingText;
        }
        public void OnFetchFailure()
        {
            _infoTMP.text = _infoFailureText;
        }

        public void OnFetchSuccess(LootLockerGetScoreListResponse leaderBoardResponse)
        {
            _infoTMP.text = _infoSuccessText;
            _boardContent.SetActive(true);
            UpdateLeaderBoard(leaderBoardResponse);      
        }
        
        private void UpdateLeaderBoard(LootLockerGetScoreListResponse leaderBoardResponse)
        {
            // Format text for TMPROs to use as a leaderboard and update them on UI with fetched data.

            string playerNames = "";
            string playerScores = "";

            for (int i = 0; i < leaderBoardResponse.items.Length; i++)
            {
                if (leaderBoardResponse.items[i].player.name == "") 
                {
                    playerNames += $"{leaderBoardResponse.items[i].rank}. {leaderBoardResponse.items[i].player.id}\n";
                }
                else
                {
                    playerNames += $"{leaderBoardResponse.items[i].rank}. {leaderBoardResponse.items[i].player.name}\n";
                }

                playerScores += leaderBoardResponse.items[i].score + "\n";
            }

            _playerNamesTMP.text = playerNames;
            _playerScoresTMP.text = playerScores;
        }
    }
}
