using System.ComponentModel.DataAnnotations.Schema;

namespace MVCHamburgerProjesi.Data
{
	[Table("Siparis")]
	public class Siparis
	{
		public int Id { get; set; }
		public int MenuId { get; set; }
		public string Boyut { get; set; }
		public int Adet { get; set; }
		public decimal ToplamTutar { get; set; }
		public Menu SeciliMenu { get; set; }
		public string Ekstralar { get; set; }
		public bool AktifMi { get; set; } = true;


		public decimal ToplamTutarHesapla(string boyut)
		{

			decimal toplamTutar = 0;
            
			
			if (boyut=="Küçük")
			{
				 toplamTutar = SeciliMenu.Fiyat ;
			}
			if (boyut=="Orta")
			{
                 toplamTutar = (SeciliMenu.Fiyat/10)+ SeciliMenu.Fiyat ;
            }
            if (boyut == "Büyük")
            {
                 toplamTutar = (SeciliMenu.Fiyat / 4) + SeciliMenu.Fiyat ;
            }
			return toplamTutar * Adet;
        }
	}
}
