using LootLocker.Requests;
using System.Collections;
using UnityEngine;

namespace SametHope.RLLGS
{
    /// <summary>
    /// A mono script that fetchs leaderboard data and calls <see cref="ILeaderboardUpdateBehaviour"/> methods accordingly in the process.
    /// <br>Also requires an component implemented with <see cref="ILeaderboardUpdateBehaviour"/>.</br>
    /// </summary>
    [RequireComponent(typeof(ILeaderboardUpdateBehaviour))]
    public class LeaderboardUpdater : MonoBehaviour
    {
        /// <summary>
        /// Behaviour to use, set manually on awake, can be changed later.
        /// </summary>
        public ILeaderboardUpdateBehaviour UpdateBehaviour;

        /// <summary>
        /// Should fetch leaderboard each time gameObject is enabled or only manually?
        /// </summary>
        public bool FetchOnEnable = true;

        /// <summary>
        /// Fetch the highscores. Optionally gets called each time gameObject is enabled if <see cref="FetchOnEnable"/> is true.
        /// </summary>
        public void FetchHighscores()
        {
            if (UpdateBehaviour == null)
            {
                this.LogError("Failed to fetch leaderboard. UpdateBehaviour was null.");
                return;
            }
            else if (!RLLManager.SessionEstablished)
            {
                this.LogWarning("Failed to fetch leaderboard. Session was not available.");
                UpdateBehaviour.OnFetchFailure();
                return;
            }

            StartCoroutine(Co_FetchHighscores());
        }

        #region Private Logic
        
        private void OnEnable()
        {
            if (!FetchOnEnable) return;
            FetchHighscores();
        }
        private void Awake()
        {
            UpdateBehaviour = GetComponent<ILeaderboardUpdateBehaviour>();
        }

        private IEnumerator Co_FetchHighscores()
        {
            bool responseReceived = false;
            LootLockerSDKManager.GetScoreList(UpdateBehaviour.LeaderBoardID, UpdateBehaviour.FetchAmount, 0, (response) =>
            {
                if (!response.success)
                {
                    this.LogWarning("Leaderboard fetch failed because of response failure.");
                    this.LogWarning(response.Error);
                    responseReceived = true;

                    UpdateBehaviour.OnFetchFailure();
                    return;
                }

                this.Log("Leaderboard fetch succeeded.");
                responseReceived = true;

                UpdateBehaviour.OnFetchSuccess(response);
            });
            yield return new WaitWhile(() => responseReceived == false);
        }

        #endregion
    }
}
