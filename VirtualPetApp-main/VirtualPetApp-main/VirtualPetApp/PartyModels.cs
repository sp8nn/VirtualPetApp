namespace VirtualPetApp
{
    public class CreateRoomRequest
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CreateRoomResponse
    {
        public string roomId { get; set; }
    }

    public class Visitor
    {
        public string name { get; set; }
        public string image { get; set; }
    }

    public class JoinRoomResponse
    {
        public Visitor visitor { get; set; }
    }
}