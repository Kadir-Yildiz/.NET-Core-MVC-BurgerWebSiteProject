namespace MVCHamburgerProjesi.Data
{
	public class Siparis
	{
		public int Id { get; set; }
		public int MenuId { get; set; }
		public string Boyut { get; set; }
		public int Adet { get; set; }
		public decimal ToplamTutar { get; set; }
		public Menu SeciliMenu { get; set; }
		public List<Ekstra> Ekstralar { get; set; }
	}
}
