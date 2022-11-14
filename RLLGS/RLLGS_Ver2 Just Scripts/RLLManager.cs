using System.Collections;
using UnityEngine;

using LootLocker.Requests;

namespace SametHope.RLLGS
{
    /// <summary>
    /// A mono script with optional singleton pattern. Responsible for starting and storing the session data, and submitting scores and names.
    /// </summary>
    public class RLLManager : MonoBehaviour
    {
        #region Private Singleton Pattern
        [SerializeField] private bool SingletonMode = true;
        public static RLLManager Instance;
        private void Awake()
        {
            if (!SingletonMode) return;
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InstanceAwake();
            }
            else
            {
                this.LogWarning($"Another Instance of this singleton has been found. Destroying this instance.");
                Destroy(gameObject);
            }
        }
        #endregion

        #region Session Related Code
        
        #region Public Fields
        /// <summary>
        /// Returns true if a guest session was established, false otherwise.
        /// </summary>
        public static bool SessionEstablished { get; private set; } = false;

        /// <summary>
        /// Returns the numerical ID stored on the PlayerPrefs to interact with the LootLocker. It is set on first sessions start.
        /// <br>Notice this is not the same as <see cref="LootLockerGuestSessionResponse.player_identifier"/>, which is set by SDK on session start and also stored on the PlayerPrefs, but is not only numerical and quite long.</br>
        /// <br></br>
        /// <br>See the sample project if you are confused. Seeing how it is used once should be enough clear it up pretty easily.</br>
        /// </summary>
        public static string PlayerID => PlayerPrefs.GetString(LootLockerPlayerID_PrefKey);

        /// <summary>
        /// PlayerPref key to store <see cref="PlayerID"/> with.
        /// </summary>
        public const string LootLockerPlayerID_PrefKey = "RLLGS PlayerID";
        #endregion

        #region Start Session
        private void InstanceAwake()
        {
            StartCoroutine(Co_StartSessionAsGuest());
        }

        private IEnumerator Co_StartSessionAsGuest()
        {
            bool responseReceived = false;
            LootLockerSDKManager.StartGuestSession((response) =>
            {
                if (!response.success)
                {
                    this.LogWarning("Session establishment failed.");
                    this.LogWarning(response.Error);
                    responseReceived = true;
                    SessionEstablished = false;
                    return;
                }

                this.Log("Session establishment succeeded.");
                PlayerPrefs.SetString(LootLockerPlayerID_PrefKey, response.player_id.ToString());
                responseReceived = true;
                SessionEstablished = true;
            });
            yield return new WaitWhile(() => responseReceived == false);
        }
        #endregion

        #endregion


        #region Submitting Related Code

        #region Public Calls

        /// <summary>
        /// Set the name of the player with the current session to <paramref name="newName"/>
        /// <br>Optionally invoke <paramref name="OnComplete"/> after a response is received if it is provided.</br>
        /// </summary>
        public void SetName(string newName, System.Action OnComplete = null)
        {
            StartCoroutine(Co_SetPlayerName(newName, OnComplete));
        }

        /// <summary>
        /// Submit the score of the player with the <paramref name="playerID"/> in the leader board with <paramref name="leaderBoardId"/> to <paramref name="scoreToSubmit"/>.
        /// <br>Optionally invoke <paramref name="onComplete"/> after a response is received if it is provided.</br>
        /// </summary>
        public void SubmitScore(string playerID, int scoreToSubmit, int leaderBoardId, System.Action onComplete = null)
        {
            StartCoroutine(Co_SubmitScore(playerID, scoreToSubmit, leaderBoardId, onComplete));
        }

        #endregion

        #region Private Logic

        private IEnumerator Co_SetPlayerName(string nameToSet, System.Action onComplete = null)
        {
            bool responseReceived = false;
            LootLockerSDKManager.SetPlayerName(nameToSet, (response) =>
            {
                if (!response.success)
                {
                    this.LogWarning($"Failed to set player name to '{nameToSet}'.");
                    this.LogWarning(response.Error);
                    responseReceived = true;
                    return;
                }

                this.Log($"Succesfully set player name to '{nameToSet}'.");
                responseReceived = true;
            });
            yield return new WaitWhile(() => responseReceived == false);
            onComplete?.Invoke();
        }
        private IEnumerator Co_SubmitScore(string playerId, int scoreToSubmit, int leaderboardId, System.Action onComplete = null)
        {
            bool responseReceived = false;
            LootLockerSDKManager.SubmitScore(playerId, scoreToSubmit, leaderboardId, (response) =>
            {
                if (!response.success)
                {
                    this.LogWarning($"Failed to set the score of player with id '{playerId}' to '{scoreToSubmit}'.");
                    this.LogWarning(response.Error);
                    responseReceived = true;
                    return;
                }

                this.Log($"Successfully set the score of player with id '{playerId}' to '{scoreToSubmit}'.");
                responseReceived = true;
            });
            yield return new WaitWhile(() => responseReceived == false);
            onComplete?.Invoke();
        }
        #endregion

        #endregion
    }
}

