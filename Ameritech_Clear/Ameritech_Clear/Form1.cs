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
                var rawTotal = new List<long>();

                for (int i = 0; i < lines.Count; i++) //iterates through the list and seperates the data, and stores them.
                {
                   List<long> nums = lines[i].Split(',').Select(x => long.Parse(x)).ToList();                   
                    rawTotal.Add(nums.Sum());                    
                }

                var newTotal = rawTotal.Sum().ToString().ToArray();
                
                
                if (newTotal.Length >= 10)                
                {
                    var tool = new List<char>();

                    for (int i = newTotal.Length - 10; i < newTotal.Length; i++)
                    {
                        tool.Add(newTotal[i]);
                    }
                    
                    string finalTotal = new string(tool.ToArray());

                    txtBox.Text = $"{finalTotal}";
                    Console.WriteLine(finalTotal);

                }

                else
                {
                    txtBox.Text = $"{rawTotal.Sum()}";
                    Console.WriteLine(rawTotal.Sum());                    
                }
            }        
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
