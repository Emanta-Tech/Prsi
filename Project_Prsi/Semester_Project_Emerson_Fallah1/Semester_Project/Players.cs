using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester_Project
{
	class Players
	{

		public string PlayerName { get; set; }
		public string RobotName { get; set; }

		public Players()
		{

		}

		public Players(string Player, string Robot)
		{
			this.PlayerName = Player;
			this.RobotName = Robot;
		}

		public override string ToString()
		{
			return "PLAYERNAME: " + PlayerName + "RobotName: " + RobotName;
		}

	}
}
