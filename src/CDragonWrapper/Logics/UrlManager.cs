using CDragonWrapper.Exceptions;
using CDragonWrapper.Misc;

namespace CDragonWrapper.Logics
{
    public static class UrlManager
    {
        private static string _domain = "https://raw.communitydragon.org";
        private static string _dirGameData = "rcp-be-lol-game-data";
        private static string _dirStaticAsset = "rcp-fe-lol-static-assets";
        private static string _dirSocial = "rcp-fe-lol-social";
        private static string _dirCollection = "rcp-fe-lol-collections";
        private static string _dirSharedComponent = "rcp-fe-lol-shared-components";
        private static string _dirMatchHistory = "rcp-fe-lol-match-history";
        private static string _dirPostGame = "rcp-fe-lol-postgame";

        public static class GameData
        {
            public static string GetUrl(string version, Language language, string dataName, string? dataDic = null)
            {
                var dataUrl = dataDic != null ? $"{dataDic}/{dataName}" : dataName;
                return $"{_domain}/{version}/plugins/{_dirGameData}/global/{language}/v1/{dataUrl}.json".ToLower();
            }
        }

        public static class Image
        {
            private static Dictionary<EpicMonster, string> _epicInMatchHisory = new()
            {
                { EpicMonster.Baronnashor, "baron" },
                { EpicMonster.ChemtechDrake, "dragon" },
                { EpicMonster.CloudDrake, "air" },
                { EpicMonster.Dragon, "dragon" },
                { EpicMonster.ElderDrake, "elder" },
                { EpicMonster.HextechDrake, "dragon" },
                { EpicMonster.InfernalDrake, "fire" },
                { EpicMonster.MountainDrake, "earth" },
                { EpicMonster.OceanDrake, "water" },
                { EpicMonster.PartyDrake, "dragon" },
                { EpicMonster.Riftherald, "herald" },
            };

            private static Dictionary<EpicMonster, string> _epicInMiniMap = new()
            {
                { EpicMonster.Baronnashor, "baron" },
                { EpicMonster.ChemtechDrake, "dragon_chemtech" },
                { EpicMonster.CloudDrake, "dragon_cloud" },
                { EpicMonster.Dragon, "dragon" },
                { EpicMonster.ElderDrake, "dragon_elder" },
                { EpicMonster.HextechDrake, "dragon_hextech" },
                { EpicMonster.InfernalDrake, "dragon_infernal" },
                { EpicMonster.MountainDrake, "dragon_mountain" },
                { EpicMonster.OceanDrake, "dragon_ocean" },
                { EpicMonster.PartyDrake, "dragon_party" },
                { EpicMonster.Riftherald, "riftherald" },
                { EpicMonster.RuinousAtakhan, "atakhan_r" },
                { EpicMonster.VoraciousAtakhan, "atakhan_v" },
                { EpicMonster.VoidGrub, "grub" },
            };

            public static string GetRankEmblemUrl(Rank rank)
            {
                return Merge(_dirSharedComponent, $"images/{rank}.png");
            }
            public static string GetRankCrestUrl(Rank rank)
            {
                return Merge(_dirStaticAsset, $"images/ranked-mini-crests/{rank}.png");
            }

            public static string GetRoleIconUrl(Role role)
            {
                return Merge(_dirSocial, $"roleicon-{role}.png");
            }

            public static string GetPositionIconUrl(Position position)
            {
                return Merge(_dirSocial, $"positionicon-{position}.png");
            }

            public static string GetMasteryIconUrl(int level, bool withFlag = false)
            {
                if (level < 1 || level > 10)
                {
                    throw new CDragonException("Argument must be 1 ~ 10.");
                }

                if (withFlag)
                {
                    return Merge(_dirCollection, $"images/item-element/crest-and-banner-mastery-{level}.png");
                }
                return Merge(_dirSharedComponent, $"mastery-{level}.png");
            }

            /// <param name="monster">Some monsters are not supported.</param>
            /// <returns></returns>
            /// <exception cref="CDragonException"></exception>
            public static string GetScoreBoardIconUrl(EpicMonster monster)
            {
                if ((int)monster > 100)
                {
                    throw new CDragonException("Some monsters are not supported.");
                }
                return GetScoreBoardIconUrl(monster.ToString());
            }

            public static string GetScoreBoardIconUrl(JangleMonster monster)
            {
                return GetScoreBoardIconUrl(monster.ToString());
            }

            private static string GetScoreBoardIconUrl(string monster)
            {
                return $"{_domain}/latest/game/assets/ux/scoreboard/_{monster}.png".ToLower();
            }

            public static string GetMatchHistoryIconUrl()
            {
                return Merge(_dirMatchHistory, "right_icons_grub.png");
            }

            public static string GetMatchHistoryIconUrl(EpicMonster monster, bool isBlueTeam = true)
            {
                if ((int)monster > 100)
                {
                    throw new CDragonException("Some monsters are not supported.");
                }
                var team = isBlueTeam ? "100" : "200";
                var picName = _epicInMatchHisory[monster];
                return Merge(_dirMatchHistory, $"{picName}-{team}.png");
            }

            public static string GetMatchHistoryIconUrl(Building building, bool isBlueTeam = true)
            {
                var team = isBlueTeam ? "100" : "200";
                return Merge(_dirMatchHistory, $"{building}-{team}.png");
            }

            public static string GetMiniMapIconUrl(EpicMonster monster, bool isBountied = false)
            {
                var addition = isBountied ? "_bounty" : "";
                return $"{_domain}/latest/game/assets/ux/minimap/icons/{_epicInMiniMap[monster]}{isBountied}.png";
            }
        }

        public static class Svg
        {
            private static Dictionary<Score, string> _scoreIconName = new()
            {
                { Score.Kda, "kda-icon" },
                { Score.Coins, "coins-icon" },
                { Score.MinionsSlain, "stat-switcher-minions-slain" }
            };

            public static string GetRankCrestUrl(Rank rank)
            {
                return Merge(_dirStaticAsset, $"images/ranked-mini-crests/{rank}.svg");
            }

            /// <param name="color">0: default, 1: light, 2: red</param>
            public static string GetPositionIconUrl(Position position, int color = 0)
            {
                var additional = "";
                if (color == 1)
                {
                    additional = "-light";
                }
                else if (color == 2)
                {
                    additional = "-red";
                }

                return Merge(_dirStaticAsset, $"svg/position-{position}{additional}.svg");
            }

            public static string GetScoreBoardIconUrl(Score score)
            {
                return Merge(_dirPostGame, $"scoreboard-{_scoreIconName[score]}.svg");
            }
        }

        private static string Merge(string plugin, string itemPath)
        {
            return $"{_domain}/latest/plugins/{plugin}/global/default/{itemPath}".ToLower();
        }
    }
}
