namespace AdapterPattern
{
    // Abstract Adapter
    public interface ITextRadioAdapter
    {
        void Send(string message, byte channel);
    }

    public interface IBinaryRadioAdapter
    {
        void Send(byte[] data, byte channel);
    }
}
