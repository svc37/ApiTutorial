using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveTheWorld.Models
{
    // Models is where we house all of our classes that we will smash our Elastic Search Json in to. This is our "DataContract".


    public class LeagueApiResponse
    {
        //most of these guys are just plain old data types. ints and strings
        public int MatchID { get; set; }
        public string Region { get; set; }
        public string PlatformID { get; set; }
        public string MatchMode { get; set; }
        public string MatchType { get; set; }
        public int MatchCreating { get; set; } 
        public int MatchDuration { get; set; }
        public string QueueType { get; set; }
        public int MapID { get; set; }
        public string Season { get; set; }
        public string MatchVersion { get; set; }
        //this guys gets his own class because "Participants" has its own sub properties.  See below.
        public IEnumerable<Participant> Participants { get; set; } 

        //Side Note:  IEnumberable is basically the interface for the "List" type.  We can use "List", but it is
        //common practice to use "IEnumerable" instead for Json.  I'd have to look up exactly why that is. 

        public IEnumerable<ParticipantIdentity> ParticipantIdentities { get; set; }
        public IEnumerable<Team> Teams { get; set; }

        //The Json results can have "results within results".  when that happens they get their own subclass defined
        //and then become they property type in the main class. 
        public class Participant
        {
            public int TeamID { get; set; }
            public int Spell1ID { get; set; }
            public int Spell2ID { get; set; }
            public int ChampionID { get; set; }
            public string HighestAchievedSeasonTier { get; set; }
            public Timeline TimeLine { get; set; }
            public IEnumerable<Mastery> Masteries { get; set; }
            public Stats Stats { get; set; }
            public int ParticipantID { get; set; }
            public IEnumerable<Rune> Runes { get; set; }
        }

        #region classes for participants

        public class Timeline
        {
            public CreepsPerMinDeltas CreepsPerMin { get; set; }
            public XpPerMinDeltas XpPerMin { get; set; }
            public GoldPerMinDeltas GoldPerMin { get; set; }
            public CsDiffPerMinDeltas CsDiffPerMin { get; set; }
            public XpDiffPerMinDeltas XpDiffPerMin { get; set; }
            public DamageTakenPerMinDeltas DamageTakenPerMin { get; set; }
            public DamageTakenDiffPerMinDeltas DamageTakenDiffPerMin { get; set; }
            public string Role { get; set; }
            public string Lane { get; set; }
        }

        #region classes for Timeline

        public class CreepsPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class XpPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class GoldPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class CsDiffPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class XpDiffPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class DamageTakenPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        public class DamageTakenDiffPerMinDeltas
        {
            public decimal ZeroToTen { get; set; }
            public decimal TenToTwenty { get; set; }
            public decimal TwentyToThirty { get; set; }
            public decimal ThirtyToEnd { get; set; }
        }

        #endregion

        public class Mastery
        {
            public int MasteryID { get; set; }
            public int Rank { get; set; }
        }

        public class Stats
        {
            public bool Winner { get; set; }
            public int ChampLevel { get; set; }
            public int Item0 { get; set; }
            public int Item1 { get; set; }
            public int Item2 { get; set; }
            public int Item3 { get; set; }
            public int Item4 { get; set; }
            public int Item5 { get; set; }
            public int Item6 { get; set; }
            public int Kills { get; set; }
            public int DoubleKills { get; set; }
            public int TripleKills { get; set; }
            public int QuadraKills { get; set; }
            public int PentaKills { get; set; }
            public int UnrealKills { get; set; }
            public int LargestKillingSpree { get; set; }
            public int Deaths { get; set; }
            public int Assists { get; set; }
            public int TotalDamageDealth { get; set; }
            public int TotalDamageDealtToChampions { get; set; }
            public int TotalDamageTaken { get; set; }
            public int LargestCriticalStrike { get; set; }
            public int TotalHeal { get; set; }
            public int MinionsKilled { get; set; }
            public int NeutralMinionsKilled { get; set; }
            public int NeutralMinionsKilledTeamJungle { get; set; }
            public int NeutralMinionsKilledEnemyJungle { get; set; }
            public int GoldEarned { get; set; }
            public int GoldSpent { get; set; }
            public int CombatPlayerScore { get; set; }
            public int ObjectivePlayerScore { get; set; }
            public int TotalPlayerScore { get; set; }
            public int TotalScoreRank { get; set; } //maybe do something with this in app???
            public int MagicDamageDealtToChampions { get; set; }
            public int PhysicalDamageDealtToChampions { get; set; }
            public int TrueDamageDealthToCHampions { get; set; }
            public int VisionWardsBoughtInGame { get; set; }
            public int SightWardsBoughtInGame { get; set; }
            public int MagicDamageDealt { get; set; }
            public int PhysicalDamageDealt { get; set; }
            public int TrueDamageDealt { get; set; }
            public int MagicDamageTaken { get; set; }
            public int PhysicalDamageTaken { get; set; }
            public int TrueDamageTaken { get; set; }
            public bool FirstBloodKill { get; set; }
            public bool FirstBloodAssist { get; set; }
            public bool FirstTowerKill { get; set; }
            public bool FirstTowerAssist { get; set; }
            public bool FirstInhibitorKill { get; set; }
            public bool FirstInhibitorAssist { get; set; }
            public int InhibitorKills { get; set; }
            public int TowerKills { get; set; }
            public int WardsPlaced { get; set; }
            public int WardsKilled { get; set; }
            public int LargestMultiKill { get; set; }
            public int KillingSprees { get; set; }
            public int TotalUnitsHealed { get; set; }
            public int TotalTimeCrowdControlDealt { get; set; }


        }

        public class Rune
        {
            public int RuneID { get; set; }
            public int Rank { get; set; }

        }

        #endregion

        public class ParticipantIdentity
        {
            public int ParticipantID { get; set; }
            public Player Player { get; set; }
        }

        #region classes for ParticipantIdentity

        public class Player
        {
            public Int64 SummonerID { get; set; } //check on the size of this one.  Example ID = 62671120
            public string SummonerName { get; set; }
            public string MatchHistoryUri { get; set; }
            public int ProfileIcon { get; set; }
        }

        #endregion

        public class Team
        {
            public int TeamID { get; set; }
            public bool Winner { get; set; }
            public bool FirstBlood { get; set; }
            public bool FirstTower { get; set; }
            public bool FirstInhibitor { get; set; }
            public bool FirstBaron { get; set; }
            public bool FirstDragon { get; set; }
            public int TowerKills { get; set; }
            public int InhibitorKills { get; set; }
            public int BaronKills { get; set; }
            public int DragonKills { get; set; }
            public int VilemawKills { get; set; }
            public int DominionVictoryScore { get; set; }
            public IEnumerable<Ban> Bans { get; set; }
        }

        #region classes for Team

        public class Ban
        {
            public int ChampionID { get; set; }
            public int PickTurn { get; set; }
        }

        #endregion

    }
}