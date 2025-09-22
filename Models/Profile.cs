using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Staria.Models.Enums;

namespace Staria.Models;

public class Profile
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }
    [JsonProperty(PropertyName = "imagePath")]
    public string ImagePath { get; set; }
    [JsonProperty(PropertyName = "playlists")]
    public List<Playlist> Playlists { get; set; }

    public Profile(string name, string password, string imagePath)
    {
        Name = name;
        Password = password;
        ImagePath = imagePath;
        Playlists = [];
    }
    
    //Info
    internal void UpdateName(string text) =>
        Name = text;
    
    internal void UpdateImage(string text) =>
        ImagePath = text;
}