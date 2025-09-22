using Staria.Models;

namespace Staria;

public class AppInfo
{
    internal static Profile? Profile { get; private set; }
    
    internal static void LoadProfile(Profile profile) =>
        Profile = profile;
}