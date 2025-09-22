using System;
using Newtonsoft.Json;
using MsBox.Avalonia;
using Staria.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Staria;

public class FileManager
{
    internal static bool IsLoaded = false;
    internal static string StariaDirectoryPath { get; private set; }
    
    //Info
    internal static void ChangeStariaDirectoryPath(string path) =>
        StariaDirectoryPath = path;
    
    //Sign in
    internal static async void TryToLoadProfile(string name, string password)
    {
        try
        {
            if (File.Exists(Path.Combine(StariaDirectoryPath, $"{name}.json")))
            {
                var reader = new StreamReader($"{StariaDirectoryPath}/{name}.json");
                var text = "";
                while (!reader.EndOfStream) {
                    text += reader.ReadLine();
                }
                var profile = JsonConvert.DeserializeObject<Profile>(text, new JsonSerializerSettings{Formatting = Formatting.Indented});
                reader.Close();

                if (profile != null && profile.Name == name && profile.Password == password)
                {
                    AppInfo.LoadProfile(profile);
                    IsLoaded = true;
                }
                else
                {
                    await MessageBoxManager
                        .GetMessageBoxStandard("Wrong password", "You entered wrong password.")
                        .ShowAsync();
                }
            }
            else
            {
                await MessageBoxManager
                    .GetMessageBoxStandard("Profile is not exists", $"There is no profile called '{name}'.")
                    .ShowAsync();
            }
        }
        catch (Exception)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Error", "Something went wrong...")
                .ShowAsync();
        }
    }


    //Sign up
    internal static void AddProfile(string name, string password)
    {
        var profile = new Profile(name, password, "");
        var jsonText = JsonConvert.SerializeObject(profile);
        var writer = new StreamWriter($"{StariaDirectoryPath}/{name}.json", false);
        writer.WriteLine(jsonText);
        writer.Close();
    }
}