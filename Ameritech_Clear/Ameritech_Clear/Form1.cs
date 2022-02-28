using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ameritech_Clear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.            

            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                string fileText = File.ReadAllText(file); //Shows the raw CSV data in the richTextBox.
                richTextBox.Text = fileText;

                var lines = File.ReadLines(file).ToList(); //Gets the CSV data in a variable that I can work with.
                                
                long grandTotal = CSVManipulation.SplitAndAdd(lines); //iterates through the list.
                              
                txtBox.Text = $"{CSVManipulation.TenTrimmer(grandTotal)}"; //Display result to the user.

                Console.WriteLine($"{CSVManipulation.TenTrimmer(grandTotal)}");//Display the result to the console.s            
            }
        }
    }
}
