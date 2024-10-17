namespace CanHazFunny;
using System;
public class Jester : IJoker
{
    private JokeService jokeService = new();
    public  IOutputter? ConsoleOutput { get;}
    public bool TellJoke()
    {
        string response = jokeService.GetJoke();
        ArgumentNullException.ThrowIfNull(response);
        bool isntChuckNorris = response.Contains("Norris") || response.Contains("Chuck");

        if (!isntChuckNorris)
        {
            ConsoleOutput!.ConsoleOutputter(response);
            return true;
        }
        else
        {
            return TellJoke();
        }
    }

    public bool TellJokeJson()
    {
        string jsonResponse = jokeService.GetJokeJson();
        ArgumentNullException.ThrowIfNull(jsonResponse);
        bool isntChuckNorris = jsonResponse.Contains("Norris") || jsonResponse.Contains("Chuck");
        if (!isntChuckNorris)
        {
            ConsoleOutput!.ConsoleOutputter(jsonResponse);
            return true;
        }
        else
        {
            return TellJokeJson();
        }
    }
}
