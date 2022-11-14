using LootLocker.Requests;

namespace SametHope.RLLGS
{
    /// <summary>
    /// Is used by <see cref="LeaderboardUpdater"/>. Works much like an event system in the context. Implement for custom logic.
    /// </summary>
    public interface ILeaderboardUpdateBehaviour
    {
        /// <summary>
        /// ID of leaderboard to fetch from.
        /// </summary>
        public int LeaderBoardID { get; }

        /// <summary>
        /// Amount of leaderboard members to fetch.
        /// </summary>
        public int FetchAmount { get; }

        /// <summary>
        /// Gets called when a fetch request happens. Useful for loading screens etc.
        /// </summary>
        public void OnFetchCalled();

        /// <summary>
        /// Gets called when a fetch request fails. Useful for error screens etc.
        /// </summary>
        public void OnFetchFailure();

        /// <summary>
        /// Gets called when a fetch request is successful. Useful for updating leaderboard etc.
        /// </summary>
        public void OnFetchSuccess(LootLockerGetScoreListResponse leaderBoardMemberArray);
    }
}
