namespace CDragonWrapper.Logics
{
    internal static class PathManager
    {
        internal static string? GetMappedPath(string? originalPath)
        {
            return originalPath?.Replace("/lol-game-data/assets/", "plugins/rcp-be-lol-game-data/global/default/").ToLower();
        }

        internal static string? GetCDragonUrl(string? path, string version = "latest")
        {
            if (path == null)
            {
                return null;
            }
            return $"https://raw.communitydragon.org/{version}/{path}";
        }

        internal static string? GetCloudUrl(string? path)
        {
            if (path == null)
            {
                return null;
            }
            var url = $"https://d28xe8vt774jo5.cloudfront.net/{path}";
            var skillKeyIndex = url.LastIndexOf('.') - 1;
            return url.Substring(0, skillKeyIndex - 1) + char.ToUpper(url[skillKeyIndex - 1]) + url.Substring(skillKeyIndex);
        }
    }
}
