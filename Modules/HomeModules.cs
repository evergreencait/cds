using Nancy;
using cds.Objects;
using System.Collections.Generic;

namespace cds
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/artists"] = _ => {
        var allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/new"] = _ => {
        return View["artist_form.cshtml"];
      };
      Post["/artists"] = _ => {
        var newArtist = new Artist(Request.Form["artist-name"]);
        var allArtists = Artist.GetAll();
        return View["artists.cshtml", allArtists];
      };
      Get["/artists/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedArtist = Artist.Find(parameters.id);
        var artistAlbums = selectedArtist.GetAlbums();
        model.Add("artist", selectedArtist);
        model.Add("albums", artistAlbums);
        return View["artist.cshtml", model];
      };
      Get["/artists/{id}/albums/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(parameters.id);
        List<Album> allAlbums = selectedArtist.GetAlbums();
        model.Add("artist", selectedArtist);
        model.Add("albums", allAlbums);
        return View["artist_albums_form.cshtml", model];
      };
      Post["/albums"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Artist selectedArtist = Artist.Find(Request.Form["artist-id"]);
        List<Album> artistAlbums = selectedArtist.GetAlbums();
        string albumDescription = Request.Form["album-description"];
        Album newAlbum = new Album(albumDescription);
        artistAlbums.Add(newAlbum);
        model.Add("albums", artistAlbums);
        model.Add("artist", selectedArtist);
        return View["artist.cshtml", model];
      };
      Get["/search_by_artist"] = _ => {
        return View["search_by_artist.cshtml"];
      };
      Post["/search_by_artist"] = _ => {
        var allArtists = Artist.GetAll();
        return View["search_by_artists.cshtml", allArtists];
      };
    }
  }
}
