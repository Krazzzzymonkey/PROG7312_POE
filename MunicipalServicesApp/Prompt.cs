using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string text, string caption)
    {
        Form prompt = new Form
        {
            Width = 400,
            Height = 200,
            Text = caption,
            StartPosition = FormStartPosition.CenterScreen
        };

        Label lblText = new Label { Text = text, Dock = DockStyle.Top, Padding = new Padding(10) };
        TextBox txtInput = new TextBox { Dock = DockStyle.Top, Padding = new Padding(10) };
        Button btnOk = new Button { Text = "OK", Dock = DockStyle.Bottom, DialogResult = DialogResult.OK };

        prompt.Controls.Add(lblText);
        prompt.Controls.Add(txtInput);
        prompt.Controls.Add(btnOk);

        return prompt.ShowDialog() == DialogResult.OK ? txtInput.Text : string.Empty;
    }
}
