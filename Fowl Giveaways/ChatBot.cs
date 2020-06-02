using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace Fowl_Giveaways
{
    class ChatBot
    {
        TwitchClient client;
        MainForm form;
        string currentChannel;

        public ChatBot(MainForm parent, string chatToMonitor, string botUsername, string botOAuth)
        {
            form = parent;
            ConnectionCredentials credentials = new ConnectionCredentials(botUsername, botOAuth);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(1)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, chatToMonitor);
            //Log and channel Events
            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            //Message Events
            client.OnMessageReceived += Client_OnMessageReceived;
            //Subscribe Events
            client.OnNewSubscriber += Client_OnNewSubscriber;
            client.OnReSubscriber += Client_OnReSubscriber;
            client.OnGiftedSubscription += Client_OnGiftedSubscription;
            //Raids Events
            client.OnRaidNotification += Client_OnRaidNotification;



            //Bot connect
            //client.Connect();
        }

        public void DisconnectBot()
        {
            Console.WriteLine("Disconnecting bot from chat.");
            client.Disconnect();
        }

        public void ConnectBot()
        {
            Console.WriteLine("Connecting bot to chat.");
            client.Connect();
        }

        private void Client_OnRaidNotification(object sender, OnRaidNotificationArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{e.RaidNotification.DisplayName} has raided with {e.RaidNotification.MsgParamViewerCount} viewers");
        }

        //Log and Channel Methods
        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }
        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine("Bot connected.");
            client.SendMessage(e.Channel, "Im alive.");
            currentChannel = e.Channel;
        }

        //Message Methods
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{e.ChatMessage.DisplayName} said: {e.ChatMessage.Message}");
        }

        //Subscriber Methods
        private void Client_OnGiftedSubscription(object sender, OnGiftedSubscriptionArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{e.GiftedSubscription.DisplayName} has gifted a sub to TEST!");
        }
        private void Client_OnReSubscriber(object sender, OnReSubscriberArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{e.ReSubscriber.DisplayName} has resubscribed!");
        }
        private void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{e.Subscriber.DisplayName} has subscibed!");
        }
    }
}
