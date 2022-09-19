
using System.Collections;
using System.Collections.Generic;

namespace Semester_Project {

	class Constants {

		/// <summary>
		/// Card colors (Czech version)
		/// </summary>
		public static readonly string[] CardColors = { "Cervena", "Zelena", "Kule", "Zaludy" };

		/// <summary>
		///  Card values starting from 7 (Czech Version)
		/// </summary>
		public static readonly string[] CardValues = { "7", "8", "9", "10", "E", "K", "S", "Z" };

		/// <summary>
		/// List of players / Array of names to be played with
		/// </summary>
		public static readonly List<string> RobotNames = new List<string>(10);


		//public Constants() 
		//{
		//	RobotNames.Add("Emerson Kallay");
		//	RobotNames.Add("James Fallah");
		//	RobotNames.Add("Theophilus James");
		//	RobotNames.Add("Akuna Tombo");
		//	RobotNames.Add("Samson Wallace");
		//	RobotNames.Add("Johnson Koroma");
		//	RobotNames.Add("Junior James");
		//	RobotNames.Add("John Babaloo");
		//	RobotNames.Add("Actual Dude");
		//	RobotNames.Add("Fallah James");
		//}
	}
}
