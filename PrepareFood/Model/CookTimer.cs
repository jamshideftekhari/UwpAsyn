using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using PrepareFood.Annotations;

namespace PrepareFood.Model
{
    public class CookTimer : INotifyPropertyChanged
    {
        private string _timerLog;
        private DispatcherTimer dispatcherTimer;
        private DateTimeOffset startTime;
        private DateTimeOffset lastTime;
        private DateTimeOffset stopTime;
        int timesTicked = 1;
        int timesToTick = 10;
        private int _countNumber;
        private int _secoundCounter;

        public int SecoundCounter
        {
            get { return _secoundCounter; }
            set
            {
                _secoundCounter = value;
                OnPropertyChanged();
            }
        }

        public string TimerLog
        {
            get { return _timerLog; }
            set
            {
                _timerLog = value;
                OnPropertyChanged();
            }
        }

        public int CountNumber
        {
            get { return _countNumber;}
            set
            {
                _countNumber = value;
                OnPropertyChanged();
            }
        }

        public CookTimer()
        {
            DispatcherTimerSetup();
            CountNumber = 0;
            SecoundCounter = 0;
        }

        public async void SimpleCounter(int count)
        {
            // Call the method that runs asynchronously.
            //int result = 
            for (int i = 0; i < 10; i++)
            {
                await WaitAsynchronouslyAsync(count);
            }
            

            // Call the method that runs synchronously.
            //string result = await WaitSynchronously ();

            // Display the result.
            //textBox1.Text += result;
        }

        // The following method runs asynchronously. The UI thread is not
        // blocked during the delay. You can move or resize the Form1 window 
        // while Task.Delay is running.
        public async Task WaitAsynchronouslyAsync(int count)
        {
            await Task.Delay(1000);
            //return CountNumber++;
            CountNumber = CountNumber+count;
        }

        // The following method runs synchronously, despite the use of async.
        // You cannot move or resize the Form1 window while Thread.Sleep
        // is running because the UI thread is blocked.
        public async Task<string> WaitSynchronously()
        {
            // Add a using directive for System.Threading.
            Thread.Sleep(10000);
            return "Finished";
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //IsEnabled defaults to false
            TimerLog += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
            startTime = DateTimeOffset.Now;
            lastTime = startTime;
            TimerLog += "Calling dispatcherTimer.Start()\n";
            dispatcherTimer.Start();
            //IsEnabled should now be true after calling start
            TimerLog += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - lastTime;
            lastTime = time;
            //Time since last tick should be very very close to Interval
            TimerLog += timesTicked + "\t time since last tick: " + span.ToString() + "\n";
            timesTicked++;
            SecoundCounter= SecoundCounter+100;
            if (timesTicked > timesToTick)
            {
                stopTime = time;
                TimerLog += "Calling dispatcherTimer.Stop()\n";
                dispatcherTimer.Stop();
                //IsEnabled should now be false after calling stop
                TimerLog += "dispatcherTimer.IsEnabled = " + dispatcherTimer.IsEnabled + "\n";
                span = stopTime - startTime;
                TimerLog += "Total Time Start-Stop: " + span.ToString() + "\n";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

