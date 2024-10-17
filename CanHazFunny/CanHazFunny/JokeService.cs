using System;
using System.Net.Http;
using System.Net.Http.Json;

namespace CanHazFunny;

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string joke = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api").Result;
        if (String.IsNullOrEmpty(joke))
        {
            return "Git joke returns empty Joke.";
        }
        return joke;
    }

    public string GetJokeJson()
    {
        JokeResponse? jokeResponse = HttpClient.GetFromJsonAsync<JokeResponse>("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        if (jokeResponse == null)
        {
            return "Git joke returns empty jokejson.";
        }
        return jokeResponse.Joke ?? throw new InvalidOperationException("Joke is null");
    }
}

public sealed class JokeResponse
{
    public string Joke { get; set; } = "My Parents call me a joke";
}
