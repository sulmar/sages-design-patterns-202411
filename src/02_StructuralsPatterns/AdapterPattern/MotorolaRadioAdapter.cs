using System.Text;

namespace AdapterPattern
{
    // Concrete Adapter
    public class MotorolaRadioAdapter : ITextRadioAdapter, IBinaryRadioAdapter
    {
        private readonly string pincode;

        // Adaptee
        private MotorolaRadio radio;

        public MotorolaRadioAdapter(string pincode)
        {
            radio = new MotorolaRadio();
            this.pincode = pincode;
        }

        public void Send(string message, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(message);
            radio.PowerOff();
        }

        public void Send(byte[] data, byte channel)
        {
            radio.PowerOn(pincode);
            radio.SelectChannel(channel);
            radio.Send(Encoding.UTF8.GetString(data));
        }
    }
}
