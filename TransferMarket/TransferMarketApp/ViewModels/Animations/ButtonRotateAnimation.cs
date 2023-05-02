using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TransferMarketApp.ViewModels.Animations
{
    public class ButtonRotateAnimation : ViewModelBase
    {
        public ButtonRotateAnimation()
        {
            dispatcherTimerRole = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 0, 0, 10) };
            dispatcherTimerRole.Tick += new EventHandler(RotateAnimation);
            ButtonEnability = true;
        }

        private DispatcherTimer dispatcherTimerRole;

        private int _image_angle;
        private bool _button_enability;


        public void AnimationStart()
        {
            dispatcherTimerRole.Start();
            ButtonEnability = false;
        }
        public void AnimationStop()
        {
            dispatcherTimerRole.Stop();
            ButtonEnability = true;
        }
        public async void AnimationSeconds(int millisecondTimeout)
        {
            await Task.Run(() =>
            {
                AnimationStart();
                Thread.Sleep(millisecondTimeout);
                AnimationStop();
            });
        }

        public int ImageAngle
        {
            get { return _image_angle; }
            private set
            {
                _image_angle = value;
                OnPropertyChanged(nameof(ImageAngle));
            }
        }
        public bool ButtonEnability
        {
            get { return _button_enability; }
            private set
            {
                _button_enability = value;
                OnPropertyChanged(nameof(ButtonEnability));
            }
        }

        private void RotateAnimation(object sender, EventArgs e) => ImageAngle += 10;
    }
}
