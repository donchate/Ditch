using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// api_account_object
    /// libraries\plugins\apis\condenser_api\include\steem\plugins\condenser_api\condenser_api.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ApiAccountObject
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public Authority Owner { get; set; }

        [JsonProperty("active")]
        public Authority Active { get; set; }

        [JsonProperty("posting")]
        public Authority Posting { get; set; }

        [JsonProperty("memo_key")]
        public PublicKeyType MemoKey { get; set; }

        [JsonProperty("json_metadata")]
        public ApiAccountObjectMeta JsonMetadata { get; set; }

        [JsonProperty("posting_json_metadata")]
        public ApiAccountObjectMeta PostingJsonMetadata { get; set; }

        [JsonProperty("proxy")]
        public string Proxy { get; set; }

        [JsonProperty("last_owner_update")]
        public TimePointSec LastOwnerUpdate { get; set; }

        [JsonProperty("last_account_update")]
        public TimePointSec LastAccountUpdate { get; set; }

        [JsonProperty("created")]
        public TimePointSec Created { get; set; }

        [JsonProperty("mined")]
        public bool Mined { get; set; }

        [JsonProperty("recovery_account")]
        public string RecoveryAccount { get; set; }

        [JsonProperty("reset_account")]
        public string ResetAccount { get; set; }

        [JsonProperty("last_account_recovery")]
        public TimePointSec LastAccountRecovery { get; set; }

        [JsonProperty("comment_count")]
        public uint CommentCount { get; set; }

        [JsonProperty("lifetime_vote_count")]
        public uint LifetimeVoteCount { get; set; }

        [JsonProperty("post_count")]
        public uint PostCount { get; set; }

        [JsonProperty("can_vote")]
        public bool CanVote { get; set; }

        [JsonProperty("voting_manabar")]
        public Manabar VotingManabar { get; set; }

        [JsonProperty("downvote_manabar")]
        public Manabar DownvoteManabar { get; set; }

        [JsonProperty("voting_power")]
        public uint VotingPower { get; set; }

        [JsonProperty("balance")]
        public LegacyAsset Balance { get; set; }

        [JsonProperty("savings_balance")]
        public LegacyAsset SavingsBalance { get; set; }

        [JsonProperty("sbd_balance")]
        public LegacyAsset SbdBalance { get; set; }

        [JsonProperty("sbd_seconds")]
        public UInt128 SbdSeconds { get; set; }

        [JsonProperty("sbd_seconds_last_update")]
        public TimePointSec SbdSecondsLastUpdate { get; set; }

        [JsonProperty("sbd_last_interest_payment")]
        public TimePointSec SbdLastInterestPayment { get; set; }

        [JsonProperty("savings_sbd_balance")]
        public LegacyAsset SavingsSbdBalance { get; set; }

        [JsonProperty("savings_sbd_seconds")]
        public UInt128 SavingsSbdSeconds { get; set; }

        [JsonProperty("savings_sbd_seconds_last_update")]
        public TimePointSec SavingsSbdSecondsLastUpdate { get; set; }

        [JsonProperty("savings_sbd_last_interest_payment")]
        public TimePointSec SavingsSbdLastInterestPayment { get; set; }

        [JsonProperty("savings_withdraw_requests")]
        public byte SavingsWithdrawRequests { get; set; }

        [JsonProperty("reward_sbd_balance")]
        public LegacyAsset RewardSbdBalance { get; set; }

        [JsonProperty("reward_steem_balance")]
        public LegacyAsset RewardSteemBalance { get; set; }

        [JsonProperty("reward_vesting_balance")]
        public LegacyAsset RewardVestingBalance { get; set; }

        [JsonProperty("reward_vesting_steem")]
        public LegacyAsset RewardVestingSteem { get; set; }

        [JsonProperty("vesting_shares")]
        public LegacyAsset VestingShares { get; set; }

        [JsonProperty("delegated_vesting_shares")]
        public LegacyAsset DelegatedVestingShares { get; set; }

        [JsonProperty("received_vesting_shares")]
        public LegacyAsset ReceivedVestingShares { get; set; }

        [JsonProperty("vesting_withdraw_rate")]
        public LegacyAsset VestingWithdrawRate { get; set; }

        [JsonProperty("next_vesting_withdrawal")]
        public TimePointSec NextVestingWithdrawal { get; set; }

        [JsonProperty("withdrawn")]
        public uint Withdrawn { get; set; }

        [JsonProperty("to_withdraw")]
        public uint ToWithdraw { get; set; }

        [JsonProperty("withdraw_routes")]
        public ushort WithdrawRoutes { get; set; }

        [JsonProperty("curation_rewards")]
        public uint CurationRewards { get; set; }

        [JsonProperty("posting_rewards")]
        public uint PostingRewards { get; set; }

        [JsonProperty("proxied_vsf_votes")]
        public object[] ProxiedVsfVotes { get; set; }

        [JsonProperty("witnesses_voted_for")]
        public ushort WitnessesVotedFor { get; set; }

        [JsonProperty("last_post")]
        public TimePointSec LastPost { get; set; }

        [JsonProperty("last_root_post")]
        public TimePointSec LastRootPost { get; set; }

        [JsonProperty("last_vote_time")]
        public TimePointSec LastVoteTime { get; set; }

        [JsonProperty("post_bandwidth")]
        public uint PostBandwidth { get; set; }

        [JsonProperty("pending_claimed_accounts")]
        public uint PendingClaimedAccounts { get; set; }

        //struct extended_account : public api_account_object

        [JsonProperty("vesting_balance")]
        public LegacyAsset VestingBalance { get; set; }

        [JsonProperty("reputation")]
        public ulong Reputation { get; set; }

        [JsonProperty("transfer_history")]
        public object[] TransferHistory { get; set; }

        [JsonProperty("market_history")]
        public object[] MarketHistory { get; set; }

        [JsonProperty("post_history")]
        public object[] PostHistory { get; set; }

        [JsonProperty("vote_history")]
        public object[] VoteHistory { get; set; }

        [JsonProperty("other_history")]
        public object[] OtherHistory { get; set; }

        [JsonProperty("witness_votes")]
        public object[] WitnessVotes { get; set; }

        [JsonProperty("tags_usage")]
        public object[] TagsUsage { get; set; }

        [JsonProperty("guest_bloggers")]
        public object[] GuestBloggers { get; set; }
    }
}
