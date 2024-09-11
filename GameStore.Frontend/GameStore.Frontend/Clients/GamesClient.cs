using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GamesClient(HttpClient httpClient)
    {
        public async Task<GameSummary[]> GetGamesAsync() => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

        public async Task AddGameAsync(GameDetails gameDetails)
            => await httpClient.PostAsJsonAsync("games", gameDetails);

        public async Task<GameDetails> GetGameAsync(int id)
            => await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Could not find game!");

        public async Task UpdateGameAsync(GameDetails gameDetails)
            => await httpClient.PutAsJsonAsync($"games/{gameDetails.Id}", gameDetails);

        public async Task DeleteGameAsync(int id)
            => await httpClient.DeleteAsync($"games/{id}");

    }
}
