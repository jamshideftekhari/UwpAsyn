using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using PrepareFood.Annotations;
using PrepareFood.Common;
using PrepareFood.Model;

namespace PrepareFood.Viewmodel
{
    public class PrepareMV : INotifyPropertyChanged
    {
        public Heater BoiledEgg { get; set; }
        private int _boiledTime;
        private ICommand _countCommand;
        public ObservableCollection<int> CounterCollection { get; set; }
        public CookTimer cookTime { get; set; }
        public CookTimer cookTime1 { get; set; }
        public int BoiledTime
        {
            get
            {
                return _boiledTime;
               
            }
            set
            {

                _boiledTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand CountCommand
        {
            get
            {
                if (_countCommand==null)
                {
                    _countCommand = new RelayCommand(CountNumber);
                    return _countCommand;
                }
                else
                {
                    return _countCommand;
                }
            }
            set { _countCommand = value; }
        }

        private async void CountNumber()
        {
             //BoiledTime++;
             await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority.Normal), () => { BoiledTime++; });


        }

        public PrepareMV()
        {
            CounterCollection = new ObservableCollection<int>();
            BoiledEgg = new Heater();
            BoiledEgg.Ingredient = "Egg";
            BoiledEgg.Amount = 2;
            BoiledTime = 0;
            Thread thread = new Thread(new ThreadStart(Makedelay));
            thread.Start();
            cookTime = new CookTimer();
            cookTime.SimpleCounter(1);
            cookTime1 = new CookTimer();
            cookTime1.SimpleCounter(2);
            // BoiledTime = BoiledEgg.Boil(5);
            // BoiledEgg.BoilAsync(10);
            //BoilAsync(5);
            //CountLopp();

            //BoilAsync(1);

            //BoilAsync(2);
            //BoilAsync(3);
        }

        private void Makedelay()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                CountNumber();
            }
            
        }

        //public async void BoilAsync(int sec)
        //{

        //    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority.Normal), () => { BoiledTime = sec; });

        //}

        //public async void CountLopp()
        //{
        //    for (int i = 0; i < 5000; i++)
        //    {
        //        //Thread.Sleep(1000);

        //        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority.Normal), () => { CounterCollection.Add(i); });
        //    }
        //}

        //public async void CountAsync(int N)
        //{

        //    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync((CoreDispatcherPriority.Normal), () => { CounterCollection.Add(N); });

        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
