namespace TopDownShooter
{
    public struct EventSceneLoaded
    {
        public string SceneName;

        public EventSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}