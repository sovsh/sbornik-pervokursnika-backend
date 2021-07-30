using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;

namespace SbornikBackend.Services
{
    public class PostNotificationService
    {
        public static void InitializeFirebaseApp()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json"),
            });
        }
        
        public static Task SendNotifications(PostDTO postDTO)
        {
            var messages = new List<Message>();
            
            foreach(var hashtag in postDTO.Hashtags)
                messages.Add(new Message()
                {
                    Notification = new Notification()
                    {
                        Title = hashtag,
                        Body = postDTO.ToString(),
                    },
                    Topic = "new_post",
                });

            //Console.WriteLine($"{messages.Count}");
            var response = FirebaseMessaging.DefaultInstance.SendAllAsync(messages);

            return Task.CompletedTask;
        }
    }
}