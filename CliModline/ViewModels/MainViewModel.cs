using System.Windows;
using System.Windows.Input;

using MakCraft.ViewModels;

using CliModline.Utils;

namespace CliModline.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ModLine _modLine = null;

        public MainViewModel()
        {
            InputString = "";
        }

        private string _inputString;
        public string InputString
        {
            get { return _inputString; }
            set
            {
                base.SetProperty(ref _inputString, value);
                _modLine = new ModLine(_inputString);
                LineKind = _modLine.OriginalKind.ToString();
            }
        }

        private string _lineKind;
        public string LineKind
        {
            get { return _lineKind; }
            set { base.SetProperty(ref _lineKind, value); }
        }

        private void writeClipbordWithCrLfExecute()
        {
            Clipboard.SetData(DataFormats.UnicodeText, _modLine.GetCrLf());
        }
        private ICommand _writeClipbordWithCrLfCommand;
        public ICommand WriteClipbordWithCrLfCommand
        {
            get
            {
                if (_writeClipbordWithCrLfCommand == null)
                {
                    _writeClipbordWithCrLfCommand = new RelayCommand(writeClipbordWithCrLfExecute);
                }
                return _writeClipbordWithCrLfCommand;
            }
        }

        private void writeClipbordWithLfExecute()
        {
            Clipboard.SetData(DataFormats.UnicodeText, _modLine.GetLf());
        }
        private ICommand _writeClipbordWithLfCommand;
        public ICommand WriteClipbordWithLfCommand
        {
            get
            {
                if (_writeClipbordWithLfCommand == null)
                {
                    _writeClipbordWithLfCommand = new RelayCommand(writeClipbordWithLfExecute);
                }
                return _writeClipbordWithLfCommand;
            }
        }

        private void writeClipbordWithCrExecute()
        {
            Clipboard.SetData(DataFormats.UnicodeText, _modLine.GetCr());
        }
        private ICommand _writeClipbordWithCrCommand;
        public ICommand WriteClipbordWithCrCommand
        {
            get
            {
                if (_writeClipbordWithCrCommand == null)
                {
                    _writeClipbordWithCrCommand = new RelayCommand(writeClipbordWithCrExecute);
                }
                return _writeClipbordWithCrCommand;
            }
        }
    }
}
