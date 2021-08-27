using System;

namespace Domain.Models
{
	public class Alert
	{
		public int Id { get; set; }
		public string Description { get; set; }

		public DateTime Timestamp { get; set; }

		public Alert() { }

		public Alert(string description)
		{
			Description = description;
			Timestamp = DateTime.Now;
		}
	}
}

