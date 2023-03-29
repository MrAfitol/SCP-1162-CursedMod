namespace SCP_1162_CursedMod
{
    using CursedMod.Events.Handlers.Items;
    using CursedMod.Events.Handlers.MapGeneration;
    using CursedMod.Loader;
    using CursedMod.Loader.Modules;
    using CursedMod.Loader.Modules.Enums;

    public class Plugin : CursedModule
    {
        public override string ModuleName => "SCP-1162";
        public override string ModuleAuthor => "MrAfitol";
        public override byte LoadPriority => (byte)ModulePriority.Medium;
        public override string ModuleVersion => "1.0.0";
        public override string CursedModVersion => CursedModInformation.Version;

        public static Plugin Instance;

        public Config Config;
        public EventHandlers EventHandlers;

        public override void OnLoaded()
        {
            Instance = this;
            Config = GetConfig<Config>("config");
            EventHandlers = new EventHandlers();
            MapGenerationEventsHandler.MapGenerated += EventHandlers.OnMapGenerated;
            ItemsEventsHandler.PlayerDroppingItem += EventHandlers.OnPlayerDroppingItem;

            base.OnLoaded();
        }

        public override void OnUnloaded()
        {
            MapGenerationEventsHandler.MapGenerated -= EventHandlers.OnMapGenerated;
            ItemsEventsHandler.PlayerDroppingItem -= EventHandlers.OnPlayerDroppingItem;

            EventHandlers = null;
            Config = null;
            Instance = null;

            base.OnUnloaded();
        }
    }
}
