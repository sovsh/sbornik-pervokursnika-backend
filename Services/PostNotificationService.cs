using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using SbornikBackend.DTOs;

namespace SbornikBackend.Services
{
    public class PostNotificationService
    {
        private readonly FirebaseMessaging _messaging;

        public PostNotificationService()
        {
            var app = FirebaseApp.Create(new AppOptions() { Credential = GoogleCredential.FromFile("serviceAccountKey.json").CreateScoped("https://www.googleapis.com/auth/firebase.messaging")});           
            _messaging = FirebaseMessaging.GetMessaging(app);
        }
        /*private Message CreateNotification(string title, string notificationBody, string token)
        {    
            return new Message()
            {
                Token = token,
                Notification = new Notification()
                {
                    Body = notificationBody,
                    Title = title
                }
            };
        }

        public async Task SendNotification(string token, string title, string body)
        {
            var result = await _messaging.SendAsync(CreateNotification(title, body, token)); 
            //do something with result
        }*/
        
        public static Task SendNotifications(PostDTO postDTO)
        {
            var messages = new List<Message>();
            
            foreach(var hashtag in postDTO.Hashtags)
                messages.Add(new Message()
                {
                    Notification = new Notification()
                    {
                        Title = "New post",
                        Body = postDTO.ToString(),
                    },
                    Topic = hashtag,
                });

            Console.WriteLine($"{messages.Count}");
            var response = FirebaseMessaging.DefaultInstance.SendAllAsync(messages);

            Console.WriteLine($"{response.Result}");
            return Task.CompletedTask;
        }
    }
}