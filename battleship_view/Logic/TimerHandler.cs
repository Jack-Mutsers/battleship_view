﻿using Entities.Models;
using Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace battleship_view.Logic
{
    public static class TimerHandler
    {

        private static Timer timer;

        public static int Time { get; set; } = 0;

        public static void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public static void StartTimer()
        {
            timer.Start();
        }

        public static void StopTimer()
        {
            timer.Stop();
        }

        public static void ResetTime()
        {
            TimerHandler.StopTimer();
            TimerHandler.IncreaseTurn();
            Time = 0;
            TimerHandler.StartTimer();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            ++Time;
            StaticResources.log.Time = 20 - Time;
            Console.WriteLine("The time is: "+Time);
            if (Time==20)
            {
                TimerHandler.ResetTime();
            }
        }

        private static void IncreaseTurn()
        {
            StaticResources.log.Turn = StaticResources.log.Turn >= StaticResources.PlayerList.Count() ? 1 : StaticResources.log.Turn + 1;
            while (true)
            {
                Player p = StaticResources.PlayerList.Where(Speler => Speler.orderNumber == 4).First();
                if (StaticResources.log.Turn != 5) {
                    p = StaticResources.PlayerList.Where(Speler => Speler.orderNumber == StaticResources.log.Turn).First();
                }
                if (p.GameOver)
                {
                    StaticResources.log.Turn = StaticResources.log.Turn >= StaticResources.PlayerList.Count() ? 1 : StaticResources.log.Turn++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
