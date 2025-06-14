using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRent
{
    public class PasswordAnimator : IDisposable
    {
        private TextBox targetTextBox;
        private Timer maskTimer;
        private string actualPassword = "";
        private bool isUpdatingText = false;

        public string RealPassword => actualPassword;

        public PasswordAnimator(TextBox textBoxToAnimate, int maskingDelay = 1500)
        {
            targetTextBox = textBoxToAnimate;

            maskTimer = new Timer { Interval = maskingDelay };
            maskTimer.Tick += MaskTimer_Tick;

            targetTextBox.TextChanged += TargetTextBox_TextChanged;
        }

        private void TargetTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingText) return;

            maskTimer.Stop();

            string displayedText = targetTextBox.Text;
            int oldLength = actualPassword.Length;
            bool characterWasAdded = displayedText.Length > oldLength;

            if (characterWasAdded)
            {
                actualPassword += displayedText.Substring(oldLength);
            }
            else if (displayedText.Length < oldLength)
            {
                int diff = oldLength - displayedText.Length;
                actualPassword = actualPassword.Substring(0, actualPassword.Length - diff);
            }

            if (characterWasAdded)
            {
                UpdateMask(showLastChar: true);
                if (actualPassword.Length > 0)
                {
                    maskTimer.Start();
                }
            }
            else
            {
                UpdateMask(showLastChar: false);
            }
        }

        private void MaskTimer_Tick(object sender, EventArgs e)
        {
            maskTimer.Stop();
            UpdateMask(showLastChar: false);
        }

        private void UpdateMask(bool showLastChar)
        {
            isUpdatingText = true;

            int selectionStart = targetTextBox.SelectionStart;

            if (string.IsNullOrEmpty(actualPassword))
            {
                targetTextBox.Text = "";
            }
            else if (showLastChar)
            {
                targetTextBox.Text = new string('•', actualPassword.Length - 1) + actualPassword.Last();
            }
            else
            {
                targetTextBox.Text = new string('•', actualPassword.Length);
            }

            try
            {
                targetTextBox.SelectionStart = selectionStart > targetTextBox.Text.Length
                                               ? targetTextBox.Text.Length
                                               : selectionStart;
            }
            catch { targetTextBox.SelectionStart = targetTextBox.Text.Length; }

            isUpdatingText = false;
        }

        public void Dispose()
        {
            if (maskTimer != null)
            {
                maskTimer.Stop();
                maskTimer.Dispose();
            }
            if (targetTextBox != null)
            {
                try
                {
                    targetTextBox.TextChanged -= TargetTextBox_TextChanged;
                }
                catch { }
            }
        }
    }
}
