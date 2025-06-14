using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XRent
{
    class Prompt
    {
        public static string ShowDialog(Form owner, string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.Manual
            };

            Label lblText = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            Button confirmation = new Button() { Text = "OK", Left = 270, Width = 90, Top = 90, DialogResult = DialogResult.OK, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            Button cancellation = new Button() { Text = "Отмена", Left = 170, Width = 90, Top = 90, DialogResult = DialogResult.Cancel, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            prompt.Controls.Add(lblText);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancellation);

            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancellation;

            int newX = owner.Location.X + (owner.Width - prompt.Width) / 2;
            int newY = owner.Location.Y + (owner.Height - prompt.Height) / 2;
            prompt.Location = new Point(newX, newY);

            return prompt.ShowDialog(owner) == DialogResult.OK ? inputBox.Text : null;
        }
    }
}
