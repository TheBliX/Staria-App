using Newtonsoft.Json;

namespace Staria.Models;

public class Song
{
    [JsonProperty(PropertyName = "title")]
    public string Title;
    [JsonProperty(PropertyName = "artist")]
    public string? Artist;
    [JsonProperty(PropertyName = "imagePath")]
    public string? ImagePath;
    [JsonProperty(PropertyName = "songText")]
    public string? SongText;
    [JsonProperty(PropertyName = "chordsText")]
    public string? ChordsText;

    
    public Song(string title, string? artist, string? imagePath, string? songText, string? chordsText)
    {
        Title = title;
        Artist = artist;
        ImagePath = imagePath;
        SongText = songText;
        ChordsText = chordsText;
    }
    
    //Info
    internal void UpdateTitle(string text) => 
        Title = text;
    
    internal void UpdateArtist(string text) =>
        Artist = text;
    
    internal void UpdateImage(string text) =>
        ImagePath = text;
    
    internal void UpdateText(string text) =>
        SongText = text;
    
    internal void UpdateChords(string text) =>
        ChordsText = text; 
}