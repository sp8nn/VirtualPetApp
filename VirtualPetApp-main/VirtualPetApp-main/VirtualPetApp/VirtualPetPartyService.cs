using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace VirtualPetApp
{
    public class VirtualPetPartyService
    {
        private const string ApiKey = "?api-key=foo";
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> CreateRoomAsync(string petName)
        {
            var request = new CreateRoomRequest
            {
                Name = petName,
                Image = Convert.ToBase64String(
                    System.Text.Encoding.UTF8.GetBytes("PET"))
            };

            var response =
                await _client.PostAsJsonAsync(
                    $"https://virtualpetparty.up.railway.app/api/room/create{ApiKey}",
                    request);

            response.EnsureSuccessStatusCode();

            string roomCode =
                await response.Content.ReadAsStringAsync();

            roomCode = roomCode.Trim('"');

            return roomCode;
        }

        public async Task<Visitor> JoinRoomAsync(string roomId)
        {
            var response =
                await _client.PostAsJsonAsync(
                    $"https://virtualpetparty.up.railway.app/api/room/join/{roomId}{ApiKey}",
                    new { });

            response.EnsureSuccessStatusCode();

            var result =
                await response.Content.ReadFromJsonAsync<JoinRoomResponse>();

            return result.visitor;
        }
    }
}