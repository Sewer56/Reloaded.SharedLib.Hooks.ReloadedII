using System;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace Reloaded.Hooks.ReloadedII
{
    public class Program : IMod, IExports
    {
        private IModLoader _modLoader;
        private IReloadedHooks _reloadedHooks;

        public void Start(IModLoaderV1 loader)
        {
            _modLoader = (IModLoader)loader;

            /* Your mod code starts here. */
            _reloadedHooks = new ReloadedHooks();
            _modLoader.AddOrReplaceController<IReloadedHooks>(this, _reloadedHooks);
        }

        /* Mod loader actions. */
        public void Suspend() { }
        public void Resume()  { }
        public void Unload()  { }

        public bool CanUnload()  => false;
        public bool CanSuspend() => false;

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing { get; }
        public Type[] GetTypes() => new[] { typeof(IReloadedHooks), typeof(IHook<>) };

        // Note: The reason we are Sharing IHook is because the other mods
        // (in their own AssemblyLoadContexts) will also need to load the same instance of the Reloaded.Hooks.Definitions library.

        // Warning: This forces other libraries to use the same version of IHook. Changes to IHook can cause breakages!
        // It is recommended to follow the same versioning rules as defined in "Inter-Mod-Communication".
    }
}
