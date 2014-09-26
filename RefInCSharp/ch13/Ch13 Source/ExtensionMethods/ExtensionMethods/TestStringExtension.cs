using System;
using System.Windows.Forms;

namespace ExtensionMethods
{
public partial class TestStringExtension : Form
{
    public TestStringExtension()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {                   
        foreach (String token in "123a456a789".
            SplitReturningDelimiter(new[] { 'a' }))
        {
            Console.WriteLine(token);
        }
    }
}
}
