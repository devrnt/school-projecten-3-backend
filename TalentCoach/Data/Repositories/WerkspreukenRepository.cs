using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data.Repositories {
	public class WerkspreukenRepository : IWerkspreukenRepository {
		private readonly ApplicationDbContext _context;

		private readonly DbSet<Werkspreuk> _werkspreuken;

		public WerkspreukenRepository(ApplicationDbContext context) {
			_context = context;
			_werkspreuken = _context.Werkspreuken;

		}

		public List<Werkspreuk> GetAll() {
			return _werkspreuken.OrderBy(w => w.Id).ToList();
		}

		public Werkspreuk GetWerkspreuk(int id) {
			return _werkspreuken
				.SingleOrDefault(w => w.Id == id);
		}

		public Werkspreuk GetByWeek(int week) {
			return _werkspreuken
				.SingleOrDefault(w => w.Week == week);
		}
	}
}
