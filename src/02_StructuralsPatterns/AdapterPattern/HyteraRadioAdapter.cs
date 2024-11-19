namespace AdapterPattern
{
    // Concrete Adapter
    partial class HyteraRadioAdapter : IRadioAdapter
    {
        // Adaptee
        private HyteraRadio radio;


        public HyteraRadioAdapter()
        {
            radio = new HyteraRadio();
        }

        public void Send(string message, byte channel)
        {
            radio.Init();
            radio.SendMessage(channel, message);
            radio.Release();
        }
    }

    public class RadioAdapterFactory
    {
        public IRadioAdapter Create(string model)
        {
            switch (model)
            {
                case "motorola": return new MotorolaRadioAdapter("1234");
                case "hytera": return new HyteraRadioAdapter();

                default:
                    throw new System.NotSupportedException();
            }
        }
    }
}
