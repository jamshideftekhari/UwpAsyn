using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using PrepareFood.Annotations;

namespace PrepareFood.Model
{
    public class Heater 
    {
        public string Ingredient { get; set; }
        public string Unit { get; set; }
        public int Amount { get; set; }
        private static Timer HeatTimer;
        public int TimeCount { get; set; }

        public Heater()
        {
            TimeCount = 0;
        }

        public int Boil(int sec)
        {
            //HeatTimer = new Timer(60*1000*minutes);
            for (int i = 0; i < sec; i++)
            {
                Thread.Sleep(1000);
                return TimeCount = i;

            }

            return TimeCount;

        }

        //public async void BoilAsync(int sec)
        //{
        //    //HeatTimer = new Timer(60*1000*minutes);
        //    // await Task.Run((() => { Countdown(sec);}));
        //    for (int i = 0; i < sec; i++)
        //    {
        //        //Thread.Sleep(2000);
        //        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority.Normal), () => { TimeCount = i; });
        //        await Task.Run(()=>TimeCount = i);

        //    }

        //}

        private void Countdown(int sec)
        {
            for (int i = 0; i < sec; i++)
            {
                Thread.Sleep(1000);
                TimeCount = i;
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
