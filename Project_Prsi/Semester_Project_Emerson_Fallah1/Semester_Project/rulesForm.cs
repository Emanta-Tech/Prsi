using System;
using System.Windows.Forms;

namespace Semester_Project
{

	public partial class RulesForm : Form
	{

		Form1 form1 = new Form1();

		/// <summary>
		/// Form that displays the rules 
		/// for the game, Also a link to
		/// the English Version. 
		/// </summary>
		public RulesForm()
		{
			InitializeComponent();

			RulesPictureBox.Image = form1.imageList1.Images[19]; // Sets image
			RulesPictureBox.Enabled = true;
		}

		private void RichTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void RulesForm_Load(object sender, EventArgs e)
		{

		}
	}
}
