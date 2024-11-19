using System;

namespace AdapterPattern
{
    public sealed class UnmanagedDllLibrary
    {
        public void Print()
        {

        }

        public void Release()
        {

        }
    }

    public interface IPrinterAdapter
    {
        void Print();
    }

    public class DllLibraryPrinterAdapter : IPrinterAdapter, IDisposable
    {
        // Adaptee
        private UnmanagedDllLibrary dll;

        public DllLibraryPrinterAdapter()
        {
            dll = new UnmanagedDllLibrary();
        }

        public void Print()
        {
            dll.Print();
        }

        public void Dispose()
        {
            dll.Release();
        }


    }

    // Concrete Adapter (wariant klasowy)
    class HyteraRadioClassAdapter : HyteraRadio, IRadioAdapter
    {
        public void Send(string message, byte channel)
        {
            Init();
            SendMessage(channel, message);
            Release();
        }
    }

    // Concrete Adapter (wariant obiektowy)
    class HyteraRadioAdapter : IRadioAdapter
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
