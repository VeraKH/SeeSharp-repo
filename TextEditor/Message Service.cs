using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_Editor_4
{
    public interface IMassageService
    {
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowErrow(string error);
    }

    class Message_Service : IMassageService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowExclamation(string exclamation)
        {
            MessageBox.Show(exclamation, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowErrow(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
