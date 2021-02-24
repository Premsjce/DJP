namespace DesignPatterns
{
    public class BridgePattern
    {
        public static void Driver()
        {
            var remoteTV = new ConcreteTVRemoteControl();
            remoteTV.NextChannel();
        }
    }

    public interface ITV
    {
        void PowerOn();
        void PowerOff();
        void ChangeChannel(int channleNo);
    }

    public class GoogleTV : ITV
    {
        public void ChangeChannel(int channleNo)
        {
            //Google specific code for changing channel
        }

        public void PowerOff()
        {
            //Google specific code for Power off
        }

        public void PowerOn()
        {
            //Google specific code for powering on
        }
    }

    public class AppleTV : ITV
    {
        public void ChangeChannel(int channleNo)
        {
            //Apple specific code for changing channel
        }

        public void PowerOff()
        {
            //Apple specific code for powering off
        }

        public void PowerOn()
        {
            //Apple specific code for powering on
        }
    }

    public abstract class TVRemoteControl
    {
        private readonly ITV tV = default;
        public void PowerOn() => tV.PowerOn();
        public void PowerOff() => tV.PowerOff();
        public void SetChannel(int channel) => tV.ChangeChannel(channel);
    }

    public class ConcreteTVRemoteControl : TVRemoteControl
    {
        public int currentChannel;

        public void NextChannel()
        {
            currentChannel++;
            SetChannel(currentChannel);
        }

        public void PrevChannel()
        {
            currentChannel--;
            SetChannel(currentChannel);
        }
    }
}
