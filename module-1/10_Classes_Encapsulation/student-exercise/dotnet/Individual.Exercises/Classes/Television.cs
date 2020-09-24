using System.Net.NetworkInformation;

namespace Individual.Exercises.Classes
{
    public class Television
    {
        public bool IsOn { get; private set; } = false;
        public int CurrentChannel { get; private set; } = 3;
        public int CurrentVolume { get; private set; } = 2;

        public void TurnOff()
        {
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            CurrentChannel = 3;
            CurrentVolume = 2;
        }

        public void ChangeChannel(int newChannel)
        {
            if(IsOn && newChannel >= 3 && newChannel <= 18)
                CurrentChannel = newChannel;
        }

        public void ChannelUp()
        {
            if(!IsOn) return;
            if (CurrentChannel == 18)
                CurrentChannel = 2;
            CurrentChannel++;
        }

        public void ChannelDown()
        {
            if (!IsOn) return;
            if (CurrentChannel == 3)
                CurrentChannel = 19;
            CurrentChannel--;
        }

        public void RaiseVolume()
        {
            if(IsOn && CurrentVolume < 10) 
                CurrentVolume++;
        }

        public void LowerVolume()
        {
            if(IsOn && CurrentVolume > 0)
            CurrentVolume--;
        }

    }
}
