using System.Collections.Generic;
using Ditch.Core.Models;
using Newtonsoft.Json;

namespace Ditch.Hive.Models
{
    /// <summary>
    /// get_ranked_posts response
    /// https://developers.hive.io/apidefinitions/#bridge.get_ranked_posts
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class HivemindPost
    {
        [JsonProperty("post_id")]
        public ulong Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("permlink")]
        public string Permlink { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("json_metadata")]
        public Dictionary<string, dynamic> JsonMetadata { get; set; }

        [JsonProperty("created")]
        public TimePointSec Created { get; set; }

        [JsonProperty("updated")]
        public TimePointSec Updated { get; set; }

        [JsonProperty("depth")]
        public byte Depth { get; set; }

        [JsonProperty("children")]
        public ushort Children { get; set; }

        [JsonProperty("net_rshares")]
        public long NetRshares { get; set; }

        [JsonProperty("is_paidout")]
        public bool IsPaidout { get; set; }

        [JsonProperty("payout_at")]
        public TimePointSec PayoutAt { get; set; }

        [JsonProperty("payout")]
        public float Payout { get; set; }

        [JsonProperty("pending_payout_value")]
        public Asset PendingPayoutValue { get; set; }

        [JsonProperty("author_payout_value")]
        public Asset AuthorPayoutValue { get; set; }

        [JsonProperty("curator_payout_value")]
        public Asset CuratorPayoutValue { get; set; }

        [JsonProperty("promoted")]
        public Asset Promoted { get; set; }

        [JsonProperty("replies")]
        public string[] Replies { get; set; }

        [JsonProperty("active_votes")]
        public VoteState[] ActiveVotes { get; set; }

        [JsonProperty("author_reputation")]
        public float AuthorReputation { get; set; }

        [JsonProperty("stats")]
        public HivemindPostStats Stats { get; set; }

        [JsonProperty("beneficiaries")]
        public BeneficiaryRouteType[] Beneficiaries { get; set; }

        [JsonProperty("max_accepted_payout")]
        public Asset MaxAcceptedPayout { get; set; }

        [JsonProperty("percent_steem_dollars")]
        public ushort PercentSteemDollars { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("blacklists")]
        public string[] Blacklists { get; set; }
    }
}