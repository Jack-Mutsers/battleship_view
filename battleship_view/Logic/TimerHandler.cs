using Entities.Models;
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
        private static bool activated { get; set; } = false;
        private static bool secondPast { get; set; } = false;
        private static int old { get; set; } = 0;
        private static Timer timer;
        public static DateTime startOfTurn { get; set; } = new DateTime();

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
            if (timer != null)
            {
                timer.Start();
            }
            
            activated = true;
        }

        public static void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
            }

            activated = false;
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
            if (activated)
            {
                int time = int.Parse(DateTime.Now.ToString("ss"));
                if (time > TimerHandler.old || (TimerHandler.old > 0 && time == 0))
                {
                    secondPast = false;
                    TimerHandler.old = time;
                }

                if (secondPast == false)
                {
                    secondPast = true;
                    ++Time;
                    StaticResources.log.Time = 21 - Time;
                    Console.WriteLine("The time is: "+Time);
                    if (Time >= 20)
                    {
                        TimerHandler.ResetTime();
                    }
                }
            }
        }

        private static void IncreaseTurn()
        {
            try
            {
                int turn = StaticResources.log.Turn;
                turn = turn >= StaticResources.PlayerList.Count() ? 1 : turn + 1;
                Player p = null;

                bool loop = true;
                while (loop == true)
                {
                    if(turn < 5)
                        p = StaticResources.PlayerList.Where(Speler => Speler.orderNumber == turn).First();

                    if (p == null || p.GameOver)
                        turn = turn >= StaticResources.PlayerList.Count() ? 1 : turn + 1;
                    else
                        loop = false;
                }

                StaticResources.log.Turn = turn;

                if (p.PlayerId == StaticResources.user.PlayerId)
                    StaticResources.log.MyTurn = true;

                TimerHandler.startOfTurn = DateTime.Now;
            }
            catch (Exception ex)
            {

            }
        }

        public static void ResetHandler()
        {
            StopTimer();
            timer = null;
            secondPast = false;
            old = 0;
            startOfTurn = new DateTime();
            Time = 0;
        }
    }
}
