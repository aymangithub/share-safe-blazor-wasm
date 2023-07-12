using System.Collections.Generic;


namespace AdminDashboard.Wasm.ModelsAdminDashboard.Wasm.Models
{
    public class ChatUserResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ProfilePictureDataUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsOnline { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}