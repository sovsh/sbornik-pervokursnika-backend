using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Repositories;

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

        public static Task SendNotifications(Post post, PostDTO postDTO)
        {
            var messages = new List<Message>();

            string body = post.IsShared == false ? post.Text : postDTO.OriginalPost.Text;

            foreach (var hashtag in post.HashtagsId)
                messages.Add(new Message()
                {
                    Notification = new Notification()
                    {
                        Title = post.Author,
                        Body = body
                    },
                    Topic = hashtag.ToString()
                });

            //Console.WriteLine($"{messages.Count}");
            var response = FirebaseMessaging.DefaultInstance.SendAllAsync(messages);

            return Task.CompletedTask;
        }
    }
}