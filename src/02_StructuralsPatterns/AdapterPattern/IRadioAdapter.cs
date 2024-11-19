namespace AdapterPattern
{
    // Abstract Adapter
    public interface IRadioAdapter
    {
        void Send(string message, byte channel);
    }
}
