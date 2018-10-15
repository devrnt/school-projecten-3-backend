using System.Collections.Generic;

namespace TalentCoach.Models.Domain {
	public interface IRichtingenRepository {
		List<Richting> GetAll();
		Richting GetRichting(int id);
		Richting AddRichting(Richting item);
		Richting UpdateRichting(int id, Richting item);
		Richting Delete(int id);
		void SaveChanges();
	}
}
