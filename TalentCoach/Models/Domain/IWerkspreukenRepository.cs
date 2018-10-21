using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Domain {
	public interface IWerkspreukenRepository {
		List<Werkspreuk> GetAll();
		Werkspreuk GetWerkspreuk(int id);
		Werkspreuk GetByWeek(int week);
	}
}
