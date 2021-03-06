﻿using Entities.DataModels;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using Newtonsoft.Json;
using ServiceBus.Manipulators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_view.Logic
{
    public static class ServiceBusHandler
    {
        private static Dictionary<int, Subscriptions> subscription = new Dictionary<int, Subscriptions>()
        {
            { 1, Subscriptions.ChannelOne },
            { 2, Subscriptions.ChannelTwo },
            { 3, Subscriptions.ChannelThree },
            { 4, Subscriptions.ChannelFour },
        };

        public static ServiceBus.Program program { get; private set; }

        public async static Task InitiateServiceBusHandler(Player player, bool host = false)
        {
            // create new instance of program
            program = new ServiceBus.Program(player);

            // if player is host, create new topic to play the game in
            if (host)
            {
                // add host to the player list
                StaticResources.PlayerList.Add(StaticResources.user);

                // create new topic with subscriptions
                await program.CreateNewTopic();
            }
        }

        public static async void HandleQueueMessage(string message)
        {
            // check if player is identified
            if (StaticResources.user != null)
            {
                // decode message
                Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);
                Player source;

                // check if message type is JoinRequest, so we know how to decode the message inside the transfer object and we know how to use it
                if (transfer.type == MessageType.JoinRequest)
                {
                    //check if the player is the host, because only the host may handel messages of the type JoinRequest
                    if (StaticResources.user.type == PlayerType.Host)
                    {
                        // decode message
                        source = JsonConvert.DeserializeObject<Player>(transfer.message);

                        // count amount of people in the game
                        int playerCount = StaticResources.PlayerList.Count();

                        // check if the player is already in the game
                        int exists = StaticResources.PlayerList.Where(p => p.PlayerId == source.PlayerId).Count();

                        // check if there are less than 4 people in the game and the new request is from a new player
                        if (playerCount < 4 && exists == 0)
                        {
                            // set the player order, by increasing the playerCount before assigning it to the ordernumber
                            bool inUSe = true;
                            int orderNumber = 1;
                            while (inUSe == true)
                            {
                                orderNumber += 1;

                                int count = StaticResources.PlayerList.Where(p=>p.orderNumber == orderNumber).Count();

                                if (count == 0)
                                    inUSe = false;
                            }

                            source.orderNumber = orderNumber;

                            // add new player to the player list
                            StaticResources.PlayerList.Add(source);

                            StaticResources.PlayerList = StaticResources.PlayerList.OrderBy(p => p.orderNumber).ToList();

                            // create response model
                            SessionResponse response = new SessionResponse();
                            response.Player = source;
                            response.accepted = true;
                            response.topicData = new TopicData()
                            {
                                TopicConnectionString = program.topic.TopicData.TopicConnectionString, // get newly created topic connection string
                                topic = program.topic.TopicData.topic, // get newly created topic name
                                subscription = subscription[orderNumber] // assign subscription to the new player
                            };

                            // convert the response model to a JsonString
                            string line = JsonConvert.SerializeObject(response);

                            // create writer program
                            await program.CreateQueueWriter(PlayerType.Host, transfer.QueueData);

                            // send response data on the newly joined writer queue
                            await program.QueueWriter.SendQueueMessageAsync(line, MessageType.Response);

                            // disconnect from the writer queue
                            await program.QueueWriter.DisconnectFromQueue();

                            program.QueueListner.ConnectToQueue();

                            MessageSender messageSender = new MessageSender();
                            messageSender.SendNewPlayerMessage();
                        }

                    }
                }

                // check if the message type is response
                if (transfer.type == MessageType.Response)
                {
                    // message type is response
                    // decode message to SessionResponseModel
                    SessionResponse response = JsonConvert.DeserializeObject<SessionResponse>(transfer.message);
                    
                    // get the player from the response model
                    Player player = response.Player;

                    // check if the response is meant for me
                    if (player.PlayerId == StaticResources.user.PlayerId && player.name == StaticResources.user.name && player.type == StaticResources.user.type)
                    {
                        // the response is for me
                        // update player data
                        StaticResources.user = player;

                        // store service bus topic data in program
                        program.CreateTopicConnection(response.topicData);

                        await program.DeleteListnerQueue();
                    }
                }
            }
        }

        public static void HandleNewPlayerTopicMessage(string message)
        {
            // decode message
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            // check if the message is for a new player that has joined
            if (transfer.type == MessageType.NewPlayer)
            {
                // decode message to SessionResponseModel
                NewPlayerMessage response = JsonConvert.DeserializeObject<NewPlayerMessage>(transfer.message);

                // update the player collection with the newly joinend players
                StaticResources.PlayerList = response.playerList;
            }
        }

        public static async Task ResetData()
        {
            await program.topic.DisconnectFromTopic();

            //if (StaticResources.user.type == PlayerType.Host)
            //{
            //    await program.DeleteTopic();
            //}

            await program.QueueListner.DisconnectFromQueue();

            program = null;
        }

        public static void SendPlayerListRequest()
        {
            program.topic.SendTopicMessage("", MessageType.PlayerListRequest);
        }
    }
}
