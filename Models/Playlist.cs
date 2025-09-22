using System.Collections.Generic;
using Newtonsoft.Json;
using Staria.Models.Enums;

namespace Staria.Models;

public class Playlist
{
    [JsonProperty(PropertyName = "title")]
    public string Title;
    [JsonProperty(PropertyName = "artist")]
    public string? Artist;
    [JsonProperty(PropertyName = "imagePath")]
    public string? ImagePath;
    [JsonProperty(PropertyName = "songs")]
    public List<Song> Songs;

    public PlaylistType PlaylistType => 
        ChangePlaylistType();

    public Playlist(string title, string? artist, string? imagePath)
    {
        Title = title;
        Artist = artist;
        ImagePath = imagePath;
        Songs = [];
    }
    
    //Info
    internal void UpdateTitle(string text) =>
        Title = text;
    
    internal void UpdateArtist(string text) =>
        Artist = text;
    
    internal void UpdateImage(string text) =>
        ImagePath = text;

    //Songs
    internal void AddSong(Song song)
    {
        Songs.Add(song);
        ChangePlaylistType();
    }

    internal void RemoveSong(int songIndex)
    {
        Songs.RemoveAt(songIndex);
        ChangePlaylistType();
    }
    
    //Playlist Type
    private PlaylistType ChangePlaylistType() =>
        Songs.Count switch
        {
            1 => PlaylistType.Single,
            > 2 and < 5 => PlaylistType.SmallPlaylist,
            _ => PlaylistType.LargePlaylist
        };
}